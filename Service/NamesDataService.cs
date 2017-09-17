using System;
using System.Collections.Generic;
using PCLItems.Core.Model;
using PCLItems.Core.Repository;

namespace PCLItems.Core.Service
{
    public class NamesDataService
    {
        public static NamesRepository namesRepository = new NamesRepository();
        public NamesDataService()
        {
        }

        public List<Names> GetAllNames()
        {
            return namesRepository.GetAllNames();
        }

        public List<NameGroup> GetGroupedNames()
        {
            return namesRepository.GetGroupedNames();
        }

        public List<Names> GetNamesForGroup(int groupId)
        {
            return namesRepository.GetNamesForGroup(groupId);
        }

        public Names GetNameById(int Id)
        {
            return namesRepository.GetNameById(Id);
        }
    }
}
