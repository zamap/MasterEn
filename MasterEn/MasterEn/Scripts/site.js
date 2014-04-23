$(document).ready(function () {
    $('#ex1').zoom({ on: 'grab' });
});


$('.carousel').carousel({
    interval: 3500
});


//$(document).on('click', '#showGame', function () {
//    var self = $(this);
  
//    //$.ajax({
//    //    url: 'Home/Create',
//    //    type: 'GET',
//    //    success: function (data) {
//    //        $('#modal-target').html(data);
//    //        $('#modal-person').modal('show');
//    //    }
//    //});
//    $.get('Home/Create', function (data) {
//        $('#gameContainer').html(data);

//        $('#gameModal').modal('show');
//    });
        
//});


//$(document).on('click', '#btn-person-submit', function () {
//    var self = $(this);
//    $.ajax({
//        url: 'Home/SendBuyRequest',
//        type: 'POST',
//        data: self.closest('form').serialize(),
//        success: function (data) {
//            if (data.success == true) {
//                $('#gameModal').modal('hide');
//                location.reload(false)
//            } else {
//                $('#gameContainer').html(data);
//            }
//        }
//    });
//});

function initialize() {
    var mapOptions = {
        center: new google.maps.LatLng(40.435833800555567, -78.44189453125),
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        zoom: 11
    };
    var map = new google.maps.Map(document.getElementById("map"), mapOptions);
};

function initialize() {
    var latlng = new google.maps.LatLng(50.505183, 53.2785795);
    var myOptions = {
        panControl: false,
        zoomControl: true,
        mapTypeControl: false,
        scaleControl: false,
        streetViewControl: false,
        overviewMapControl: false,
        zoom: 4,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.HYBRID
    };
    var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
}

$(function () {
    initialize();
});


