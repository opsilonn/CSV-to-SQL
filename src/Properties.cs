using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace CSV_to_SQL
{
    public class Properties
    {
        // FIELDS
        private string _tableName;
        private List<Field> _fields;


        // CONSTRUCTORS

        /// <summary>
        /// Creates a default instance of Properties
        /// </summary>
        public Properties()
        {
            tableName = "";
            fields = new List<Field>();
        }


        /// <summary>
        /// Creates a new instance of Properties with according parameters
        /// </summary>
        /// <param name="tableName">Name of the table to fill</param>
        /// <param name="fields">Fields of the table</param>
        public Properties(string tableName, List<Field> fields)
        {
            this.tableName = tableName;
            this.fields = fields;
        }


        // SERIALIZATION

        /// <summary>
        /// Return a JSON string representing the instance
        /// </summary>
        /// <returns>A JSON string representing the instance</returns>
        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }


        /// <summary>
        /// Returns a Properties instance from a JSON string
        /// </summary>
        /// <param name="json">String containing the instance data (from a JSON syntax)</param>
        /// <returns>A Properties instance from a JSON string</returns>
        public static Properties Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<Properties>(json);
        }


        // GETTER - SETTER
        public string tableName { get => _tableName; set => _tableName = value; }
        public List<Field> fields { get => _fields; set => _fields = value; }



        public class Field
        {
            // FIELDS
            private string _nameInCSV;
            private string _nameInSQL;
            private bool _isText;
            private string _defaultValue;

            // CONSTRUCTORS

            /// <summary>
            /// Creates a default instance of Field
            /// </summary>
            public Field()
            {
                nameInCSV = "";
                nameInSQL = "";
                isText = true;
                defaultValue = "";
            }


            /// <summary>
            /// Creates a new instance of Field with according parameters
            /// </summary>
            /// <param name="nameInCSV">Name of the field in the CSV input file</param>
            /// <param name="nameInSQL">Name of the field in the SQL output file</param>
            /// <param name="isText">Whether the row is text or a number</param>
            /// <param name="defaultValue">Default value of the row</param>
            public Field(string nameInCSV, string nameInSQL, bool isText, string defaultValue)
            {
                this.nameInCSV = nameInCSV;
                this.nameInSQL = nameInSQL;
                this.isText = isText;
                this.defaultValue = defaultValue;
            }


            // SERIALIZATION

            /// <summary>
            /// Return a JSON string representing the instance
            /// </summary>
            /// <returns>A JSON string representing the instance</returns>
            public string Serialize()
            {
                return JsonConvert.SerializeObject(this, Formatting.Indented);
            }


            /// <summary>
            /// Returns a Field instance from a JSON string
            /// </summary>
            /// <param name="json">String containing the instance data (from a JSON syntax)</param>
            /// <returns>A Properties instance from a JSON string</returns>
            public static Field Deserialize(string json)
            {
                return JsonConvert.DeserializeObject<Field>(json);
            }


            // GETTER - SETTER
            public string nameInCSV { get => _nameInCSV; set => _nameInCSV = value; }
            public string nameInSQL { get => _nameInSQL; set => _nameInSQL = value; }
            public bool isText { get => _isText; set => _isText = value; }
            public string defaultValue { get => _defaultValue; set => _defaultValue = value; }
        }
    }
}
