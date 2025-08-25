using Demo;
using static Demo.ListGenerator;


namespace Assignment
{
    internal class Program
    {
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



            #endregion

        }
    }
}
