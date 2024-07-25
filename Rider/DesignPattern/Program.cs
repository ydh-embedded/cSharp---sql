using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Specifications;
using static System.Console;

namespace DesignPattern
{
    // Class to represent a journal
    public class Journal
    {
        // Public enum to represent colors
        public enum Color
        {
            Red,
            Green,
            Blue
        }

        // Public enum to represent sizes
        public enum Size
        {
            Small,
            Medium,
            Large,
            Yuge
        }

        // Public nested class to represent a product
        public class Product
        {
            // Private field to store the product name
            internal string Name;

            // Private field to store the product color
            internal Color Color;

            // Internal field to store the product size
            internal Size Size;

            // Public constructor to create a new product
            public Product(string name, Color color, Size size)
            {
                if (name == null)
                {
                    throw new ArgumentNullException(paramName: nameof(name));
                }

                Name = name;
                Color = color;
                Size = size;
            }
        }

        // Public nested class to filter products
        public class ProductFilter : IFilter<Journal.Product>
        {
            // Public method to filter products by the Specifications on Interface: ISpecification
            public IEnumerable<Journal.Product> Filter(IEnumerable<Journal.Product> products, ISpecification<Journal.Product> spec)
            {
                foreach (var product in products)
                {
                    if (spec.IsSatisfied(product))
                    {
                        yield return product;
                    }
                }
            }

            public IEnumerable<Product> FilterByColor(Product[] products, Color green)
            {
                throw new NotImplementedException();
            }
        }

        // Private field to store journal entries
        private readonly List<string> entries = new List<string>();

        // Private static field to keep track of the entry count
        private static int count = 0;

        // Public method to add a new entry to the journal
        public int AddEntry(string text)
        {
            entries.Add($"{++count}:{text}");
            return count; // memento
        }

        // Public method to remove an entry from the journal
        public void RemoveEntry(int index)
        {
            if (index >= 0 && index < entries.Count)
            {
                entries.RemoveAt(index);
            }
            else
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
        }

        // Public override method to return a string representation of the journal
        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        // Public method to load journal entries from a URI (not implemented)
        public void Load(Uri uri)
        {
            // Implement loading journal entries from the specified URI
            throw new NotImplementedException();
        }
    }

    // Class to handle persistence of the journal
    public class Persistence       // Public method to save the journal to a file
    { 
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            try
            {
                if (overwrite || !File.Exists(filename))
                {
                    File.WriteAllText(filename, j.ToString());
                }
            }
            catch (Exception ex)
            {
                WriteLine($"Error saving to file: {ex.Message}");
            }
        }
    }

    // Class to demonstrate the usage of the Journal and Persistence classes
    public class Demo
    { 
        static void Main(string[] args)      // Static method to run the demo
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            WriteLine(j);

            var p = new Persistence();
            var filename = @"c:\temp\journal.txt";
            p.SaveToFile(j, filename, true);
            Process.Start(filename);

            // We add a new Product 
            var apple = new Journal.Product("Apple", Journal.Color.Green, Journal.Size.Small);
            var tree = new Journal.Product("Tree", Journal.Color.Green, Journal.Size.Large);
            var house = new Journal.Product("House", Journal.Color.Blue, Journal.Size.Large);

            var products = new[] { apple, tree, house };

            var pf = new Journal.ProductFilter();

            PrintProducts("Green products:", pf.Filter(products, new ColorSpecification(Journal.Color.Green)));
            PrintProducts("Large products:", pf.Filter(products, new SizeSpecification(Journal.Size.Large)));
            PrintProducts("Green and large products:", pf.Filter(products, new AndSpecification<Journal.Product>(new ColorSpecification(Journal.Color.Green), new SizeSpecification(Journal.Size.Large))));
            PrintProducts("Green products (old):", pf.FilterByColor(products, Journal.Color.Green).Cast<Journal.Product>());
            
        }

        static void PrintProducts(string title, IEnumerable<Journal.Product> products)
        {
            WriteLine(title);
            foreach (var product in products)
            {
                WriteLine($" - {product.Name} is {title.ToLower().Replace("products", "")}");
            }
        }
    }
}