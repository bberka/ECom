﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.DataAccess
{
	public class ImageDal : EfEntityRepositoryBase<Image, EComDbContext>, IEfEntityRepository<Image>
	{
	}
}
