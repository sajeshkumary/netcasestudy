using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceBookingLibrary.Models;
using System.Linq;
using ProductManagement.Repo;

namespace ProductManagement.Repo
{

    public class ProductRepo : IProduct
    {
        private readonly TrainingServiceBookingContext _context;

        public ProductRepo(TrainingServiceBookingContext db)
        {
            _context = db;
        }

        public async Task<Product> AddNewProduct(Product p)
        {
            _context.Products.Add(p);
            await _context.SaveChangesAsync();
            return p;
        }

        public async Task<List<Product>> getAllProduct()
        {
            var products = await _context.Products.ToListAsync();
            if (products == null || products.Count() == 0)
            {
                throw new NoProductsException("No Products");
            }
            else
            {
                return products;
            }
        }

        public async Task<Product> getProduct(int uId)
        {
            var Product = await _context.Products.FindAsync(uId);
            if (Product == null)
            {
                throw new NoProductsException("No Product with Search Critera");
            }
            else
            {
                return Product;
            }
        }

        public async Task<Product> UpdateProduct(int ProductId, Product p)
        {
            Product prd = _context.Products.Find(ProductId);

            if (prd != null)
            {
                prd.Make = p.Make;
                prd.Createddate = p.Createddate;
                prd.Cost = p.Cost;
                prd.Model = p.Model;
                prd.Name = p.Name;

                _context.Entry(prd).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return p;
            }
            else
            {
                throw new NoProductsException("No Product with Search Critera");
            }

        }
        public void deleteProduct(int ProductId)
        {
            Product prd = _context.Products.Find(ProductId);

            if (prd != null)
            {
                _context.Remove(prd);
                _context.SaveChangesAsync();

            }
            else
            {
                throw new NoProductsException("No Product with Search Critera");
            }

        }

    }
}
