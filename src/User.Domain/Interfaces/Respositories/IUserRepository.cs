using System.Threading.Tasks;

namespace User.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<Entities.User>
    {
        Task<Entities.User> GetByEmail(string email);
        Task<Entities.User> UpdatePasswordAsync(Entities.User obj);
        Task<Entities.User> UpdateRoleAsync(Entities.User obj);
    }
}
