namespace DesignPattern.Specifications
{
    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first;
        private ISpecification<T> second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first;
            this.second = second;
        }

        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }
}