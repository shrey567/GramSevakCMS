$(document).ready(function () {
    $('#ajax-table').DataTable({
        "processing": true,
        "serverSide": true,
        "responsive": true,
        "ajax": "assets/datatable/server/users.php",
        "columns": [
            { "data": "id" },
            { "data": "firstname" },
            { "data": "lastname" },
            { "data": "phone" },
            { "data": "username" },
            { "data": "email" },
            { "data": "dob" },
            { "data": "country" },
            { "data": "language" },
            { "data": "address" },
            { "data": "town_city" },
            { "data": "postal_code" },
            { "data": "created_at" },
			{ "render": function (data, type, full, meta) { return '<a   onclick="Edit(' + full["id"] + ')" >click</a>'; }, "width": "10%" },
        ]
    });
});

function Edit(id) {
    alert(id);
}

