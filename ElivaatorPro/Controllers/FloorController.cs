namespace ElivaatorPro.Controllers
{
    using Constants;
    using Manager;
    using Manager.Contract;
    using Microsoft.AspNetCore.Mvc;

    public class FloorController : Controller
    {
        private readonly IFloorManager _floorManager;
        private static int TotalFloor { get; set; }
        public FloorController(IFloorManager floorManager)
        {
            _floorManager = floorManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubmitFloor(int totalFloors)
        {
            if (!ModelState.IsValid || totalFloors < 0)
            {
                return this.BadRequest();
            }
            _floorManager.SetTotalFloor(totalFloors);
            SingletonSetLift.instance.SetEvacuation(false);
            SingletonSetLift.instance.SetCurrentFloor(0);
            return this.Ok();

        }

        public IActionResult Evacuate()
        {
            _floorManager.Evacuate();
            return this.Ok("Lift reached the destination: 0");
        }

        public IActionResult GotoFloor(int floorNumber)
        {
            if (!ModelState.IsValid || floorNumber < 0)
            {
                return this.BadRequest();
            }
            var isEvacuation = SingletonSetLift.instance.GetEvacuation();
            if (isEvacuation)
            {
                return this.Ok(FloorConstants.Evacuation);
            }

            var status = _floorManager.GotoFloor(floorNumber);
            switch (status)
            {
                case FloorInfo.floorLimitReached:
                    return this.Ok(FloorConstants.NoFloor);
                case FloorInfo.sameFloor:
                    return this.Ok(FloorConstants.SameFloor);
                case FloorInfo.reachedSelectedFloorUp:
                    return this.Ok($"{FloorConstants.ReachedUp}{floorNumber}");
                case FloorInfo.reachedSelectedFloorDown:
                    return this.Ok($"{FloorConstants.ReachedDown}{floorNumber}");
                default:
                    return this.NotFound();
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
