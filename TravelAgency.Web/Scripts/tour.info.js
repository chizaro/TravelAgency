$(".show-tour-info").on("click", tourDetailsClick);

function tourDetailsClick() {
    $.ajax({
        url: $(this).data("url"),
        type: "GET",
        dataType: "html",
        success: function (data) {
            $("#tour-info").html(data);
            $('#tourInfoModal').modal("show");
        }
    });
}