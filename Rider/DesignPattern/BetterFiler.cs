namespace DesignPattern.Specifications;

public class BetterFiler : ISpecification<Journal.Product>
{
    foreach (var i in items)
        if (Specifications.spec(i))
            yield return i;

}