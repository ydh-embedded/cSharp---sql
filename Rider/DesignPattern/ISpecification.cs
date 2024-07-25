namespace DesignPattern;

public interface ISpecification<T>
{
    bool IsSatisfied(T t);
}

