
namespace MotoForm.Domain.Repository
{
    using System;
    using System.Collections.Generic;
    using MotoForm.Domain.Model;

    public interface IMotoRepository
    {
        Tuple<Exception, bool> Disable(int motoId);

        Tuple<Exception, Moto> FindByMotoNumber(string motoNumber);

        Tuple<Exception, IEnumerable<Moto>> FuzzyQueryByOwnerName(string ownerName);

        Tuple<Exception, bool> InsertOne(Moto moto);

        Tuple<Exception, IEnumerable<Moto>> QueryByTelPhone(string telPhone);

        Tuple<Exception, bool> UpdateOne(Moto moto);
    }
}
