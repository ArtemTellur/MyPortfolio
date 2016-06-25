$(function () {
    var photos = $('.photo'),
            modal = $('#myModal'),
            currentPhoto,
            count,
            photoPlace = $('.modal-photo');

    $('.photo').on('click', function (event) {
        function indexOf(array, element) {
            for (var i = 0; i < array.length; i++) {
                if (array[i] == element) {
                    return i;
                }
            }
            return -1;
        };
        currentPhoto = $(event.currentTarget),
        count = indexOf(photos, currentPhoto[0]),

        $(photoPlace).attr('src', currentPhoto.attr('src'));
        $(photoPlace).attr('data-id', currentPhoto.attr('data-id'));
        modal.modal();
    });

    $('.left').on('click', function () {
        var id;
        photos = $('.photo');
        count -= 1;
        if (count === -1) {
            count = photos.length - 1;
        }
        $(photoPlace).attr('src', $(photos[count]).attr('src'));
        $(photoPlace).attr('data-id', $(photos[count]).attr('data-id'));
        id = $(photoPlace).attr('data-id');
        $('#comments-container').empty();
        $.get('../../Comment/GetComments?photoId=' + id, function (data) {
            for (var i = 0; i < data.length; i += 1) {
                $('#comments-container').append('<div class="block-margin"><img class="user-comment-photo" src="../../Photo/GetPhoto?pictureId=' + data[i].UserPhotoId + '" /><div class="block-comment"><div>' + data[i].Name + '</div><div class="comment-text">' + data[i].Text + '</div></div></div>');
            }
        });
        $.get('../../Like/GetLikes?photoId=' + id, function (data) {
            $('#likesLength').empty().append(data.length);
        });
    });

    $('.right').on('click', function () {
        count += 1;
        photos = $('.photo');
        if (count === photos.length) {
            count = 0;
        }
        $(photoPlace).attr('src', $(photos[count]).attr('src'));
        $(photoPlace).attr('data-id', $(photos[count]).attr('data-id'));
        id = $(photoPlace).attr('data-id');
        $('#comments-container').empty();
        $.get('../../Comment/GetComments?photoId=' + id, function (data) {
            for (var i = 0; i < data.length; i += 1) {
                $('#comments-container').append('<div class="block-margin"><img class="user-comment-photo" src="../../Photo/GetPhoto?pictureId=' + data[i].UserPhotoId + '" /><div class="block-comment"><div>' + data[i].Name + '</div><div class="comment-text">' + data[i].Text + '</div></div></div>');
            }
        });
        $.get('../../Like/GetLikes?photoId=' + id, function (data) {
            $('#likesLength').empty().append(data.length);
        });
    });
});