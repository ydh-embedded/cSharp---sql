namespace DesignPattern.Specifications
{
    public class ColorSpecification : ISpecification<Journal.Product>
    {
        private Journal.Color color;

        public ColorSpecification(Journal.Color color)
        {
            this.color = color;
        }

        public bool IsSatisfied(Journal.Product t)
        {
            return t.Color == color;
        }
    }
}