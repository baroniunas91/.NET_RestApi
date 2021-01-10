using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiHomework.Asp.Net.Models
{
    public class BoughtItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; } = 2;
        public int? Quantity { get; set; } = 100;
        public int? Discount { get; set; } = 0;
        public decimal? TotalPrice { get; set; } = 0;
    }
}
