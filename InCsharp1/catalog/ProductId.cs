using System;

namespace CsharpEvolve
{
    public class ProductId : IEquatable<ProductId>
    {
        public int Value { get; }

        public ProductId(int value)
        {
            Value = value;
        }

        public ProductId(string value)
        {
            Value = int.Parse(value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public bool Equals(ProductId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProductId) obj);
        }

        public override int GetHashCode()
        {
            return Value;
        }
    }
}