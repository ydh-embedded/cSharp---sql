using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            private string Name;

            // Private field to store the product color
            private Color Color;

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
        public class ProductFilter
        {
            // Public static method to filter products by size
            public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
            {
                foreach (var vProduct in products)
                    if (vProduct.Size == size)
                        yield return vProduct;
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
    public class Persistence
    {
        // Public method to save the journal to a file
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
        // Static method to run the demo
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            WriteLine(j);

            var p = new Persistence();
            var filename = @"c:\temp\journal.txt";
            p.SaveToFile(j, filename, true);
            Process.Start(filename);
        }
    }
}