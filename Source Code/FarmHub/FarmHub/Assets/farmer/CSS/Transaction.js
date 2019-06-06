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



//Buttons
$('#transactionOfferTbl').on('click', '#delievered', function (e) {
    e.preventDefault();

    editor.message("Bạn có xác nhận đã nhận được hàng?");
    editor.remove($(this).parents('tr')[0], 'Delete row', {
        "label": "Confirm",
        "fn": function () { this.submit(); }
    });
});

$('#transactionOfferTbl').on('click', '#cancel', function (e) {
    e.preventDefault();

    editor.message("Are you sure you want to remove this row?");
    editor.remove($(this).parents('tr')[0], 'Delete row', {
        "label": "Confirm",
        "fn": function () { this.submit(); }
    });
});



$(document).ready(function () {
    var purTbl = $("#transactionOfferTbl").DataTable({

        //"ajax": {
        //    "url": "/Transaction/GetListPurchase",
        //    "type": "GET",
        //    "datatypye": "json"
        //},
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Vietnamese.json"
        },

        "fnInitComplete": function (oSetting, json) {
            TransactionaddSearchAdvance(json);
        },

        "scrollCollapse": true,
        "columnDefs": [
            {

                "render": function (data, type, rowData) {

                    return data + ' (' + rowData['massName'] + ')';
                },
                "targets": 2
            },
            { "visible": false, "targets": [3] }
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
})