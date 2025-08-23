using System.Linq;
using static Demo.ListGenerator;


namespace Demo
{
    internal class Program
    {
        static void Main()
        {
            #region Element Operators - Immediate Excution
            // Valid Only with fluent syntax

            #region First(), Last(), FirstOrDefault(), LastOrDefault()
            #region First, Last, FirstOrDefault, LastOrDefault [Part 01]
            /// ProductsList = new List<Product>();
            /// 
            /// //var Result = ProductsList.First();
            /// //Result= ProductsList.Last();
            /// 
            /// var Result = ProductsList.FirstOrDefault();
            /// Result = ProductsList.FirstOrDefault(new Product() { ProductID = -1 });
            /// 
            /// Result = ProductsList.LastOrDefault();
            /// Result = ProductsList.LastOrDefault(new Product() { ProductID = -1 }); 
            #endregion

            #region First, Last, FirstOrDefault, LastOrDefault [Part 02]
            /// //var Result = ProductsList.First(P => P.UnitsInStock == 0);
            /// //Result = ProductsList.Last(P => P.UnitsInStock == 0);
            /// 
            /// var Result = ProductsList.FirstOrDefault(P => P.UnitsInStock > 1_000);
            /// Result = ProductsList.FirstOrDefault(P => P.UnitsInStock > 1_000, new Product() { ProductID = -1 });
            /// 
            /// Result = ProductsList.LastOrDefault(P => P.UnitsInStock > 1_000);
            /// Result = ProductsList.LastOrDefault(P => P.UnitsInStock > 1_000, new Product() { ProductID = -1 });

            #endregion
            #endregion

            #region ElementAt(), ElementAtOrDefault()
            /// var Result = ProductsList.ElementAt(1);
            /// Result = ProductsList.ElementAt(new Index(1));
            /// Result = ProductsList.ElementAt(new Index(1, true));
            /// Result = ProductsList.ElementAt(^1); // Last 1
            /// 
            /// Result = ProductsList.ElementAtOrDefault(1);
            /// Result = ProductsList.ElementAtOrDefault(new Index(1));
            /// Result = ProductsList.ElementAtOrDefault(new Index(1, true));
            /// Result = ProductsList.ElementAtOrDefault(^1); // Last 1 
            #endregion

            #region Single(), SingleOrDefault()
            //var DiscountedProducts = new List<Product>() { ProductsList[4] };

            #region Single, SingleOrDefault [Part 01]
            /// var Result = DiscountedProducts.Single();
            /// // If Sequence Contain just only one element, will return this single element
            /// // Else will throw exception (Sequence is Empty or Contains More than one element)

            /// var Result = DiscountedProducts.SingleOrDefault();
            /// // If Sequence is Empty, Will Return the Default value of TSource.
            /// // If Sequence Contains JUst only one Element, Will Return this Single Element.
            /// // If Sequence Contains More than only one Element,Throw Exception.

            /// Result = DiscountedProducts.SingleOrDefault(ProductsList[10]);
            /// // If Sequence is Empty, Will Return the Default value of TSource.
            /// // If Sequence Contains JUst only one Element, Will Return this Single Element.
            /// // If Sequence Contains More than only one Element,Not Throw Exception. 
            #endregion

            #region Single, SingleOrDefault [Part 02]
            /// //var Result = ProductsList.Single(p => p.UnitsInStock == 0);
            /// var Result = DiscountedProducts.Single(p => p.UnitsInStock == 0);
            /// // If Sequence Contain just only one element Matching the Condition, will return this Matched single element
            /// // Else will throw exception (Sequence is Empty or Contains More than one element Or not Matching the condition)

            /// var Result = DiscountedProducts.SingleOrDefault(p => p.UnitsInStock == 0);
            /// Result = DiscountedProducts.SingleOrDefault(p => p.UnitsInStock == 0, ProductsList[10]);
            #endregion

            #endregion

            #region DefaultIfEmpty()
            /// ProductsList = new List<Product>();
            /// 
            /// var Result = ProductsList.DefaultIfEmpty();
            /// Result = ProductsList.DefaultIfEmpty(ProductsList[2]);
            #endregion

            #region SingleOrDefault vs FirstOrDefault
            /// var Result = ProductsList.FirstOrDefault(p => p.UnitsInStock == 0);
            /// Result = ProductsList.SingleOrDefault(p => p.UnitsInStock == 0); 
            #endregion
            #endregion

            #region Aggregate Operators - Count, GetNonEnumeratedCount - Immediate Excution

            #region Count(), TryGetNonEnumeratedCount() [.NET 6.0 New Feature] [in Progress (V3)]
            // Using if i have IEnumerable
            /// //var Result = ProductsList.Count();
            /// //Result = ProductsList.Count;
            /// IEnumerable<int> Numbers = Enumerable.Range(0, 100);
            /// Numbers.Count();

            //var Result = ProductsList.Count(p=> p.UnitsInStock ==0);
            //ProductsList.TryGetNonEnumeratedCount(out var Result); // Here Access Count Property direct with out make enumaration
            #endregion

            #region Sum(), Average()
            /// var Result = ProductsList.Sum(p => p.UnitPrice);
            /// Result = ProductsList.Average(p => p.UnitPrice); 
            #endregion

            #region Max(), Min() [First 2 Overloads] && MaxBy(), MinBy() [.NET 6.0 NEW Featur]
            /// var Result = ProductsList.Max();// to use first overload should implement IComparable
            /// Result = ProductsList.Min();
            /// 
            /// Result = ProductsList.Max(new ProductComparer());
            /// Result = ProductsList.OrderByDescending(p => p.UnitPrice).FirstOrDefault();
            /// 
            /// Result = ProductsList.Min(new ProductComparer());
            /// Result = ProductsList.OrderBy(p => p.UnitPrice).FirstOrDefault();
            /// 
            /// Result = ProductsList.MaxBy(p => p.UnitPrice);
            /// Result = ProductsList.MinBy(p => p.UnitPrice);
            /// //Result = ProductsList.MinBy(p => p.UnitPrice,new IntComparer()); 
            #endregion

            #region Max(), Min(), [Other Overloads]
            /// var Result = ProductsList.Max(p => p.UnitPrice); // 263.5000
            ///                                                  //var Result = ProductsList.MaxBy(p => p.UnitPrice); // ProductID:38,ProductName:Côte de Blaye,CategoryBeverages,UnitPrice:263.5000,UnitsInStock:17
            /// 
            /// Result = ProductsList.Min(p => p.UnitPrice); // 2.5000
            /// //var Result = ProductsList.MaxBy(p => p.UnitPrice); 


            //var Result = ProductsList.Max(p => p.ProductName);
            //Result = ProductsList.Min(p => p.ProductName);

            //var Result = ProductsList.MaxBy(p => p.ProductName);
            //Result = ProductsList.MinBy(p => p.ProductName); 
            #endregion

            string[] Names = ["Mena", "Erian", "Farouk", "Makar"];

            /// That's like foreach
            /// first itration => str1 = "Mena", str2 = "Erian";
            /// Next itration  => str1 = str2 { return from last itration => "Mena Erian" }, str2 = Next itration { "Farouk" }
            /// 
            var Result = Names.Aggregate((str1, str2) => $"{str1} {str2}");

            Result = Names.Aggregate("Hello", (SeedValue, str2) => $"{SeedValue} {str2}");

            Result = Names.Aggregate("Hello", (SeedValue, str2) => $"{SeedValue} {str2}", (TAccumlate) => TAccumlate.Replace(" ", ", "));


            #endregion

            Result.Print();
            //Result.PrintAll();
         }
    }
}
