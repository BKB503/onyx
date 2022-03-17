//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Diagnostics.HealthChecks;
//using Moq;
//using NUnit.Framework;
//using ONYXTest.Controllers;
//using ONYXTest.Tests.TestUtils;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ONYXTest.Tests.Controllers
//{
//    public class HealthControllerTests
//    {
//        private HealthController subject;
//        private Mock<HealthCheckService> healthCheckService;
//        private Mock<IHealthCheck> healthCheck;

//        [SetUp]
//        public void Setup()
//        {

//            healthCheck = new Mock<IHealthCheck>();
//            //var te = new HealthCheckResult(HealthStatus.Healthy, "");
//            // healthCheck.Setup(x => x.CheckHealthAsync()).ReturnsAsync(te);

//            IReadOnlyDictionary<string, HealthReportEntry> entries = new Dictionary<string, HealthReportEntry> { };
            
//          //  Entries.
//            healthCheckService = new Mock<HealthCheckService>();

           
//            var test = new HealthReport(entries,TimeSpan.FromSeconds(3));

//            //var foo = new HealthReport();
//            var I = test.GetType().GetProperty(nameof(test.Status), BindingFlags.Public | BindingFlags.Instance);
//            I.SetValue(test.Status, HealthStatus.Healthy);
//            I.SetValue(test.TotalDuration, TimeSpan.FromDays(3));

//            //  Mock<HealthReport> report = new Mock<HealthReport>();
//            // report.Setup(x => x.Entries).Returns(entries);
//            //report.Setup(x => x.Status).Returns(HealthStatus.Healthy);

//            // healthCheckService.Setup( x=> x.)
//            healthCheckService.Setup(x => x.CheckHealthAsync(It.IsAny<CancellationToken>())).ReturnsAsync(It.IsAny<HealthReport>);

//            subject = new HealthController(healthCheckService.Object);
//        }

//        [Test]
//        public void MusHaveHttpGetAttribute()
//        {
//            var attribute = AttributeChecker.GetMethodAttributes(subject, nameof(subject.Get), typeof(HttpGetAttribute)).SingleOrDefault();

//            Assert.That(attribute, Is.Not.Null);
//        }

//        [Test]
//        public void WhenGet_ThenMustCallService()
//        {
//           var result =  subject.Get();
//            // Then
//            healthCheckService.Verify(m => m.CheckHealthAsync(CancellationToken.None), Times.Once);
//        }

//    }
//}
