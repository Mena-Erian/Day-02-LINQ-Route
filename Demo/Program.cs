using System;
using System.Collections.Immutable;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static Demo.ListGenerator;


namespace Demo
{
    class StringEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
            => string.Equals(x, y, StringComparison.CurrentCultureIgnoreCase);
        //  => x?.ToLower().Equals(y.ToLower())  ?? (y is null?  true : false ) ;


        public int GetHashCode([DisallowNull] string obj)
         => obj.ToLower().GetHashCode();
    }
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

            #region Aggregate() [3 Overloads]
            /// string[] Names = ["Mena", "Erian", "Farouk", "Makar"];
            /// 
            /// /// That's like foreach
            /// /// first itration => str1 = "Mena", str2 = "Erian";
            /// /// Next itration  => str1 = str2 { return from last itration => "Mena Erian" }, str2 = Next itration { "Farouk" }
            /// /// 
            /// var Result = Names.Aggregate((str1, str2) => $"{str1} {str2}");
            /// 
            /// Result = Names.Aggregate("Hello", (SeedValue, str2) => $"{SeedValue} {str2}");
            /// 
            /// Result = Names.Aggregate("Hello", (SeedValue, str2) => $"{SeedValue} {str2}", (TAccumlate) => TAccumlate.Replace(" ", ", "));
            #endregion

            #endregion

            #region Conversion (Casting) Operators - Immediate Excution
            /// List<Product> productsList = ProductsList.Where(p => p.UnitsInStock == 0).ToList();
            /// 
            /// Product[] array = ProductsList.Where(p => p.UnitsInStock == 0).ToArray();
            /// 
            /// Dictionary<long, Product> dic01 = ProductsList.Where(p => p.UnitsInStock == 0)
            ///                                 .ToDictionary((p) => p.ProductID);
            /// 
            /// //Dictionary<string, Product> dic01 = ProductsList.Where(p => p.UnitsInStock == 0)
            /// //                                .ToDictionary((p) => p.ProductName);
            /// 
            /// Dictionary<long, Product> dic02 = ProductsList.Where(p => p.UnitsInStock == 0)
            ///                                 .ToDictionary((p) => p.ProductID, new CustomEqulityComparer());
            /// 
            /// Dictionary<long, string> dic03 = ProductsList.Where(p => p.UnitsInStock == 0)
            ///                                 .ToDictionary((p) => p.ProductID, p => p.ProductName);
            /// 
            /// Dictionary<long, string> dic04 = ProductsList.Where(p => p.UnitsInStock == 0)
            ///                                .ToDictionary((p) => p.ProductID, p => p.ProductName, new CustomEqulityComparer());
            /// 
            /// HashSet<Product> hashSet01 = ProductsList.Where(p => p.UnitsInStock == 0)
            ///                             .ToHashSet();
            /// 
            /// HashSet<Product> hashSet02 = ProductsList.Where(p => p.UnitsInStock == 0)
            ///                             .ToHashSet(new CustomEqulityComparer02());
            /// 
            /// ILookup<long, Product> lookup = ProductsList.Where(p => p.UnitsInStock == 0).ToLookup(p=>p.ProductID);
            /// ILookup<char, Product> lookup01 = ProductsList.OrderBy(p => p.ProductName).ToLookup(group => group.ProductName[0]);
            /// 
            /// var Result = ProductsList.Where(p => p.UnitsInStock == 0).ToImmutableSortedSet();
            #endregion

            #region Generation Operators
            /// // The only way for calling these operators => is as Static Method Through "Enumerable" Class.
            /// 
            /// //var Result = Enumerable.Range(0, 100);//0..9
            /// 
            /// //Result = Enumerable.Repeat(2, 100); // => 2 with count 100
            /// 
            /// //var Result = Enumerable.Repeat<Product>(new Product { Category = "Meat" }, 100);
            /// 
            /// var Result = Enumerable.Empty<Product>();
            #endregion

            #region Set Operators - Union Family
           
            #region Example 01
            /// var Seq01 = Enumerable.Range(0, 100);   // 0..99
            /// var Seq02 = Enumerable.Range(50, 100);   // 50..149
            /// 
            /// var Result = Seq01.Union(Seq02); // Merging with Removing Duplicates 0..149
            /// 
            /// Result = Seq01.Concat(Seq02); // Merging without Removing Duplicates = 0..99. 50..149
            /// 
            /// //Result = Result.Distinct(); // Merging with Removing Duplicates // Distinct Value = 0..149
            /// 
            /// Result = Seq01.Intersect(Seq02); // Shared in the Same Value Between 2 Sequenses // 50..99
            /// 
            /// Result = Seq01.Except(Seq02); // Values in Seq01 not in Seq02 // 0..9 
            #endregion

            #region Example 02
            /// var Seq01 = ProductsList.Where(p => p.ProductId <= 40).ToList(); // 1..40
            /// var Seq02 = ProductsList.Where(p => p.ProductId >= 40 && p.ProductId < 78).ToList(); // 40..77
            /// 
            /// //var Seq01 = ProductsList.Where(p => p.ProductId <= 50).ToList(); // 1..50
            /// //var Seq02 = ProductsList.Where(p => p.ProductId >= 40 && p.ProductId < 78).ToList(); // 40..77

            #region Union, UnionBy
            /// var Result = Seq01.Union(Seq02);
            /// Result = Seq01.Union(Seq02, new ProductEquiltyComparer());
            /// Result = Seq01.UnionBy(Seq02, p => p.Category);
            /// Result = Seq01.UnionBy(Seq02, p => new { p.ProductName, p.Category }); // trying to match on both name and category together.
            ///                                                                        // NOTE: if you Trying to distinct the matching in name alone and
            ///                                                                        // category alone not together in the same list you Can do this =>
            ///                                                                        // - Builds two HashSets from Seq01 — one for names, one for categories.
            ///                                                                        // - Filters Seq02 to exclude any product whose name or category already exists.
            ///                                                                        // - Concatenates the filtered Seq02 with Seq01 to form the union.
            /// Result = Seq01.UnionBy(Seq02, p => p.Category, new StringEqualityComparer()); // another string comparer (ignore case)
            #endregion

            #region Concat
            //var Result = Seq01.Concat(Seq02);
            #endregion

            #region Intersect, IntersectBy
            /// var Result = Seq01.Intersect(Seq02); // Shared in the Same State Between 2 Sequenses // 40..50
            /// Result = Seq01.Intersect(Seq02, new ProductEquiltyComparer()); // Shared in the Same State Between 2 Sequenses based on ProductEquiltyComparer() and get the matching from fist sequense  
            /// 
            /// Result = Seq01.IntersectBy(Seq02.Select(p => p.ProductId), p => p.ProductId);
            /// Result = Seq01.IntersectBy(Seq02.Select(p => p.UnitPrice), p => p.ProductId);
            /// Result = Seq01.IntersectBy(Seq02.Select(p => p.Category), p => p.Category, new StringEqualityComparer());
            /// Result = Seq01.IntersectBy(Seq02.Select(p => new { p.ProductId, p.ProductName }), p => new { p.ProductId, p.ProductName }); 
            #endregion

            #region Except, ExceptBy
            /// var Result = Seq01.Except(Seq02); // Product in seq01 not in seq02 // 1 to 39
            /// Result = Seq01.Except(Seq02, new ProductEquiltyComparerByCategory()); // Do the Same Based on Category and Regardless another porperties
            /// Result = Seq01.ExceptBy(Seq02.Select(p => p.Category), p => p.Category); // Do the Same Based on Category and Regardless another porperties
            /// Result = Seq01.ExceptBy(Seq02.Select(p => new { p.ProductName, p.Category }), p => new { p.ProductName, p.Category });
            /// Result = Seq01.ExceptBy(Seq02.Select(p => p.Category), p => p.Category, new StringEqualityComparer()); // Do the Same Based on Category and Regardless another porperties
            #endregion

            //Result.Count().Print(); 
            #endregion

            #endregion


            //Result.Print();
            //Result.PrintAll();
        }
    }
}
