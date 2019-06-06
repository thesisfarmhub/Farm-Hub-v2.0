
//--------------------------Date range search----------------------------
$.fn.dataTable.ext.search.push(
    function (settings, data, dataIndex) {
        //var day=$("#Purchasedatetimebegin").val($.datepicker.formatDate('dd MM yy', new Date()));

        var min = $('#Purchasedatetimebegin').datepicker("getDate");
        var max = $('#Purchasedatetimeend').datepicker("getDate");


        var startDate = parseDate(data[0]);

        if (min == null || max == null) { return true; }
        if (startDate <= max && startDate >= min) { return true; }

        return false;
    },

    function (settings, data, dataIndex) {
        var min = parseInt($('#Purchaseweightbegin').val());
        var max = parseInt($('#Purchaseweightend').val());
        var weight = parseFloat(data[2]) || 0; // use data for the age column

        if ((isNaN(min) && isNaN(max)) ||
            (isNaN(min) && weight <= max) ||
            (min <= weight && isNaN(max)) ||
            (min <= weight && weight <= max)) {
            return true;
        }
        return false;
    },

    function (settings, data, dataIndex) {
        //var day=$("#Purchasedatetimebegin").val($.datepicker.formatDate('dd MM yy', new Date()));

        var min = $('#Saledatetimebegin').datepicker("getDate");
        var max = $('#Saledatetimeend').datepicker("getDate");

        var startDate = parseDate(data[0]);

        if (min == null || max == null) { return true; }
        if (startDate <= max && startDate >= min) { return true; }

        return false;
    },

    function (settings, data, dataIndex) {
        var min = parseInt($('#Saleweightbegin').val());
        var max = parseInt($('#Saleweightend').val());
        var weight = parseFloat(data[2]) || 0; // use data for the age column

        if ((isNaN(min) && isNaN(max)) ||
            (isNaN(min) && weight <= max) ||
            (min <= weight && isNaN(max)) ||
            (min <= weight && weight <= max)) {
            return true;
        }
        return false;
    }
);

function parseDate(s) {
    var p = s.split('/');
    return new Date(p[2], p[1], p[0]);
}


$("#Saledatetimebegin").datepicker(
    {
        onSelect: function () {
            $('#saleOfferTbl').DataTable().draw();
        },
        changeMonth: true,
        changeYear: true,
        duration: '1000',
        "showAnim": "slide",
        dateFormat: 'dd-mm-yy',
        monthNames: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"],
        monthNamesShort: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"],
    });

$("#Saledatetimeend").datepicker(
    {
        onSelect: function () {
            $('#saleOfferTbl').DataTable().draw();
        },
        changeMonth: true,
        changeYear: true,
        duration: '1000',
        "showAnim": "slide",
        dateFormat: 'dd-mm-yy',
        monthNames: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"],
        monthNamesShort: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"],
    });

$("#Purchasedatetimebegin").datepicker(
    {
        onSelect: function () {
            $('#purchaseOfferTbl').DataTable().draw();
        },
        changeMonth: true,
        changeYear: true,
        duration: '1000',
        showAnim: "slide",
        dateFormat: 'dd-mm-yy',
        monthNames: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"],
        monthNamesShort: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"],
    });

$("#Purchasedatetimeend").datepicker(
    {
        onSelect: function () {
            $('#purchaseOfferTbl').DataTable().draw();
        },
        changeMonth: true,
        changeYear: true,
        duration: '1000',
        showAnim: "slide",
        dateFormat: 'dd-mm-yy',
        monthNames: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"],
        monthNamesShort: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"],
    });

//Date Range search trigger
$('#Purchasedatetimebegin, #Purchasedatetimeend').change(function () {
    $('#purchaseOfferTbl').DataTable().draw();
});
$('#Saledatetimebegin, #Saledatetimeend').change(function () {
    $('#saleOfferTbl').DataTable().draw();
});

//Weight Range Search trigger
$('#Purchaseweightbegin, #Purchaseweightend').keyup(function () {
    $('#purchaseOfferTbl').DataTable().draw();
});
$('#Saleweightbegin, #Saleweightend').keyup(function () {
    $('#saleOfferTbl').DataTable().draw();
});
//--------------------------Date range search----------------------------


//--------------------------------------Main Tables-----------------------------------------------------//



//Data=Table PurchaseOffer
$(document).ready(function () {
    $('[data-tooltip="Newtooltip"]').tooltip();
    $('[data-toggle="Deletetooltip"]').tooltip();
    $('[data-toggle="Detailtooltip"]').tooltip();
    $('[data-toggle="Bargaintooltip"]').tooltip();

    var purchaseOfferTbl = $("#purchaseOfferTbl");
    var saleOffertbl = $("#saleOfferTbl");

    var purTbl = purchaseOfferTbl.DataTable({
   
        paging: true,
        scrollCollapse: true,
        "ajax": {
            "url": "/TraderOffer/GetListPurchase",
            "type": "GET",
            "datatypye": "json"
        },

        "columns": [
            { "data": "createdDate" },
            { "data": "canBargain" },
            {
                "data": "productName",
                "render": function (data, type, rowData) {
                    return data + ' (' + rowData['seedName'] + ')';
                },
            },
            { "data": "seedName" },
            {
                "data": "quantity",
                //Merge Data of MassName to Quantity
                "render": function (data, type, rowData) {
                    return data + ' (' + rowData['massName'] + ')';
                },
            },

            { "data": "massName" },
            { "data": "trueMass" },
            {
                "render": function (data, type, rowData) {
                   
                    var str = numToCurrencyString(rowData['price']);
                    return str;
                }
            },
            { "data": "numberOfOrder" },
           
            {
                "render": function (data, type, rowData ) {

                    var detailbtnHTML = '<button type="button" class="small blue button" role="purchaseDetailBtn"  data-toggle="Detailtooltip" title="Xem Chi tiết Đơn" ><span class="fa fa-info"></button>'; 
                    var deletebtnHTML = ' <button class="small red button " type="button" role="deleteBtn" data-toggle="Deletetooltip" title="Xóa Đơn" " style="   padding: 4px 8px;"><span class="glyphicon glyphicon-trash"> </span> </button >';

                    var bargainImg = '<img src="/Assets/Images/Bargain.png" title=" Có thể Thương Lượng " width="22" height="22"/>  &nbsp;';
                    var noBargainImg = '<img src="/Assets/Images/Non-Bargainpng.png" width="22" height="22" title="Không Được Thương Lượng " /> &nbsp; ';

                    if (rowData['canBargain']) {
                        return bargainImg + detailbtnHTML + deletebtnHTML 
                    }

                   

                    return noBargainImg + detailbtnHTML + deletebtnHTML 
                }, 
            }
        ],

        //"aaSorting": [[0, "desc"]],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Vietnamese.json",
            searchPlaceholder: "Nhập từ khóa"
        },

        "fnInitComplete": function (oSetting, json) {
            PurchaseaddSearchAdvance(json);
        },

        "columnDefs": [
            { "visible": false, "targets": [6] },
            { "visible": false, "targets": [5] },
            { "visible": false, "targets": [1] },
            { "visible": false, "targets": [3] },
            {
                render: function (data, type, full, meta) {
                    return "<div class='text-wrap width-200'>" + data + "</div>";
                },
                targets: 2
            }
        ]
    });

    function PurchaseaddSearchAdvance(json) {
        $("#purchaseOfferTbl thead").append($("#purchaseOfferTbl thead tr:first").clone());

        $("#purchaseOfferTbl thead tr:eq(1) th").each(function (index) {
            if (index != 5) {
                $(this).replaceWith('<th> <center><input type="text" placeholder="Tìm ' + $(this).html() + '" style = "max-width:70px;"></input>  </center></th>');
                var searchControl = $("#purchaseOfferTbl thead tr:eq(1) th:eq(" + index + ") input");
                searchControl.on('keyup', function () {
                    purTbl.column(index).search(searchControl.val()).draw();
                });
            }
            else {
                $(this).replaceWith('<th></th>');
            }
        });

        $("#purchaseOfferTbl thead tr:eq(1)").hide();

    }


    //DateTable SaleOffer
    var saleTbl = $("#saleOfferTbl").DataTable({
        "ajax": {
            "url": "/TraderOffer/GetListSale",
            "type": "GET",
            "datatypye": "json"
        },

        "columns": [
            {
                "data": "productName",
                "render": function (data, type, rowData) {
                    return data + ' (' + rowData['seedName'] + ')';
                },
            },

            { "data": "seedName" },
            { "data": "farmName" },

            {
                "data": "quantity",
                "render": function (data, type, rowData) {
                    return data + ' (' + rowData['massName'] + ')';
                },
            },

            { "data": "massName" },
            { "data": "trueMass" },
            { "data": "price" },
            { "defaultContent": '<button type="button" class="small blue button" role="orderBtn"  data-toggle="Detailtooltip" title="Xem Chi tiết Đơn" ><span class="fa fa-info"></button>' },
        ],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Vietnamese.json",
            searchPlaceholder: "Nhập từ khóa"
        },

        "fnInitComplete": function (oSetting, json) {
            SaleaddSearchAdvance(json);
        },

        "scrollCollapse": true,

        //"sDom": 'lrtip',

        "columnDefs": [
            { "visible": false, "targets": [4] },
            { "visible": false, "targets": [5] },
            { "visible": false, "targets": [1] }
        ]
    });

    function SaleaddSearchAdvance(json) {
        $("#saleOfferTbl thead").append($("#saleOfferTbl thead tr:first").clone());

        $("#saleOfferTbl thead tr:eq(1) th").each(function (index) {
            if (index != 4) {
                $(this).replaceWith('<th> <center><input type="text" placeholder="Tìm ' + $(this).html() + '" style = "max-width:85px;"></input>  </center></th>');
                var searchControl = $("#saleOfferTbl thead tr:eq(1) th:eq(" + index + ") input");
                searchControl.on('keyup', function () {
                    purTbl.column(index).search(searchControl.val()).draw();
                });
            }
            else {
                $(this).replaceWith('<th></th>');
            }
        });

        $("#saleOfferTbl thead tr:eq(1)").hide();
    }

    //-----------------------------------------Functions-------------------------------------//
    //Delete Offer
    purTbl.on('click', 'button[role="deleteBtn"]', function () {
        var id = purchaseOfferTbl.DataTable().row($(this).closest('tr')[0]).data()['purchOfferID'];
        var NOO = purchaseOfferTbl.DataTable().row($(this).closest('tr')[0]).data()['numberOfOrder'];

        $.confirm({
            icon: 'fa fa-question-circle',
            boxWidth: '100%',
            title: 'Xóa Đơn',
            content: '<h4>Bạn có muốn xóa đơn này?</h4>',
            type: 'red',
            typeAnimated: true,
            animationSpeed: 500,
            closeIcon: true,
            closeIconClass: 'fa fa-close',
            escapeKey: true,
            backgroundDismiss: false,

            autoClose: 'cancel|6000',
            buttons: {
                confirm: {
                    text: "Xác Nhận",
                    btnClass: "btn-red",
                    action: function () {

                        if (NOO == 0) {
                            $.ajax({
                                type: "DELETE",
                                url: "/TraderOffer/CallDeleteOffer/" + id,
                                contentType: "application/json; charset=utf-8",
                                method: 'DELETE',
                                datatype: "text",
                                serverSide: true,
                                success: function (data) {
                                    console.log(data);
                                    purTbl.row($(this).parents('tr')).remove().draw(true);
                                    purTbl.ajax.reload();
                                },
                                error: function (data) {
                                    console.log("Error response is: " + data);
                                }
                            });

                        }

                        else {
                            $.confirm({
                                icon: 'fa fa-exclamation-triangle',
                                title: "Lỗi",
                                content: '<h4>Vui lòng hủy tất cả giao dịch trước khi xóa thỏa thuận!',
                                animation: 'left',
                                confirmButton: false,
                                type: 'red',
                                typeAnimated: true,
                                animationSpeed: 500,

                                closeIcon: true,
                                closeIconClass: 'fa fa-close',


                            })
                        }
                    }
                },

                cancel: function () {

                }
            }
        });
    })




    purchaseOfferTbl.on('click', 'button[role="purchaseDetailBtn"]', function () {
        var id = purchaseOfferTbl.DataTable().row($(this).closest('tr')[0]).data()['purchOfferID'];
        window.location.href = window.location.origin + "/TraderOfferDetail/TraderOfferDetail?" + "traderOfferId=" + id;
     
    });

    saleOffertbl.on('click', 'button[role="orderBtn"]', function () {

        var id = saleOffertbl.DataTable().row($(this).closest('tr')[0]).data()['id'];
        window.location.href = window.location.origin + "/TraderOrder/TraderOrderIndex?" + "saleOfferId=" + id;



    });



    //Table PurchaseOffer Onclick
    $('#purchaseOfferTbl tbody').on('click', 'tr:not(td:eq(9))', function () {

        //Alternative way
        //table.columns([0, 1, 2, 3, 4, 5, 6, 7, 8, 9]).search($(this).val()).draw();

        //var mass = purchaseOfferTbl.DataTable().row($(this)).data()['trueMass'];
        //var price = purchaseOfferTbl.DataTable().row($(this)).data()['price'];
        //var id = purchaseOfferTbl.DataTable().row($(this)).data()['id'];
        //alert("id là:" + id);

        var product = purchaseOfferTbl.DataTable().row($(this)).data()['productName'];
        var seed = purchaseOfferTbl.DataTable().row($(this)).data()['seedName'];

        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
            saleTbl.search("").draw();
        }
        else {
            purTbl.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            saleTbl.search("" + product).search(seed).draw();
        }
    });

    $('#CreateForm').on('submit', function (e) {
        if (e.isDefaultPrevented()) {
            // handle the invalid form...
        } else {

            //Get checkbox value
            var bargain;
            if ($("#canBargain").is(":checked")) {
                bargain = true;
           
            }
            else {
                bargain = false;
            }


            var purchaseOffer = {
                productID: $('#product').val(),
                seedId: $('#seed').val(),
                quantity: $('#quantity').val(),
                unitId: $('#unit').val(),
                price: $('#price').val(),
                payingTime: $('#payingTime').val(),
                deliveringTime: $('#deliveringTime').val(),
                canBargain: bargain
            };
            console.log(purchaseOffer);

            var dataType = 'application/x-www-form-urlencoded; charset=utf-8';
            $.ajax({
                type: "POST",
                url: "/Offer/CreatePurchaseOffer",
                data: purchaseOffer,
                dataType: 'json',
                contentType: dataType,
                success: function (data) {
                    if (data == "success") {
                        alert("success");
                        window.location.reload();
                    }
                    
                },
                error: function () {
                    //alert("error");
                    window.location.reload();
                }
            });


        }
        return false;
    })

})


