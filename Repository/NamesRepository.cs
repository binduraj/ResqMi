using System;
using System.Collections.Generic;
using System.Linq;
using PCLItems.Core.Model;

namespace PCLItems.Core.Repository
{
    public class NamesRepository
    {
        public NamesRepository()
        {
        }

        public List<Names> GetAllNames()
        {
            IEnumerable<Names> namelist =
                from NameGroup in NameGroups
                from name in NameGroup.Names
                select name;

            return namelist.ToList();
        }


        public Names GetNameById(int Id)
        {
            IEnumerable<Names> namelist =
                from NameGroup in NameGroups
                from name in NameGroup.Names
                select name;
            return namelist.FirstOrDefault();
        }

        public List<NameGroup> GetGroupedNames()
        {
            return NameGroups;
        }

        public List<Names> GetNamesForGroup(int groupId)
        {
            var group = NameGroups.Where(h => h.GroupId == groupId)
                                  .FirstOrDefault();
            if (group == null)
            {
                return group.Names;
            }
            return null;
        }

        public List<Names> GetFavoriteNames()
        {
            IEnumerable<Names> names =
                from NameGroup in NameGroups
                from name in NameGroup.Names
                where name.isFavorite
                select name;
            return names.ToList<Names>();
        }

        private static List<NameGroup> NameGroups = new List<NameGroup>()
        {
            new NameGroup()
            {
                GroupId = 1, Title = "Group 1", ImagePath = "",
                Names = new List<Names>()
                {
                    new Names()
                    {
                        Id = 1,
                        Name = "Name 1",
                        ImagePath = "Image1",
                        available = true,
                        Description = "Test Description",
                        ShortDescription = "Short Description",
                        Ingredients = new List<string>(){
                            "Extra Long Bun", "Sausage"
                        },
                        isFavorite = true,
                        preptime = 10,
                        price = 8
                                           
                    },

					new Names()
                    {
                        Id = 2,
                        Name = "Name 2",
                        ImagePath = "Image2",
                        available = true,
                        Description = "Test 2 Description",
                        ShortDescription = "Short 2 Description",
                        Ingredients = new List<string>(){
                            "Extra Long Bun 2", "Sausage 2"
                        },
                        isFavorite = false,
						preptime = 10,
						price = 8

					},
                }
            },

			new NameGroup()
			{
				GroupId = 2, Title = "Group 2", ImagePath = "",
				Names = new List<Names>()
				{
					new Names()
					{
						Id = 3,
						Name = "Name 3",
						ImagePath = "Image3",
						available = true,
						Description = "Test 3 Description",
						ShortDescription = "Short 3 Description",
						Ingredients = new List<string>(){
							"Extra Long Bun 3", "Sausage 3"
						},
						isFavorite = true,
						preptime = 10,
						price = 8

					},

					new Names()
					{
						Id = 4,
						Name = "Name 4",
						ImagePath = "Image4",
						available = true,
						Description = "Test 4 Description",
						ShortDescription = "Short 4 Description",
						Ingredients = new List<string>(){
							"Extra Long Bun 4", "Sausage 4"
						},
						isFavorite = false,
						preptime = 10,
						price = 8

					},
				}
			}
        };
    }
}
