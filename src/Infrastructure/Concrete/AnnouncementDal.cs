using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECom.Infrastructure.Abstract;

namespace ECom.Infrastructure.Concrete
{
	public class AnnouncementDal : EfEntityRepositoryBase<Announcement, EComDbContext>, IAnnouncementDal
	{
	
	}
}
