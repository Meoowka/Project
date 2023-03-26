using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Programm_L.Models
{
    public class Personal
    {
        [Key]
        public int Personal_ID { get; set; }
        public string? Name_pers { get; set; }
        public int Staj_pers { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data_post { get; set; }
    }
}
