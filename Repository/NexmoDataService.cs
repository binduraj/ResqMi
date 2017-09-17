using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PCLItems.Core.Repository
{
    public class NexmoDataService
    {

		HttpClient client;
        public NexmoDataService()
        {

			client = new HttpClient();

        }

        public void SMS(string to, string from)
        {
			var RestUrl = @"https://rest.nexmo.com/sms/json?api_key=579413a5&api_secret=424fc17619fb167a&to=" +
	        to + "&from=" + from + "&text=Please Help";

			Task.Run(() => this.LoadDataAsync(RestUrl)).Wait();
        }

		public void VoiceCall(string to, string from)
		{
			var RestUrl = @"https://rest.nexmo.com/v1/calls?api_key=579413a5&api_secret=424fc17619fb167a&to=" +
			to + "&from=" + from;

			Task.Run(() => this.LoadDataAsync(RestUrl)).Wait();
		}

		private async Task LoadDataAsync(string url)
		{
			try
			{
				HttpResponseMessage response = await client.GetAsync(url);
				var responseString = await response.Content.ReadAsStringAsync();

			}
			catch (Exception ex)
			{
				string message = ex.Message;
			}
		}
    }
}
