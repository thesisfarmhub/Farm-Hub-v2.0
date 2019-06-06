$.fn.dataTable.ext.search.push(
    function (settings, data, dataIndex) {
        //var day=$("#Purchasedatetimebegin").val($.datepicker.formatDate('dd MM yy', new Date()));

        var min = $('#datetimebegin').datepicker("getDate");
        var max = $('#datetimeend').datepicker("getDate");


        var startDate = parseDate(data[0]);

        if (min == null || max == null) { return true; }
        if (startDate <= max && startDate >= min) { return true; }

        return false;
    },
    function (settings, data, dataIndex) {
        var min = parseInt($('#weightbegin').val());
        var max = parseInt($('#weightend').val());
        var weight = parseFloat(data[2]) || 0;

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


$("#datetimebegin").datepicker(
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

$("#datetimeend").datepicker(
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


//Date Range search trigger
$('#datetimebegin, #datetimeend').change(function () {
    $('#transactionOfferTbl').DataTable().draw();
});


//Weight Range Search trigger
$('#weightbegin, #weightend').keyup(function () {
    $('#transactionOfferTbl').DataTable().draw();
});

$(document).ready(function () {
    var transOffertbl = $("#transactionOfferTbl");
    var purTbl = $("#transactionOfferTbl").DataTable({
        "ajax": {
            "url": `${window.location.origin}/FarmerTransaction/GetListTransaction`,
            "type": "GET",
            "datatypye": "json"
        },
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Vietnamese.json"
        },

        "fnInitComplete": function (oSetting, json) {
            TransactionaddSearchAdvance(json);
        },

        "scrollCollapse": true,
        "columns": [
            { "data": "endTransDay" },
            {
                "data": "productName",
                "render": function (data, type, rowData) {
                    return data + ' (' + rowData['seedName'] + ')';
                },
            },
            {
                "data": "seedName",
                visible: false,
            },
            { "data": "farmName" },
            { "data": "traderName" },
            { "data": "price" },
            {
                "data": "quantity",
                "render": function (data, type, rowData) {
                    return data + ' (' + rowData['unitName'] + ')';
                },
            },
            {
                "data": "unitName",
                visible: false,
            },
            { "data": "totalMoney" },
            { "data": "StatusName" },
            {
                "render": function (data, type, rowData) {
                    var rdDisabledClass = '', etDisabledClass = '', viDisabledClass='', nrDisabledClass = '';
                    var rdDisabled = '', etDisabled = '', viDisabled, nrDisabled = '';


                    if (rowData['StatusName'] == "Đã Nhận Tiền" ) {
                        nrDisabledClass = 'disabledBtn';
                        nrDisabled = 'disabled';
                        
                        viDisabledClass = 'disabledBtn';
                        viDisabled = 'disabled';
                    }

                    else if (rowData['StatusName'] == "Chưa Nhận Được Hàng ") {
                        nrDisabledClass = 'disabledBtn';
                        nrDisabled = 'disabled';
                        etDisabledClass = 'disabledBtn';
                        etDisabled = 'disabled';
                        viDisabledClass = 'disabledBtn';
                        viDisabled = 'disabled';
                    }

                    else if (rowData['StatusName'] == "Đã Chuyển Tiền" || rowData['StatusName'] == "Đã Chuyển Tiền Lại"){
                        rdDisabledClass = 'disabledBtn';
                        rdDisabled = 'disabled';
                        etDisabledClass = 'disabledBtn';
                        etDisabled = 'disabled';
                    }

                    else {
                        rdDisabledClass = 'disabledBtn';
                        rdDisabled = 'disabled';
                        nrDisabledClass = 'disabledBtn';
                        nrDisabled = 'disabled';
                        etDisabledClass = 'disabledBtn';
                        etDisabled = 'disabled';
                        viDisabledClass = 'disabledBtn';
                        viDisabled = 'disabled';
                    }

                    var readybtnHTML = `<button type="button" class="small green button ${rdDisabledClass}" role="readyBtn" title="Sẵn Sàng Giao Hàng"  ${rdDisabled}><span class="fas fa-people-carry"></span> </button>`;
                    var notReceivedMoneybtnHTML = ` <button class="small blue button ${nrDisabledClass}" type="button" role="notReceivedBtn"  title="Chưa Nhận Được Tiền"${nrDisabled}><span class="fas fa-strikethrough"></span></button >`;
                    var extendbtnHTML = ` <button type="button" class="small yellow button ${etDisabledClass}"  role="extendBtn" title="Gia Hạn Thời Gian Giao Hàng" ${etDisabled}><span class="fa fa-clock-o"></span></button >`;
                    var viewInvoiceHTML = `<button type="button" class="small green button ${viDisabledClass}" role="viewBtn" title="Xem hóa đơn chuyển tiền" data-toggle="modal" data-target="#NewOfferModal" ${viDisabled}><span class="fa fa-file-invoice"></span> </button>`;
                    var reportbtnHTML = ' <button class="small blue button" type="button" role="reportBtn"  title="Tố cáo" ><span class="fa fa-flag"></span> </button >';
                    var cancelbtnHTML = ` <button class="small red button " type="button" role="cancelBtn"  title="Hủy Thỏa Thuận"><span class="fa fa-ban"></span></button >`;
                    //var optionbtnHTML = ` <div class="dropdown"><button class="small blue button dropdown-toggle" type = "button" data - toggle="dropdown" ><span class="fa fa-bars"></span></button > <ul class="dropdown-menu"> <li><a role="extendbtnHTML" id="extendbtnHTML" >Gia Hạn Giao Tiền</a></li> <li><a role="reportBtn" id="reportBtn" >Tố Cáo</a></li> </ul></div>`;
                    return readybtnHTML + notReceivedMoneybtnHTML + extendbtnHTML + viewInvoiceHTML + cancelbtnHTML + reportbtnHTML;
                },
            }
        ]
    });

    function TransactionaddSearchAdvance(json) {
        $("#purchaseOfferTbl thead").append($("#purchaseOfferTbl thead tr:first").clone());

        $("#purchaseOfferTbl thead tr:eq(1) th").each(function (index) {
            if (index != 6) {
                $(this).replaceWith('<th> <center><input type="text" placeholder="'+ $(this).html() + '" style = "max-width:85px;"></input>  </center></th>');
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

    transOffertbl.on('click', 'button[role="readyBtn"]', function () {
        var transactionId = transOffertbl.DataTable().row($(this).closest('tr')[0]).data()['transId'];

        $.confirm({
            icon: 'fa fa-question-circle',
            boxWidth: '100%',
            title: 'Sẵn Sàng Giao Hàng',
            content: '<h4>Bạn có chắc đã sẵn sàng giao hàng?</h4>',
            type: 'green',
            typeAnimated: true,
            animationSpeed: 500,
            closeIcon: true,
            closeIconClass: 'fa fa-close',
            escapeKey: true,
            backgroundDismiss: false,

            buttons: {
                confirm: {
                    text: "Xác Nhận",
                    btnClass: "btn-default",
                    action: function () {
                        $.ajax({
                            "url": "/Farmer/FarmerTransaction/Handler?Command=" + "Readied" + "&transactionId=" + transactionId,
                            "type": "POST",
                            "datatypye": "json",
                            success: function (data) {
                                alert("sucess");
                                window.location.reload();
                            },
                            error: function (data) {

                            }
                        });
                    }
                },
                cancel: {
                    text: "Hủy",
                    btnClass: "btn-red",
                }
            }
        });

    });
    transOffertbl.on('click', 'button[role="extendBtn"]', function () {
        var transactionId = transOffertbl.DataTable().row($(this).closest('tr')[0]).data()['transId'];
        var totalMoney = transOffertbl.DataTable().row($(this).closest('tr')[0]).data()['totalMoney'];
        var Fine = numToCurrencyString(totalMoney * 0.1);

        $.confirm({
            icon: 'fa fa-question-circle',
            boxWidth: '100%',
            title: 'Xóa Đơn',
            content: '<h4>Bạn có muốn gia hạn thêm thời gian giao tiền? Bạn sẽ bị phạt 10% giá trị hóa đơn tương ứng với ' + Fine + ' VNĐ. </h4>',
            type: 'orange',
            typeAnimated: true,
            animationSpeed: 500,
            closeIcon: true,
            closeIconClass: 'fa fa-close',
            escapeKey: true,
            backgroundDismiss: false,
            
            buttons: {
                confirm: {
                    text: "Xác Nhận",
                    btnClass: "btn-default",
                    action: function () {
                        $.ajax({
                            "url": "/Farmer/FarmerTransaction/Handler?Command=" + "Extend" + "&transactionId=" + transactionId,
                            "type": "POST",
                            "datatypye": "json",
                            success: function (data) {
                                window.location.reload();
                            },
                            error: function (data) {

                            }
                        });
                    }
                },
                cancel: {
                    text: "Hủy",
                    btnClass: "btn-red",
                }
            }
        });
    });
   
    transOffertbl.on('click', 'button[role="notReceivedBtn"]', function () {
        var transactionId = transOffertbl.DataTable().row($(this).closest('tr')[0]).data()['transId'];

        $.confirm({
            icon: 'fa fa-question-circle',
            boxWidth: '100%',
            title: 'Chưa Nhận Được Tiền',
            content: '<h4>Bạn có chắc không nhận được tiền từ thương lái?</h4>',
            type: 'blue',
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
                    btnClass: "btn-default",
                    action: function () {
                        $.ajax({
                            "url": "/Farmer/FarmerTransaction/Handler?Command=" + "NotReceived" + "&transactionId=" + transactionId,
                            "type": "POST",
                            "datatypye": "json",
                            success: function (data) {
                                window.location.reload();
                            },
                            error: function (data) {

                            }
                        });
                    }
                },

                cancel: {
                    text: "Hủy",
                    btnClass: "btn-red",
                }
            }
        });


    });
    
    transOffertbl.on('click', 'button[role="cancelBtn"]', function () {

        var transactionId = transOffertbl.DataTable().row($(this).closest('tr')[0]).data()['transId'];
        var statusName = transOffertbl.DataTable().row($(this).closest('tr')[0]).data()['StatusName'];

        if (statusName == "Gia Hạn Giao Tiền") {
            $.confirm({
                icon: 'fa fa-question-circle',
                boxWidth: '100%',
                title: 'Hủy Thỏa Thuận',
                content: '<h4>Bạn có muốn hủy thỏa thuân này? Bạn sẽ không bị phạt do thương lái đã xin gia hạn thời gian.</h4>',
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
                        btnClass: "btn-default",
                        action: function () {
                            $.ajax({
                                "url": "/Farmer/FarmerTransaction/Handler?Command=" + "Cancel" + "&transactionId=" + transactionId,
                                "type": "POST",
                                "datatypye": "json",
                                success: function (data) {
                                    window.location.reload();
                                },
                                error: function (data) {

                                }
                            });
                        }
                    },
                    cancel: {
                        text: "Hủy",
                        btnClass: "btn-red",
                    }
                }
            });
        }

        else {
            $.confirm({
                icon: 'fa fa-question-circle',
                boxWidth: '100%',
                title: 'Hủy Thỏa Thuận',
                content: '<h4>Bạn có muốn hủy thỏa thuân này? Bạn sẽ mất 1 điểm tín nhiệm.</h4>',
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
                        btnClass: "btn-default",
                        action: function () {
                            $.ajax({
                                "url": "/Farmer/FarmerTransaction/Handler?Command=" + "Cancel" + "&transactionId=" + transactionId,
                                "type": "POST",
                                "datatypye": "json",
                                success: function (data) {
                                    window.location.reload();
                                },
                                error: function (data) {

                                }
                            });
                        }
                    },

                    cancel: {
                        text: "Hủy",
                        btnClass: "btn-red",
                    }
                }
            });
        }
        

    });

    transOffertbl.on('click', 'button[role="viewBtn"]', function () {
        var id = transOffertbl.DataTable().row($(this).closest('tr')[0]).data()['id'];

    });

    transOffertbl.on('click', 'button[role="reportBtn"]', function () {
        var id = transOffertbl.DataTable().row($(this).closest('tr')[0]).data()['purchOfferID'];


    });
})