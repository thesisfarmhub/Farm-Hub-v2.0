$('document').ready(function () {
    $("#purchaseOfferDetailsTbl").DataTable({
        "columns": [
            { "data": "id" },
            { "data": "productName" },
            { "data": "quantity" },
            { "data": "name_mass" },
            { "data": "totalMoney" },
            { "data": "Status" },

        ],

        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Vietnamese.json"
        }
    });

    $("#purchaseOfferDetailsTbl").DataTable({
        "columns": [
            { "data": "id" },
            { "data": "productName" },
            { "data": "quantity" },
            { "data": "name_mass" },
            { "data": "totalMoney" },
            { "data": "Status" },
        ],

        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Vietnamese.json"
        }
    });
})


