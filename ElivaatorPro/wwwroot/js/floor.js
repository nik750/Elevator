$(".SubmitFloor").click(function () {
    var totalFloor = $(".totalFloors").val();
    $.post("Floor/SubmitFloor", { totalFloors: totalFloor }).done(function () {
        $(".totalFloors").attr("readonly", "true");
        $(".SubmitFloor").attr("disabled", "true");
        $(".Go").removeAttr("disabled");
        $(".totalFloorLabel").html(totalFloor);
    }).fail(function (data) {
        $(".alert").css("display", "block");
        $(".errorMessage").html(data.statusText);
        $(".alert").fadeOut(10000);
    })
});

$(".Go").click(function () {
    var selectedFloor = $(".selectedFloor").val();
    $.post("Floor/GotoFloor", { floorNumber: selectedFloor }).done(function (data) {
        $(".liftInfo").css("display", "block");
        $(".liftInfoMessage").html(data.statusText);
        $(".liftInfoMessage").html(data);
    }).fail(function (data) {
        $(".alert").css("display", "block");
        $(".errorMessage").html(data.statusText);
        $(".alert").fadeOut(10000);
    })
});

$(".Evacuate").click(function () {
    $.post("Floor/Evacuate").done(function (data) {
        $(".liftInfoMessage").html(data.statusText);
        $(".liftInfoMessage").html(data);
    }).fail(function (data) {
        $(".alert").css("display", "block");
        $(".errorMessage").html(data.statusText);
        $(".alert").fadeOut(10000);
    })
})