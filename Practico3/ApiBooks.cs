namespace Practico3
{
    public class ApiBooks
    {
        public string getLibros (string texto, string key)
        {
            UriBuilder builder = new UriBuilder("https://www.googleapis.com/books/v1/volumes");
            builder.Query = $"?key={key}&q={texto}";

            //Create a query
            HttpClient Client = new HttpClient();
            var result = Client.GetAsync(builder.Uri).Result;

            using (StreamReader sr = new StreamReader(result.Content.ReadAsStreamAsync().Result)) { 
            
                return sr.ReadToEnd();
            }
        }
    }
}