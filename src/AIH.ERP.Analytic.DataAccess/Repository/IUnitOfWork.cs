using System;
using System.Threading.Tasks;

namespace AIH.ERP.Analytic.DataAccess.Repository
{
    public interface IUnitOfWork: IDisposable
    {
        Task CompleteAsync();
       
    }
}
