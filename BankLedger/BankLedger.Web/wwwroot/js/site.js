$("#loginAccount").click(function (e) {
    e.preventDefault();
    var data = $('#loginAccountForm').serializeArray();
    $.ajax({
        url: 'Home/AccountLogin',
        data: {
            username: data[0].value,
            password: data[1].value
        },
        contentType: 'json',
        type: 'GET'
    });

    var account = {
        Username: data[0].value,
        Password: data[1].value
    };

    $.ajax({
        url: 'Balance/Index',
        data: account,
        contentType: 'json',
        type: 'GET'
    });
});

$('#createAccount').click(function () {
    var dataType = 'application/x-www-form-urlencoded; charset-utf-8';
    var data = $('#postAccount').serialize();
    $.ajax({
        url: 'Home/AccountCreate',
        data: data,
        contentType: dataType,
        type: 'POST'
    });
});