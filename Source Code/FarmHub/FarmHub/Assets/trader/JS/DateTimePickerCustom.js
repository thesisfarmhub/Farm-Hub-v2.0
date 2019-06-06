
//DateRangeBoxes
var datePicker1 = new DatePicker({
    input: $('#Purchasedatetimebegin'),
    trigger: $('#Purchasedatetimebegin_button'),
    events: {
        onSelect: function (e) {
            var currentButton = $(e.currentTarget);
            var minDate = new Date();
            minDate.setTime(currentButton.attr("data-date"));
            datePicker2.minDate = minDate;
            if (datePicker2.currentPicker != null) {
                datePicker2.monthChange(minDate);
            }

            table.draw();
        }
    }
});
datePicker1.init();

var handleOnSelect = function (e) {

}

var table = $('#purchaseOfferTbl').DataTable();

var datePicker2 = new DatePicker({
    input: $('#Purchasedatetimeend'),
    trigger: $('#Purchasedatetimeend_button'),
    events: {
        onSelect: function (e) {
            var currentButton = $(e.currentTarget);
            var maxDate = new Date();
            maxDate.setTime(currentButton.attr("data-date"));
            datePicker1.maxDate = maxDate;
            //if (datePicker1.currentPicker != null) {
            //    datePicker1.monthChange(maxDate);
            //}
            table.draw();
        },

        onclose: function () {



        }
    }
});
datePicker2.init();