using System;
using System.Collections.Generic;


namespace CSV_to_SQL
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            // 1 - we read the properties
            Properties properties = ReaderWriter.ReadProperties();

            // 2 - we read the CSV
            List<Dictionary<String, String>> dictionaries = ReaderWriter.ReadCSV();

            // 3 - we write the SQL
            await ReaderWriter.WriteSQLAsync(properties, dictionaries);
        }
    }
}
