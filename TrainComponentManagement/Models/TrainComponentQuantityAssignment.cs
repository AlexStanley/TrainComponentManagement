using System.ComponentModel.DataAnnotations;

namespace TrainComponentManagement.Models
{
    public class TrainComponentQuantityAssignment
    {
        [Key]
        public int ID { get; set; }
        public int? Quantity { get; set; }
        public int TrainComponentID { get; set; }
        public virtual TrainComponent? TrainComponent { get; set; }
    }
}
