
namespace MotoForm.Applibs
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using MotoForm.Model;

    internal static class ConfigHelper
    {
        public readonly static string FilePath = ConfigurationManager.AppSettings["FilePath"].ToString();

        public static List<User> Users
        {
            get
            {
                return ConfigurationManager.AppSettings["User"].ToString().Split(';')
                     .Select(p => new User()
                     {
                         UserName = p.Split(',')[0],
                         PWD = p.Split(',')[1],
                         Weight = int.Parse(p.Split(',')[2])
                     }).ToList();
            }
        }

        public static User CurrentUser { get; set; }
    }
}
