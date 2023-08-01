﻿using ECom.Shared.Entities;

namespace ECom.Shared.Abstract;

public interface IUnitOfWork : IUnitOfWorkBase
{
  DbSet<Address> Addresses { get; }
  DbSet<Admin> Admins { get; }
  DbSet<AdminLog> AdminLogs { get; }
  DbSet<Announcement> Announcements { get; }
  DbSet<CargoOption> CargoOptions { get; }
  DbSet<Cart> Carts { get; }
  DbSet<Category> Categories { get; }
  DbSet<CategoryDiscount> CategoryDiscounts { get; }
  DbSet<Collection> Collections { get; }
  DbSet<CollectionProduct> CollectionProducts { get; }
  DbSet<CompanyInformation> CompanyInformation { get; }
  DbSet<DiscountCoupon> DiscountCoupons { get; }
  DbSet<DiscountNotify> DiscountNotifies { get; }
  DbSet<EmailVerifyToken> EmailVerifyTokens { get; }
  DbSet<FavoriteProduct> FavoriteProducts { get; }
  DbSet<Image> Images { get; }
  DbSet<Option> Options { get; }
  DbSet<Order> Orders { get; }
  DbSet<PasswordResetToken> PasswordResetTokens { get; }
  DbSet<PaymentOption> PaymentOptions { get; }

  DbSet<Product> Products { get; }
  DbSet<ProductComment> ProductComments { get; }
  DbSet<ProductDetail> ProductDetails { get; }
  DbSet<ShowCase> ShowCases { get; }
  DbSet<ProductCategory> ProductCategories { get; }
  DbSet<ProductVariant> ProductVariants { get; }
  DbSet<Role> Roles { get; }
  DbSet<PermissionRole> PermissionRoles { get; }
  DbSet<SecurityLog> SecurityLogs { get; }
  DbSet<Slider> Sliders { get; }
  DbSet<SmtpOption> SmtpOptions { get; }
  DbSet<StockChange> StockChanges { get; }
  DbSet<Supplier> Suppliers { get; }
  DbSet<User> Users { get; }

}