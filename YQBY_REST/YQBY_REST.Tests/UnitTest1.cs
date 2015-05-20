using System;
using NUnit.Framework;
using YQBY_REST.ServiceInterface;
using YQBY_REST.ServiceModel;
using ServiceStack.Testing;
using ServiceStack;

namespace YQBY_REST.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private readonly ServiceStackHost appHost;

        public UnitTests()
        {
            appHost = new BasicAppHost(typeof(MyServices).Assembly)
            {
                ConfigureContainer = container =>
                {
                    //Add your IoC dependencies here
                }
            }
            .Init();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            appHost.Dispose();
        }

        [Test]
        public void TestMethod1()
        {
            var service = appHost.Container.Resolve<MyServices>();

            var response = (HelloResponse)service.Any(new Login { Name = "World" });

            Assert.That(response.Result, Is.EqualTo("Hello, World!"));
        }
    }
}
