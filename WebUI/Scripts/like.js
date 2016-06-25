$(function () {
    $('.photo').on('click', function (event) {
        $('#likesLength').empty();
        var currentPhoto = $(event.currentTarget),
            photoId = currentPhoto.attr('data-id'),
            from;
        $.get('../../Like/GetLikes?photoId=' + photoId, function (data) {
            $('#likesLength').empty().append(data.length);
        });
    });

    $('#like').on('click', function () {
        var photoId = $('#modal-photo').attr('data-id');
        $.post('../../Like/Toggle',{photoId: photoId}, function (data) {
            var likesLength = parseInt($('#likesLength').html(), 10);
            if (data) {
                $('#likesLength').html(likesLength + 1);
            }
            else {
                $('#likesLength').html(likesLength - 1);
            }
        });
    });
});