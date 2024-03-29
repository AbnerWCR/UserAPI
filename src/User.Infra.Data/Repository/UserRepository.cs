﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Domain.Interfaces;
using User.Infra.Data.Context;
using Entity = User.Domain.Entities;

namespace User.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<Entity.User>, IUserRepository
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
            : base(userContext)
        {
            _userContext = userContext;
        }

        public async Task<Entity.User> GetByEmail(string email)
        {
            var user = await _userContext.Users
                                            .Where(x => string.Equals(x.Email.Address.ToLower(), email.ToLower()))
                                            .AsNoTracking()
                                            .ToListAsync();

            return user.FirstOrDefault();
        }

        public override async Task<Entity.User> UpdateAsync(Entity.User obj)
        {
            _userContext.Attach(obj);
            _userContext.Entry(obj.Name).Property(p => p.FirstName).IsModified = true;
            _userContext.Entry(obj.Name).Property(p => p.LastName).IsModified = true;
            _userContext.Entry(obj.Email).Property(p => p.Address).IsModified = true;
            await _userContext.SaveChangesAsync();

            return obj;
        }

        public async Task<Entity.User> UpdatePasswordAsync(Entity.User obj)
        {
            _userContext.Attach(obj);
            _userContext.Entry(obj.Password).Property(p => p.PasswordHash).IsModified = true;
            await _userContext.SaveChangesAsync();

            return obj;
        }

        public async Task<Entity.User> UpdateRoleAsync(Entity.User obj)
        {
            _userContext.Attach(obj);
            _userContext.Entry(obj.Role).Property(p => p.UserRole).IsModified = true;
            await _userContext.SaveChangesAsync();

            return obj;
        }
    }
}
