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

    //Select
    $('#farm').change(function () {
        var idFarm = $('#farm').val();
        var purchaseOfferId = $('#purchaseOfferId').val();
        $.ajax({
            "url": "/FarmerOrder/ProductDetailList?idFarm=" + idFarm + "&purchaseOfferId=" + purchaseOfferId,
            "type": "Get",
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

$('#quantity,#price,#payingTime,#deliveringTime').each(function () {
    $(this).keypress(function (e) {
        if (this.value.length == 0 && e.which == 48) {
            return false;
        }
    })
})