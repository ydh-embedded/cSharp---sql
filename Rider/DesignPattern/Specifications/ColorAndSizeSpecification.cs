namespace DesignPattern.Specifications;

public class ColorAndSizeSpecification : ISpecification<Journal.Product>
{
    private Journal.Color _color;
    private Journal.Size _size;

    public ColorAndSizeSpecification(Journal.Color color, Journal.Size size)
    {
        _color = color;
        _size = size;
    }
    
    public bool IsSatisfied(Journal.Product t)
    {
        return t.Color == _color && t.Size == _size;
        throw new NotImplementedException();
    }
}