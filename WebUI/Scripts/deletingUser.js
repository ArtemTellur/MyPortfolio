$(function () {
    $('.deleteUser').on('click', function (event) {
        var id = $(event.currentTarget).attr('id');
        $('#deletingModal').attr('data-id', id);
        $('#deletingModal').modal();
    });

    $('#yes').on('click', function () {
        var id = $('#deletingModal').attr('data-id');
        $.post('../../User/Delete', { id: id });
        $('#' + id).remove();
        $('#deletingModal').modal('hide');
    })
});