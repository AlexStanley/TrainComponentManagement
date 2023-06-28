namespace TrainComponentManagement.Dtos
{
    public class TrainComponentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UniqueNumber { get; set; } = string.Empty;
        public bool CanAssignQuantity { get; set; }
        public int? ItemAmount { get; set; }
        public List<TrainComponentDto>? Children { get; set; }
    }
}
