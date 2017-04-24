namespace ElivaatorPro.Constants
{
    public class FloorConstants
    {
        public const string NoFloor = "Building dont have that floor";
        public const string SameFloor = "You have selected same floor";
        public const string ReachedUp = "[UP] Lift reached the destination: ";
        public const string ReachedDown = "[DOWN] Lift reached the destination: ";
        public const string Evacuation = "Evacuation in progress, cannot use lift now.";
    }

    public enum FloorInfo
    {
        floorLimitReached,
        sameFloor,
        reachedSelectedFloorUp,
        reachedSelectedFloorDown
    }

    public enum LiftStatus
    {
        up,
        down,
        stopped
    }
}
