namespace TrainComponentManagement.Models
{
    public class ComponentHierarchy
    {
        public int ParentComponentID { get; set; }
        public int ChildComponentID { get; set; }

        public TrainComponent? ParentComponent { get; set; }
        public TrainComponent? ChildComponent { get; set; }
        public int Depth { get; set; }
    }
}
