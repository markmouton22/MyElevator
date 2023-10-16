namespace MyElevator.Tests
{
    [TestFixture]
    public class ElevatorTests
    {
        private Building building;
        private ElevatorController controller;

        [SetUp]
        public void Setup()
        {
            building = new Building(2, 10);  // 2 elevators, 10 floors
            controller = new ElevatorController(building);
        }

        [Test]
        public void Test_Initial_Elevator_Status()
        {
            foreach (var elevator in building.Elevators)
            {
                Assert.That(elevator.Status, Is.EqualTo(ElevatorStatus.Stationary));
                Assert.That(elevator.Occupants, Is.EqualTo(0));
            }
        }

        [Test]
        public void Test_Call_Elevator()
        {
            var elevator = controller.CallElevator(5);

            Assert.That(elevator.CurrentFloor, Is.EqualTo(5));
            Assert.That(elevator.Status, Is.EqualTo(ElevatorStatus.Stationary));
        }

        [Test]
        public void Test_Elevator_Move_Up()
        {
            var elevator = building.Elevators.First();
            elevator.Move(7);
      
            Assert.That(elevator.CurrentFloor, Is.EqualTo(7));
            Assert.That(elevator.Status, Is.EqualTo(ElevatorStatus.Stationary));
        }

        [Test]
        public void Test_Elevator_Move_Down()
        {
            var elevator = building.Elevators.First();
            elevator.Move(7);  // Move to 7 first
            elevator.Move(3);  // Then move down to 3

            Assert.That(elevator.CurrentFloor, Is.EqualTo(3));
            Assert.That(elevator.Status, Is.EqualTo(ElevatorStatus.Stationary));
        }

        [Test]
        public void Test_Boarding_Elevator()
        {
            var elevator = building.Elevators.First();
            elevator.Board(3);
            Assert.That(elevator.Occupants, Is.EqualTo(3));
        }

        [Test]
        public void Test_Alighting_Elevator()
        {
            var elevator = building.Elevators.First();
            elevator.Board(5);
            elevator.Alight(3);
            Assert.That(elevator.Occupants, Is.EqualTo(2));
        }

        [Test]
        public void Test_Boarding_Exceeding_MaxOccupants()
        {
            var elevator = building.Elevators.First();
            var boardingResult = elevator.Board(11); // trying to board 11 people with a limit of 10
            Assert.IsFalse(boardingResult);
            Assert.That(elevator.Occupants, Is.EqualTo(0)); // no one should have boarded
        }

        [Test]
        public void Test_Boarding_Within_MaxOccupants()
        {
            var elevator = building.Elevators.First();
            var boardingResult = elevator.Board(5); // boarding 5 people with a limit of 10
            Assert.IsTrue(boardingResult);
            Assert.That(elevator.Occupants,Is.EqualTo(5)); // 5 people should have boarded
        }

        [Test]
        public void Test_Elevator_Maintenance_Mode()
        {
            var elevator = building.Elevators.First();

            elevator.EnterMaintenanceMode();
            Assert.That(elevator.State, Is.EqualTo(ElevatorState.Maintenance));

            elevator.ExitMaintenanceMode();
            Assert.That(elevator.State, Is.EqualTo(ElevatorState.Operational));
        }

        [Test]
        public void Test_Elevator_Emergency_Mode()
        {
            var elevator = building.Elevators.First();

            elevator.TriggerEmergency();
            Assert.That(elevator.State, Is.EqualTo(ElevatorState.Emergency));

            elevator.ResolveEmergency();
            Assert.That(elevator.State, Is.EqualTo(ElevatorState.Operational));
        }

        [Test]
        public void Test_Elevator_Malfunction_Mode()
        {
            var elevator = building.Elevators.First();

            elevator.Malfunction();
            Assert.That(elevator.State, Is.EqualTo(ElevatorState.Malfunction));

            elevator.Repair();
            Assert.That(elevator.State, Is.EqualTo(ElevatorState.Operational));
        }

        [Test]
        public void Test_Elevator_State_When_People_Leave()
        {
            var elevator = building.Elevators.First();
         
            elevator.Board(10);   // Assuming MaxOccupants is 10 for this test.
            Assert.That(elevator.State, Is.EqualTo(ElevatorState.FullCapacity));

            elevator.Leave(1); // one person leaves
            Assert.That(elevator.State, Is.EqualTo(ElevatorState.Operational));
        }
    }
}