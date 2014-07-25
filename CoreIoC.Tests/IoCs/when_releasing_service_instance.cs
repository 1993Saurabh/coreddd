﻿using NUnit.Framework;
using Rhino.Mocks;

namespace CoreIoC.Tests.IoCs
{
    [TestFixture]
    public class when_releasing_service_instance : IoCSetup
    {
        private object _serviceInstance;

        [SetUp]
        public override void Context()
        {
            base.Context();
            _serviceInstance = new object();

            IoC.Release(_serviceInstance);
        }

        [Test]
        public void release_was_called_on_container()
        {
            Container.AssertWasCalled(x => x.Release(_serviceInstance));
        }
    }
}