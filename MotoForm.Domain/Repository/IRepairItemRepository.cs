
namespace MotoForm.Domain.Repository
{
    using System;
    using System.Collections.Generic;
    using MotoForm.Domain.Model;

    public interface IRepairItemRepository
    {
        Tuple<Exception, IEnumerable<RepairItem>> GetAll();

        Tuple<Exception> InsertOne(RepairItem item);

        Tuple<Exception> UpdateOne(RepairItem item);
    }
}
