$(function () {
    $('.input-search').on('keyup', function () {
        var subString = $('.input-search').val();
        $.get('../../User/Search?subString=' + subString, function (data) {
            var i = 0;
            cleanContainer();
            for (; i < data.length; i += 1) {
                render(data[i]);
            }
        });
    });

    function render(item) {
        $('#tableBody').append('<tr><td>' + '<img src="../../Photo/GetPhoto?pictureId=' + item.PictureId + '" style="max-width:50px; max-height:50px" />' + '</td><td>' + item.Name + '</td><td>' + item.Age + '</td><td>' + item.Email + '</td><td>' + '<a href="../../User/UserPage?id='+item.Id+'">Перейти на страницу</a>' + '</td></tr>')
    };

    function cleanContainer() {
        $('#tableBody').empty();
    }
});