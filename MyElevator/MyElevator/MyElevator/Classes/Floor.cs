public class Floor
{
    public int FloorNumber { get; }
    public int WaitingPeople { get; private set; }

    public Floor(int floorNumber)
    {
        FloorNumber = floorNumber;
    }

    public void Arrive(int numberOfPeople)
    {
        WaitingPeople += numberOfPeople;
    }

    public void Depart(int numberOfPeople)
    {
        WaitingPeople -= numberOfPeople;
    }
}