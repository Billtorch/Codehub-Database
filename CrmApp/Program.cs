using CrmApp.Options;
using CrmApp.Repository;
using CrmApp.Services;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CrmApp
{
    class Program
    {
        static void Main()
        {
            
            CustomerOption custOpt = new CustomerOption
            {
                FirstName = "Maria",
                LastName = "Pentagiotissa",
                Address = "Athens",
                Email = "maria@gmail.com",

            };

            using CrmDbContext db = new CrmDbContext(); //to using to xrisomopioume anti gia to dispose (disconnect apo vasi)

            CustomerManagement custMangr = new CustomerManagement(db);
            Customer customer = custMangr.CreateCustomer(custOpt);

            Console.WriteLine(
                $"Id= {customer.Id} Name= {customer.FirstName}");

            //testing reading a customer
            Customer cx = custMangr.FindCustomerById(2);
            if (cx != null)
            {
                Console.WriteLine(
                 $"Id={cx.Id} Name={cx.FirstName} Address={cx.Address}");
            }
            else
            {
                Console.WriteLine("No customer found");
            }
            //testing updating
            CustomerOption custChangingAddress = new CustomerOption
            {

                Address = "Lamia",

            };
            Customer c2 = custMangr.Update(custChangingAddress, 1);
            Console.WriteLine(
                 $"Id= {c2.Id} Name= {c2.FirstName} Address= {c2.Address}");


        


        

            // data input

            ProductOption prodOpt = new ProductOption
            {
                ProdName = "ksartoriza",
                Price = 5.99m,
                Quantity = 5,
                

            };

           //create product

            ProductManagement prodMangr = new ProductManagement(db);
            Product product = prodMangr.CreateProduct(prodOpt);

            Console.WriteLine(
                $"ProdName= {product.ProdName} Price= {product.Price}");

            //READ
            Product px = prodMangr.FindProductById(2);
            if (px != null)
            {
                Console.WriteLine(
                 $"Prodname={px.ProdName} Price={px.Price} Quantity={px.Quantity} TotalCost={px.TotalCost}");
            }
            else
            {
                Console.WriteLine("Not Found");
            }

            //UPDATE
            ProductOption prodChangingQuantity = new ProductOption
            {

                Quantity = 2,

            };
            Product p2 = prodMangr.Update(prodChangingQuantity, 1);
            Console.WriteLine(
                 $"ProdName= {p2.ProdName} Price= {p2.Price} Quantity= {p2.Quantity}");

        }
    }
}