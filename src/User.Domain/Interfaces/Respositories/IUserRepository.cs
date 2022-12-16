using System.Threading.Tasks;

namespace User.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<Entities.User>
    {
        Task<Entities.User> GetByEmail(string email);
    }
}
