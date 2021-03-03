# CSV to SQL

## What's my purpose ?

This is a fairly simple projectthat takes a CSV input file, and produces a SQL output file given some indications.


## How do I configure it ?

The project works with little configuration :

```
Everything happens in the 'config' folder !

First, take your CSV file so that is located and named after :
config/data.csv

Second, give your indication in the config/config.json file :
- 'tableName' is the name of the SQL table to create;
- 'fields' contains all the fields of the table, with each being as follow :
  - 'nameInCSV' : name of the row in the CSV input file;
  - 'nameInSQL' : name of the row in the SQL output file;
  - 'isText' : whether the row is text (char, string, date) or not (number, boolean);
  - 'defaultValue' : Default value of the row;

The output SQL file can be found under :
config/data.sql
```


## Authors

It was made by the following author(s) :
* **BEGEOT Hugues** - [his Git repository](https://github.com/opsilonn)

See also the list of [contributors](https://github.com/opsilonn/CSV-to-SQL/graphs/contributors) who participated in this project.
