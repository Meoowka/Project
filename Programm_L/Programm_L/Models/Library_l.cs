using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Programm_L.Models
{
    public class Library_l
    {
        [Key]
        public int Lib_ID { get; set; }
        public string? Name_lib { get; set; }
        public int Code_lib { get; set; }
    }
}
