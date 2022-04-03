using System.Threading;
using System.Threading.Tasks;

namespace HostedBackgroundWorker.Services
{
    public interface IWorker
    {
        Task DOWork(CancellationToken cancellation, string location);
    }
}