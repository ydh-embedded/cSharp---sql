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
    
    public class Journal                        // Class to represent a journal
    {
        public enum Color                       // Public enum to represent colors
        {
            Red,
            Green,
            Blue
        }
        
        public enum Size                        // Public enum to represent sizes
        {
            Small,
            Medium,
            Large,
            Yuge
        }
        public class Product                     // Public nested class to represent a product
        {
            
            internal string Name;               // Private field to store the product name
            
            internal Color Color;               // Private field to store the product color
            
            internal Size Size;                     // Internal field to store the product size

            
            public Product(string name, Color color, Size size)     // Public constructor to create a new product
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

        
        public class ProductFilter : IFilter<Journal.Product>   // Public nested class to filter products
        {
            
            public IEnumerable<Journal.Product> Filter(IEnumerable<Journal.Product> products, ISpecification<Journal.Product> spec) // Public method to filter products by the Specifications on Interface: ISpecification
            {
                foreach (var product in products)
                {
                    if (spec.IsSatisfied(product))
                    {
                        yield return product;
                    }
                }
            }

            public IEnumerable<Product> FilterByColor(Product[] products, Color color)
            {
                foreach (var product in products)
                {
                    if (product.Color == color)
                    {
                        yield return product;
                    }
                }
            }
        }

        
        private readonly List<string> entries = new List<string>();            // Private field to store journal entries

        
        private static int count = 0;                           // Private static field to keep track of the entry count

        
        public int AddEntry(string text)                    // Public method to add a new entry to the journal
        {
            entries.Add($"{++count}:{text}");
            return count; // memento
        }

        
        public void RemoveEntry(int index)              // Public method to remove an entry from the journal
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

        
        public override string ToString()                    // Public override method
                                                            // to return a string representation of the journal
        {
            return string.Join(Environment.NewLine, entries);
        }

        
        public void Load(Uri uri)                 // Public method to load journal entries from a URI (not implemented)
        {
            
            throw new NotImplementedException();         // Implement loading journal entries from the specified URI
        }
    }

    
    public class Persistence                        // Public method to save
                                                    // the journal to a file
                                                    // Class to handle persistence of the journal
    
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

    
    public class Demo                            // Class to demonstrate the usage
                                                 // of the Journal and Persistence classes
    { 
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            WriteLine(j);

            var p = new Persistence();
            
            var filename =
                @"C:\Users\Student\Documents\working-directory\cSharp-SQL\cSharp---sql\Rider\DesignPattern\DesignPatternJournal.md";
            p.SaveToFile(j, filename, true);
            
            Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });

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