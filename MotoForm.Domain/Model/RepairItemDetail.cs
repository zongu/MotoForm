
namespace MotoForm.Domain.Model
{
    public class RepairItemDetail
    {
        public string ItemName { get; set; }

        public RepairCategory Category { get; set; }

        public int Price { get; set; }

        public int Qty { get; set; }
    }
}
