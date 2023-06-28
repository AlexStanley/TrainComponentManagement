namespace TrainComponentManagement.Models
{
    public class ComponentHierarchy
    {
        public int ParentComponentID { get; set; }
        public int ChildComponentID { get; set; }

        public TrainComponent ParentComponent { get; set; } = new();
        public TrainComponent ChildComponent { get; set; } = new();
    }
}
