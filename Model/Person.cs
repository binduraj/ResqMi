using System;
namespace PCLItems.Core.Model
{
    public class Person
    {
        public Person()
        {
        }

		public int Id { get; set; }
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
