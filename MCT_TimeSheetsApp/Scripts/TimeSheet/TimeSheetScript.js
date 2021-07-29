function UpdateResourceTimeSheetLine(model) {

    alertify.defaults.transition = "slide";
    alertify.defaults.theme.ok = "btn btn-primary";
    alertify.defaults.theme.cancel = "btn btn-danger";
    alertify.defaults.theme.input = "form-control";
    alertify.confirm('Are You Sure?', 'Do you want to update time sheet?', function () {

        $.ajax({
            url: '/Update/UpdateResourceTimeSheet',
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
                        location.reload();
                    }, 5000);

                }
                else {
                    alertify.set('notifier', 'position', 'top-center');
                    alertify.error(response.ErrorMessage, 5);
                    setTimeout(function () {
                        location.reload();
                    }, 5000);
                }
            },
            error: function (response) {

                alertify.set('notifier', 'position', 'top-center');
                alertify.error(response.ErrorMessage, 5);
                setTimeout(function () {
                    location.reload();
                }, 5000);

            }
        });
    }, function () {
        alertify.set('notifier', 'position', 'top-center');
        alertify.error().setContent('<div style="color:#FFFFFF">Update Action Cancelled</div>');
    });
}