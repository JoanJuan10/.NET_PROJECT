// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function callToken () {
    var data = {
        "Email":"InventoryAdmin@abc.com",
        "Password":"$admin@2017"
    };

    // FUNCIONA
    $.ajax({
        method: "POST",
        url: "https://localhost:44311/api/Token",
        dataType: "json",
        data: JSON.stringify(data),
        headers: { 
            'Accept': 'application/json',
            'Content-Type': 'application/json' 
        },
        success: function (response) {
            sessionStorage.setItem("token", response);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function GETTrabajadores () {
    // FUNCIONA
    var token = sessionStorage.getItem("token");
    $.ajax({
        method: "GET",
        url: "https://localhost:44311/api/Trabajadores",
        dataType: "json",
        headers: {
            'Accept':'application/json',
            'Authorization':'Bearer ' + token
        },
        contentType:'application/x-www-form-urlencoded',
        success: function (response) {
            console.log(response);
            var gridDataSource = new kendo.data.DataSource({
                data: response,
                schema: {
                    model: {
                        fields: {
                            id: { type: "number" },
                            nombre: { type: "string" },
                            apellido1: { type: "string" },
                            apellido2: { type: "string" },
                        }
                    }
                },
                pageSize: 10,
                sort: {
                    field: "nombre",
                    dir: "desc"
                }
            });
            $("#trabajadoresGrid").kendoGrid({
                dataSource: gridDataSource,
                height: 700,
                scrollable: true,
                pageable: true,
                sortable: true,
                filterable: true,
                columns: [{
                  field:"id",
                  title: "Cod.",
                  width: 160
                }, {
                  field: "nombre",
                  title: "Nombre",
                  width: 160,
                }, {
                  field: "apellido1",
                  title: "Primer Apellido",
                  width: 200,
                }, {
                  field: "apellido2",
                  title: "Segundo Apellido",
                  width: 200,
                }]
              });
           /*var productos = [];
            $.each(response, function (key, val) { 
                   productos.push("<tr><td>" + val.productId + "</td><td>" + val.name + "</td><td>" + val.color + "</td><td>" + val.category + "</td><td>" + val.unitPrice + "</td><td>" + val.availableQuantity + '</td><td><button type="button" class="btn btn-primary"><i class="fa fa-eye" aria-hidden="true"></i></button><button type="button" class="btn btn-success"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></button><button type="button" class="btn btn-danger"><i class="fa fa-trash" aria-hidden="true"></i></button></td></tr>');
            });
            $.each(productos, function (key, val) { 
                $("#productos").last().append(val);
            });*/
        },
        error: function (error) {
            console.log(error);
        }
    });
    
    
}
