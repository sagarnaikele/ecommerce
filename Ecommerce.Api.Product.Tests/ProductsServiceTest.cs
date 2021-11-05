using AutoMapper;
using Ecommerce.Api.Product.DB;
using Ecommerce.Api.Product.Profile;
using Ecommerce.Api.Product.Provider;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Ecommerce.Api.Product.Tests
{
  public class ProductsServiceTest
  {
    [Fact]
    public async Task GetProductsReturnAllProducts()
    {
      var options = new DbContextOptionsBuilder<ProductDbContext>().UseInMemoryDatabase(nameof(GetProductsReturnAllProducts)).Options;
      var dbContext = new ProductDbContext(options);
      CreateProduct(dbContext);
      var productProfile = new ProductProfile();
      var config = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
      var mapper = new Mapper(config);
      var provider = new ProductsProvider(dbContext, null, mapper);
      var res = await provider.GetProductsAsync();
      Assert.True(res.IsSuccess);
      Assert.True(res.Products.Any());
      Assert.Null(res.ErrorMessage);
    }

    [Fact]
    public async Task GetProductReturnProductWithValidId()
    {
      var options = new DbContextOptionsBuilder<ProductDbContext>().UseInMemoryDatabase(nameof(GetProductReturnProductWithValidId)).Options;
      var dbContext = new ProductDbContext(options);
      CreateProduct(dbContext);
      var productProfile = new ProductProfile();
      var config = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
      var mapper = new Mapper(config);
      var provider = new ProductsProvider(dbContext, null, mapper);
      var res = await provider.GetProductAsync(1);
      Assert.True(res.IsSuccess);
      Assert.NotNull(res.Product);
      Assert.True(res.Product.Id==1);
      Assert.Null(res.ErrorMessage);
    }

    [Fact]
    public async Task GetProductReturnNullProductWithInValidId()
    {
      var options = new DbContextOptionsBuilder<ProductDbContext>().UseInMemoryDatabase(nameof(GetProductReturnNullProductWithInValidId)).Options;
      var dbContext = new ProductDbContext(options);
      CreateProduct(dbContext);
      var productProfile = new ProductProfile();
      var config = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
      var mapper = new Mapper(config);
      var provider = new ProductsProvider(dbContext, null, mapper);
      var res = await provider.GetProductAsync(-1);
      Assert.True(!res.IsSuccess);
      Assert.Null(res.Product);
      Assert.NotNull(res.ErrorMessage);
    }
    private void CreateProduct(ProductDbContext dbContext)
    {
      for (int i = 1; i <= 10; i++)
      {
        dbContext.Products.Add(new DB.Product()
        {
          Id=i,
          Name=Guid.NewGuid().ToString(),
          Inventory=i*10,
          Price=(decimal) (i*3.14)
        });

      }
      dbContext.SaveChanges();
    }
  }
}
