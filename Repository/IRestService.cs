using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PCLItems.Core.Model;

namespace PCLItems.Core.Repository
{

        public interface IRestService
        {
            Task<List<ServiceModel>> RefreshDataAsync();

		    Task SaveTodoItemAsync(ServiceModel item, bool isNewItem);

		    Task DeleteTodoItemAsync(string id);
        }
 
}
