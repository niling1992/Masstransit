﻿// Copyright 2007-2016 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.MongoDbIntegration.Tests.Saga
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MassTransit.Saga;
    using MongoDbIntegration.Saga;
    using MongoDbIntegration.Saga.Context;
    using MongoDB.Driver;
    using Moq;
    using NUnit.Framework;
    using Pipeline;
    using Util;


    [TestFixture]
    public class MongoDbSagaRepositoryTestsForSendingWhenInstanceNotReturnedFromPolicy
    {
        [Test]
        public void ThenPolicyUpdatedWithSagaInstance()
        {
            _policy.Verify(m => m.Existing(_sagaConsumeContext.Object, _nextPipe.Object));
        }

        [Test]
        public void ThenPreInsertInstanceCalledToGetInstance()
        {
            _policy.Verify(m => m.PreInsertInstance(_context.Object, out _nullSimpleSaga));
        }

        [Test]
        public async Task ThenVersionIncremeted()
        {
            var saga = await SagaRepository.GetSaga(_correlationId);

            Assert.That(saga.Version, Is.EqualTo(1));
        }

        Mock<ISagaPolicy<SimpleSaga, InitiateSimpleSaga>> _policy;
        Mock<ConsumeContext<InitiateSimpleSaga>> _context;
        SimpleSaga _nullSimpleSaga;
        Guid _correlationId;
        CancellationToken _cancellationToken;
        Mock<IPipe<SagaConsumeContext<SimpleSaga, InitiateSimpleSaga>>> _nextPipe;
        SimpleSaga _simpleSaga;
        Mock<IMongoDbSagaConsumeContextFactory> _sagaConsumeContextFactory;
        Mock<SagaConsumeContext<SimpleSaga, InitiateSimpleSaga>> _sagaConsumeContext;

        [TestFixtureSetUp]
        public void GivenAMongoDbSagaRepository_WhenSendingAndInstanceNotReturnedFromPolicy()
        {
            _correlationId = Guid.NewGuid();
            _cancellationToken = new CancellationToken();

            _context = new Mock<ConsumeContext<InitiateSimpleSaga>>();
            _context.Setup(x => x.CorrelationId).Returns(_correlationId);
            _context.Setup(m => m.CancellationToken).Returns(_cancellationToken);

            _nullSimpleSaga = null;

            _policy = new Mock<ISagaPolicy<SimpleSaga, InitiateSimpleSaga>>();
            _policy.Setup(x => x.PreInsertInstance(_context.Object, out _nullSimpleSaga)).Returns(false);

            _nextPipe = new Mock<IPipe<SagaConsumeContext<SimpleSaga, InitiateSimpleSaga>>>();

            _simpleSaga = new SimpleSaga {CorrelationId = _correlationId};

            _sagaConsumeContext = new Mock<SagaConsumeContext<SimpleSaga, InitiateSimpleSaga>>();
            _sagaConsumeContext.Setup(x => x.CorrelationId).Returns(_correlationId);

            _sagaConsumeContextFactory = new Mock<IMongoDbSagaConsumeContextFactory>();
            _sagaConsumeContextFactory.Setup(
                m => m.Create(It.IsAny<IMongoCollection<SimpleSaga>>(), _context.Object, It.Is<SimpleSaga>(x => x.CorrelationId == _correlationId), true))
                .Returns(_sagaConsumeContext.Object);

            TaskUtil.Await(() => SagaRepository.InsertSaga(_simpleSaga));

            var repository = new MongoDbSagaRepository<SimpleSaga>(SagaRepository.Instance, _sagaConsumeContextFactory.Object);

            TaskUtil.Await(() => repository.Send(_context.Object, _policy.Object, _nextPipe.Object));
        }

        [TestFixtureTearDown]
        public void Kill()
        {
            TaskUtil.Await(() => SagaRepository.DeleteSaga(_correlationId));
        }
    }
}