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

$('#deposit').click(function () {
    CallAction('Deposit');
});

$('#withdraw').click(function () {
    CallAction('Withdraw');
});

$('#transactionHistory').click(function() {
    $.ajax({
        url: 'TransactionHistory',
        contentType: 'json',
        type: 'GET'
    });
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
    console.log(amount);
    console.log(account);
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
    });
};