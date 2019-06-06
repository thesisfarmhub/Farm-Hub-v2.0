
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
    //DateTable SaleOffer
    
    var saleTbl = $("#saleOfferTbl").DataTable({
        "aaSorting": [[1, "desc"]],
        "ajax": {
            "url": `${window.location.origin}/FarmerOffer/GetListSale`,
            "type": "GET",
            "datatypye": "json"
        },

        "columns": [
            { "data": "canBargain" },
            {
                "data": "createdDate",
                width: "10%",
                render: function (data, type, rowData) {
                    if (type == "sort") {
                        var str = data.split('/');
                        console.log(str);
                        return new Date(str[2], str[1], str[0]).getTime();

                    }
                    return data;
                }
            },
            { "data": "farmName", width: "20%"},
            {
                "data": "productName",
                "render": function (data, type, rowData) {
                    return data + ' (' + rowData['seedName'] + ')';
                },
                 width: "20%"
            },

            { "data": "seedName" },

            {
                "data": "quantity",
                "render": function (data, type, rowData) {
                    return data + ' (' + rowData['massName'] + ')';
                },
                 width: "10%"
            },
            { "data": "massName" },
            { "data": "price", width: "10%"},
            { "data": "numberOfOrder", width: "5%"},

            {
                "render": function (data, type, rowData) {

                    var detailbtnHTML = '<button type="button" class="small blue button" role="saleDetailBtn"  data-toggle="Detailtooltip" title="Xem Chi tiết Đơn"  ><span class="fa fa-info"></span></button> ';
                    var deletebtnHTML = '<button class="small red button " type="button" role="deleteBtn" data-toggle="Deletetooltip" title="Xóa Đơn" " style="padding: 4px 8px;"><span class="glyphicon glyphicon-trash"> </span> </button >';

                    var bargainImg = '<img src="/Assets/Images/Bargain.png" title=" Có thể Thương Lượng " width="22" height="22"/>  &nbsp;';
                    var noBargainImg = '<img src="/Assets/Images/Non-Bargainpng.png" width="22" height="22" title="Không Được Thương Lượng " /> &nbsp; ';

                    if (rowData['canBargain']) {
                        return bargainImg + detailbtnHTML + "&nbsp;" + deletebtnHTML

                    }
                    return noBargainImg + detailbtnHTML + "&nbsp;" + deletebtnHTML
                },
                width: "25%"
            },
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
            { "visible": false, "targets": [6] },
            { "visible": false, "targets": [4] },
            { "visible": false, "targets": [0] },
           
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



    var purchaseOfferTbl = $("#purchaseOfferTbl");
    var saleOffertbl = $("#saleOfferTbl");

    var purTbl = purchaseOfferTbl.DataTable({

        paging: true,
        scrollCollapse: true,
        "ajax": {
            "url": `${window.location.origin}/FarmerOffer/GetListPurchase`,
            "type": "GET",
            "datatypye": "json"
        },

        "columns": [
            { "data": "traderName" },
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
            { "data": "price" },
            {
                "defaultContent": '<button type="button" role="orderBtn" class="small blue button"><span class="fa fa-info"></span></button>'
            }



        ],

        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Vietnamese.json",
            searchPlaceholder: "Nhập từ khóa"
        },

        "fnInitComplete": function (oSetting, json) {
            PurchaseaddSearchAdvance(json);
        },

        "columnDefs": [
            { "visible": false, "targets": [4] },
            { "visible": false, "targets": [2] },

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


    //Delete Offer
    saleTbl.on('click', 'button[role="deleteBtn"]', function () {
        var id = saleOffertbl.DataTable().row($(this).closest('tr')[0]).data()['saleOfferid'];
        var NOO = saleOffertbl.DataTable().row($(this).closest('tr')[0]).data()['numberOfOrder'];

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
                        if (NOO > 0) {
                            $.ajax({
                                type: "DELETE",
                                url: "${window.location.origin}/FarmerOffer/CallDeleteOffer/" + id,
                                contentType: "application/json; charset=utf-8",
                                method: 'DELETE',
                                datatype: "text",
                                serverSide: true,
                                success: function (data) {
                                    console.log(data);
                                    saleTbl.row($(this).parents('tr')).remove().draw(true);
                                    saleTbl.ajax.reload();
                                },
                                error: function (data) {
                                    console.log("Error response is: " + data);
                                }
                            });

                        }

                        else {
                            $.confirm({
                                icon: 'fa fa-exclamation-triangle',
                                title: "Giao dịch trong thỏa thuận đang hoạt động",
                                content: "<h4>Vui lòng hủy tất cả giao dịch trước khi xóa thỏa thuận!<h4/>",
                                animation: 'left',
                                confirmButton: false,
                                type: 'red',
                                typeAnimated: true,
                                animationSpeed: 500,

                                closeIcon: true,
                                closeIconClass: 'fa fa-close',
                                columnClass: 'col-md-4'

                            })
                        }
                    }
                },
                cancel: function () {

                }
            }
        });
    })


    //DateRange Search


    //Weight Range Search
    $('#Saleweightbegin, #Saleweightend').keyup(function () {
        table.draw();
    });

    saleOffertbl.on('click', 'button[role="saleDetailBtn"]', function () {

        var id = saleOffertbl.DataTable().row($(this).closest('tr')[0]).data()['saleOfferid'];
        window.location.href = window.location.origin + "/Farmer/FarmerOfferDetail/FarmerOfferDetail?" + "saleOfferId=" + id;
    });

    purchaseOfferTbl.on('click', 'button[role="orderBtn"]', function () {
        var id = purchaseOfferTbl.DataTable().row($(this).closest('tr')[0]).data()['id'];
        window.location.href = window.location.origin + "/Farmer/FarmerOrder/FarmerOrderIndex?" + "purchaseOfferId=" + id;

    });



    //Table PurchaseOffer Onclick
    $('#saleOfferTbl tbody').on('click', 'tr:not(td:eq(4))', function () {

        var product = saleOffertbl.DataTable().row($(this)).data()['productName'];
        var seed = saleOffertbl.DataTable().row($(this)).data()['seedName'];
        //alert("id là:" + id);
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
            purTbl.search("").draw();
        }
        else {
            saleTbl.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            purTbl.search("" + product).search(seed).draw();

        }
    });

    //CreateForm
    $('#CreateForm').on('submit', function (e) {
        if (e.isDefaultPrevented()) {
            // handle the invalid form...
        }

        else {
            var saleOffer = {
                farmId: $('#farm').val(),
                productDetailId: $('#productDetail').val(),
                quantity: $('#quantity').val(),
                idUnit: $('#unit').val(),
                price: $('#price').val(),
                payingTime: $('#payingTime').val(),
                deliveringTime: $('#deliveringTime').val(),
                canBargain: $('#canBargain').val()
            };

            console.log(saleOffer);

            var dataType = 'application/x-www-form-urlencoded; charset=utf-8';
            $.ajax({
                type: "POST",
                url: `${window.location.origin}/FarmerOffer/CreateSaleOffer`,
                data: saleOffer,
                dataType: 'json',
                contentType: dataType,
                success: function () {
                    window.location.reload();
                    alert("success");
                },
                error: function () {
                    console.log("12312");
                }
            });
        }
        return false;
    })

    //Select
    $('#farm').change(function () {
        var idFarm = $('#farm').val();
        $.ajax({
            "url": "/FarmerOffer/ProductDetailList?idFarm=" + idFarm,
            "type": "GET",
            "datatypye": "json",
            success: function (resp) {
                console.log(resp);
                var data = resp.data;
                var optionHtml = "";
                
                for (var i = 0; i < data.length; i++) {
                    optionHtml += `<option value=${data[i].id}>${data[i].productName}(${data[i].seedname}-${data[i].cropName})`;
                }

                console.log(optionHtml);
                $('#productDetail').html(optionHtml);
                $('#productDetail').niceSelect('update');
            },
            error: function (data) {
                console.log("Error response is: " + data);
            }
        });

       
    });
    $('#farm').change();
})


