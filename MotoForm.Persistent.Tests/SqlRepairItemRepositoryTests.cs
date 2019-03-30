
namespace Domain.Persistent.Tests
{
    using System;
    using System.IO;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MotoForm.Domain.Model;
    using MotoForm.Domain.Repository;
    using MotoForm.Persistent;

    [TestClass]
    public class SqlRepairItemRepositoryTests
    {
        private IRepairItemRepository repo;

        [TestInitialize]
        public void Init()
        {
            if (File.Exists($"{Environment.CurrentDirectory}\\{Applibs.ConfigHelper.FilePath}"))
            {
                File.Delete($"{Environment.CurrentDirectory}\\{Applibs.ConfigHelper.FilePath}");
            }
            var maintainceRepo = new SqlLiteMaintainRepository(Applibs.ConfigHelper.FilePath);
            var checkResult = maintainceRepo.InstanceCheck();
            Assert.IsNull(checkResult.Item1);

            this.repo = new SqlRepairItemRepository(Applibs.ConfigHelper.FilePath);
        }

        [TestMethod]
        public void InsertOneTests()
        {
            var insertResult = this.repo.InsertOne(new RepairItem()
            {
                ItemName = "ItemName -",
                Category = RepairCategory.Battery,
                Price = 1000
            });

            Assert.IsNull(insertResult.Item1);
        }


        [TestMethod]
        public void UpdateOneTest()
        {
            var item = new RepairItem()
            {
                ItemName = "ItemName -",
                Category = RepairCategory.Battery,
                Price = 1000
            };

            var insertResult = this.repo.InsertOne(item);
            Assert.IsNull(insertResult.Item1);

            item.RepairItemId = 1;
            item.ItemName += "Update";
            item.Category = RepairCategory.Electronic;
            item.Price = 2000;

            var updateResult = this.repo.UpdateOne(item);
            Assert.IsNull(updateResult.Item1);
        }

        [TestMethod]
        public void GetAllTests()
        {
            Enumerable.Range(1, 5).Select(index => new RepairItem()
            {
                ItemName = $"{index}ItemName -",
                Category = RepairCategory.Battery,
                Price = index * 1000
            }).ToList().ForEach(item =>
            {
                var insertResult = this.repo.InsertOne(item);
                Assert.IsNull(insertResult.Item1);
            });

            var getResult = this.repo.GetAll();
            Assert.IsNull(getResult.Item1);
            Assert.IsNotNull(getResult.Item2);
            Assert.AreEqual(5, getResult.Item2.Count());
        }

        [TestMethod]
        public void DisableTests()
        {
            Enumerable.Range(1, 5).Select(index => new RepairItem()
            {
                ItemName = $"{index}ItemName -",
                Category = RepairCategory.Battery,
                Price = index * 1000
            }).ToList().ForEach(item =>
            {
                var insertResult = this.repo.InsertOne(item);
                Assert.IsNull(insertResult.Item1);
            });

            var getResult = this.repo.GetAll();
            Assert.IsNull(getResult.Item1);
            Assert.IsNotNull(getResult.Item2);
            Assert.AreEqual(5, getResult.Item2.Count());

            var disableResult = this.repo.Disable(1);
            Assert.IsNull(disableResult.Item1);

            getResult = this.repo.GetAll();
            Assert.IsNull(getResult.Item1);
            Assert.IsNotNull(getResult.Item2);
            Assert.AreEqual(4, getResult.Item2.Count());
        }
    }
}
