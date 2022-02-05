using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Company.Function.Models;

namespace Company.Function.Repositories
{
    public interface IUsersRepository
    {
        Task<List<User>> GetUsers(CancellationToken cancellationToken);
        
        Task AddUser(string firstName, string lastName, CancellationToken cancellationToken);
    }
}