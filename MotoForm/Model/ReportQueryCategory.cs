
namespace MotoForm.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public enum ReportQueryCategory
    {
        Day,
        Week,
        Month
    }

    public static class ReportQueryCategoryLibs
    {
        public static IEnumerable<ComboBoxItem> ReportQueryCategoryComboBoxItems()
        {
            Func<ReportQueryCategory, string> getDisplyaName = (category) =>
            {
                switch (category)
                {
                    case ReportQueryCategory.Day:
                        return "天";
                    case ReportQueryCategory.Week:
                        return "周";
                    case ReportQueryCategory.Month:
                        return "月";
                    default:
                        return "NotExist";
                }
            };

            return Enum.GetNames(typeof(ReportQueryCategory))
                .Select((value, index) => new ComboBoxItem() { Key = getDisplyaName((ReportQueryCategory)index), Value = $"{index}" });
        }
    }
}
