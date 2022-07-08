$(document).ready(function () {
    
    /*$("#dd1").hide();*/
    $("#myform").parsley();
   
    
    $("#myform").on('submit', function (e) {
        e.preventDefault();
        var first = $("#FirstName").val()
        var form = $('#myform')[0];
        var data = new FormData(form);
        var first = $("#FirstName").val()
        var last = $("#LastName").val()
        var user = $("#Username").val()
        var role = $("#RoleId").val()
        var gender = $("#GenderId").val()
        var city = $("#CityId").val()
        var nickname = $("#UserNickName").val()
        var password = $("#Password").val()
        var email = $("#Email").val()
            $.ajax({
                type: "POST",
                enctype: 'multipart/form-data',
                url: "/Admin/AddUser",
                data: data,
                processData: false,
                contentType: false,
                success: function (data) {
                    $("#dd1").show();
                    $("#dd1").html(data);
                    setTimeout(function () {
                        $('#dd1').fadeOut('slow');

                    }, 2000);
                    $("#Usersearchbtn").click();
                    $('#myform')[0].reset();
                },
                error: function (e) {

                }

            })
        
        
        
    })
    
    $("#Country").change(function () {
       
        var id = $("#Country").val();
        
        $.ajax({
            type:"POST",
            url: "/Admin/Bindstate",
            data: { id: id },
            success: function (data) {
                
                console.log(data);
                var v="<option>--select--</option>";
                $.each(data, function (i, v1) {
                    v += "<option value=" + v1.StateId + ">" + v1.State_Name + "</option>";
                });
                $("#StateId").html(v);
            },
            error: function (e) {

            }
        })
    })
    $("#StateId").change(function () {

        var id = $("#StateId").val();

        $.ajax({
            type: "POST",
            url: "/Admin/Bindcity",
            data: { id: id },
            success: function (data) {
                console.log(data);
              
                var v = "<option>--select--</option>";
                $.each(data, function (i, v1) {
                    v += "<option value=" + v1.CityId + ">" + v1.City_Name + "</option>";
                });
                $("#CityId").html(v);
            },
            error: function (e) {

            }
        })
    })
})
$("#usereditfrom").on('submit', function (e) {
    e.preventDefault();
    var form = $('#usereditfrom')[0];
    var data = new FormData(form);

    $.ajax({
        type: "POST",
        enctype: 'multipart/form-data',
        url: "/Admin/UserEdit",
        data: data,
        processData: false,
        contentType: false,
        success: function (data) {
            alert(data);
            window.location.href = '/Admin/AddUser';
            
        },
        error: function (e) {

        }

    })



})
