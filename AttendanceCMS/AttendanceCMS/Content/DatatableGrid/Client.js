$(document).ready(function () {

    $('#datatable').DataTable({
        "pageLength": 10,
        "ajax": {
            "url": "/Master/getClientDetails/",
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
                { "data": "AppId" },
                { "data": "AppName" },
                { "data": "ReferenceID" },
                { "data": "QrCode" },
                { "data": "EmailId" },
                { "data": "website" },
                { "data": "AppVersion" },
                { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" onclick="Edit(' + full["AppId"] + ')" >Edit</a>'; }, "width": "10%" },
        ]
    });

});



function Edit(ID) {
    window.location.href = "/Admin/Client?q=" + ID;
}

