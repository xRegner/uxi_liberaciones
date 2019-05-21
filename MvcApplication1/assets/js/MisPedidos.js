function detalleOrden(idOrden,total,estatus)
{
    $(".modal-message button").prop("disabled", false);
    $(".modal-message textarea").val("");
    $(".modal-message textarea").prop("disabled", false);
    var url = _apiUX + "api/OrdenService/GetDetail?";
    //var url = _apiUX + "api/login/";
    var data = "IdOrdenCompra=" & idOrden;
    $.ajax({
        type: "GET",
        dataType: 'json',
        url: _apiUX + 'api/OrdenService/GetDetail?',
        data: "IdOrdenCompra=" + idOrden,
        success: function (data) {
            var template = " ";

            for (var i = 0; i < data.Productos.length; i++) {
                var obj = data.Productos[i].Producto;
                template += '<tr><td>' + obj.Descripcion_Corta + '</td><td>' + data.Productos[i].PrecioNeto + ' MXN</td></tr>';
            };

            $(".modal-title").html("Orden: " + idOrden);
            $("#totalOrden").html("Total $" + total + " MXN");
            $("#hiddenIdorden").val(idOrden);
            $("#estatusOrden").html("<b>Estatus:</b>" + estatus);
            $("#modalBody").html(template);

            console.log("ready!");
        },
        error: function (data) {
            showMessageType("danger", "Problemas con la conexíon, !O es el infierno en la tierra o se rompió el server!");
        }

    });
    
    $("#editaPedidoModal").modal("show");
};

function CancelarOrden()
{
    


    var idOrden = $("#hiddenIdorden").val();
    var resultado;
    $.ajax({
        type: "GET",
        dataType: 'json',
        url: _apiUX + 'api/Cancelacion?id=' + idOrden,
        data: {
            id: idOrden
        },
        success: function (data) {
            resultado = data;
            if (resultado == true) {
                showMessageType("success", "Lo hizo, queda cancelada la orden!");
            }
            else {
                showMessageType("alert", "No puedes cancelar una orden que ya se esta trabajando!");
            }
           
        },
        error: function (data) {
            showMessageType("danger", "No pudimos cancelar la orden comunicate con nosotros!");
        }
           

    })
         $("#hiddenIdorden").val('');
         var template = "";
         $("#OrdenesBody").html(template);
         $("#altField").val('');
         $("#datepicker").val('');
         $("#editaPedidoModal").modal("hide");

}

function filtrarOrdenes() {
    var userId = $("#userId").val();
    //var fechaOrden = $("#altField").val()
    var fechaOrden = ($("#altField").val() != "" ? $("#altField").val() : "00010101");

    var idOrden = ($("#idOrden").val() != "" ? $("#idOrden").val() : "0");
    
    var statusOrden = $("#tipoestatus").val();
    var style = "";
    $.ajax({
        type: "GET",
        dataType: 'json',
        url: _apiUX + 'api/OrdenService/GetList?IdOrdenCompra'+idOrden,
        data: {
            FechaOrden: fechaOrden,
            IdUsuario: userId
        },
        success: function (data) {
            var template = "";

            for (var i = 0; i < data.length; i++) {



              
                var d = new Date(data[i].FechaOrden);

                if ((statusOrden == "NA") || data[i].IdEstatusOC==statusOrden) {
                    template += "<tr>";
                    template += "<td>" + data[i].IdOrdenCompra + "</td>";
                    template += "<td>" + d.toDateString('dd/MM/yyyy') + "</td>";
                    template += "<td>" + data[i].Total + "</td>";
                    switch (data[i].EstatusDesc) {
                        case "CANCELADO":
                            style = "RED";
                            break;
                        case "ACTIVO":
                            style = "CORAL";
                            break;
                        case "ACEPTADO":
                            style = "GREEN";
                            break;
                        case "TERMINADO":
                            style = "blue";
                            break;
                            	
                        default:
                            style = "black";

                    }

                    template += "<td style='color: " + style +";' >" + data[i].EstatusDesc+"</td>";
                    template += '<td><button class="btn-sm" onclick="detalleOrden(' + data[i].IdOrdenCompra + ',' + data[i].Total + ",\n'" + data[i].EstatusDesc + "')" + '">Detalle</button ></td>';
                    template += '<td><button class="btn-sm" onclick="verMensajes(' + data[i].IdOrdenCompra + ')">Mensajes</button ></td>';
                    template += "<tr>";
                };
            }

            
            //$(".modal-title").html("Orden: " + idOrden);
            //$("#totalOrden").html("Total $" + total + " MXN");
            //$("#estatusOrden").html("<b>Estatus:</b>" + estatus);
            $("#OrdenesBody").html(template);
            $("#altField").val('');
            $("#datepicker").val('');
            //console.log("ready!");
        },
        error: function (data) {
            showMessageType("danger", "Problemas con la conexíon, !O es el infierno en la tierra o se rompió el server!");
        }

    })

};