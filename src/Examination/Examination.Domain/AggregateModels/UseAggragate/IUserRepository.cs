using System.Threading.Tasks;

namespace Examination.Domain.AggregateModels.UseAggragate
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(string externalId);
    }
}