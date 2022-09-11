// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {

    $("#btnRegister").submit( function (e) {
         
        e.preventDefault();

        var url = "Success";    
        $.ajax({
            async: true,
            type: "get",
            data : Msg,
            url: "Success",
            dataType: "text",
            success: function (response) {

            }
        });

    });

});
