namespace DesignPattern.Specifications
{
    public class SizeSpecification : ISpecification<Journal.Product>
    {
        private Journal.Size size;

        public SizeSpecification(Journal.Size size)
        {
            this.size = size;
        }

        public bool IsSatisfied(Journal.Product t)
        {
            return t.Size == size;
        }
    }
}