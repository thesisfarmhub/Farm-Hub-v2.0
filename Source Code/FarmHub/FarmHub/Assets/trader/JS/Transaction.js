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
        "aaSorting": [[0, "desc"]],
        "ajax": {
            "url": "/TraderTransaction/GetListImportantTransaction",
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
            { "data": "farmerName" },
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
                    var tfDisabledClass = '', etDisabledClass = '', ndDisabledClass = '', cancelDisabledClass = '';
                    var tfDisabled = '', etDisabled = '', ndDisabled = '', cancelDisabled = '';

                    if (rowData['StatusName'] == "Đã Đồng Ý") {
                        ndDisabledClass = 'disabledBtn';
                        ndDisabled = 'disabled';

                    }

                    else if (rowData['StatusName'] == "Chưa Nhận Được Tiền " ) {
                        ndDisabledClass = 'disabledBtn';
                        ndDisabled = 'disabled';
                        etDisabledClass = 'disabledBtn';
                        etDisabled = 'disabled';
                    }

                     

                    else if (rowData['StatusName'] == "Sẵn Sàng Giao Hàng") {
                        tfDisabledClass = 'disabledBtn';
                        tfDisabled = 'disabled';
                        etDisabledClass = 'disabledBtn';
                        etDisabled = 'disabled';
                    }

                    else {
                        tfDisabledClass = 'disabledBtn';
                        tfDisabled = 'disabled';
                        ndDisabledClass = 'disabledBtn';
                        ndDisabled = 'disabled';
                        etDisabledClass = 'disabledBtn';
                        etDisabled = 'disabled';
                    }

                    var tranferedbtnHTML = `<button type="button" class="small green button ${tfDisabledClass}" role="transferedBtn"  data-toggle="Detailtooltip" title="Đã chuyển tiền"  ${tfDisabled}><span class="fas fa-funnel-dollar"></span> </button>`;
                    var extendbtnHTML = ` <button type="button" class="small yellow button ${etDisabledClass}"  role="cancelBtn" data-toggle="Deletetooltip" title="Gia Hạn Thời Gian Trả Tiền" ${etDisabled}><span class="fa fa-clock-o"></span></button >`;
                    var notDeliveredbtnHTML = ` <button class="small yellow button ${ndDisabledClass}" type="button" role="notDeliveredBtn" data-toggle="Deletetooltip" title="Chưa Nhận Được Hàng"  ${ndDisabled}><span class="fas fa-car-crash"></span></button >`;
                    var cancelbtnHTML = ` <button class="small red button ${cancelDisabledClass}" type="button" role="cancelBtn" data-toggle="Deletetooltip" title="Từ Chối"  ${cancelDisabled}><span class="fa fa-ban"></span></button >`;
                    var reportbtnHTML = ' <button class="small blue button" type="button" role="cancelBtn" data-toggle="Deletetooltip" title="Tố cáo" ><span class="fa fa-flag"></span> </button >';
                    //var optionbtnHTML = ` <div class="dropdown"><button class="small blue button dropdown-toggle" type = "button" data - toggle="dropdown" ><span class="fa fa-bars"></span></button > <ul class="dropdown-menu"> <li><a role="extendbtnHTML" id="extendbtnHTML" >Gia Hạn Giao Tiền</a></li> <li><a role="reportBtn" id="reportBtn" >Tố Cáo</a></li> </ul></div>`;
                    return tranferedbtnHTML + notDeliveredbtnHTML + extendbtnHTML + cancelbtnHTML + reportbtnHTML;
                },
            }
        ]
    });

    function TransactionaddSearchAdvance(json) {
        $("#purchaseOfferTbl thead").append($("#purchaseOfferTbl thead tr:first").clone());

        $("#purchaseOfferTbl thead tr:eq(1) th").each(function (index) {
            if (index != 6) {
                $(this).replaceWith('<th> <center><input type="text" placeholder="Tìm ' + $(this).html() + '" style = "max-width:85px;"></input>  </center></th>');
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

    transOffertbl.on('click', 'button[role="transferedBtn"]', function () {
        var transactionId = transOffertbl.DataTable().row($(this).closest('tr')[0]).data()['transId'];

        $.confirm({
            icon: 'fa fa-question-circle',
            boxWidth: '100%',
            title: 'Xác Nhận Chuyển Tiền',
            content: '<h4>Vui lòng đăng ảnh hóa đơn ngân hàng của bạn.</h4> <input type="file" class="" onchange="readURL(this);" id="anhSanPham" name="ImageFile" style="color:aliceblue"> <img style="max-width:80px; max-height:120px" id="blah" src="http://placehold.it/180" alt="your image" />',
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
                            "url": "/TraderTransaction/Handler?Command=" + "Delivered" + "&transactionId=" + transactionId,
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

    transOffertbl.on('click', 'button[role="extendBtn"]', function () {
        var transactionId = transOffertbl.DataTable().row($(this).closest('tr')[0]).data()['transId'];
        var totalMoney = transOffertbl.DataTable().row($(this).closest('tr')[0]).data()['totalMoney'];
        var Fine = totalMoney * 0.1 ;
        $.confirm({
            icon: 'fa fa-question-circle',
            boxWidth: '100%',
            title: 'Xóa Đơn',
            content: '<h4>Bạn có muốn gia hạn thêm thời gian giao tiền.Bạn sẽ bị phạt 10% giá trị hóa đơn tương ứng với ' + Fine +' VNĐ. </h4>',
            type: 'green',
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
                            "url": "/TraderTransaction/Handler?Command=" + "Extend" + "&transactionId=" + transactionId,
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


    transOffertbl.on('click', 'button[role="deliveredBtn"]', function () {
        var transactionId = transOffertbl.DataTable().row($(this).closest('tr')[0]).data()['transId'];

        $.confirm({
            icon: 'fa fa-question-circle',
            boxWidth: '100%',
            title: 'Xóa Đơn',
            content: '<h4>Bạn có chắc đã nhận được hàng từ chủ nông trại?</h4>',
            type: 'green',
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
                            "url": "/TraderTransaction/Handler?Command=" + "Delivered" + "&transactionId=" + transactionId,
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
                cancel:  {
                    text: "Hủy",
                    btnClass: "btn-red",
                }
            }
        });
        
    });

    transOffertbl.on('click', 'button[role="notDeliveredBtn"]', function () {

        var transactionId = transOffertbl.DataTable().row($(this).closest('tr')[0]).data()['transId'];

        $.confirm({
            icon: 'fa fa-question-circle',
            boxWidth: '100%',
            title: 'Chưa Nhận Được Hàng',
            content: '<h4>Bạn có chắc không nhận được hàng từ chủ nông trại?</h4>',
            type: 'orange',
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
                            "url": "/TraderTransaction/Handler?Command=" + "NotDelivered" + "&transactionId=" + transactionId,
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

        if (statusName == "Gia Hạn Giao Hàng") {
            $.confirm({
                icon: 'fa fa-question-circle',
                boxWidth: '100%',
                title: 'Hủy Thỏa Thuận',
                content: '<h4>Bạn có muốn hủy thỏa thuân này? Bạn sẽ không bị phạt do chủ nông trại đã xin gia hạn thời gian.</h4>',
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
                                "url": "/TraderTransaction/Handler?Command=" + "Cancel" + "&transactionId=" + transactionId,
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
                                "url": "/TraderTransaction/Handler?Command=" + "Cancel" + "&transactionId=" + transactionId,
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

    transOffertbl.on('click', 'button[role="report"]', function () {

        var id = transOffertbl.DataTable().row($(this).closest('tr')[0]).data()['transId'];

    });
})

function readURL(input) {
    console.log(input);
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#blah')
                .attr('src', e.target.result);
        };

        reader.readAsDataURL(input.files[0]);
    }
}