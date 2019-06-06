

$('document').ready(function () {
    var saleOfferId = $('#saleOfferId').val();

    var suitablePurchaseOfferTbl = $("#suitablePurchaseOfferTbl").DataTable({
        "ajax": {
            "url": `${window.location.origin}/FarmerOfferDetail/GetSuitableListPurchase?saleOfferId=${saleOfferId}`,
            "type": "GET",
            "datatypye": "json"
        },
        "pageLength": 5,
        "columns": [
            { "data":"traderName"},
            { "data": "productName" },
            {
                "data": "seedName"
               
            },
            { "data": "quantity" },
            { "data": "massName" },
            { "data": "price" },
            { "defaultContent": '<button type="button" class="small blue button">Xem chi tiết</button>' },

        ],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Vietnamese.json",
            searchPlaceholder: "Nhập từ khóa"
        },

    });

    var purchaseOfferFromSaleOffer = $('#purchaseOfferFromSaleOffer').val();

    $("#purchaseOfferFromSaleOffer").DataTable({
        paging: true,
        scrollCollapse: true,
        "ajax": {
            "url": `${window.location.origin}/FarmerOfferDetail/PurchaseOfferListBySaleOfferID?saleOfferId=${saleOfferId}`,
            dataSrc: ""
        },
        "pageLength": 5,
        "columns": [
            { "data":"endTransDay"},
            { "data": "traderName" },
            {
                "data": "productName",
                "render": function (data, type, rowData) {
                    return data + ' (' + rowData['seedName'] + ')';
                },
            },
            {
                "data": "seedName",
                visible: false
            },
            {
                "data": "quantity",
                "render": function (data, type, rowData) {
                    return data + ' (' + rowData['unitName'] + ')';
                },
            },
            { "data": "unitName" },
            { "data": "price" },
            { "data": "totalMoney" },
            { "data":"StatusName"},
            {
                "render": function (data, type, rowData) {

                    var agreebtnHTML = '<button type="button" class="small green button" role="agreeBtn"  data-toggle="Detailtooltip" title="Đồng ý" >Đồng Ý </button>';
                    var rejectbtnHTML = ' <button class="small red button" type="button" role="rejectBtn" data-toggle="Deletetooltip" title="Từ Chối">Từ Chối </button >';

                    return agreebtnHTML + rejectbtnHTML
                },
            }
        ],

        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Vietnamese.json"
        }
    });

    
    var suitablePurchaseOfferTbl = $("#purchaseOfferDetailsTbl");
    var purchaseOfferBySaleOffer = $("#purchaseOfferFromSaleOffer");

    // Agree button
    purchaseOfferBySaleOffer.on('click', 'button[role="agreeBtn"]', function () {
        var transactionId = purchaseOfferBySaleOffer.DataTable().row($(this).closest('tr')[0]).data()['transId'];
        var purchaseOfferQuantity = purchaseOfferBySaleOffer.DataTable().row($(this).closest('tr')[0]).data()['quantity'];
        var unitName = purchaseOfferBySaleOffer.DataTable().row($(this).closest('tr')[0]).data()['unitName'];


        var remainQuantity = $("#remainQuantity").val();
        var counterOfferQuantity = 0;
        var a = 1;

        //alert("podId: " + purchaseOfferId + " remain: " + remainQuantity + " TransId: " + transactionId + "soQuantity: " + saleOfferQuantity);


        $.confirm({

            icon: 'fa fa-question-circle',
            boxWidth: '100%',
            title: 'Đồng Ý',
            content: '<h4>Bạn có chấp nhận thỏa thuận này?</h4>',
            type: 'red',
            typeAnimated: true,
            animationSpeed: 500,
            closeIcon: true,
            closeIconClass: 'fa fa-close',
            escapeKey: true,
            backgroundDismiss: true,

            autoClose: 'cancel|6000',
            buttons: {
                confirm: {
                    text: "Chấp Nhận",
                    action: function () {
                        //alert("transId= " + transactionId + "saleOfferQuantity= " + saleOfferQuantity + "remainQuantity= " + remainQuantity);
                        alert(remainQuantity - purchaseOfferQuantity);
                        if (remainQuantity - purchaseOfferQuantity >= 0) {
                            $.ajax({
                                type: "POST",
                                async: false,
                                "url": `${window.location.origin}/FarmerOfferDetail/AccepOffer?transactionId=` + transactionId ,
                                contentType: "application/json; charset=utf-8",
                                method: 'POST',
                                datatype: "text",
                                serverSide: true,
                                success: function (data) {
                                    window.location.href = window.location.origin + '/Farmer/FarmerOffer/FarmerOfferIndex';
                                },
                                error: function (data) {
                                    alert("Error response is: " + data);
                                }
                            });
                        }
                        //alert(remainQuantity);
                        else if (remainQuantity == 0) {
                            $.confirm({
                                icon: 'fa fa-exclamation-triangle',
                                title: "Lỗi",
                                content: "<h4>Đơn này không thể nhận thêm bất cứ thỏa thuận nào khác! <h4/>",
                                animation: 'left',
                                confirmButton: false,
                                type: 'red',
                                typeAnimated: true,
                                animationSpeed: 500,
                                backgroundDismiss: true,
                                closeIcon: true,
                                closeIconClass: 'fa fa-close',
                            })
                        }

                        else {
                            remainQuantity = $("#remainQuantity").val();
                            alert("remainQuantity: " + remainQuantity);
                            $.confirm({
                                icon: 'fa fa-exclamation-triangle',
                                title: "Lỗi",
                                content: "<h4>Số Lượng đặt vượt quá giới hạn <h4/>",
                                animation: 'left',
                                confirmButton: false,
                                type: 'red',
                                typeAnimated: true,
                                animationSpeed: 500,

                                closeIcon: true,
                                closeIconClass: 'fa fa-close',

                                buttons: {
                                    CounterOffer: {
                                        text: "Thỏa thuận lại",
                                        action: function () {
                                            if (a = 1) {
                                                $.confirm({
                                                    icon: 'fa fa-pencil',
                                                    title: "Thỏa Thuận Lại",
                                                    content: ' <h4>Nhập vào số lượng đặt mới(Tối đa: ' + remainQuantity + ' ' + unitName + ')<h4/> <input id="counterOfferQuantity" type="number" class="btn btn-block" style="border-style:solid;border-width: 1px;">',
                                                    animation: 'left',
                                                    confirmButton: false,
                                                    type: 'red',
                                                    typeAnimated: true,
                                                    animationSpeed: 500,
                                                    closeIcon: true,
                                                    closeIconClass: 'fa fa-close',
                                                    buttons: {
                                                        Confirm: {
                                                            text: "Xác Nhận",
                                                            action: function () {
                                                                counterOfferQuantity = $('#counterOfferQuantity').val();

                                                                $.ajax({

                                                                    type: "POST",
                                                                    "url": `${window.location.origin}/FarmerOfferDetail/CounterOffer?transactionId=` + transactionId + '&counterOfferQuantity=' + counterOfferQuantity,
                                                                    contentType: "application/json; charset=utf-8",
                                                                    method: 'POST',
                                                                    datatype: "text",
                                                                    serverSide: true,

                                                                    success: function (data) {
                                                                        window.location.href = window.location.origin + '/Farmer/FarmerOffer/FarmerOfferIndex';
                                                                    },

                                                                    error: function (data) {
                                                                        alert("Error response is: " + data);
                                                                    }
                                                                });
                                                            }
                                                        },

                                                        Cancle: {
                                                            text: "Hủy"
                                                        }
                                                    }
                                                })
                                            }
                                        }
                                    },

                                    cancle: {
                                        text: "Hủy"
                                    }
                                }
                            })
                        }


                    }

                },
                cancel: {
                    text: "Hủy",
                }
            }
        });

    });
})