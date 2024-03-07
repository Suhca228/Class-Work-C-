using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._03._2024
{
    public class Product
    {
        public string Name { get; set; }
        public int PurchasePrice { get; set; }
        public int SalePrice { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int TotalValue => Quantity * PurchasePrice;

        public Product(string name, int purchasePrice, int salePrice, int id, int quantity)
        {
            Name = name;
            PurchasePrice = purchasePrice;
            SalePrice = salePrice;
            Id = id;
            Quantity = quantity;
        }
    }

    public class Warehouse
    {
        private List<Product> products;
        private CashRegister cashRegister;

        public Warehouse()
        {
            products = new List<Product>();
            cashRegister = new CashRegister();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine("Product " + product.Name + " added to the warehouse.");
        }

        public void RemoveProduct(int id)
        {
            Product productToRemove = products.Find(p => p.Id == id);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                Console.WriteLine("Product " + productToRemove.Name + " removed from the warehouse.");
            }
            else
            {
                Console.WriteLine("Product not found in the warehouse.");
            }
        }

        public void DisplayProducts()
        {
            Console.WriteLine("Products in the warehouse:");
            foreach (var product in products)
            {
                Console.WriteLine("ID: " + product.Id + ", Name: " + product.Name + ", Quantity: " + product.Quantity + ", Purchase Price: " + product.PurchasePrice);
            }
        }

        public void SellProduct(int id, int quantity)
        {
            Product productToSell = products.Find(p => p.Id == id);
            if (productToSell != null)
            {
                cashRegister.SellProduct(productToSell, quantity);
            }
            else
            {
                Console.WriteLine("Product not found in the warehouse.");
            }
        }

        public void PrintReceipt()
        {
            cashRegister.PrintReceipt();
        }
    }

    public class CashRegister
    {
        private List<Product> productsSold;

        public CashRegister()
        {
            productsSold = new List<Product>();
        }

        public void SellProduct(Product product, int quantity)
        {
            if (product.Quantity >= quantity)
            {
                product.Quantity -= quantity;
                productsSold.Add(new Product(product.Name, product.PurchasePrice, product.SalePrice, product.Id, quantity));
                Console.WriteLine("Sold " + quantity + " " + product.Name);
            }
            else
            {
                Console.WriteLine("Insufficient quantity of " + product.Name + " in stock.");
            }
        }

        public void PrintReceipt()
        {
            Console.WriteLine("Receipt:");
            int totalPrice = 0;
            foreach (var product in productsSold)
            {
                int productTotalPrice = product.SalePrice * product.Quantity;
                Console.WriteLine(product.Name + " - Quantity: " + product.Quantity + ", Total Price: " + productTotalPrice);
                totalPrice += productTotalPrice;
            }
            Console.WriteLine("Total: " + totalPrice);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();

            warehouse.AddProduct(new Product("Potato", 10, 15, 1, 1000));
            warehouse.AddProduct(new Product("Cucumber", 10, 15, 2, 1000));
            warehouse.AddProduct(new Product("Apple", 5, 10, 3, 1000));

            warehouse.DisplayProducts();

            warehouse.SellProduct(1, 500);
            warehouse.SellProduct(2, 800);
            warehouse.SellProduct(3, 700);

            warehouse.PrintReceipt();
            warehouse.DisplayProducts();

        }
    }
}