using System;
using System.Collections.Generic;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public class InformationBoardViewModel : IInformationBoardViewModel
    {
        private DbService _dbService;

        public InformationBoardViewModel(DbService dbService, int informationBoardId)
        {
            Categories = new();
            _dbService = dbService;
            GetInformationBoardData(informationBoardId);
            GetCategories(informationBoardId);
        }

        public InformationBoardViewModel()
        {
        }

        public InformationBoard InformationBoardModel { get; set; }

        public List<ICategoryViewModel> Categories { get; set; }

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