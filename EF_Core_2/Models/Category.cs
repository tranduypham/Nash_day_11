using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core_2.Models
{
    [Table("Categories")]
    public class Category
    {
        // [Key]
        public int CategoriId { get; set; }

        // [Column("CategoryName", TypeName = "ntext")]
        public string CategoryName { get; set; }
        // public ICollection<Product> Products { get; set; }
    }
}