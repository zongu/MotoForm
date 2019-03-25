
namespace MotoForm.Applibs
{
    using System.Windows.Forms;
    using Autofac;
    using MotoForm.App;
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

            builder.RegisterType<Sale>()
               .Keyed<Form>(nameof(Sale));

            builder.RegisterType<ItemMaintaince>()
               .Keyed<Form>(nameof(ItemMaintaince));

            builder.RegisterType<Report>()
               .Keyed<Form>(nameof(Report));

            Container = builder.Build();
        }
    }
}
