
using System.Diagnostics.CodeAnalysis;

namespace Demo
{
    internal class CustomEqulityComparer : IEqualityComparer<long>
    {
        public bool Equals(long x, long y) => x.Equals(y);
        public int GetHashCode([DisallowNull] long obj) => obj.GetHashCode();
    }
    internal class CustomEqulityComparer02 : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y) => x.Equals(y);
        public int GetHashCode([DisallowNull] Product obj) => obj.GetHashCode();
    }
}