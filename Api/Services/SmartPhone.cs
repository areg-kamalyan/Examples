using Api.Models;
using System.IO;
using System.Numerics;
using System.Text.Json;

namespace Api.Services
{
    public class SmartPhone: ISmartPhone
    {
        private HttpClient client;

        public SmartPhone(HttpClient _client)
        {
            client = _client;
            client.BaseAddress = new Uri("https://api.restful-api.dev");
        }


        public async Task<List<Phone>?> ListOFAllObjects()
        {
            HttpResponseMessage response = await client.GetAsync("/objects");
            return await GetData<List<Phone>?>(response);
        }

        public async Task<List<Phone>?> ListOfObjectsByIds(IEnumerable<string> Ids)
        {
            string url = "objects" + BuildUrlWithIds(Ids);
            HttpResponseMessage response = await client.GetAsync(url);
            return await GetData<List<Phone>?>(response);
        }

        public async Task<Phone?> SingleObject(string Id)
        {
            string url = $"objects/{Id}";
            HttpResponseMessage response = await client.GetAsync(url);
            return await GetData<Phone?>(response);

        }
        public async Task<Phone?> AddObject(Phone phone)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/objects", phone, new JsonSerializerOptions { WriteIndented = true });

            return await GetData<Phone?>(response);
        }
        public async Task<Phone?> UpdateObject(Phone phone)
        {
            string url = "objects/" + phone.Id;
            HttpResponseMessage response = await client.PutAsJsonAsync(url, phone, new JsonSerializerOptions { WriteIndented = true });
            return await GetData<Phone?>(response);
        }

        public async Task<Dictionary<string, string>?> DeleteObject(string Id)
        {
            string url = "objects/" + Id;
            HttpResponseMessage response = await client.DeleteAsync(url);
            return await GetData<Dictionary<string, string>>(response);
        }

        private async Task<T?> GetData<T>(HttpResponseMessage response) where T : class?
        {
            var Data = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            return null;
        }

        private string BuildUrlWithIds(IEnumerable<string> ids)
        {
            // Build the query string for the IDs
            var query = new List<string>();
            foreach (var id in ids)
            {
                query.Add($"id={id}");
            }

            // Join all query parameters with '&'
            string queryString = string.Join("&", query);

            // Combine base URL with query string
            return $"?{queryString}";
        }
    }
}
