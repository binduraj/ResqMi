using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PCLItems.Core.Model;

namespace PCLItems.Core.Repository
{
    public class ShelterRestService : IRestService
    {
        HttpClient client;
		List<ServiceModel> shelters = new List<ServiceModel>();

        public ShelterRestService()
        {

			//var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
			//var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

			client = new HttpClient();

			var RestUrl = @"https://jsonplaceholder.typicode.com/posts?userId=1";

            Task.Run(() => this.LoadDataAsync(RestUrl)).Wait();
			//client.MaxResponseContentBufferSize = 256000;
			//client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public Task DeleteTodoItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ServiceModel>> RefreshDataAsync()
        {
            return shelters;
        }

        private async Task LoadDataAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                var responseString = await response.Content.ReadAsStringAsync();

                shelters = JsonConvert.DeserializeObject<List<ServiceModel>>(responseString);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public Task SaveTodoItemAsync(ServiceModel item, bool isNewItem)
        {
            throw new NotImplementedException();
        }
    }
}
