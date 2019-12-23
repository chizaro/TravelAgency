$("form").submit(function (event) {
    let dateFrom = $("#DateFrom");
    if (dateFrom.val() === "")
        dateFrom.val("0001-01-01");

    let dateTo = $("#DateTo");
    if (dateTo.val() === "")
        dateTo.val("0001-01-01");

});