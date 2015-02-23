
//Change the active class on the sidebar depending on the page...
$(document).ready(function () {

    $("#input-1a").fileinput();

    $('.fileList').hide();
    $(function() {
        $('#showdiv').each(function () {
            if ($(this).attr('href')  ===  window.location.pathname) {
                $(this).parent().addClass('active');
            }
        });
    });


    $(".backHistory").click(function () {
        history.back();
    })


   $(".showfile").click(function () {
       $(this).nextAll('.fileList:first').slideToggle();
    });


   var url = document.location.toString();
   if (url.match('#')) {
       $('.nav-tabs a[href=#' + url.split('#')[1] + ']').tab('show');
   }
   $(this).scrollTop(0);
    // Change hash for page-reload
   /*$('.nav-tabs a').on('shown', function (e) {
       window.location.hash = e.target.hash;
   })*/

    /*Please DONT DELETE THIS AGAIN RYAN*/
    $('a[href="' + this.location.pathname + '"]').parent().addClass('active');


    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();
  
    $('#calendar').fullCalendar({
       theme: true,
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        editable: true,
        events: [
          {
              title: 'All Day Event',
              start: new Date(y, m, 1)
          },
          {
              title: 'Long Event',
              start: new Date(y, m, d-5),
              end: new Date(y, m, d-2)
          },
          {
              id: 999,
              title: 'Repeating Event',
              start: new Date(y, m, d-3, 16, 0),
              allDay: false
          },
          {
              id: 999,
              title: 'Repeating Event',
              start: new Date(y, m, d+4, 16, 0),
              allDay: false
          },
          {
              title: 'Meeting',
              start: new Date(y, m, d, 10, 30),
              allDay: false
          },
          {
              title: 'Lunch',
              start: new Date(y, m, d, 12, 0),
              end: new Date(y, m, d, 14, 0),
              allDay: false
          },
          {
              title: 'Birthday Party',
              start: new Date(y, m, d+1, 19, 0),
              end: new Date(y, m, d+1, 22, 30),
              allDay: false
          },
          {
              title: 'Click for Google',
              start: new Date(y, m, 28),
              end: new Date(y, m, 29),
              url: 'http://google.com/'
          }
        ],
        eventColor: '#4099FF'
    });


    ////make sidebar big as viewport or devicing viewing
    //var height = $(document).height();
    //$('.sidebar').height(height);

    //$(window).resize(function () {
    //    var height = $(document).height();
    //    $('.sidebar').height(height);
    //})

    ////Make the side Bar stick while scrolling
    //$(window).scroll(function () {
    //    $('.sidebar').css(top, $(this).scrollTop());
    //});



    //--------Admin Code
 //   $("#editDeath").hide();
  //  $("#addDeath").hide();
    deathToggle();
    $("#showDeath").show();
    //--Deaths
    

    $(".deathAdd").click(function () {
        $("#showDeath").hide();
        $("#editDeath").hide();
        $("#addDeath").show();
    });

    function deathToggle (){
        $("#showDeath").hide();
        $("#editDeath").hide();
        $("#addDeath").hide();
    }

});
