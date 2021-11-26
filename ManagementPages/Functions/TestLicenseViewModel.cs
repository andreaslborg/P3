using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ManagementPages.Model;
using License = ManagementPages.Model.License;

namespace ManagementPages.Functions
{
    public class TestLicenseViewModel : ILicenseViewModel
    {
        private IInformationBoardViewModel _selectedInformationBoard;

        public TestLicenseViewModel(int licenseId)
        {
            InformationBoards = new List<IInformationBoardViewModel>();
            GetLicenseData(licenseId);
            GetInformationBoards(licenseId);
        }

        private string LoremIpsum { get; } =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce quis lectus quis sem lacinia nonummy. Proin mollis lorem non dolor. In hac habitasse platea dictumst. Nulla ultrices odio. Donec augue. Phasellus dui. Maecenas facilisis nisl vitae nibh. Proin vel seo est vitae eros pretium dignissim. Aliquam aliquam sodales orci. Suspendisse potenti. Nunc adipiscing euismod arcu. Quisque facilisis mattis lacus. Fusce bibendum, velit in venenatis viverra, tellus ligula dignissim felis, quis euismod mauris tellus ut urna. Proin scelerisque. Nulla in mi. Integer ac leo. Nunc urna ligula, gravida a, pretium vitae, bibendum nec, ante. Aliquam ullamcorper iaculis lectus. Sed vel dui. Etiam lacinia risus vitae lacus. Aliquam elementum imperdiet turpis. In id metus. Mauris eu nisl. Nam pharetra nisi nec enim. Nulla aliquam, tellus sed laoreet blandit, eros urna vehicula lectus, et vulputate mauris arcu ut arcu. Praesent eros metus lirum larum, accumsan a, malesuada et, commodo vel, nulla. Aliquam sagittis auctor sapien. Morbi a nibh.";

        public License LicenseModel { get; set; } = new License();


        public List<IInformationBoardViewModel> InformationBoards { get; }


        public IInformationBoardViewModel SelectedInformationBoard
        {
            get => _selectedInformationBoard ?? InformationBoards.FirstOrDefault();
            set => _selectedInformationBoard = value;
        }

        public void GetLicenseData(int licenseId)
        {
            LicenseModel.RegistrationDate = new DateTime(2021, 01, 11);
            LicenseModel.LicenseId = 123;
        }

        public void GetInformationBoards(int licenseId)
        {
            var post1 = new PostViewModel
            {
                PostModel = new Post
                {
                    Author = "John",
                    ExpirationDate = new DateTime(2022, 01, 01),
                    IsPublished = true,
                    Text = LoremIpsum,
                    Title = "Post 1"
                }
            };

            var post2 = new PostViewModel
            {
                PostModel = new Post
                {
                    Author = "Hanne",
                    ExpirationDate = new DateTime(2022, 01, 01),
                    IsPublished = true,
                    Text = LoremIpsum,
                    Title = "Post 2"
                }
            };

            var posts1 = new List<IPostViewModel>();
            posts1.Add(post1);
            posts1.Add(post2);

            var post3 = new PostViewModel
            {
                PostModel = new Post
                {
                    Author = "John",
                    ExpirationDate = new DateTime(2022, 01, 01),
                    IsPublished = true,
                    Text = LoremIpsum,
                    Title = "Post 3"
                }
            };

            var post4 = new PostViewModel
            {
                PostModel = new Post
                {
                    Author = "Hanne",
                    ExpirationDate = new DateTime(2022, 01, 01),
                    IsPublished = true,
                    Text = LoremIpsum,
                    Title = "Post 4"
                }
            };

            var posts2 = new List<IPostViewModel>();
            posts2.Add(post3);
            posts2.Add(post4);

            var category1 = new CategoryViewModel
            {
                CategoryModel = new Category
                {
                    IsPublished = true,
                    Title = "IB1: Category 1"
                },
                Posts = posts1
            };

            var category2 = new CategoryViewModel
            {
                CategoryModel = new Category
                {
                    IsPublished = true,
                    Title = $"IB1: Category 2"
                },
                Posts = posts2
            };

            var categories1 = new List<ICategoryViewModel>();
            categories1.Add(category1);
            categories1.Add(category2);

            var category3 = new CategoryViewModel
            {
                CategoryModel = new Category
                {
                    IsPublished = true,
                    Title = "IB2: Category 1"
                },
                Posts = posts2
            };

            var category4 = new CategoryViewModel
            {
                CategoryModel = new Category
                {
                    IsPublished = true,
                    Title = "IB2: Category 2"
                },
                Posts = posts1
            };

            var categories2 = new List<ICategoryViewModel>();
            categories2.Add(category3);
            categories2.Add(category4);

            var informationBoard1 = new InformationBoardViewModel
            {
                Categories = categories1,
                InformationBoardModel = new InformationBoard
                {
                    IsPublished = true,
                    Title = "Information Board 1",
                    InformationBoardId = 1
                }
            };

            var informationBoard2 = new InformationBoardViewModel
            {
                Categories = categories2,
                InformationBoardModel = new InformationBoard
                {
                    IsPublished = true,
                    Title = "Information Board 2",
                    InformationBoardId = 2
                }
            };

            InformationBoards.Add(informationBoard1);
            InformationBoards.Add(informationBoard2);
        }
    }
}