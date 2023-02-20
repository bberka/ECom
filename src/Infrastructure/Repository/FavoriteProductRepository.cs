﻿using EasMe.EntityFrameworkCore.V2;

namespace ECom.Infrastructure.Repository;

public class FavoriteProductRepository : GenericRepository<FavoriteProduct,EComDbContext>
{
    public FavoriteProductRepository(EComDbContext context) : base(context)
    {
    }
}