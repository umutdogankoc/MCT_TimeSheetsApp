$(document).ready(function () {
    $("#btn_Confirm_New_Pass_Spinner").hide();
    $("#btn_Confirm_New_Pass").attr("disabled", true);
    $("#txt_Forgot_Pass_Confirm").keyup(checkPasswordMatch);
});

$(document).ajaxStart(function () {
    $("#btn_Confirm_New_Pass").hide();
    $("#btn_Confirm_New_Pass_Spinner").show();
    $("#txt_Forgot_Pass").attr('disabled', true);
    $("#txt_Forgot_Pass_Confirm").attr('disabled', true);

});

$("#CP_Reset_Pass_Form").submit(function (event) {

    event.preventDefault();
    var model = {};
    model.NewPassword = $("#txt_Forgot_Pass_Confirm").val();
    model.UserCode = $("#PassResetUserID").attr('userId');
    PostNewPassword(model);

})

function checkPasswordMatch() {
    var password = $("#txt_Forgot_Pass").val();
    var confirmPassword = $("#txt_Forgot_Pass_Confirm").val();

    if (password != confirmPassword) {
        $("#divCheckPasswordMatch").html("Passwords do not match!");
        $("#divCheckPasswordMatch").addClass("alert alert-danger");
        $("#btn_Confirm_New_Pass").attr("disabled", true);

    }
    else {
        $("#divCheckPasswordMatch").html("Passwords match.");
        $("#divCheckPasswordMatch").removeClass("alert alert-danger");
        $("#divCheckPasswordMatch").addClass("alert alert-success");
        $("#btn_Confirm_New_Pass").attr("disabled", false);

    }
}

function PostNewPassword(model) {

    $.ajax({
        url: '/Login/SetNewPassword',
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
