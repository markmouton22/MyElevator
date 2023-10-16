public class Elevator
{
    public int CurrentFloor { get; private set; }

    public ElevatorStatus Status { get; private set; }

    public int Capacity { get; } = 5; 

    public int Occupants { get; private set; } = 0;

    public int MaxOccupants { get;  set; }

    public ElevatorState State { get; set; } = ElevatorState.Operational;


    public Elevator()
    {
        this.Status = ElevatorStatus.Stationary;
        this.Occupants = 0;
        this.MaxOccupants = 10;
    }

    public void Move(int targetFloor)
    {
        if (targetFloor > CurrentFloor)
        {
            Status = ElevatorStatus.Up;
        }
        else if (targetFloor < CurrentFloor)
        {
            Status = ElevatorStatus.Down;
        }
        else
        {
            Status = ElevatorStatus.Stationary;
        }

        CurrentFloor = targetFloor;
        Status = ElevatorStatus.Stationary; // After reaching target, the elevator becomes stationary
    }

    public bool Board(int numberOfPeople)
    {
        if (Occupants + numberOfPeople <= MaxOccupants)
        {
            Occupants += numberOfPeople;
            if (Occupants == MaxOccupants)
            {
                State = ElevatorState.FullCapacity;
            }
            return true;
        }
        return false;
    }


    public void Alight(int numberOfPeople)
    {
        Occupants -= numberOfPeople;
    }

    public void Leave(int numberOfPeople)
    {
        if (numberOfPeople <= Occupants)
        {
            Occupants -= numberOfPeople;
        }
        else
        {
            Occupants = 0;
        }
      
        if (State == ElevatorState.FullCapacity && Occupants < MaxOccupants)
        {
            State = ElevatorState.Operational;
        }
    }
    public void EnterMaintenanceMode()
    {
        State = ElevatorState.Maintenance;
    }

    public void ExitMaintenanceMode()
    {
        State = ElevatorState.Operational;
    }

    public void TriggerEmergency()
    {
        State = ElevatorState.Emergency;
    }

    public void ResolveEmergency()
    {
        State = ElevatorState.Operational;
    }

    public void Malfunction()
    {
        State = ElevatorState.Malfunction;
    }

    public void Repair()
    {
        State = ElevatorState.Operational;
    }
}