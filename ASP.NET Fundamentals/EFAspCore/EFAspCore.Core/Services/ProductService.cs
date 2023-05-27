﻿namespace EFAspCore.Core.Services
{
	using EFAspCore.Core.Contracts;
	using EFAspCore.Core.Models;
	using EFAspCore.Infrastructure.Model;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.IdentityModel.Tokens;
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class ProductService : IProductService
	{
		private readonly WebShopDbContext dbContext;

		public ProductService(WebShopDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task AddProductAsync(ProductFormModel model)
		{
			Product product = new Product
			{
				ProductName = model.Name,
				Quantity = model.Quantity
			};

			await dbContext.Products.AddAsync(product);
			await dbContext.SaveChangesAsync();
		}

		public async Task<List<ProductViewModel>> GetProductsAsync()
		{
			return await dbContext.Products
				.Select(p => new ProductViewModel
				{
					Name = p.ProductName,
					Id = p.Id
				})
				.ToListAsync();
		}
	}
}
