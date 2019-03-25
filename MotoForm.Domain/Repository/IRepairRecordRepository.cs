
namespace MotoForm.Domain.Repository
{
    using System;
    using System.Collections.Generic;
    using MotoForm.Domain.Model;

    public interface IRepairRecordRepository
    {
        Tuple<Exception> Insert(RepairRecord record);

        Tuple<Exception, IEnumerable<RepairRecord>> QueryByDateTime(DateTime startDateTime, DateTime endDateTime);

        Tuple<Exception, IEnumerable<RepairRecord>> QueryByMotoId(int motoId);

        Tuple<Exception> Update(RepairRecord record);
    }
}
