namespace ElivaatorPro.Manager
{
    using Constants;
    using Manager.Contract;

    public class FloorManager : IFloorManager
    {
        private bool[] isFloorReady;
        private int CurrentFloor = 1;
        private int finalFloor;
        public LiftStatus status = LiftStatus.stopped;

        public FloorManager()
        {
        }

        public void SetTotalFloor(int totalFloors)
        {
            SingletonSetLift.instance.SetFloor(totalFloors);
        }
        public FloorInfo GotoFloor(int floor)
        {
            finalFloor = SingletonSetLift.instance.GetFloor();
            isFloorReady = new bool[finalFloor + 1];
            CurrentFloor = SingletonSetLift.instance.GetCurrentFloor();

            if (floor > finalFloor)
                return FloorInfo.floorLimitReached;

            isFloorReady[floor] = true;
            switch (status)
            {
                case LiftStatus.up:
                    return GoUp(floor);
                case LiftStatus.down:
                    return GoDown(floor);
                case LiftStatus.stopped:
                    if (CurrentFloor < floor)
                        return GoUp(floor);
                    else if (CurrentFloor == floor)
                        return NoAction();
                    else
                        return GoDown(floor);
                default:
                    return FloorInfo.sameFloor;
            }

        }

        public FloorInfo GoUp(int floor)
        {
            for (int i = CurrentFloor; i <= finalFloor; i++)
            {
                if (isFloorReady[i])
                    StopElevator(floor);
                else
                    continue;
            }
            status = LiftStatus.stopped;
            return FloorInfo.reachedSelectedFloorUp;
        }

        public FloorInfo GoDown(int floor)
        {
            for (int i = CurrentFloor; i >= 1; i--)
            {
                if (isFloorReady[i])
                    StopElevator(floor);
                else
                    continue;
            }
            status = LiftStatus.stopped;
            return FloorInfo.reachedSelectedFloorDown;
        }

        public FloorInfo NoAction()
        {
            return FloorInfo.sameFloor;
        }

        public void StopElevator(int floor)
        {
            status = LiftStatus.stopped;
            SingletonSetLift.instance.SetCurrentFloor(floor);
            isFloorReady[floor] = false;
        }

        public void Evacuate()
        {
            SingletonSetLift.instance.SetEvacuation(true);
        }
    }
}
