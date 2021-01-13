using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiHomework.Asp.Net.Models
{
    public abstract class Item
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; } = 3.00M;
        public int? Quantity { get; set; } = 4;
    }
}
