
namespace MotoForm.Domain.Model
{
    public class RepairItem
    {
        public int RepairItemId { get; set; }

        public string ItemName { get; set; }

        public RepairCategory Category { get; set; }

        public int Price { get; set; }
    }
}
