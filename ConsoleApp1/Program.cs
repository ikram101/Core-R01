using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            string schemaJson = @"{
                              'description': 'A person',
                              'type': 'object',
                              'properties':
                              {
                                'name': {'type':'string'},
                                'hobbies': {
                                  'type': 'array',
                                  'items': {'type':'string'}
                                }
                              }
                            }";

            bool check = IsValidJson(schemaJson);

            int ddd = 2022;

            Console.ReadLine();
        }




        public static bool IsValidJson(string stringValue)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return false;
            }

            var value = stringValue.Trim();

            if ((value.StartsWith("{") && value.EndsWith("}")) || //For object
                (value.StartsWith("[") && value.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(value);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
            }

            return false;
        }
    }

}
