$(document).ready(function () {
    //--------Admin Code

    //--Page Start
    deathToggle();
    $("#showDeath").show();

    announceToggle();
    $("#showAnnounce").show();

    eventToggle();
    $("#showEvent").show();

    meetToggle();
    $("#showMeet").show();

    contactToggle();
    $("#showContact").show();

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

    //Events Code
    $(".eventReset").click(function () {
        eventToggle();
        $("#showEvent").show();
    });

    $(".eventAdd").click(function () {
        eventToggle();
        $("#addEvent").show();
    });

    $(".eventEdit").click(function () {
        eventToggle();
        $("#editEvent").show();
    });

    function eventToggle() {
        $("#showEvent").hide();
        $("#editEvent").hide();
        $("#addEvent").hide();
    }

    //Meeting Code
    $(".meetReset").click(function () {
        meetToggle();
        $("#showMeet").show();
    });

    $(".meetAdd").click(function () {
        meetToggle();
        $("#addMeet").show();
    });

    $(".meetEdit").click(function () {
        meetToggle();
        $("#editMeet").show();
    });

    function meetToggle() {
        $("#showMeet").hide();
        $("#addMeet").hide();
        $("#editMeet").hide();
    }

    //Contact Code
    $(".contactReset").click(function () {
        contactToggle();
        $("#showContact").show();
    });

    $(".contactAdd").click(function () {
        contactToggle();
        $("#addContact").show();
    });

    $(".contactEdit").click(function () {
        contactToggle();
        $("#editContact").show();
    });

    function contactToggle() {
        $("#showContact").hide();
        $("#addContact").hide();
        $("#editContact").hide();
    }

    $("#adminFile").click(function () {
        location.href = 'http://localhost:61986/Admin/Index?searchString=bob#filesTab#top';
    });

});