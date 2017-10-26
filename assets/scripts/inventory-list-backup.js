$(function () {
    var filter_box = $('.filter-box');
    //$("#slider").rangeSlider({
    //    bounds: {min: 10000, max: 1000000},
    //    defaultValues:{min: 50000, max: 500000},
    //    valueLabels:"change",
    //    durationIn: 1000,
    //    durationOut: 1000,
    //    arrows: false
    //});

    $('.filter-toggle').on('click', function(){
        if($(this).hasClass('hide-filter')) {
            $(this).animate({left: 0}, 500, function() {
                $('a > i',this).removeClass('fa-close').addClass('fa-forward');
            });
            filter_box.animate({left: -filter_box.width()}, 500, function() {
                $('.filter-toggle').removeClass('hide-filter');
            });
        } else {
            $(this).animate({left: filter_box.width()}, 500, function() {
                $('a > i',this).removeClass('fa-forward').addClass('fa-close');
            });
            filter_box.animate({left: '0'}, 500, function() {
                $('.filter-toggle').addClass('hide-filter');
            });
        }
    });

    $("#slider").bind("valuesChanging", function (e, data) {
        console.log("Something moved. min: " + data.values.min + " max: " + data.values.max);
    });

   // $('button.slide-show').on('click', function(){
        //$.ajax({
        //        url: '/path/to/file',
        //        type: 'default GET (Other values: POST)',
        //        dataType: 'default: Intelligent Guess (Other values: xml, json, script, or html)',
        //        data: {param1: 'value1'},
        //    })
        //    .done(function(dataGet) {
        //        $('.custom-slide-show').html(dataGet);
        //        $('.custom-slide-show').slick({
        //            slidesToShow: 1,
        //            autoplay: true,
        //            arrows: false
        //        });
        //        $($(this).data('target')).modal();
        //    })
        //    .fail(function() {
        //        console.log("error");
        //    })
        //    .always(function() {
        //        console.log("complete");
        //    });
        //$('.custom-slide-show').html();
        //$('.custom-slide-show').slick({
        //    slidesToShow: 1,
        //    autoplay: true,
        //    arrows: false
        //});
        //$($(this).data('target')).modal();

    //});

    //$('#slide_show').on('hidden.bs.modal', function () {
    //    $('.custom-slide-show').slick('unslick');
    //});
    $('.btn-qr').on('click', function(){
        $(this).next('.pop-up').fadeIn('200');
        event.stopPropagation();
    });
    $('.pop-up .pop-up-anchor').on('click', function(){
        $(this).closest('.pop-up').fadeOut('200')
    });
    $(document).on('click', function () {
        if ($('.pop-up').is(':visible')) {
            $('.pop-up').fadeOut(200)
        }
    });
});
