using System.Threading.Tasks;

namespace User.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<Entities.User>
    {
        new Task<Entities.User> UpdateAsync(Entities.User obj);
        Task<Entities.User> UpdatePasswordAsync(Entities.User obj);
        Task<Entities.User> GetByEmail(string email);
    }
}
