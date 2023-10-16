public class Building
{
    public List<Elevator> Elevators { get; set; }

    public Building(int numOfElevators, int floors)
    {
        Elevators = new List<Elevator>();

        for (int i = 0; i < numOfElevators; i++)
        {
            var elevator = new Elevator{ 
                MaxOccupants = 10
            };
            Elevators.Add(elevator);
        }
    }
}