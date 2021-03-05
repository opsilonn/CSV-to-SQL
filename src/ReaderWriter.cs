using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

namespace CSV_to_SQL
{
    static class ReaderWriter
    {
        private static string PATH_CONFIG = @"../../../config/config.json";

        private static string PATH_CSV = @"../../../config/data.csv";

        private static string PATH_SQL = @"../../../config/data.sql";


        /**
         * Reads the properties from the config file 
         * <returns>A Properties object</returns>
         */
        public static Properties ReadProperties()
        {
            // We check if the config file exists
            if (!File.Exists(PATH_CONFIG))
            {
                // We display an error message
                CONSOLE.WriteLine(ConsoleColor.Red, "ERROR : the config.json file could not be found !");

                // We end the program
                System.Environment.Exit(0);
            }

            // We read the json
            string json = System.IO.File.ReadAllText(PATH_CONFIG);

            // We deserialize the properties
            Properties properties = Properties.Deserialize(json);

            // We return the properties
            return properties;
        }



        /**
         * Reads the CSV file 
         * <returns>A list of dictionaries containing all the CSV data</returns>
         */
        public static List<Dictionary<String, String>> ReadCSV()
        {
            // We check if the config file exists
            if (!File.Exists(PATH_CSV))
            {
                // We display an error message
                CONSOLE.WriteLine(ConsoleColor.Red, "ERROR : the data.csv file could not be found !");

                // We end the program
                System.Environment.Exit(0);
            }


            // We initialize the list of strings
            List<string> lines = System.IO.File.ReadAllLines(PATH_CSV).ToList();

            // We get the headers
            string[] headers = lines[0].Split(',');

            // We remove the header
            lines.RemoveAt(0);

            // We initialize a dictionary
            List<Dictionary<String, String>> dictionaries = new List<Dictionary<String, String>>();
            int cpt = 0;

            // We iterate through the CSV file
            lines.ForEach(line =>
            {
                // We get the content
                string[] content = line.Split(',');

                // We add an item to the list
                dictionaries.Add(new Dictionary<string, string>());

                // We iterate through the content
                for (int i = 0; i < headers.Length; i++)
                {
                    // We add it to the dictionary
                    dictionaries[cpt].Add(headers[i], content[i]);
                }

                // We increment the counter
                cpt++;
            });

            // We return the dictionaries
            return dictionaries;
        }



        /**
         * Write the SQL file
         */
        public static async System.Threading.Tasks.Task WriteSQLAsync(Properties properties, List<Dictionary<String, String>> dictionaries)
        {
            // We initialize a list of lines to write
            List<string> lines = new List<string>();

            // We initialize the first line
            string header = String.Format("INSERT INTO {0} (", properties.tableName.ToUpper());

            // We add all the fields
            for (int i = 0; i < properties.fields.Count; i++)
            {
                // We add the field
                header += properties.fields[i].nameInSQL;

                // If not the last, we add a coma ','
                if (i != properties.fields.Count - 1)
                {
                    header += ", ";
                }
            }

            // We end the header
            header += ") VALUES";

            // We add the header line
            lines.Add(header);

            // For each line to add
            dictionaries.ForEach(dictionary =>
            {
                // We declare a line with the id
                string line = "(";

                // We fill the line
                properties.fields.ForEach(field =>
                {
                    // We get the value to write : the one found, or if empty, the default one 
                    string value = (dictionary[field.nameInCSV].Length != 0) ? dictionary[field.nameInCSV] : field.defaultValue;

                    // We duplicate each character : '
                    // So that the code won't crash
                    value = value.Replace("'", "''");

                    // We add the field
                    if (field.isText)
                    {
                        line += "'" + value + "'";
                    }
                    else
                    {
                        line += value;
                    }

                    // If the field is not the last, we add a ','
                    if (field != properties.fields.Last())
                    {
                        line += ",";
                    }
                });

                // We end the line (';' if last, ',' otherwise)
                line += (dictionary == dictionaries.Last()) ? ");" : "),";

                // We add the line
                lines.Add(line);
            });

            // We write the SQL file
            await File.WriteAllLinesAsync(PATH_SQL, lines.ToArray());
        }
    }
}
