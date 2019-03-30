
namespace MotoForm.Applibs
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using MotoForm.Domain.Model;
    using MotoForm.Model;

    internal static class ConfigHelper
    {
        public readonly static string FilePath = ConfigurationManager.AppSettings["FilePath"].ToString();

        public readonly static IEnumerable<string> MotoLabel = ConfigurationManager.AppSettings["MotoLabel"].ToString().Split(',');

        public readonly static List<User> Users = ConfigurationManager.AppSettings["User"].ToString().Split(';')
            .Select(p => new User()
            {
                UserName = p.Split(',')[0],
                PWD = p.Split(',')[1],
                Weight = int.Parse(p.Split(',')[2])
            }).ToList();
        
        public static User CurrentUser { get; set; }

        public static string GetPowerSourceDisplayName(MotoPowerSource source)
        {
            switch (source)
            {
                case MotoPowerSource.SecondTrip:
                    return "二行程";
                case MotoPowerSource.FourTrip:
                    return "四行程";
                case MotoPowerSource.Electric:
                    return "電動車";
                default:
                    return "NotExist";
            }
        }

        public static string GetGenderTypeDisplayName(GenderType type)
        {
            switch (type)
            {
                case GenderType.Male:
                    return "男";
                case GenderType.Female:
                    return "女";
                default:
                    return "不詳";
            }
        }

        public static string GetRepairCategoryDisplayName(RepairCategory category)
        {
            switch (category)
            {   
                case RepairCategory.Oil:
                    return "油品";
                case RepairCategory.Tire:
                    return "輪胎";
                case RepairCategory.Brake:
                    return "制動";
                case RepairCategory.Battery:
                    return "電瓶";
                case RepairCategory.Transmission:
                    return "傳動";
                case RepairCategory.FI:
                    return "FI";
                case RepairCategory.Light:
                    return "燈類";
                case RepairCategory.Electronic:
                    return "電裝";
                case RepairCategory.Body:
                    return "車體";
                case RepairCategory.Engine:
                    return "引擎";
                case RepairCategory.Other:
                    return "其他";
                case RepairCategory.Wage:
                    return "工資";
                default:
                    return "NotExist";
            }
        }
    }
}
