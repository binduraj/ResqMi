using System;
using System.Collections.Generic;
using PCLItems.Core.Model;
using PCLItems.Core.Repository;

namespace PCLItems.Core.Service
{
    public class PersonDataService
    {
        public PersonDataService()
        {
        }

		public static PersonRepository namesRepository = new PersonRepository();

		public List<Person> GetAllPerson()
		{
			return namesRepository.GetAllNames();
		}
    }
}
