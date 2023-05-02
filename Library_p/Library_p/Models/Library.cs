using System.ComponentModel.DataAnnotations;

namespace Library_p.Models
{
    public class Library
    {

        [Key]
         public int? Lib_ID { get; set; }
        public string Name_Lib { get; set; }
        public string Adress_Lib { get; set; }

        public string Department_lib { get; set; }

    }
}
