using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PCLItems.Core.Model;
using PCLItems.Core.Repository;

namespace PCLItems.Core.Service
{

    public class RestDataService
    {
		IRestService restService;

        public RestDataService(IRestService service)
        {
            restService = service;
        }

		public Task<List<ServiceModel>> GetTasksAsync()
		{
			return restService.RefreshDataAsync();
		}

		public Task SaveTaskAsync(ServiceModel item, bool isNewItem = false)
		{
			return restService.SaveTodoItemAsync(item, isNewItem);
		}

		public Task DeleteTaskAsync(ServiceModel item)
		{
			return restService.DeleteTodoItemAsync(item.userId);
		}
    }
}
