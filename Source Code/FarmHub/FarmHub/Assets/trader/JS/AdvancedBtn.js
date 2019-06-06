$(document).ready(function () {
    //Toogle AdvanceSearch

    $("#PurchaseRangeSearchTbl").hide();


    $("#advanced_search").click(function (e) { 
        e.preventDefault();

        $("#Purchasedatetimebegin").val("");
        $("#Purchasedatetimeend").val("");
        $("#Purchaseweightbegin").val("");
        $("#Purchaseweightend").val("");
       
        $("#purchaseOfferTbl thead tr:eq(1)").toggle(1000);
        $("#saleOfferTbl thead tr:eq(1)").toggle(1000);
        $("#PurchaseRangeSearchTbl").toggle(1000);

        var purchaseTable = $('#purchaseOfferTbl').DataTable();
        var saleTable = $('#saleOfferTbl').DataTable();
        purchaseTable.draw();
        saleTable.draw();

       

    });
});

