
namespace Domain.Persistent.Tests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MotoForm.Domain.Repository;
    using MotoForm.Persistent;

    [TestClass]
    public class SqlLiteMaintainRepositoryTests
    {
        private IMaintainRepository repo;

        [TestInitialize]
        public void Init()
        {
            if (File.Exists($"{Environment.CurrentDirectory}\\{Applibs.ConfigHelper.FilePath}"))
            {
                File.Delete($"{Environment.CurrentDirectory}\\{Applibs.ConfigHelper.FilePath}");
            }

            this.repo = new SqlLiteMaintainRepository(Applibs.ConfigHelper.FilePath);
        }

        [TestMethod]
        public void InstanceCheckTests()
        {
            var checkResult = this.repo.InstanceCheck();
            Assert.IsNull(checkResult.Item1);
        }
    }
}
