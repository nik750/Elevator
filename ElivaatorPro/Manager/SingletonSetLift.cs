/// <summary>
/// Singleton class to hold all the requried values withing the instance
/// </summary>
namespace ElivaatorPro.Manager
{
    public sealed class SingletonSetLift
    {
        public static readonly SingletonSetLift instance = new SingletonSetLift();
        private static readonly object synclock = new object();
        private int totalFloor = new int();
        private int currentFloor = new int();
        private bool isEvacuated = new bool();
        public SingletonSetLift()
        {

        }

        public void SetFloor(int totalFloors)
        {
            totalFloor = totalFloors;
        }

        public int GetFloor()
        {
            return totalFloor;
        }
        public void SetCurrentFloor(int floor)
        {
            currentFloor = floor;
        }

        public int GetCurrentFloor()
        {
            return currentFloor;
        }

        public void SetEvacuation(bool isEvacuate)
        {
            isEvacuated = isEvacuate;
        }

        public bool GetEvacuation()
        {
            return isEvacuated;
        }
    }
}
