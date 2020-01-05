using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;

namespace Fetch_API_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            GetPokemon();
            GetOnePokemon(1);

            Console.ReadLine();
            Console.ReadKey();
            //ConsoleReadKey_Test.TestReadKey();
        }

        #region GetPokemon method
        public static async void GetPokemon()
        {
            //Define your baseUrl
            string baseUrl = "http://pokeapi.co/api/v2/pokemon/";

            try
            {
                //We will now define your HttpClient with your first using statement which will implements a IDisposable interface.
                using (HttpClient client = new HttpClient())
                {
                    //In the next using statement you will initiate the Get Request, use the await keyword so it will execute the using statement in order.
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        //Then get the content from the response in the next using statement, then within it you will get the data, and convert it to a c# object.
                        using (HttpContent content = res.Content)
                        {
                            //Now assign your content to your data variable, by converting into a string using the await keyword.
                            var data = await content.ReadAsStringAsync();
                            //If the data isn't null return log convert the data using newtonsoft JObject Parse class method on the data.
                            if (content != null)
                            {
                                Console.WriteLine("data------------{0}", JObject.Parse(data)["results"]);
                            }
                            else
                            {
                                Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
            }
        }
        #endregion


        #region GetOnePokemon method
        public static async void GetOnePokemon(int pokeId)
        {
            //Define your base url
            string baseURL = $"http://pokeapi.co/api/v2/pokemon/{pokeId}/";
            try
            {
                //Now we will have our using directives which would have a HttpClient 
                using (HttpClient client = new HttpClient())
                {
                    //Now get your response from the client from get request to baseurl.
                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {
                        //Now we will retrieve content from our response, which would be HttpContent, retrieve from the response Content property.
                        using (HttpContent content = res.Content)
                        {
                            //Retrieve the data from the content of the response, have the await keyword since it is asynchronous.
                            string data = await content.ReadAsStringAsync();

                            if (data != null)
                            {
                                //Parse your data into a object.
                                var dataObj = JObject.Parse(data);
                                //Then create a new instance of PokeItem, and string interpolate your name property to your JSON object.
                                //Which will convert it to a string, since each property value is a instance of JToken.
                                PokeItem pokeItem = new PokeItem(name: $"{dataObj["name"]}");
                                Console.WriteLine("Pokemon Name: {0}", pokeItem.Name);
                            }
                            else
                            {
                                Console.WriteLine("Data is null!");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
        #endregion

    }
}
