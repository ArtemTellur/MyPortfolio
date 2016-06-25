$(function () {
    $('#deletePhoto').on('click', function () {
        var id = $('#modal-photo').attr('data-id'),
            userId = $('.self-container').attr('id');
        $.post('../../Photo/Delete', { id: id, userId: userId });
        $('#' + id).remove();
        $('#myModal').modal('hide');
    });
});