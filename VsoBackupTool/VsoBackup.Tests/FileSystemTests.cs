using System;
using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using VsoBackup.Configuration;
using VsoBackup.DependencyInjection;
using VsoBackup.Services;
using Assert = NUnit.Framework.Assert;
using VsoBackup.Models;

namespace VsoBackup.Tests
{
    [TestFixture]
    public class FileSystemTests
    {
        private const string FolderTestName = "test";

        private IWindsorContainer container;

        [SetUp]
        public void Setup()
        {
            container = new Bootstrapper().BootstrapContainer();
        }

        [Test]
        public void CreateDirectoryTest()
        {
            var fileSystemService = container.Resolve<IFileSystemService>();
            fileSystemService.CreateDirectory(Constants.Today);

           // Assert.IsTrue(_fileSystemService.FolderExists(FolderTestName));
        }
    }
}
