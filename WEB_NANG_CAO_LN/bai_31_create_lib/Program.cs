using Newtonsoft.Json;
namespace bai_31_create_lib
{
    /*
     *  dotnet add package packageName -- version xxx
     */
    public class Product
    {
        public string Name { get; set; }
        public DateTime Expiry { get; set; }
        public string[] Sizes { get; set; }
    }
    public class Movie
    {
        public string Name { set; get; }
        public DateTime ReleaseDate { get; set; }
        public string[] Genres { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            product.Name = "Apple";
            product.Expiry = new DateTime(2008, 12, 28);
            product.Sizes = new string[] { "Small" };


            // sử dụng giá trị của đôi tượng để tạo ra json 
           // string json = JsonConvert.SerializeObject(product);
            // {
            //   "Name": "Apple",
            //   "Expiry": "2008-12-28T00:00:00",
            //   "Sizes": [
            //     "Small"
            //   ]
            // }
           // Console.WriteLine(json);

            // sử dụng json để gán lại giá trị cho tôi đượng 
            string json = @"{
              'Name': 'Bad Boys',
              'ReleaseDate': '1995-4-7T00:00:00',
              'Genres': [
                'Action',
                'Comedy'
              ]
            }";

            Movie m = JsonConvert.DeserializeObject<Movie>(json);

            string name = m.Name;
            Console.WriteLine(name);
            Console.WriteLine(" For product ");

        }
    }
}
