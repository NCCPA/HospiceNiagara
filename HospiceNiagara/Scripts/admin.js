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

    //do on load
    //strip data from http://stackoverflow.com/questions/19491336/get-url-parameter-jquery
    function getUrlParameter(sParam) {
        var sPageURL = window.location.search.substring(1);
        var sURLVariables = sPageURL.split('&');
        for (var i = 0; i < sURLVariables.length; i++) {
            var sParameterName = sURLVariables[i].split('=');
            if (sParameterName[0] == sParam) {
                return sParameterName[1];
            }
        }
    }

    //Search String for File
    var getSearch = getUrlParameter('searchString');
    if (getSearch != null)
        $("#txtFileSearch").val(getSearch);

    $("#adminFile").click(function () {
        var txtSearch = $("#txtFileSearch").val();
        var ddlList = $("#ddlFileShedule").val();
       
        txtSearch = $.trim(txtSearch);
        txtSearch = txtSearch.replace(/\s+/g, '+');
        location.href = 'http://localhost:61986/Admin/Index?searchString=' + txtSearch + '#filesTab#top';
    });





});