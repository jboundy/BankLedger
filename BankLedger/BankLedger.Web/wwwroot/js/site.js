$("#loginAccount").click(function () {
    var dataType = 'application/x-www-form-urlencoded; charset-utf-8';
    var data = $('form').serialize();
    $.ajax({
        url: 'Home/AccountLogin',
        data: data,
        contentType: dataType,
        type: 'GET'
    });

});

$('#createAccount').click(function () {
    var dataType = 'application/x-www-form-urlencoded; charset-utf-8';
    var data = {
        'username': $('.modal-body#Username').val(),
        'password': $('.model-body#Password').val()
    };

    $.ajax({
        url: 'Home/AccountCreate',
        data: data,
        contentType: dataType,
        type: 'POST'
    });
});