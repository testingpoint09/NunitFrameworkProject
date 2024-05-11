using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FrameworkPractice.Utilities
{
    public  class JsonReader
    {

        public string extractData(String tokenName)
        {

            String myJsonString = File.ReadAllText("C://Users//ADMIN//source//repos//TestingPoint//NunitFrameworkProject//FrameworkPractice//Utilities//testData.json");

            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();


        }
    }
}
