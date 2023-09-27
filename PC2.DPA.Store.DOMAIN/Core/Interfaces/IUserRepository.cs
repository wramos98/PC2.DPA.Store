using PC2.DPA.Store.DOMAIN.Core.Entities;

namespace PC2.DPA.Store.DOMAIN.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Delete(int id);
        Task<User> GetUser(string email, string password);
        Task<IEnumerable<User>> GetUsers();
        Task<bool> Insert(User user);
        //Task<bool> Update(User user);
    }
}