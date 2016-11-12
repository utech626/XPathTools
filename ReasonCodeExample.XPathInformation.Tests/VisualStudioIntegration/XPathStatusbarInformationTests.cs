﻿using NUnit.Framework;

namespace ReasonCodeExample.XPathInformation.Tests.VisualStudioIntegration
{
    [TestFixture]
    [Category("Integration")]
    public class XPathStatusbarInformationTests
    {
        private readonly VisualStudioExperimentalInstance _instance = new VisualStudioExperimentalInstance();

        [OneTimeSetUp]
        public void StartVisualStudio()
        {
            _instance.ReStart(VisualStudioVersion.VS2015);
        }

        [OneTimeTearDown]
        public void StopVisualStudio()
        {
            _instance.Stop();
        }

        [Test]
        public void StatusbarShowsXPath()
        {
            // Arrange
            var xml = "<e1><e2><e3 /></e2></e1>";
            var caretPosition = 11;
            var expectedXPath = "/e1/e2/e3";
            _instance.OpenXmlFile(xml, caretPosition);

            // Act
            var statusbar = _instance.MainWindow.FindDescendant(expectedXPath);

            // Assert
            Assert.That(statusbar, Is.Not.Null);
        }
    }
}