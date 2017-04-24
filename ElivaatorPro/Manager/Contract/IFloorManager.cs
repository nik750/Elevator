namespace ElivaatorPro.Manager.Contract
{
    using ElivaatorPro.Constants;

    public interface IFloorManager
    {
        /// <summary>
        /// Sets total number of floor for the instance
        /// </summary>
        /// <param name="totalFloor">total floor as int</param>
        void SetTotalFloor(int totalFloor);

        /// <summary>
        /// Stops the elevator
        /// </summary>
        /// <param name="floor">stoping floor as int</param>
        void StopElevator(int floor);

        /// <summary>
        /// Gets the elevator down
        /// </summary>
        /// <param name="floor">floor to go</param>
        /// <returns>returns floor information <see cref="FloorInfo"/></returns>
        FloorInfo GoDown(int floor);

        /// <summary>
        /// Gets the elevator up
        /// </summary>
        /// <param name="floor">floor to go</param>
        /// <returns>returns floor information <see cref="FloorInfo"/></returns>
        FloorInfo GoUp(int floor);

        /// <summary>
        /// Does nothing
        /// </summary>
        /// <returns></returns>
        FloorInfo NoAction();

        /// <summary>
        /// Goto specified floors
        /// </summary>
        /// <param name="Floor">floor to go</param>
        /// <returns>returns floor information <see cref="FloorInfo"/></returns>
        FloorInfo GotoFloor(int Floor);

        /// <summary>
        /// Stops all activity and takes elevator to 0th floor
        /// </summary>
        void Evacuate();
    }
}
