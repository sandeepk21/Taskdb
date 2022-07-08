$(document).ready(function () {
    $("#employeeform").parsley();
    
    $("#employeeform").on('submit', function (e) {
        e.preventDefault();
        var form = $('#employeeform')[0];
        var data = new FormData(form);
       
        $.ajax({
            type: "POST",
            enctype: 'multipart/form-data',
            url: "/Admin/AddEmployee",
            data: data,
            processData: false,
            contentType: false,
            success: function (data) {
                alert(data);
                $("#searchbtn").click();
                $('#employeeform')[0].reset();
                
                
            },
            error: function (e) {

            }

        })



    })

    
    
})