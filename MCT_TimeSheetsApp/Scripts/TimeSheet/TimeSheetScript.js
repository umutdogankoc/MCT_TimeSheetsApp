$(document).ready(function () {
    $("#btnCreateNewTimeSheetLineWait").attr('hidden', true);
});
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
            beforeSend: function () {
                $("#target :input").prop("disabled", true);
            },
            type: 'POST',
            success: function (response) {
                if (response.State == true) {
                    alertify.set('notifier', 'position', 'top-center');
                    alertify.success(response.SuccessMessage +'. ' +response.UpdatedLineCount +' lines updated.', 5);
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
                $('.page-loader-wrapper').hide();
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

$(document).ajaxStart(function () {
    $("#btnCreatenewTimeSheetSubmit").attr('disabled', true);
    $("#btnCreateNewTimeSheetCancel").attr('disabled', true);
    $("#btnCreatenewTimeSheetLineSubmit").attr('hidden', true);
    $("#btnCreateNewTimeSheetLineCancel").attr('hidden', true);
    $("#btnCreateNewTimeSheetLineWait").attr('hidden', false);

});

$("#createNewTimeSheetForm").submit(function (event) {

    event.preventDefault();

    var model = {};
    model.StartingDate = $("#NewTS_StartDate").val();

    PostCreateNewTimeSheet(model);
});

function PostCreateNewTimeSheet(model) {

    $.ajax({
        url: '/Update/CreateNewTimeSheet',
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
                alertify.error(response.ErrorMessage);

            }
        },
        error: function (response) {
            alertify.set('notifier', 'position', 'top-center');
            alertify.error(response.ErrorMessage);

        },
    });

}


$(document).on('click', "#btnSelectJobPlanningLine", function (e) {

    e.preventDefault();
    var row = $(this).closest("tr");
    var model = {};
    model.JobNo = row.find("#planLineJobNo").text();
    model.JobTaskNo = row.find("#planLineJobTaskNo").text();
    model.JobPlanDate = row.find("#planLinePlanDate").text();
    model.JobDescription = row.find("#planLineJobDesc").text();

    $('#jobPlanningLinesModal').modal('hide');

    $("#NewTSLine_JobNo").val(model.JobNo);
    $("#NewTSLine_JobTaskNo").val(model.JobTaskNo);
    $("#NewTSLine_JobPDescription").val(model.JobDescription);
    $("#NewTSLine_JobPlanLineNo").val(model.JobNo + ' ' + model.JobTaskNo + ' ' + model.JobPlanDate);


});

$("#btnCreatenewTimeSheetLineSubmit").on('click',function (event) {
    event.preventDefault;

    var newLineModel = {};
    newLineModel.NewLineJobNo = $("#NewTSLine_JobNo").val();
    newLineModel.NewLineJobTaskNo = $("#NewTSLine_JobTaskNo").val();
    newLineModel.NewLineDescription = $("#NewTSLine_JobPDescription").val();
    newLineModel.NewLineWorkType = $("#TimeSheetWorkTypeCode").find('option:selected').attr('id');
    newLineModel.NewTimeSheetLineHeaderNo = $("#lblTimeSheetHeaderNo").text();

    PostCreateTimeSheetLine(newLineModel);
});

function PostCreateTimeSheetLine(newLineModel) {

    $.ajax({
        url: '/Update/CreateNewTimeSheetLine',
        contentType: 'application/json;content=UTF-8',
        dataType: 'json',
        async: true,
        data: JSON.stringify(newLineModel),
        type: 'POST',
        success: function (response) {
            if (response.State == true) {
                alertify.set('notifier', 'position', 'top-center');
                alertify.success(response.SuccessMessage, 5);
                setTimeout(function () {
                    window.location.href = '/Home/TimeSheetLines/?TimeSheetId=' + response.TimeSheetId;
                }, 5000);

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
