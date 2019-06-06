var user = {
    init: function () {
        user.registerEvent();
    },
    registerEvent: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();             //reset default '#'
            var btn = $(this);
            var id = btn.data('id')    // because of 'data-id' in the HTML page
            
            $.ajax({
                url: "/Admin/User/ChangeStatus/", // Area/Controller/Method/
                data: { id: id },            // 1 'id' from UserController parameter and one 'id' inside the JS function
                dataType: "json",
                type: "POST",
 /*parameter*/
                success: function (response) // this function will return to JSON in 'ChangeStatus' Method
                {
                    
                    if (response.status == 1) {
                        btn.text('Kích Hoạt');
                        btn.remove('btn-danger');
                        btn.remove('btn-primary');
                        btn.addClass('btn-success');

                    }
                    if (reponse.status == 2) {
                        btn.text('Khóa')
                        btn.remove('btn-success');
                        btn.remove('btn-primary');
                        btn.addClass('btn-danger');
                    }
                    else {
                        btn.text('Xóa')
                        btn.remove('btn-success');
                        btn.remove('btn-danger');
                        btn.addClass('btn-primary');
                        
                    }
                }
            })
        })
    }
}

user.init();