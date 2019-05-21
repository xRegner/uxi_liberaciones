function detalleOrdenAdm(idOrden, total, estatus) {
    var url = _apiUX + "api/OrdenService/GetDetail?";
    var data = "IdOrdenCompra=" & idOrden;
    var tel = $("#tel" + idOrden).val();
    var email = $("#email" + idOrden).val();
    var nombre = $("#nombre" + idOrden).val();
    $(".modal-message button").prop("disabled", false);
    $(".modal-message textarea").val("");
    $(".modal-message textarea").prop("disabled", false);

    $.ajax({
        type: "GET",
        dataType: 'json',
        url: url,
        data: "IdOrdenCompra=" + idOrden,
        success: function (data) {
            var template = " ";
            var price = this.price;
            //var email=

            for (var i = 0; i < data.Productos.length; i++) {
                var obj = data.Productos[i].Producto;
                template += '<tr><td>' + obj.Descripcion_Corta + '</td><td>' + data.Productos[i].Producto.IMEI + '<td>' + data.Productos[i].PrecioNeto + ' MXN</td></tr>';
            };
            $('#tipoestatusModalO').val(estatus).attr('selected', 'selected')
            if (estatus == 5) {
                $('#btnSave').attr("disabled", true);
            };

            //$(".modal-title").html("Orden: " + idOrden);
            $("#myModalLabel").html("Orden: " + idOrden);
            $("#telM").html("|" + tel);
            $("#nombreM").html("|" + nombre);
            $("#emailM").html(email);
            $("#totalOrden").html("Total $" + total + " MXN");
            $("#hiddenIdorden").val(idOrden);
            //$("#estatusOrden").html("<b>Estatus:</b>" + estatus);
            $("#modalBody").html(template);

            //console.log("ready!");
        },
        error: function (data) {
            showMessageType("danger", "Problemas con la conexíon, !O es el infierno en la tierra o se rompió el server!");
        }
    });

    $("#editaPedidoModal").modal("show");
};

function cambiaEstatus()
{
    var url = _apiUX + "api/OrdenService/GETUpdateODS?";
    var idS = $("#tipoestatusModalO").val();
    var idO = $("#hiddenIdorden").val();

    //var data = "IdOrdenCompra=" & idO;
    $.ajax({
        type: "GET",
        dataType: 'json',
        url: url,
        data: { id: idO, idStatus: idS },
        success: function (data) {
            if (data == true) {
                $("#editaPedidoModal").modal("hide");
                $("#OrdenesBody").html("");
                showMessageType("", "Orden Actualizada Correctamente!");
                //alert('Orden Actualiza');
            }
            else {
                $("#editaPedidoModal").modal("hide");
                showMessageType("danger", "Orden NO Actualizada, por favor intente nuevamente!");
            }

        },
        error: function (data) {
            showMessageType("danger", "Problemas con la conexíon, !O es el infierno en la tierra o se rompió el server!");
        }

    });

    $("#editaPedidoModal").modal("show");
};

function generaExcel() {
    var _email = $("#email").val();
    var _idOrden = $("#idOrden").val();
    var _tipoEstatus = $("#tipoestatus").val();
    var _altFieldHasta = $("#altFieldHasta").val();
    var _altField = $("#altField").val();

    var parameters = "altField=" + _altField + "&altFieldHasta=" + _altFieldHasta + "&estatus=" + _tipoEstatus + "&ordenCompra=" + _idOrden + "&email=" + _email;
    window.location.href = "/Adm/_reporteOrden?"+parameters;
};

