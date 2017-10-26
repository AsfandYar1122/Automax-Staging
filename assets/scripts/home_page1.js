$(document).ready(function () {
    $('.deal-tab > .carousel-custom').slick({
        slidesToShow: 3,
        autoplay: true,
        responsive: [
            {
                breakpoint: 992,
                settings: {
                    slidesToShow: 2,
                    infinite: true,
                    arrows: false
                }
            }, {
                breakpoint: 768,
                settings: {
                    slidesToShow: 1,
                    infinite: true,
                    arrows: false
                }
            }],
        prevArrow: '<button type="button" class="slick-prev"><i class="fa fa-angle-left"></i></button>',
        nextArrow: '<button type="button" class="slick-next"><i class="fa fa-angle-right"></i></button>'
    });

    $('.feature-tab > .carousel-custom-feature').slick({
        slidesToShow: 3,
        autoplay: true,
        responsive: [
            {
                breakpoint: 992,
                settings: {
                    slidesToShow: 2,
                    infinite: true,
                    arrows: false
                }
            }, {
                breakpoint: 768,
                settings: {
                    slidesToShow: 1,
                    infinite: true,
                    arrows: false
                }
            }],
        prevArrow: '<button type="button" class="slick-prev"><i class="fa fa-angle-left"></i></button>',
        nextArrow: '<button type="button" class="slick-next"><i class="fa fa-angle-right"></i></button>'
    });

    $('.carousel-custom-reason').slick({
        responsive: [
            {
                breakpoint: 3840,
                settings: {
                    slidesToShow: 4,
                    infinite: true,
                    arrows: false
                }
            }, {
                breakpoint: 992,
                settings: {
                    slidesToShow: 2,
                    infinite: true,
                    arrows: false,
                    autoplay: true
                }
            }, {
                breakpoint: 768,
                settings: {
                    slidesToShow: 1,
                    infinite: true,
                    arrows: false,
                    autoplay: true
                }
            }]
    });
    $('.carousel-custom-brand').slick({
        responsive: [
            {
                breakpoint: 3840,
                settings: {
                    slidesToShow: 6,
                    infinite: true,
                    arrows: false
                }
            }, {
                breakpoint: 992,
                settings: {
                    slidesToShow: 2,
                    infinite: true,
                    arrows: false,
                    autoplay: true
                }
            }, {
                breakpoint: 768,
                settings: {
                    slidesToShow: 1,
                    infinite: true,
                    arrows: false,
                    autoplay: true
                }
            }]
    });

    $('.carousel-custom-comment').slick({
        slidesToShow: 1,
        autoplay: true,
        arrows: false
    });
    $('.carousel-custom-type').slick({
        slidesToShow: 3,
        autoplay: false,
        arrows: true,
        responsive: [
            {
                breakpoint: 992,
                settings: {
                    slidesToShow: 4,
                    infinite: true,
                    arrows: true,
                    autoplay: true
                }
            },{
                breakpoint: 768,
                settings: {
                    slidesToShow: 3,
                    infinite: true,
                    arrows: true
                }
            }, {
                breakpoint: 480,
                settings: {
                    slidesToShow: 3,
                    infinite: true,
                    arrows: true
                }
            }],
        prevArrow: '<button type="button" class="slick-prev-type"><i class="fa fa-angle-left"></i></button>',
        nextArrow: '<button type="button" class="slick-next-type"><i class="fa fa-angle-right"></i></button>'
    });

});
function initMap() {
    var coordinates = {lat: 21.566896, lng: 39.169674};
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

