///Métodos comunes para ser usados en donde se ocupe


///Crea un mensaje para un usuario
///Selector -> El contexto del cual el usuario dió click
///Correo -> Se puede o no mandar el correo a quien se le mandará el mensaje
function mandarMensaje(Selector, Correo) {
    var IdUsuario, IdOrdenCompra, Mensaje;
    IdOrdenCompra = $("#hiddenIdorden").val();
    IdUsuario = $("#userId").val();
    Mensaje = $(Selector).closest("div").find("textarea").val();
    Correo = Correo != undefined ? Correo : $("#emailM").text();
    
    var url = _apiUX + "api/MensajesOrdenes";
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: 'application/json',
        url: url,
        data: JSON.stringify({ IdUsuario: IdUsuario, IdOrdenCompra: IdOrdenCompra, Mensaje: Mensaje }),
        success: function (data) {
            $(Selector).prop("disabled", true);
            $(Selector).closest("div").find("textarea").prop("disabled", true);
            $(Selector).closest("div").find("textarea").val("Mensaje creado...");
            mandarCorreo(Correo, "Nuevo mensaje de tu orden de servicio", "<h1>" + Correo + " te ha mandado el siguiente mensaje:</h1></br>" + Mensaje);
        },
        error: function (data) {
            showMessageType("danger", "Problemas con la conexíon, !O es el infierno en la tierra o se rompió el server!");
        }
    });
}

///Manda un correo a un destinatario
///Para -> Correo destino
///Asunto -> Asunto del correo
///Mensaje -> El cuerpo del correo
function mandarCorreo(Para, Asunto, Mensaje) {
    var url = _apiUX + "api/Mail";
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: 'application/json',
        url: url,
        data: JSON.stringify({ sTo: Para, sSubject: Asunto, sBody: Mensaje }),
        success: function (data) {
            console.log("correo mandado");
        },
        error: function (data) {
            showMessageType("danger", "Problemas con la conexíon, !O es el infierno en la tierra o se rompió el server!");
        }
    });
}

///Obtiene los mensajes relacionados a un id de orden de compra
///IdOrdenCompra -> El identificador de la orden de compra
function verMensajes(IdOrdencompra) {
    $("#verMensajes").modal("show");
    var url = _apiUX + "api/MensajesOrdenes/" + IdOrdencompra;
    $("#verMensajes .modal-message").html("");
    var html = '<strong>No existen mensajes</strong>';
    var classStyle;
    var IdUsuario = $("#userId").val();
    $.ajax({
        type: "GET",
        dataType: 'json',
        contentType: 'application/json',
        url: url,
        success: function (data) {
            if (data.length > 0) {
                html = '';
            }
            for (var i = 0; i < data.length; i++) {
                var _date = new Date(data[i].FechaAlta);
                classStyle = data[i].IdUsuario == IdUsuario ? 'post' : 'get';
                html = html + '<div class="modal-message-content ' + classStyle + '">' +
                    '<strong>' + _date.toLocaleDateString() + " - " + _date.toLocaleTimeString() + ' - ' + data[i].Nombre + ' ' + data[i].ApPaterno + '</strong></br>' +
                    data[i].Mensaje + '</div>';
            }
            $("#verMensajes .modal-message").append(html);
        },
        error: function (data) {
            showMessageType("danger", "Problemas con la conexíon, !O es el infierno en la tierra o se rompió el server!");
        }
    });
}