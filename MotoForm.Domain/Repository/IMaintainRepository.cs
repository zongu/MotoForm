
namespace MotoForm.Domain.Repository
{
    using System;

    public interface IMaintainRepository
    {
        Tuple<Exception> InstanceCheck();
    }
}
