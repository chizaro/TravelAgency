$("form").on("submit", (event) => {
    event.preventDefault();
    createOrder();
});

function createOrder() {
    $.ajax({
        url: "/Orders/Create",
        type: "POST",
        data: {
            __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val(),
            viewModel: getFormData($("form"))
        },
        dataType: "json",
        success: function (result) {
            if (result) {
                $("form")[0].reset();
                $('#orderModal').modal("show");
            }
        }
    });
}

function getFormData($form) {
    let formValues = $form.serializeArray();
    let formData = {};

    $.map(formValues, function (obj, i) {
        formData[obj['name']] = obj['value'];
    });

    return formData;
}
