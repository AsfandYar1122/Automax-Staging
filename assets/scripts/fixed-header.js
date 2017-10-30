$(function() {
    $(document).on('scroll', function() {
        if($(this).scrollTop() >= $('.top-nav').height()) {
            $('.navbar.navbar-default').addClass('navbar-fixed-top');
        } else {
            $('.navbar.navbar-default').removeClass('navbar-fixed-top');
        }
        console.log($(this).scrollTop());
        console.log($('.top-nav').height());
    });
});