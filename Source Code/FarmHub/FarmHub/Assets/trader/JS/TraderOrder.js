$('document').ready(function () {
    $("#quantity").attr('maxlength', 10);

    $('#quantity').keyup(function changeTotalMoney() {
        var price = $('#price').val();
        var truemass = $('#truemass').val();
        var quantity = $("#quantity").val();

        var total = price * truemass * quantity;


        $('#totalMoney').val(total);
    })

    var canBargain = $('#canBargain').data();

    if (canBargain === false) {
        $('#counterOffer').attr('disabled', 'disabled');

    }


    $("#counterOffer").click(function () {
        $("#counterOffered").val("true");
        
        $('#payingTime').prop('readonly', false);
        $('#deliveringTime').prop('readonly', false);
        $('#payingTime').addClass('focusInput');
        $('#deliveringTime').addClass('focusInput');
    })
})

$('#quantity,#price,#payingTime,#deliveringTime').each(function () {
    $(this).keypress(function (e) {
        if (this.value.length == 0 && e.which == 48) {
            return false;
        }
    })
})