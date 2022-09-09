using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class HttpClientService<T> where T : class, IEntity
{
    public async Task<List<T>> GetAllAsync(string controller)
    {
        try
        {
            var client = new HttpClient();
            var result = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string stringResult = await result.Content.ReadAsStringAsync();
                List<T> jsonString = JsonSerializer.Deserialize<List<T>>(stringResult);
                return jsonString;
            }
            else
            {
                throw new NotFoundException("Didn't find result");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
    public async Task<T> GetAsync(string controller, int id)
    {
        HttpClient client = new HttpClient();
        var result = await client.GetAsync($"{Constants.base_url}/{controller}/{id}");
        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string stringResult = await result.Content.ReadAsStringAsync();
            T jsonString = JsonSerializer.Deserialize<T>(stringResult);
            return jsonString;
        }
        else
        {
            throw new NotFoundException("Didn't find result by given id");
        }

    }
}

