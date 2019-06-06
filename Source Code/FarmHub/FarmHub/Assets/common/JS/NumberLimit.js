
    $(document).ready(function () {
        $('#quantity,#price').each(function () {
            $(this).keydown(function (e) {
                if (this.value.length < 7) {
                    if (this.value.length == 0 && (e.which == 48 || e.which == 69)) {
                        return false;
                    }
                }
                else {
                    $(this).val($(this).val().substr(0, 7));
                }

            })


        })

        $('#payingTime,#deliveringTime').each(function () {
        $(this).keydown(function (e) {
            if (this.value.length < 2) {
                if (this.value.length == 0 && (e.which == 48 || e.which == 69)) {
                    return false;
                }
            }
            else {
                $(this).val($(this).val().substr(0, 2));
            }
        })


    })
})


