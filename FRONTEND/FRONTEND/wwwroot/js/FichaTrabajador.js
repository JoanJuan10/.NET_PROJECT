﻿$(function () {
    console.log(localStorage.getItem("id"));
    console.log(localStorage.getItem("token"));
    $.ajax({
        method: "GET",
        url: "https://localhost:44311/api/Trabajadores/" + localStorage.getItem("id"),
        dataType: "json",
        headers: {
            'Accept': 'application/json',
            'Authorization': 'Bearer ' + localStorage.getItem("token")
        },
        contentType: 'application/x-www-form-urlencoded',
        success: function (trabajador) {
            console.log(trabajador);
            $("#fichaH2").text(trabajador.nombre + " " + trabajador.apellido1 + " " + trabajador.apellido2);
            $("#idTrabajador").text(trabajador.id);
            $("#grupo").html('<strong>Grupo profesional </strong> &emsp; &emsp; ' + trabajador.grupo + '</p>');
            
            
            $.ajax({
                method: "GET",
                url: "https://localhost:44311/api/VNivOrgs/" + trabajador.nivOrgId,
                dataType: "json",
                headers: {
                    'Accept': 'application/json',
                    'Authorization': 'Bearer ' + localStorage.getItem("token")
                },
                contentType: 'application/x-www-form-urlencoded',
                success: function (nivOrg) {
                    if (nivOrg.dNivel == nivOrg.dNivelPadre) {
                        $("#u-org").text(nivOrg.dNivel);
                    }
                    else {
                        $("#u-org").text(nivOrg.dNivel);
                        $("#puesto").text(nivOrg.dNivelPadre);
                    }
                    console.log(nivOrg);
                },
                error: function (error) {
                    console.log(error);
                }
            });

            $.ajax({
                method: "GET",
                url: "https://localhost:44311/api/TProvis/" + trabajador.tProvis,
                dataType: "json",
                headers: {
                    'Accept': 'application/json',
                    'Authorization': 'Bearer ' + localStorage.getItem("token")
                },
                contentType: 'application/x-www-form-urlencoded',
                success: function (TProvis) {
                    console.log(TProvis);
                    $("#generico").text(TProvis.descrip);
                },
                error: function (error) {
                    console.log(error);
                }
            });
            
            $.ajax({
                method: "GET",
                url: "https://localhost:44311/api/Categorias/" + trabajador.idCategoria,
                dataType: "json",
                headers: {
                    'Accept': 'application/json',
                    'Authorization': 'Bearer ' + localStorage.getItem("token")
                },
                contentType: 'application/x-www-form-urlencoded',
                success: function (categoria) {

                    $.ajax({
                        method: "GET",
                        url: "https://localhost:44311/api/ClasePers/" + categoria.idClasePer,
                        dataType: "json",
                        headers: {
                            'Accept': 'application/json',
                            'Authorization': 'Bearer ' + localStorage.getItem("token")
                        },
                        contentType: 'application/x-www-form-urlencoded',
                        success: function (clasePers) {
                            $("#tipo").text(clasePers.dClasePer);

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
});