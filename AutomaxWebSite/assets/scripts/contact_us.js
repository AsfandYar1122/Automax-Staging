
$(document).ready(function () {
    function initMap() {
        var coordinates = { lat: 21.546340, lng: 39.235567 };
        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 16,
            center: coordinates,
            scrollwheel: false
        });
        var marker = new google.maps.Marker({
            position: coordinates,
            map: map
        });
    }
    initMap() 
} );