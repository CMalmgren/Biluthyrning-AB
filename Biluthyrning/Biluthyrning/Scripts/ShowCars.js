$(function () {

        $("#CheckLitenBil").click(function () {
            if ($(this).is(":checked")) {
                $("#resultsLitenBil").show();

            } else {
                $("#resultsLitenBil").hide();
            }
        });
    });

    $(function () {
        $("#CheckVan").click(function () {
            if ($(this).is(":checked")) {
                $("#resultsVan").show();

            } else {
                $("#resultsVan").hide();
            }
        });
    });

    $(function () {
        $("#CheckMinibuss").click(function () {
            if ($(this).is(":checked")) {
                $("#resultsMinibuss").show();

            } else {
                $("#resultsMinibuss").hide();
            }
        });
    });
});
