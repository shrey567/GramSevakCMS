$(document).ready(function () {

    var fdate = $('#txt_fdate').val();
    var tdate = $('#txt_tdate').val();
    var UserID = $('#EmployeeID').val();

    $('#datatable').DataTable({
        "pageLength": 10,
        "ajax": {
            "url": "/Report/getAttendenceReport",
            "data": {
                "fdate": fdate,
                "tdate": tdate,
                "UserID": UserID
            },
            "tye": "POST",
            "datatype": "json",
        },

        "columns": [
                { "data": "Employee" },
                { "data": "StartDate" },
                { "data": "StartTime" },
                { "data": "EndTime" },
                //{ "data": "Lat" },
                //{ "data": "Long" },
                //{ "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" onclick="Edit(' + full["UserID"] + ')" >Edit</a>'; }, "width": "10%" },
        ]
    });

   

});

function Datatable() {
    
    $("#datatable").dataTable().fnDestroy();
    var fdate1 = $('#txt_fdate').val();
    var tdate1 = $('#txt_tdate').val();
    var UserID1 = $('#EmployeeID').val();

    $('#datatable').DataTable({
        "pageLength": 10,
        "ajax": {
            "url": "/Report/getAttendenceReport",
            "data": {
                "fdate": fdate1,
                "tdate": tdate1,
                "UserID": UserID1
            },
            "tye": "POST",
            "datatype": "json",
        },

        "columns": [
                { "data": "Employee" },
                { "data": "StartDate" },
                { "data": "StartTime" },
                { "data": "EndTime" },
                //{ "data": "Lat" },
                //{ "data": "Long" },
                //{ "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" onclick="Edit(' + full["UserID"] + ')" >Edit</a>'; }, "width": "10%" },
        ]
    });
}
function Search() {
    Datatable();
}


//function showInventoriesGrid() {
//    Search();
//}

//function Search() {
//    var txt_fdate, txt_tdate, Client, UserId;
//    var name = [];
//    var arr = [$('#txt_fdate').val(), $('#txt_tdate').val()];

//    for (var i = 0; i <= arr.length - 1; i++) {
//        name = arr[i].split("/");
//        arr[i] = name[1] + "/" + name[0] + "/" + name[2];
//    }

//    txt_fdate = arr[0];
//    txt_tdate = arr[1];
//    UserId = $('#selectnumber').val();
//    Client = " ";
//    NesEvent = " ";
//    var Product = "";
//    var catProduct = "";
//    var value = txt_fdate + "," + txt_tdate + "," + UserId + "," + $("#s").val();//txt_fdate + "," + txt_tdate + "," + UserId + "," + Client + "," + NesEvent + "," + Product + "," + catProduct + "," + 1;
//    // alert(value );
//    oTable = $('#demoGrid').DataTable();
//    oTable.search(value).draw();
//    oTable.search("");
//    document.getElementById('USER_ID_FK').value = -1;
//}

