
#Link https://www.sqlitetutorial.net/sqlite-primary-key/


______________


- creat for two or more Coloumns
-

```sql
	CREATE TABLE db_Database(
	   constance_1 INTEGER NOT NULL,
	   constance_2 INTEGER NOT NULL,
	PRIMARY KEY(constance_1,constance_2)
	);
```

.

**Open SQLite**:

Open a terminal and run SQLite with your database name:

```bash
	sqlite3 db_Database.db
```
.

**Create Table with Primary Key**:

You can create a table with a primary key using the `CREATE TABLE` statement. Here's an example where `id` is the primary key:

```sql
	CREATE TABLE users (
    id INTEGER PRIMARY KEY,
    name TEXT NOT NULL,
    email TEXT UNIQUE NOT NULL
	);
```
.

1. In this example:
    
    - `id` is the primary key, automatically incremented by SQLite when you insert new records because it's defined as `INTEGER PRIMARY KEY`.
    - `name` and `email` are other fields with their respective constraints.
2. **Verify the Table**:
    
    To verify that the table has been created as expected, you can use the `.schema` command followed by the table name:

```sql
	.schema users
```
.
1. This will display the SQL statement used to create the table, showing the primary key and other constraints.
    
2. **Insert Data**:
    
    To test the primary key auto-increment, insert some data:


```sql
	INSERT INTO users (name, email) VALUES ('John Doe', 'john@example.com');
	INSERT INTO users (name, email) VALUES ('Jane Doe', 'jane@example.com');
```
.

Then, query the table to see the auto-incremented `id` values:

```sql
	SELECT * FROM users;
```

**Exit SQLite**:

When you're done, you can exit SQLite by typing:

```sql
	.quit
```

This guide should help you create a table with a primary key in SQLite on Rocky Linux 9. Remember, when you define a column as `INTEGER PRIMARY KEY`, SQLite automatically increments it for new rows if you don't specify a value for that column during insertion.