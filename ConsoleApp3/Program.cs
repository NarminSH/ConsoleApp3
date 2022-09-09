using System;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("dsa");
            GetRequest();
        }

        public static async Task GetRequest()
        {
            try
            {
                HttpClientService<Post> newPost = new HttpClientService<Post>();
                var result = await newPost.GetAllAsync("posts");
                foreach (var item in result)
                {
                    Console.WriteLine(item.Title);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
