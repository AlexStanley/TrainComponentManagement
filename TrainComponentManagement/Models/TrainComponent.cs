using System.ComponentModel.DataAnnotations;

namespace TrainComponentManagement.Models
{
    public class TrainComponent
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string UniqueNumber { get; set; } = string.Empty;
        [Required]
        public bool CanAssignQuantity { get; set; }
        public int? ItemAmount { get; set; }
    }
}
