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


    $('.filter-box-close').on('click', function(){
        $('.filter-toggle').animate({left: 0}, 500, function() {
            $('a > i',this).removeClass('fa-close').addClass('fa-forward');
            $('.filter-toggle').fadeIn(100);
        });
        filter_box.animate({left: -filter_box.width()}, 500, function() {
            $('.filter-toggle').removeClass('hide-filter');
            filter_box.removeClass('active');
        });
    });

    $('.filter-toggle').on('click', function(){
            $(this).animate({left: filter_box.width()}, 500);
            filter_box.animate({left: '0'}, 500, function() {
                $('.filter-toggle').addClass('hide-filter');
                $('.filter-toggle').fadeOut(100);
                filter_box.addClass('active');
            });
    });

    $("#slider").bind("valuesChanging", function (e, data) {
        console.log("Something moved. min: " + data.values.min + " max: " + data.values.max);
    });

    var html = '<div class="light-gallery"><a href="./assets/images/auto_eva.png"><img src="./assets/images/auto_eva.png"></a><a href="./assets/images/auto_eva.png"><img src="./assets/images/auto_eva.png"></a><a href="./assets/images/auto_eva.png"><img src="./assets/images/auto_eva.png"></a><a href="./assets/images/auto_eva.png"><img src="./assets/images/auto_eva.png"></a><a href="./assets/images/auto_eva.png"><img src="./assets/images/auto_eva.png"></a></div>';
    var lg = $('.light-gallery');
    lg.lightGallery();
    $('button.slide-show').on('click', function() {
        lg.remove();
        $('body').append(html);
        lg = $('.light-gallery');
        lg.lightGallery();
        $('a', lg).eq(0).trigger('click');
    });

    $('#slide_show').on('hidden.bs.modal', function () {
        $('.custom-slide-show').slick('unslick');
    });
    $('.btn-qr').on('click', function(){
       $(this).next('.pop-up').fadeIn('200');
        event.stopPropagation();
    });

    $('.pop-up .pop-up-anchor').on('click', function(){
        $(this).closest('.pop-up').fadeOut('200')
    });

    $(document).on('click', function() {
        if($('.pop-up').is(':visible')) {
            $('.pop-up').fadeOut(200)
        }
    });
});
