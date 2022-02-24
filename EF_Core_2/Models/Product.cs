using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core_2.Models
{
    [Table("Products")]
    public class Product
    {
        // [Key]
        public int ProductId { get; set; }

        // [Column("ProductName", TypeName = "ntext")]
        public string ProductName { get; set; }
        
        // [Column("Manufacture", TypeName = "ntext")]
        public string Manufacture { get; set; }

        public int CategoryId { get; set; }

        // [ForeignKey("CategoryId")]
        // public Category? Category { get; set; }
    }
}