public class ElevatorController
{
    private Building Building;

    public ElevatorController(Building building)
    {
        Building = building;
    }

    public Elevator CallElevator(int floorNumber)
    {
        Elevator ?closestElevator = null;
        int shortestDistance = int.MaxValue;

        foreach (var elevator in Building.Elevators)
        {
            if (elevator.State != ElevatorState.Operational)
            {
                continue; //Non operational
            }

            var distance = Math.Abs(elevator.CurrentFloor - floorNumber);
            if (distance < shortestDistance)
            {
                closestElevator = elevator;
                shortestDistance = distance;
            }
        }

        if (closestElevator == null)
        {
            throw new InvalidOperationException("No operational elevator available!");
        }

        closestElevator.Move(floorNumber);
        return closestElevator;
    }
}