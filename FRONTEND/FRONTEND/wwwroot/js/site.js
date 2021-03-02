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
            localStorage.setItem("token", response);
            GETTrabajadores(response);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function showDetails (e) {
    localStorage.setItem("id", this.dataItem($(e.currentTarget).closest("tr")).id);
    document.getElementById("fichaTrabajador").submit();
}

function GETTrabajadores (token) {
    // FUNCIONA
    //var token = localStorage.getItem("token");
    $.ajax({
        method: "GET",
        url: "https://localhost:44311/api/Trabajadores",
        dataType: "json",
        headers: {
            'Accept':'application/json',
            'Authorization':'Bearer ' + token
        },
        contentType:'application/x-www-form-urlencoded',
        success: function (trabajadores) {
            $.ajax({
                method: "GET",
                url: "https://localhost:44311/api/Empresas",
                dataType: "json",
                headers: {
                    'Accept':'application/json',
                    'Authorization':'Bearer ' + token
                },
                contentType:'application/x-www-form-urlencoded',
                success: function (empresas) {
                    $.ajax({
                        method: "GET",
                        url: "https://localhost:44311/api/Categorias",
                        dataType: "json",
                        headers: {
                            'Accept':'application/json',
                            'Authorization':'Bearer ' + token
                        },
                        contentType:'application/x-www-form-urlencoded',
                        success: function (categorias) {
                            console.log(categorias);
                            $.ajax({
                                method: "GET",
                                url: "https://localhost:44311/api/Cuerpos",
                                dataType: "json",
                                headers: {
                                    'Accept':'application/json',
                                    'Authorization':'Bearer ' + token
                                },
                                contentType:'application/x-www-form-urlencoded',
                                success: function (cuerpos) {
                                    console.log(cuerpos);
                                    $.ajax({
                                        method: "GET",
                                        url: "https://localhost:44311/api/TProvis",
                                        dataType: "json",
                                        headers: {
                                            'Accept':'application/json',
                                            'Authorization':'Bearer ' + token
                                        },
                                        contentType:'application/x-www-form-urlencoded',
                                        success: function (tprovis) {
                                            console.log(tprovis);
                                            var data = [];
                                            $.each(trabajadores, function (key, val) {
                                                $.each(empresas, function (keyEmpresa, valEmpresa) {
                                                    if (val.idEmpresa == valEmpresa.idEmpresa) {
                                                        $.each(categorias, function (keyCategoria, valCategoria) { 
                                                            if (val.idCategoria == valCategoria.categori) {
                                                                $.each(cuerpos, function (keyCuerpos, valCuerpos) { 
                                                                    if (val.cuerpo == valCuerpos.cuerpo) {
                                                                        $.each(tprovis, function (keyTprovis, valTprovis) { 
                                                                            if (val.tProvis == valTprovis.tProvis1) {
                                                                                data.push({
                                                                                    id: val.id,
                                                                                    nombre: val.nombre + " " + val.apellido1 + " " + val.apellido2,
                                                                                    tp: valTprovis.idClasePer,
                                                                                    tprovis: valTprovis.descrip,
                                                                                    empresa: valEmpresa.dEmpresa,
                                                                                    grupo: val.grupo,
                                                                                    categoria: valCategoria.descrip,
                                                                                    cuerpo: valCuerpos.descrip,
                                                                                });   
                                                                            }
                                                                        });
                                                                    }
                                                                });
                                                            }
                                                        });
                                                    }
                                                });
                                            });
                                            console.log(trabajadores);
                                            var gridDataSource = new kendo.data.DataSource({
                                                data: data,
                                                schema: {
                                                    model: {
                                                        fields: {
                                                            id: { type: "int" },
                                                            nombre: { type: "string" },
                                                            tp: { type: "string" },
                                                            tprovis: { type: "string" },
                                                            empresa: { type: "string"},
                                                            grupo: { type: "string"},
                                                            cuerpo: { type: "string"},
                                                            categoria: { type: "string"},
                                                            
                                                        }
                                                    }
                                                },
                                                pageSize: 17,
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
                                                width: 80
                                                }, {
                                                field: "nombre",
                                                title: "Nombre",
                                                width: 160,
                                                }, {
                                                field: "tp",
                                                title: "TP",
                                                width: 50,
                                                }, {
                                                field: "tprovis",
                                                title: "Tipo de Empleado",
                                                width: 150,
                                                }, {
                                                field: "empresa",
                                                title: "Empresa",
                                                width: 100,
                                                }, {
                                                field: "grupo",
                                                title: "Grupo",
                                                width: 60,
                                                }, {
                                                field: "cuerpo",
                                                title: "Cuerpo",
                                                width: 80,
                                                }, {
                                                field: "categoria",
                                                title: "Categoria / Escala",
                                                width: 80,
                                                }, {
                                                command: { text: 'Editar', click: showDetails },
                                                title: "Opciones",
                                                width: 80,
                                                }]
                                            });
                                        },
                                        error: function (error) {
                                            console.log(error);
                                        }
                                    });
                                    
                                },
                                error: function (error) {
                                    console.log(error);
                                }
                            });
                        },
                        error: function (error) {
                            console.log(error);
                        }
                    });
                },
                error: function (error) {
                    console.log(error);
                }
            });
        },
        error: function (error) {
            console.log(error);
        }
    });
}
