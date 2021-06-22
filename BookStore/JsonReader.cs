using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace BookStore
{
    class JsonReader : IReader<Book>
    {
        private readonly string[] nestedKeys;
        private readonly ISourceReader reader;

        public JsonReader(ISourceReader reader, string[] nestedKeys)
        {
            this.reader = reader;
            this.nestedKeys = nestedKeys;
        }

        public List<Book> Read()
        {
            string jsonString = reader.ReadAllData();
            if (jsonString == null)
            {
                Console.WriteLine("Json reader was unable to get json string");
                return null;
            }
            jsonString = FindNestedString(jsonString, 0);
            if (jsonString == null)
            {
                return null;
            }

            List<Book> result = new List<Book>();
            JArray jsonArray = null;
            try
            {
                jsonArray = JArray.Parse(jsonString);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Problem in json array parsing: " + ex);
            }

            if (jsonArray != null)
            {
                IEnumerator<JToken> enumerator = jsonArray.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    try
                    {
                        result.Add(enumerator.Current.ToObject<Book>());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Problem in json object parsing: " + ex);
                    }
                }
            }
            //result = JsonConvert.DeserializeObject<List<Book>>(jsonString);

            return result;
        }

        private string FindNestedString(string jsonString, int nestedIndex)
        {
            if(nestedKeys == null || nestedKeys.Length == 0 || nestedIndex < 0 || nestedIndex >= nestedKeys.Length)
            {
                return jsonString;
            }

            try
            {
                JObject jsonObject = JObject.Parse(jsonString);
                JToken jsonToken = jsonObject.SelectToken(nestedKeys[nestedIndex]);
                string currentJsonString = jsonToken.ToString();
                return FindNestedString(currentJsonString, nestedIndex + 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem in json parsing: " + ex);
            }
            return null;
        }
    }
}
