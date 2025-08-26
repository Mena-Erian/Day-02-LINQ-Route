using Demo;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using static Demo.ListGenerator;
using static System.Net.Mime.MediaTypeNames;


namespace Assignment
{
    internal class Program
    {

        class StringEqualityComparer : IEqualityComparer<string>
        {
            // NOTE!:
            // To be honest, this Class made with the help of chatgpt :\
            public bool Equals(string? x, string? y)
            {
                if (x == null) return y == null;
                if (y == null) return false;

                return x.OrderBy(c => c).SequenceEqual(y.OrderBy(c => c));
            }

            public int GetHashCode([DisallowNull] string obj)
            {

                int hash = 0;
                foreach (char item in obj) hash += item;
                return hash;
            }
        }
        static void Main()
        {
            #region LINQ - Element Operators

            #region 1. Get first Product out of Stock 
            /// var Result = ProductsList.First(p => p.UnitsInStock == 0);
            /// 
            /// Result = (from p in ProductsList
            ///           where p.UnitsInStock == 0
            ///           select p).First();
            #endregion

            #region 2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            /// var Result = ProductsList.FirstOrDefault((p) => p.UnitPrice > 1000);
            /// 
            /// Result = (from p in ProductsList
            ///           where p.UnitPrice > 1000
            ///           select p).FirstOrDefault();
            #endregion

            #region 3. Retrieve the second number greater than 5 
            /// int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }; // 8
            /// var Result = Arr
            ///     .Where(num => num > 5)
            ///     .ElementAt(1);
            /// 
            /// Result = (from num in Arr
            ///          where num > 5
            ///          select num).ElementAt(1);
            #endregion

            //Result.Print();
            #endregion

            #region LINQ - Aggregate Operators

            #region 1. Uses Count to get the number of odd numbers in the array
            /// int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            /// Arr.Count(num => num % 2 != 0).Print();
            #endregion

            #region 2. Return a list of customers and how many orders each has.
            /// var Result = CustomersList.Select(ctm => new
            /// {
            ///     ctm.CustomerName,
            ///     OrderCount = ctm.Orders.Length,
            ///     //OrderCount = ctm.Orders.Count(),
            /// });
            /// Result.PrintAll();
            #endregion

            #region 3. Return a list of categories and how many products each has
            /// var Result = ProductsList.GroupBy(p => p.Category);
            /// Result.PrintAll();
            #endregion

            #region 4. Get the total of the numbers in an array.
            /// int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            /// Arr.Sum().Print();
            #endregion

            #region 5. Get the total number of characters of all words in dictionary_english.txt 
            /// var Result = DictionaryEnglish.Line.Sum(str => str.Length);
            /// Result.Print();
            #endregion

            #region 6. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            /// //var smallestElement = DictionaryEnglish.Line.MinBy(str => str.Length);
            /// //smallestElement.Print();
            /// 
            /// var Result = DictionaryEnglish.Line.Min(str => str.Length);
            /// Result.Print();
            #endregion

            #region 7. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            /// var Result = DictionaryEnglish.Line.Max(str => str.Length);
            /// Result.Print();
            #endregion

            #region 8. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            /// var Result = DictionaryEnglish.Line.Average(str => str.Length);
            /// Result.Print();
            #endregion

            #region 9. Get the total units in stock for each product category.
            /// var Result = ProductsList.GroupBy(p => p.Category, (key, products) => new
            /// {
            ///     key,
            ///     UntisInStock = products.Sum(p => p.UnitsInStock)
            /// });
            /// 
            /// Result.PrintAll();
            #endregion

            #region 10. Get the cheapest price among each category's products
            /// var Result = ProductsList.GroupBy(p => p.Category, (key, products) => new
            /// {
            ///     Category = key,
            ///     CheapestProduct = products.MinBy(p => p.UnitPrice)
            /// });
            /// 
            /// Result = from p in ProductsList
            ///          group p by p.Category
            ///          into prdCtr
            ///          select new
            ///          {
            ///              Category = prdCtr.Key,
            ///              CheapestProduct = prdCtr.MinBy(p => p.UnitPrice)
            ///          };
            /// 
            /// Result.PrintAll();
            #endregion

            #region 11. Get the products with the cheapest price in each category (Use Let)
            /// var Result = from p in ProductsList
            ///              let prdCtr = p.Category
            ///              group p by p.Category into prdCtr
            ///              select new
            ///              {
            ///                  Category = prdCtr.Key,
            ///                  CheapestProduct = prdCtr.MinBy(p => p.UnitPrice)
            ///              };
            /// 
            /// Result.PrintAll();
            #endregion

            #region 12. Get the most expensive price among each category's products.
            /// var Result = ProductsList.GroupBy(p => p.Category, (key, products) => new
            /// {
            ///     Category = key,
            ///     MostExpensivePrice = products.Max(p => p.UnitPrice)
            /// });
            /// 
            /// Result = from p in ProductsList
            ///          group p by p.Category
            ///          into prdCtr
            ///          select new
            ///          {
            ///              Category = prdCtr.Key,
            ///              MostExpensivePrice = prdCtr.Max(p => p.UnitPrice)
            ///          };
            /// 
            /// Result.PrintAll();
            #endregion

            #region 13. Get the products with the most expensive price in each category.
            /// var Result = ProductsList.GroupBy(p => p.Category, (key, products) => new
            /// {
            ///     Category = key,
            ///     MostExpensiveProduct = products.MaxBy(p => p.UnitPrice)
            /// });
            /// 
            /// Result = from p in ProductsList
            ///          group p by p.Category
            ///          into prdCtr
            ///          select new
            ///          {
            ///              Category = prdCtr.Key,
            ///              MostExpensiveProduct = prdCtr.MaxBy(p => p.UnitPrice)
            ///          };
            /// 
            /// Result.PrintAll();
            #endregion

            #region 14. Get the average price of each category's products.
            /// var Result = ProductsList.GroupBy(p => p.Category, (key, products) => new
            /// {
            ///     Category = key,
            ///     PriceAvg = products.Average(p => p.UnitPrice)
            /// });
            /// 
            /// Result = from p in ProductsList
            ///          group p by p.Category
            ///          into prdCtr
            ///          select new
            ///          {
            ///              Category = prdCtr.Key,
            ///              PriceAvg = prdCtr.Average(p => p.UnitPrice)
            ///          };
            /// 
            /// Result.PrintAll();
            #endregion

            #endregion

            #region LINQ - Set Operators

            #region 1. Find the unique Category names from Product List
            /// var Result = ProductsList.Select(p => p.Category).Distinct();
            /// 
            /// Result = (from p in ProductsList
            ///           select p.Category).Distinct();
            /// 
            /// Result.PrintAll();
            #endregion

            #region 2. Produce a Sequence containing the unique first letter from both product and customer names.
            /// var seq01 = ProductsList.Select(p => p.ProductName[0]);
            /// var seq02 = CustomersList.Select(c => c.CustomerName[0]);
            /// var Result = seq01.Union(seq02).Order();
            /// 
            /// Result.PrintAll(); 
            #endregion

            #region 3. Create one sequence that contains the common first letter from both product and customer names.
            /// var seq01 = ProductsList.Select(p => p.ProductName[0]);
            /// var seq02 = CustomersList.Select(c => c.CustomerName[0]);
            /// var Result = seq01.Concat(seq02).Order();
            /// 
            /// Result.PrintAll();  
            #endregion

            #region 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.
            /// var seq01 = ProductsList.Select(p => p.ProductName[0]);
            /// var seq02 = CustomersList.Select(c => c.CustomerName[0]);
            /// var Result = seq01.Except(seq02).Order();
            /// 
            /// Result.PrintAll(); 
            #endregion

            #region 5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates
            /// var seq01 = ProductsList.Select(p => p.ProductName.Substring(p.ProductName.Length <= 3 ? 0 : p.ProductName.Length - 3, 3));
            /// var seq02 = CustomersList.Select(c => c.CustomerName.Substring(c.CustomerName.Length <= 3 ? 0 : c.CustomerName.Length - 3, 3));
            /// var Result = seq01.Concat(seq02);
            /// 
            /// Result.PrintAll();
            #endregion

            #endregion

            #region LINQ - Partitioning Operators

            #region 1. Get the first 3 orders from customers in Washington
            /// var Result = CustomersList.Where(ctr => ctr.City == "London") // "Washington" not Customer within File in Washington
            ///                            .SelectMany(ctr => ctr.Orders)
            ///                            .Take(3);
            /// Result.PrintAll();
            #endregion

            #region 2. Get all but the first 2 orders from customers in Washington.
            /// var first2Order = CustomersList.Where(ctr => ctr.City == "London")
            ///                                .Select(ctr => new { ctr.City, ctr.Orders })
            ///                                .Take(2);
            /// var allOrders = CustomersList.Select(ctr => new { ctr.City, ctr.Orders });
            /// var Result = first2Order.Union(allOrders);
            /// Result.PrintAll();
            #endregion

            #region 3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
            /// int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            /// var Result = numbers.TakeWhile((num, index) => num >= index);
            /// 
            /// Result.PrintAll();
            #endregion

            #region 4.Get the elements of the array starting from the first element divisible by 3.
            ///int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            ///var Result = numbers.SkipWhile(num => num % 3 != 0);
            ///
            ///Result.PrintAll();
            #endregion

            #region 5. Get the elements of the array starting from the first element less than its position.
            /// int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            /// var Result = numbers.SkipWhile((num, index) => num >= index);
            /// 
            /// Result.PrintAll();
            #endregion

            #endregion

            #region LINQ - Quantifiers

            #region 1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            /// var Result = DictionaryEnglish.Line.Any(str => str.Contains("ei"));
            /// Result.Print();
            #endregion

            #region 2. Return a grouped a list of products only for categories that have at least one product that is out of stock.
            /// var Result = ProductsList.GroupBy(p => p.Category)
            ///                          .Where((prdCtr) => prdCtr.Any(p => p.UnitsInStock == 0));
            /// 
            /// Result.PrintAll();
            #endregion

            #region 3. Return a grouped a list of products only for categories that have all of their products in stock.
            /// var Result = ProductsList.GroupBy(p => p.Category)
            ///                          .Where((prdCtr) => prdCtr.All(p => p.UnitsInStock > 0));
            /// 
            /// Result.PrintAll();
            #endregion

            #endregion

            #region LINQ – Grouping Operators

            #region 1. Use group by to partition a list of numbers by their remainder when divided by 5
            /// List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            /// List<int> remainders = new List<int> { 0, 1, 2, 3, 4 };
            /// 
            /// var Result = numbers
            ///             .GroupBy((num) => num % 5);
            /// 
            /// 
            /// foreach (IGrouping<int, int> item in Result)
            /// {
            ///     Console.WriteLine($"Numbers with a remainder of {item.Key} when divided by 5: ");
            ///     item.PrintAll();
            /// }
            #endregion

            #region 2. Uses group by to partition a list of words by their first letter.
            /// var Result = DictionaryEnglish.Line.GroupBy(line => line[0]);
            /// Result.PrintAll();
            #endregion

            #region 3. Consider this Array as an Inpution Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            /// string[] Arr = { "from", "salt", "earn", " last", "near", "form" };
            /// var Result = Arr.GroupBy(word => word, new StringEqualityComparer());
            /// 
            /// Result.PrintAll();
            #endregion

            #endregion

        }
    }
}
