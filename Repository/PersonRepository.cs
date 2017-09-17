using System;
using System.Collections.Generic;
using System.Linq;
using PCLItems.Core.Model;

namespace PCLItems.Core.Repository
{
    public class PersonRepository
    {
        public PersonRepository()
        {
        }

		public List<Person> GetAllNames()
        {

			return persons.ToList();
		}


		public Person GetNameById(int Id)
		{
			return persons.FirstOrDefault();
		}



        private static List<Person> persons = new List<Person>()
        {

                    new Person()
                    {
                        Id = 1,
                        Name = "Binduraj Chandrasekaran",
                        PhoneNumber = "1 925 699-3334",
                        latitude = 37.778177,
                        longitude = -122.392287

                    },

                    new Person()
                    {
                        Id = 2,
                         Name = "Sathish Kumar Natarajan",
                        PhoneNumber = "1 415 513-2416",
                        latitude = 37.774611,
                        longitude = -122.389573
                    },


                    new Person()
                    {
                        Id = 3,
                        Name = "Murugavel Sambandan",

                        PhoneNumber = "1 510 445-5555",
                        latitude = 37.774475,
                        longitude = -122.391032
                    },

                    new Person()
                    {
                        Id = 4,
                        Name = "Manikandan Subramiam",
                        PhoneNumber = "1 408 604-1321",
                        latitude = 37.774458,
                longitude = -122.391470
                    },


                    new Person()
                    {
                        Id = 5,
                        Name = "Suriya Shankar",
                        PhoneNumber = "1 315 256-1321",
                        latitude = 37.777257,
                        longitude = -122.391061
                       

                    },

					new Person()
					{
						Id = 6,
						Name = "Victim 6",
                        PhoneNumber = "1 208 324-5555",
										latitude = 37.775257,
						longitude = -122.391161
					}
        };
    }
}
