$(document).ready(function () {
    //--------Admin Code

    //--Page Start
    deathToggle();
    $("#showDeath").show();

    announceToggle();
    $("#showAnnounce").show();

    //--Deaths Code
    $(".deathReset").click(function () {
        deathToggle();
        $("#showDeath").show();
    });

    $(".deathAdd").click(function () {
        deathToggle();
        $("#addDeath").show();
    });
    
    $(".deathEdit").click(function () {
        deathToggle();
        $("#editDeath").show();
    });

    function deathToggle() {
        $("#showDeath").hide();
        $("#editDeath").hide();
        $("#addDeath").hide();
    }

    //Anouncements Code
    $(".announceReset").click(function () {
        announceToggle();
        $("#showAnnounce").show();
    });

    $(".announceAdd").click(function () {
        announceToggle();
        $("#addAnnounce").show();
    });

    $(".announceEdit").click(function () {
        announceToggle();
        $("#editAnnounce").show();
    });

    function announceToggle() {
        $("#showAnnounce").hide();
        $("#editAnnounce").hide();
        $("#addAnnounce").hide();
    }

});