$("body").on("click", "#confirm", deleteClick);

function deleteClick() {
    $.ajax({
        url: $(this).val(),
        type: "POST",
        data: {
            __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
        },
        dataType: "json",
        success: function (result) {
            if (result) {
                $("#deleteModal .close").click();
                window.location.replace($(".delete").data('replace'));
            }
            else {
                $("#deleteModal .close").click();
            }
        }
    });
}

$(document).on("click", ".delete", function () {
    var action = $(this).data("url");
    $(".modal-footer #confirm").val(action);
});
