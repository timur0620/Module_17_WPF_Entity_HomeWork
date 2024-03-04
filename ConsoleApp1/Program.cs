using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBaseMyEtity context = new DataBaseMyEtity();

            //var res = context.Product;
            //var res = context.Product.Where(p => p.ProductCod.Equals("983"));
            var res = context.Client.Where(c => c.Id > 100);

             List<Client> cd =  res.ToList();

            Console.WriteLine(res);
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.Name);

            //}
        }
    }
}
