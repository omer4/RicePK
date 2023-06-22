
function InitiateDataTable(id, sortby, sortorder, paging = true, sorting = true) {
    debugger
    var options;
    if (paging == false) {
        options = {
            order: [[sortby, sortorder]],
            "paging": false,
            scrollY: '500px',
            dom: 'Bfrtip',
            scrollX: true,
            scrollCollapse: true,
            "bSort": sorting,
            buttons: [
                'copyHtml5',
                'excelHtml5',
                'csvHtml5',
                {
                    extend: 'pdfHtml5',
                    orientation: 'landscape',
                    pageSize: 'LEGAL'
                }
            ]



        }
    }

    else {
        options = {
            order: [[sortby, sortorder]],
            dom: 'Bfrtip',
            "paging": paging,
            buttons: [
                'copyHtml5',
                'excelHtml5',
                'csvHtml5',
                {
                    extend: 'pdfHtml5',
                    orientation: 'landscape',
                    pageSize: 'LEGAL'
                }
            ]
        }
    }
    $('#' + id).DataTable(

        options,

    );
}

function setdatevalueifexists() {
    $(".datetime").each(function () {
        debugger
        if ($(this).attr("value") != "") {

            var converteddateandtime = $(this).attr("value").split(" ");
            var converteddate = converteddateandtime[0].split("-");
            var month = converteddate[1].length > 1 ? converteddate[1] : '0' + converteddate[1];
            var day = converteddate[2].length > 1 ? converteddate[2] : '0' + converteddate[2];
            $(this).val(converteddate[0] + "-" + month + "-" + day);

        }
    });

}
function InitiateMultiSelect(classname) {
    $("." + classname).select2({
        width: 'resolve'
    });
}
function showloader() {
    $(".preloader").css("display", "flex");
}
function hideloader() {
    $(".preloader").css("display", "none");
}
function showsweetalert(title, text, icon) {
    swal({
        title: title,
        text: text,
        icon: icon,
    });
}
$(function () {
    //setup ajax error handling
    $.ajaxSetup({
        error: function (x, status, error) {
            hideloader();
            debugger
            if (x.status == 403) {
                showsweetalert("Error", "Sorry, your session has expired. Please login again to continue", "error");
                window.location.href = "/Account/Login";
            }
            else {
                showsweetalert("An error occurred", error, "error");
            }
        }
    });
});
$(document).ajaxError(function myErrorHandler(event, xhr, ajaxOptions, thrownError) {
    hideloader();
    debugger
    if (xhr.responseText.indexOf("Authorization has been denied for this request") >= 0) {
        $("#logoutForm").submit();
    }
    else {
        showsweetalert("An error occurred", xhr.responseText, "error");
    }

});
$('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
    $.fn.dataTable.tables({ visible: true, api: true }).columns.adjust();
});
$('.modal').on('shown.bs.modal', function (e) {
    $.fn.dataTable.tables({ visible: true, api: true }).columns.adjust();
});