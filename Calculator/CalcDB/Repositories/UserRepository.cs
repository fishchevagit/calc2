using System.Linq;
using CalcDB.Models;

namespace CalcDB.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public bool Check(string loginOrEmail, string password)
        {
            var result = ExecQuery(
                $"[Password] = N'{password}' AND " +
                "[Status] in (1, 4)  AND " +
                $"([Login] = N'{loginOrEmail}' OR [Email] = N'{loginOrEmail}') ");

            return result.Any();
        }

        public User GetByLogin(string loginOrEmail)
        {
            var result = ExecQuery(
                "[Status] in (1, 4)  AND " +
                $"([Login] = N'{loginOrEmail}' OR [Email] = N'{loginOrEmail}') ");

            return result.FirstOrDefault();
        }
    }
}
