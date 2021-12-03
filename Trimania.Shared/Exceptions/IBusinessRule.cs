using System.Threading.Tasks;

namespace Trimania.Shared.Exceptions
{
    public interface IBusinessRule
    {
        string Message { get; }
        Task<bool> IsBroken();
    }
}