$(document).ready(function () {
    $('.item').css('height', $(window).height());
});
$(window).resize(function () {
    $('.item').css('height', $(window).height());
});