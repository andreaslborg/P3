using System;
using System.Collections.Generic;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public class InformationBoardViewModel : IInformationBoardViewModel
    {
        private DbService _dbService;

        public List<ICategoryViewModel> Categories = new();

        public InformationBoardViewModel(DbService dbService, int informationBoardId)
        {
            _dbService = dbService;
            GetInformationBoardData(informationBoardId);
            GetCategories(informationBoardId);
        }

        public InformationBoard InformationBoardModel { get; set; }

        public void GetInformationBoardData(int informationBoardId)
        {
            throw new NotImplementedException();
        }

        public void GetCategories(int informationBoardId)
        {
            throw new NotImplementedException();
        }
    }
}