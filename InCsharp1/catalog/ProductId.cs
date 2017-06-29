namespace CsharpEvolve
{
    public class ProductId
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
    }
}