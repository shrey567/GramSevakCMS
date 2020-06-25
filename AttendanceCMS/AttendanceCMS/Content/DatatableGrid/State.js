$(document).ready(function () {
    
    $('#datatable').DataTable({
        "pageLength": 10,
        "ajax": {
            "url": "/Master/getStateDetails/",
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
                { "data": "StateID" },
                { "data": "State" },
                { "data": "StateMar" },
                { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" onclick="Edit(' + full["StateID"] + ')" >Edit</a>'; }, "width": "10%" },
        ]
    });

});



function Edit(ID) {
    window.location.href = "/Master/State?q=" + ID;
}

