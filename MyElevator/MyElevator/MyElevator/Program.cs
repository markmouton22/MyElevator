class Program
{
    static void Main(string[] args)
{
        var building = new Building(2, 10);  // 2 elevators, 10 floors
        var controller = new ElevatorController(building);

        bool running = true;

        Elevator ? dispatchedElevator = null; 

        while (running)
        {
            Console.WriteLine("1. Call Elevator");
            Console.WriteLine("2. Show Elevator Status");
            Console.WriteLine("3. Exit");
            var choice = int.Parse(Console.ReadLine() ?? string.Empty);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Which floor?");
                    var floor = int.Parse(Console.ReadLine() ?? string.Empty);
                    dispatchedElevator = controller.CallElevator(floor);
                    Console.WriteLine($"Your elevator {dispatchedElevator.GetHashCode()} is on its way!");
                    break;

                case 2:
                    foreach (var elevator in building.Elevators)
                    {
                        Console.WriteLine($"Elevator {elevator.GetHashCode()} - " +
                                          $"Floor: {elevator.CurrentFloor}, " +
                                          $"Status: {elevator.Status}, " +
                                          $"Occupants: {elevator.Occupants}");
                    }
                    break;

                case 3:
                    running = false;
                    break;
            }
        }
    }
}