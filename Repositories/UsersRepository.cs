using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Company.Function.Contexts;
using Company.Function.Entities;
using Company.Function.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Function.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDbContextFactory<DataBaseContext> _contextFactory;

        public UsersRepository(IDbContextFactory<DataBaseContext> contextFactory) => 
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));

        public async Task<List<User>> GetUsers(CancellationToken cancellationToken)
        {
            using(var context = await _contextFactory.CreateDbContextAsync())
            {
                return await context.Users.Select(s => new User
                {
                    UserId = s.UserId,
                    FirstName = s.FirstName,
                    LastName = s.LastName
                }).ToListAsync(cancellationToken);
            }
        }

        public async Task AddUser(string firstName, string lastName, CancellationToken cancellationToken)
        {
            using(var context = await _contextFactory.CreateDbContextAsync())
            {
                context.Users.Add(new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName
                });

                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}