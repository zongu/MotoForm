
namespace MotoForm.Applibs
{
    using Autofac;
    using MotoForm.Domain.Repository;
    using MotoForm.Persistent;

    internal static class AutoFacConfig
    {
        public static IContainer Container;

        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SqlLiteMaintainRepository>()
                .WithParameter("filePath", ConfigHelper.FilePath)
                .As<IMaintainRepository>();

            builder.RegisterType<SqlMotoRepository>()
                .WithParameter("filePath", ConfigHelper.FilePath)
                .As<IMotoRepository>();

            builder.RegisterType<SqlRepairItemRepository>()
                .WithParameter("filePath", ConfigHelper.FilePath)
                .As<IRepairItemRepository>();

            builder.RegisterType<SqlRepairRecordRepository>()
               .WithParameter("filePath", ConfigHelper.FilePath)
               .As<IRepairRecordRepository>();

            Container = builder.Build();
        }
    }
}
