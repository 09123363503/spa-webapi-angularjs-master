using HomeCinema.Data.Repositories;
using HomeCinema.Entities;
using System.Linq;

namespace HomeCinema.Data.Extensions
{
    public static class UserExtensions
    {
        public static User GetSingleByUsername(this IEntityBaseRepositoryInetger<User> userRepository, string username)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.Username == username);
        }
    }
}
