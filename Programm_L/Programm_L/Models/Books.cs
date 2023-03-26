using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Programm_L.Models
{
    public class Books
    {
        [Key]
        public int Book_ID { get; set; }
        public string? Name_book { get; set; }
        public string? Name_author { get; set; }
        public string? Janr_book { get; set; }
        public int Kol_vo { get; set; }

    }
}
