using System;
using System.Collections.Generic;
using System.Linq;
using ManagementPages.Model;

namespace ManagementPages.Functions
{
    public class InformationBoardViewModel : IInformationBoardViewModel
    {
        private DbService _dbService;
        private ICategoryViewModel _selectedCategory;

        public InformationBoardViewModel(DbService dbService, int informationBoardId)
        {
            _dbService = dbService;
            GetInformationBoardData(informationBoardId);
            GetCategories(informationBoardId);
        }

        public InformationBoardViewModel()
        {
        }

        public InformationBoard InformationBoardModel { get; set; }

        public List<ICategoryViewModel> Categories { get; set; } = new();

        public void GetInformationBoardData(int informationBoardId)
        {
            throw new NotImplementedException();
        }

        public void GetCategories(int informationBoardId)
        {
            throw new NotImplementedException();
        }

        public ICategoryViewModel SelectedCategory
        {
            get => _selectedCategory ?? Categories.FirstOrDefault();
            set => _selectedCategory = value;
        }
    }
}