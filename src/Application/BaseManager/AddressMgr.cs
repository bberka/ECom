using EasMe.EFCore;

namespace ECom.Application.BaseManager
{
    public class AddressMgr : EfEntityRepositoryBase<Address,EComDbContext>
	{
		private AddressMgr() { }
		public static AddressMgr This 
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static AddressMgr? Instance;
	}
}
