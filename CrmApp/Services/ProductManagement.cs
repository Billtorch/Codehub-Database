using CrmApp.Options;
using CrmApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmApp.Services
{
    public class ProductManagement
    {

        private CrmDbContext db = new CrmDbContext();
        //DB Injection gia na mi to vazoume pantou
        public ProductManagement(CrmDbContext _db)
        {
            db = _db;
        }

        //CRUD
        // create read update delete
        public Product CreateProduct(ProductOption prodOption)
        {
            Product product = new Product
            {
                ProdName = prodOption.ProdName,
                Price = prodOption.Price,
                Quantity = prodOption.Quantity,
            };


            // db.Database.EnsureCreated();

            db.Products.Add(product);
            db.SaveChanges();

            return product;
        }

        public Product FindProductById(int Id)
        {
            Product product = db.Products.Find(Id);
            return product;
        }

        public Product Update(ProductOption prodOption, int Id)
        {

            Product product = db.Products.Find(Id);

            if (prodOption.ProdName != null)
                product.ProdName = prodOption.ProdName;
            if (prodOption.Price != null)
                product.Price = prodOption.Price;
            if (prodOption.Quantity != null)
                product.Quantity = prodOption.Quantity;
            
            db.SaveChanges();
            return product;
        }

        public bool DeleteProductById(int Id)
        {

            Product product = db.Products.Find(Id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}