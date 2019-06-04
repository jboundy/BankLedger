var dataType = 'application/x-www-form-urlencoded; charset-utf-8';

$('#createAccount').click(function () {
    var data = $('#postAccount').serialize();
    $.ajax({
        url: 'Home/AccountCreate',
        data: data,
        contentType: dataType,
        type: 'POST'
    });
});

$('#loginAccount').click(function() {
    var data = $('#loginAccountForm').serialize();
    $.ajax({
        url: 'Home/AccountLogin',
        data: data,
        contentType: dataType,
        type: 'GET'
    }).done(function (result, status) {
        if (status !== 'success') {
            $('#errorContent').text(result);
            $('.alert').alert();
        } else {
           window.location.href = result;
        }
    });
});

$('#deposit').click(function () {
    var accountUpdate = CallAction('Deposit');
    $('#currentBalance').text('Current Balance: $' + accountUpdate.balance);
    $('#Balance').val("0");
});

$('#withdraw').click(function () {
    var accountUpdate = CallAction('Withdraw');
    $('#currentBalance').text('Current Balance: $' + accountUpdate.balance);
});

$('#transactionHistory').click(function () {
    document.location.reload(true);
});

var CallAction = function(url) {
    var data = $('#accountBalanceForm').serializeArray();
    var amount = data[0].value;
    var accountHidden = $('#ActiveAccount').serializeArray();
    var obj = JSON.parse(accountHidden[0].value);
    var account = {
        Username: obj.username,
        Password: obj.password
    };
    $.ajax({
        url: url,
        data: {
            account: account,
            amount: amount
        },
        contentType: dataType,
        type: 'PUT'
    }).done(function(result) {
        obj.balance = result;
        $('#currentBalance').text('Current Balance: $' + result);
    });
    return obj;
};