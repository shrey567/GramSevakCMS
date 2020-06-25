$(document).ready(function () {

    $('#datatable').DataTable({
        "pageLength": 10,
        "ajax": {
            "url": "/Master/getEmployeeDetails/",
            "tye": "GET",
            "datatype": "json",
        },

        //"columnDefs":
        //[{
        //    "targets": [0],
        //    "visible": false,
        //    "searchable": false
        //}],
        "columns": [
                { "data": "UserID" },
                { "data": "UserName" },
                { "data": "EmployeeID" },
                { "data": "Address" },
                { "data": "Mobile" },
                { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" onclick="Edit(' + full["UserID"] + ')" >Edit</a>'; }, "width": "10%" },
        ]
    });

});

function Edit(ID) {
    window.location.href = "/Master/Employee?q=" + ID;
}

