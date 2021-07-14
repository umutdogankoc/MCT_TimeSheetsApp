$(document).ready(function () {
    $("#BtnLoginSubmitSpinner").hide();
});

$(document).ajaxStart(function () {
    $("#BtnLoginSubmit").hide();
    $("#BtnLoginSubmitSpinner").show();
    $("#CP_Username").attr('disabled', true);
    $("#CP_Password").attr('disabled', true);

});

$(document).ajaxStop(function () {
    //$("#BtnLoginSubmit").show();
    //$("#BtnLoginSubmitSpinner").hide();
    //$("#CP_Username").attr('disabled', false);
    //$("#CP_Password").attr('disabled', false);

});

$("#CP_Login_Form").submit(function (event) {

    event.preventDefault();

    var model = {};
    model.Username = $("#CP_Username").val();
    model.Password = $("#CP_Password").val();

    PostLoginCredentials(model);
});

function PostLoginCredentials(model) {
    $.ajax({
        url: '/Login/LoginCheck',
        contentType: 'application/json;content=UTF-8',
        dataType: 'json',
        async: true,
        data: JSON.stringify(model),
        type: 'POST',
        success: function (response) {
            if (response.State == true) {
                alertify.set('notifier', 'position', 'top-center');
                alertify.success(response.SuccessMessage, 5);
                setTimeout(function () {
                    window.location.href = response.RedirectUrl;
                }, 5000);
            }
            else {
                alertify.set('notifier', 'position', 'top-center');
                alertify.error(response.ErrorMessage);
                $("#BtnLoginSubmit").show();
                $("#BtnLoginSubmitSpinner").hide();
                $("#CP_Username").attr('disabled', false);
                $("#CP_Password").attr('disabled', false);

            }
        },
        error: function (response) {
            alertify.set('notifier', 'position', 'top-center');
            alertify.error(response.ErrorMessage);
            $("#BtnLoginSubmit").show();
            $("#BtnLoginSubmitSpinner").hide();
            $("#CP_Username").attr('disabled', false);
            $("#CP_Password").attr('disabled', false);

        },
    });
}
