# SQL 

________________________________________________________________

Here are the tasks of each method:

**Journal Class**

1. `AddEntry(string text)`:
    - Task: Adds a new entry to the journal with a unique identifier (incrementing count) and returns the count.
    - Description: This method takes a string parameter `text` and adds it to the `entries` list with a prefix of the current count (e.g., "1: I cried today"). It then increments the count and returns it.
2. `RemoveEntry(int index)`:
    - Task: Removes an entry from the journal at the specified index.
    - Description: This method takes an integer parameter `index` and removes the entry at that index from the `entries` list. It checks if the index is within the valid range before removing the entry.
3. `ToString()`:
    - Task: Returns a string representation of the journal entries.
    - Description: This method overrides the default `ToString()` method and returns a string representation of the journal entries, separated by newline characters.
4. `Load(Uri uri)`:
    - Task: Loads journal entries from a specified URI (not implemented).
    - Description: This method is not implemented and is intended to load journal entries from a specified URI.

**Persistence Class**

1. `SaveToFile(Journal j, string filename, bool overwrite = false)`:
    - Task: Saves the journal entries to a file.
    - Description: This method takes a `Journal` object `j`, a `filename` string, and an optional `overwrite` boolean parameter. It saves the journal entries to the specified file, overwriting it if `overwrite` is true.

**Demo Class**

1. `Main(string[] args)`:
    - Task: Demonstrates the usage of the Journal and Persistence classes.
    - Description: This method creates a `Journal` object, adds some entries, saves the journal to a file using the `Persistence` class, and then opens the file using the `Process.Start` method.