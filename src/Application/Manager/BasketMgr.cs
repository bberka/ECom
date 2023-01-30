﻿using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager
{
    public static class BasketMgr
    {
        public static Result AddOrIncreaseProduct(int userId, int productId,int count)
        {
            UserMgr.ValidateUser(userId);
            var ctx = EComDbContext.New();
            var existing = ctx.BasketProducts.FirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
            if(existing != null)
            {
                existing.Count += count;
                ctx.BasketProducts.Update(existing);
            }
            else
            {
                var newBasket = new BasketProduct
                {
                    Count = count,
                    RegisterDate = DateTime.Now,
                    ProductId = productId,
                    UserId = userId,
                    LastUpdateDate = DateTime.Now,
                };
                ctx.Add(newBasket);
            }
            var saveRes = ctx.SaveChanges();
            if(saveRes == 0)
            {
                return Result.Error(1, Response.InternalDbError);
            }
            return Result.Success(Response.Basket_AddOrIncreaseProduct_Success);
        }
        public static Result RemoveOrDecreaseProduct(int userId, int productId)
        {
            UserMgr.ValidateUser(userId);
            var ctx = EComDbContext.New();
            var exist = ctx.BasketProducts.FirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
            if(exist is null) 
            {
                return Result.Error(1, Response.Basket_ProductNotFound);
            }
            if (exist.Count > 1)
            {
                exist.Count--;
                ctx.BasketProducts.Update(exist);
            }
            else
            {
                ctx.Remove(exist);
            }
            var saveRes = ctx.SaveChanges();
            if (saveRes == 0)
            {
                return Result.Error(1, Response.InternalDbError);
            }
            return Result.Success(Response.Basket_AddOrIncreaseProduct_Success);
        }
        public static int GetBasketProductCount(int userId)
        {
            UserMgr.ValidateUser(userId);
            var ctx = EComDbContext.New();
            var count = ctx.BasketProducts.Count(x => x.UserId == userId);
            return count;
        }
        public static List<BasketProduct> GetBasketProducts(int userId)
        {
            UserMgr.ValidateUser(userId);
            var ctx = EComDbContext.New();
            var list = ctx.BasketProducts.Where(x => x.UserId == userId).ToList();
            return list ?? new();
        }
    }
}
