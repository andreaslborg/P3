using System;

namespace ManagementPages.Model
{
    public class TestLicenseWithData : License
    {
        //creates a License with three information boards with categories and posts. For #2, isPublished is false
        //(for both information boards, categories, and posts)
        public TestLicenseWithData()
        {
            InitializeTestLicense();
            LicenseNumber = new Guid("FD97CFDB-9FFB-45C5-8B45-A48B25116E3C");
            RegistrationDate = new DateTime(2021, 02, 03);
        }

        private string LoremIpsum { get; } =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce quis lectus quis sem lacinia nonummy. Proin mollis lorem non dolor. In hac habitasse platea dictumst. Nulla ultrices odio. Donec augue. Phasellus dui. Maecenas facilisis nisl vitae nibh. Proin vel seo est vitae eros pretium dignissim. Aliquam aliquam sodales orci. Suspendisse potenti. Nunc adipiscing euismod arcu. Quisque facilisis mattis lacus. Fusce bibendum, velit in venenatis viverra, tellus ligula dignissim felis, quis euismod mauris tellus ut urna. Proin scelerisque. Nulla in mi. Integer ac leo. Nunc urna ligula, gravida a, pretium vitae, bibendum nec, ante. Aliquam ullamcorper iaculis lectus. Sed vel dui. Etiam lacinia risus vitae lacus. Aliquam elementum imperdiet turpis. In id metus. Mauris eu nisl. Nam pharetra nisi nec enim. Nulla aliquam, tellus sed laoreet blandit, eros urna vehicula lectus, et vulputate mauris arcu ut arcu. Praesent eros metus lirum larum, accumsan a, malesuada et, commodo vel, nulla. Aliquam sagittis auctor sapien. Morbi a nibh.";

        private void InitializeTestLicense()
        {
            var post1 = new Post
            {
                Title = "Post 1",
                Text = LoremIpsum,
                Author = "Hanne Nielsen",
                IsPublished = true,
                ExpirationDate = new DateTime(2022, 09, 02)
            };
            var post2 = new Post
            {
                Title = "Post 2 - not published",
                Text = LoremIpsum,
                Author = "Lars Jørgensen",
                IsPublished = false,
                ExpirationDate = new DateTime(2022, 09, 03)
            };
            var post3 = new Post
            {
                Title = "Post 3",
                Text = LoremIpsum,
                Author = "Bo Andersen",
                IsPublished = true,
                ExpirationDate = new DateTime(2022, 10, 02)
            };

            var category1 = new Category
            {
                Title = "Category 1",
                IsPublished = true
            };
            var category2 = new Category
            {
                Title = "Category 2 - not published",
                IsPublished = false
            };
            var category3 = new Category
            {
                Title = "Category 3",
                IsPublished = true
            };

            var informationBoard1 = new InformationBoard
            {
                Title = "Information board 1",
                IsPublished = true
            };
            var informationBoard2 = new InformationBoard
            {
                Title = "Information board 2 - not published",
                IsPublished = false
            };
            var informationBoard3 = new InformationBoard
            {
                Title = "Information board 3",
                IsPublished = true
            };

            category1.Posts.Add(post1);
            category1.Posts.Add(post2);
            category1.Posts.Add(post3);
            category2.Posts.Add(post2);
            category2.Posts.Add(post3);
            category2.Posts.Add(post1);
            category3.Posts.Add(post3);
            category3.Posts.Add(post1);
            category3.Posts.Add(post2);

            informationBoard1.Categories.Add(category1);
            informationBoard1.Categories.Add(category2);
            informationBoard1.Categories.Add(category3);
            informationBoard2.Categories.Add(category2);
            informationBoard2.Categories.Add(category3);
            informationBoard2.Categories.Add(category1);
            informationBoard3.Categories.Add(category3);
            informationBoard3.Categories.Add(category1);
            informationBoard3.Categories.Add(category2);

            InformationBoards.Add(informationBoard1);
            InformationBoards.Add(informationBoard2);
            InformationBoards.Add(informationBoard3);
        }
    }
}