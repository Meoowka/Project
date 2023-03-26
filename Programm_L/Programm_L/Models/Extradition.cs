using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Programm_L.Models
{
    public class Extradition
    {
        [Key]
        public int Extra_ID { get; set; }
        public int Personal_ID  { get; set; }
        [ForeignKey("Personal_ID")]
        public Personal? personal { get; set; }
        public int Book_ID { get; set; }
        [ForeignKey("Book_ID")]
        public Books? Books { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data_extra { get; set; }

    }
}
