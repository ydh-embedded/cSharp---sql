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
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}:{text}");
            return count; // memento
        }

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

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        public void Load(Uri uri)
        {
            // Implement loading journal entries from the specified URI
            throw new NotImplementedException();
        }
    }
    public class Persistence
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

    public class Demo
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            WriteLine(j);

            var p = new Persistence();
            var filename = @"C:\Users\Student\Documents\working-directory\cSharp-SQL\cSharp---sql\Rider\DesignPattern\DesignPatternJournal.md";
            
            p.SaveToFile(j, filename, true);
            Process.Start(filename);
        }
    }
}