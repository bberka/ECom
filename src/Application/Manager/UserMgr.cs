using Domain.Entities;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager
{
    public static class UserMgr
    {
        public static User? GetUser(long userNo)
        {
            var ctx = EComDbContext.New();
            var user = ctx.Users.Where(x => x.Id == userNo).FirstOrDefault();
            return user;
        }
        public static User GetUserSingle(long userNo)
        {
            var ctx = EComDbContext.New();
            var user = ctx.Users.Where(x => x.Id == userNo).Single();
            return user;
        }
        public static User? GetUser(string username)
        {
            var ctx = EComDbContext.New();
            var user = ctx.Users.Where(x => x.Username == username).FirstOrDefault();
            return user;
        }
        public static User GetUserSingle(string username)
        {
            var ctx = EComDbContext.New();
            var user = ctx.Users.Where(x => x.Username == username).Single();
            return user;
        }
    }
}
