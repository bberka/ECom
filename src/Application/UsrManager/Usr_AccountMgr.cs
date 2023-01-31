

namespace ECom.Application.UsrManager
{
    public static class Usr_AccountMgr
    {
        public static User? GetUser(int userId)
        {
			var ctx = EComDbContext.New();
            var user = ctx.Users.Where(x => x.Id == userId).FirstOrDefault();
            return user;
        }
        public static User GetUserSingle(int userId)
        {
            var ctx = EComDbContext.New();
            var user = ctx.Users.Where(x => x.Id == userId).Single();
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
        public static void ValidateUser(int userId)
        {
            var ctx = EComDbContext.New();
            var exist = ctx.Users.Where(x => x.Id == userId).Any();
            if (!exist) throw new BaseException(Response.NotExist);
        }
    }
}
