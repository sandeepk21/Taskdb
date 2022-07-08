$(document).ready(function () {
    
    $("#employeeeditform").on('submit', function (e) {
        e.preventDefault();
        var form = $('#employeeeditform')[0];
        var data = new FormData(form);

        $.ajax({
            type: "POST",
            enctype: 'multipart/form-data',
            url: "/Admin/EmployeeEdit",
            data: data,
            processData: false,
            contentType: false,
            success: function (data) {
              
                alert(data);
                window.location.href = '/Admin/AddEmployee';
              
            },
            error: function (e) {

            }

        })



    })
})