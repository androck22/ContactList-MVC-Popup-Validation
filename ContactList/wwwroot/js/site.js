// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $("#loaderbody").addClass('hide');

    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
});

showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            console.log(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
            var form = $('#form-modal .modal-body form');
            $.validator.unobtrusive.parse(form);

        }
    })
}

jQueryAjaxPost = form => {
    try {
        
        if (!$(form).valid())
            return false;

        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                console.log(res);
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                    $.notify('saved successfully', { globalPosition: 'top center', className: 'success' });
                } else
                {
                    $('#form-modal .modal-body').html(res.html);
                    var form = $('#form-modal .modal-body form');
                    $.validator.unobtrusive.parse(form);
                }
                    
            },
            error: function (err) {
                console.log(err)
            }
        })

    } catch (ex) {
        console.log(ex)
    }

    //to prevent default form submit event
    return false;
}

jQueryAjaxDelete = form => {
    if (confirm('Are you sure to delete this record ?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#view-all').html(res.html);
                    $.notify('deleted successfully', { globalPosition: 'top center', className:'success' });
                },
                error: function (err) {
                    console.log(err)
                }
            })
        } catch (ex) {
            console.log(ex)
        }
    }

    //prevent default form submit event
    return false;
}