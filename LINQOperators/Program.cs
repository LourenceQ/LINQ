using Domain.Data;
using System.Collections.Generic;
using System.Linq;

namespace LINQOperators
{
    class Program
    {
        private readonly AppDbContext _context;
        public Program(AppDbContext context)
        {
            _context = context;
        }
        static void Main(string[] args)
        {
            // var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 11, 13 };
            // var enumerable = from num in list
            //                  where num < 6
            //                  select num;

            // foreach (var item in enumerable)
            // {
            //     System.Console.WriteLine(item);
            // }

            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<string> query = names.Where(name => name.EndsWith("y"));

            System.Console.WriteLine("linq1");
            foreach (var el in query)
            {
                System.Console.WriteLine(el);
            }
            /**/
            IEnumerable<string> query2 = from n in names
                                         where n.EndsWith("y")
                                         select n;

            System.Console.WriteLine("\nlinq2");
            foreach (var el in query2)
            {
                System.Console.WriteLine(el);
            }
            /**/
            IEnumerable<string> query3 = from n in names
                                         where n.Length > 3
                                         let u = n.ToUpper()
                                         where u.EndsWith("Y")
                                         select u;
            System.Console.WriteLine("\nlinq3");
            foreach (var el in query3)
            {
                System.Console.WriteLine(el);
            }
            /**/
            IEnumerable<string> query4 = names.Where((n, i) => i % 2 == 0);
            System.Console.WriteLine("\nlinq4");
            foreach (var el in query4)
            {
                System.Console.WriteLine(el);
            }
            /**/            

             //var db = new AppDbContext();
            
            /*var data2  = db.Purchases.Where(p => p.Description.CompareTo("C") < 0);
            // System.Console.WriteLine($"\ndata2:{data2.ToString()}");
            foreach (var item in data2)
            {
                System.Console.WriteLine(item);
            }*/


            

        }
    }


}
