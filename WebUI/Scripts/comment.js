function indexOf(array, element) {
    for (var i = 0; i < array.length; i++) {
        if (array[i] == element) {
            return i;
        }
    }
    return -1;
};

var photos = $('.photo');

$('#send-comment').on('click', function () {
    var text = $('#text-comment').val(),
        photoId = $('.modal-photo').attr('data-id');
    $('#text-comment').val('');
    $.post('../../Comment/AddComment', { text: text, photoId: photoId }, function (data) {
        $('#comments-container').append('<div class="block-margin"><img class="user-comment-photo" src="../../Photo/GetPhoto?pictureId=' + data.UserPhotoId + '" /><div class="block-comment"><div>' + data.Name + '</div><div class="comment-text">' + data.Text + '</div></div></div>');
    });
});

$('.photo').on('click', function (event) {
    $('#comments-container').empty();
    var currentPhoto = $(event.currentTarget),
        id = currentPhoto.attr('data-id'),
        from;
    $.get('../../Comment/GetComments?photoId=' + id, function (data) {
        for (var i = 0; i < data.length; i += 1) {
            $('#comments-container').append('<div class="block-margin"><img class="user-comment-photo" src="../../Photo/GetPhoto?pictureId=' + data[i].UserPhotoId + '" /><div class="block-comment"><div>' + data[i].Name + '</div><div class="comment-text">' + data[i].Text + '</div></div></div>');
        }
    });
});

