// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $(document).on('click', function (e) {
        const X = e.pageX;
        const Y = e.pageY;

        console.log(`Клик по координатам: X=${X}, Y=${Y}`);

        $.ajax({
            type: "POST",
            data: {
                x: X,
                y: Y
            },
            url: "https://localhost:7278/?handler=Click",
            headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },


            success: function (result) {
                document.getElementById("pos-x").innerText = e.pageX;
                document.getElementById("pos-y").innerText = e.pageY;
                console.log("Успешный ответ:", result);

                $('#word').addClass('word');
                setTimeout(() => { $('#word').removeClass('word'); }, 4000);     
            },
            error: function (xhr, status, error) {
                console.error("Ошибка отправки данных:", error);
            }
        });
    });
});