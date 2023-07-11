using TrainComponentManagement.Models;

namespace TrainComponentManagement.Data
{
    public class InitializationDbWithData
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<TrainComponentContext>());
        }

        private static void SeedData(TrainComponentContext context)
        {
            if (!context.TrainComponents.Any())
            {
                var trainComponents = new List<TrainComponent>
                {
                    new TrainComponent { Name = "Engine", UniqueNumber = "ENG123", CanAssignQuantity = false },
                    new TrainComponent { Name = "Passenger Car", UniqueNumber = "PAS456", CanAssignQuantity = false },
                    new TrainComponent { Name = "Freight Car", UniqueNumber = "FRT789", CanAssignQuantity = false },
                    new TrainComponent { Name = "Wheel", UniqueNumber = "WHL101", CanAssignQuantity = true },
                    new TrainComponent { Name = "Seat", UniqueNumber = "STS234", CanAssignQuantity = true },
                    new TrainComponent { Name = "Window", UniqueNumber = "WIN567", CanAssignQuantity = true },
                    new TrainComponent { Name = "Door", UniqueNumber = "DR123", CanAssignQuantity = true },
                    new TrainComponent { Name = "Control Panel", UniqueNumber = "CTL987", CanAssignQuantity = true },
                    new TrainComponent { Name = "Light", UniqueNumber = "LGT456", CanAssignQuantity = true },
                    new TrainComponent { Name = "Brake", UniqueNumber = "BRK789", CanAssignQuantity = true },
                    new TrainComponent { Name = "Bolt", UniqueNumber = "BLT321", CanAssignQuantity = true },
                    new TrainComponent { Name = "Nut", UniqueNumber = "NUT654", CanAssignQuantity = true },
                    new TrainComponent { Name = "Engine Hood", UniqueNumber = "EH789", CanAssignQuantity = false },
                    new TrainComponent { Name = "Axle", UniqueNumber = "AX456", CanAssignQuantity = false },
                    new TrainComponent { Name = "Piston", UniqueNumber = "PST789", CanAssignQuantity = false },
                    new TrainComponent { Name = "Handrail", UniqueNumber = "HND234", CanAssignQuantity = true },
                    new TrainComponent { Name = "Step", UniqueNumber = "STP567", CanAssignQuantity = true },
                    new TrainComponent { Name = "Roof", UniqueNumber = "RF123", CanAssignQuantity = false },
                    new TrainComponent { Name = "Air Conditioner", UniqueNumber = "AC789", CanAssignQuantity = false },
                    new TrainComponent { Name = "Flooring", UniqueNumber = "FLR456", CanAssignQuantity = false },
                    new TrainComponent { Name = "Mirror", UniqueNumber = "MRR789", CanAssignQuantity = true },
                    new TrainComponent { Name = "Horn", UniqueNumber = "HRN321", CanAssignQuantity = false },
                    new TrainComponent { Name = "Coupler", UniqueNumber = "CPL654", CanAssignQuantity = false },
                    new TrainComponent { Name = "Hinge", UniqueNumber = "HNG987", CanAssignQuantity = true },
                    new TrainComponent { Name = "Ladder", UniqueNumber = "LDR456", CanAssignQuantity = true },
                    new TrainComponent { Name = "Paint", UniqueNumber = "PNT789", CanAssignQuantity = false },
                    new TrainComponent { Name = "Decal", UniqueNumber = "DCL321", CanAssignQuantity = true },
                    new TrainComponent { Name = "Gauge", UniqueNumber = "GGS654", CanAssignQuantity = true },
                    new TrainComponent { Name = "Battery", UniqueNumber = "BTR987", CanAssignQuantity = false },
                    new TrainComponent { Name = "Radiator", UniqueNumber = "RDR456", CanAssignQuantity = false },
                };

                context.TrainComponents.AddRange(trainComponents);
                context.SaveChanges();
            }

            if (!context.ComponentHierarchies.Any())
            {
                var trainComponentHierarchy = new List<ComponentHierarchy>
                {
                    new ComponentHierarchy
                    {
                        ParentComponentID = 3,
                        ChildComponentID = 2,
                        Depth = 1
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 2,
                        ChildComponentID = 1,
                        Depth = 2
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 2,
                        ChildComponentID = 4,
                        Depth = 2
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 2,
                        ChildComponentID = 5,
                        Depth = 2
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 2,
                        ChildComponentID = 6,
                        Depth = 2
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 2,
                        ChildComponentID = 7,
                        Depth = 2
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 2,
                        ChildComponentID = 8,
                        Depth = 2
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 2,
                        ChildComponentID = 9,
                        Depth = 2
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 2,
                        ChildComponentID = 10,
                        Depth = 2
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 2,
                        ChildComponentID = 18,
                        Depth = 2
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 2,
                        ChildComponentID = 19,
                        Depth = 2
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 2,
                        ChildComponentID = 20,
                        Depth = 2
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 2,
                        ChildComponentID = 22,
                        Depth = 2
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 2,
                        ChildComponentID = 26,
                         Depth = 2
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 2,
                        ChildComponentID = 27,
                        Depth = 2
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 2,
                        ChildComponentID = 29,
                        Depth = 2
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 29,
                        ChildComponentID = 30,
                        Depth = 3
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 1,
                        ChildComponentID = 13,
                        Depth = 3
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 1,
                        ChildComponentID = 14,
                        Depth = 3
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 1,
                        ChildComponentID = 15,
                        Depth = 3
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 1,
                        ChildComponentID = 23,
                        Depth = 3
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 1,
                        ChildComponentID = 24,
                        Depth = 3
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 4,
                        ChildComponentID = 11,
                        Depth = 3
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 4,
                        ChildComponentID = 12,
                        Depth = 3
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 7,
                        ChildComponentID = 16,
                        Depth = 3
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 7,
                        ChildComponentID = 17,
                        Depth = 3
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 7,
                        ChildComponentID = 21,
                        Depth = 3
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 16,
                        ChildComponentID = 28,
                        Depth = 4
                    },
                    new ComponentHierarchy
                    {
                        ParentComponentID = 21,
                        ChildComponentID = 25,
                        Depth = 4
                    },
                };

                context.ComponentHierarchies.AddRange(trainComponentHierarchy);
                context.SaveChanges();
            }
        }
    }
}
