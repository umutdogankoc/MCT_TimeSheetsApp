$(document).ready(function () {
    $("#btn_Reset_Pass_Spinner").hide();
});

$(document).ajaxStart(function () {
    $("#btn_Reset_Pass").hide();
    $("#btn_Reset_Pass_Spinner").show();
    $("#txt_UserName_Forgot_Pass").attr('disabled', true);

});

$("#CP_Forgot_Pass_Form").submit(function (event) {

    event.preventDefault();
    var model = {};
    model.Username = $("#txt_UserName_Forgot_Pass").val();
    PostResetPassword(model);
});

function PostResetPassword(model) {

    $.ajax({
        url: '/Login/SendNewPasswordEmail',
        contentType: 'application/json;content=UTF-8',
        dataType: 'json',
        async: true,
        data: JSON.stringify(model),
        type: 'POST',
        success: function (response) {
            if (response.State == true) {
                alertify.set('notifier', 'position', 'top-center');
                var msg = alertify.success(response.SuccessMessage, 5);
                msg.callback = function (isClicked) {
                    if (isClicked) {
                        window.location.href = response.RedirectUrl;
                    }
                    else {
                        window.location.href = response.RedirectUrl;
                    }
                }
            }
            else {
                alertify.set('notifier', 'position', 'top-center');
                alertify.error(response.ErrorMessage);
            }

        },

        error: function (response) {
            alertify.set('notifier', 'position', 'top-center');
            alertify.error(response.ErrorMessage);
        },
    });


}
