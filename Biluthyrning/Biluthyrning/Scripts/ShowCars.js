$(function () {

    $(function () {
        $("#LitenBil").click(function () {
            if ($(this).is(":checked")) {
                $("#resultsLitenBil").show();

            } else {
                $("#resultsLitenBil").hide();
            }
        });
    });

    $(function () {
        $("#Van").click(function () {
            if ($(this).is(":checked")) {
                $("#resultsVan").show();

            } else {
                $("#resultsVan").hide();
            }
        });
    });

    $(function () {
        $("#Minibuss").click(function () {
            if ($(this).is(":checked")) {
                $("#resultsMinibuss").show();

            } else {
                $("#resultsMinibuss").hide();
            }
        });
    });
});
