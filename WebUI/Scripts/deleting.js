$(function () {
    $('.glyphicon-remove').on('click', function (event) {
        var id = $(event.currentTarget).attr('data-id');
        $('#deletingModal').attr('data-id', id);
        $('#deletingModal').modal();
    });

    $('#yes').on('click', function () {
        var id = $('#deletingModal').attr('data-id'),
            userId = $('.self-container').attr('id');
        $.post('../../Album/Delete', {id:id, userId:userId});
        $('#'+id).remove();
        $('#deletingModal').modal('hide');
    })
});