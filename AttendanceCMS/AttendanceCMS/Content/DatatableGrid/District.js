$(document).ready(function () {

    //$.ajax({
    //    type: "get",
    //    url: "/Master/getDistrictDetails/",
    //    //data: { userId: UserId },
    //    datatype: "json",
    //    traditional: true,
    //    success: function (data) {
    //        console.log(data);
    //    }
    //});



    $('#datatable').DataTable({
        "pageLength": 10,
        "ajax": {
            "url": "/Master/getDistrictDetails/",
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
                { "data": "District_ID" },
                //{ "data": "State_ID" },
                { "data": "District_Name" },
                { "data": "District_Name_Mar" },
                { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" onclick="Edit(' + full["District_ID"] + ')" >Edit</a>'; }, "width": "10%" },
        ]
    });

});



function Edit(ID) {
    window.location.href = "/Master/District?q=" + ID;
}

