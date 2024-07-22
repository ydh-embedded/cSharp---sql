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
                if (overwrite ||!File.Exists(filename))
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