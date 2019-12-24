$("body").on("click", "#confirmOrderCancel", cancelClick);

function cancelClick() {
    $.ajax({
        url: $(this).val(),
        type: "POST",
        data: {
            __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
        },
        dataType: "json",
        success: function (result) {
            if (result) {
                $("#cancelModal .close").click();
                window.location.replace($(".delete").data('replace'));
            }
            else {
                $("#cancelModal .close").click();
            }
        }
    });
}

$(document).on("click", ".cancel-order", function () {
    var action = $(this).data("url");
    $(".modal-footer #confirmOrderCancel").val(action);
});
