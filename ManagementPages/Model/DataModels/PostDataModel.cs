using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementPages.Model
{
    public class PostDataModel
    {
        public int PostId { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Titel-feltet skal udfyldes")]
        [StringLength(30, ErrorMessage = "Titlen er for lang")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Tekst-feltet skal udfyldes")]
        [StringLength(429496729, ErrorMessage = "Teksten er for lang")]
        public string Text { get; set; }


        [Required(ErrorMessage = "Forfatter-feltet skal udfyldes")]
        [StringLength(100, ErrorMessage = "Navnet er for lang")]
        public string Author { get; set; }

        public string Image { get; set; }

        public string Audio { get; set; }

        public bool IsPublished { get; set; }
        
        public string Link { get; set; }

        public DateTime ExpirationDate { get; set; }

        // Method that makes it possible to write " and \ in title, author and textfield
        public void FixSpecialCharacters()
        {
            Title = Title.Replace("\\", "\\\\").Replace("\"", "\\\"");
            Author = Author.Replace("\\", "\\\\").Replace("\"", "\\\"");
            Text = Text.Replace("\\", "\\\\").Replace("\"", "\\\"");
        }
    }
}