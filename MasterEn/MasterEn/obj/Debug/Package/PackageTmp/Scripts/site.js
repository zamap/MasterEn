$(document).ready(function () {
    $('#ex1').zoom({ on: 'grab' });
});


$('.carousel').carousel({
    interval: 3500
});

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
        zoom:4,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.HYBRID
    };
    var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
}

$(function () {
    initialize();
});


