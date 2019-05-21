function GetMessageType(type, modalMessage) {
    var typeMessage = '';
    switch (type) {
        case 'success':
            typeMessage = 'success';
            break;
        case 'info':
            typeMessage = 'info';
            break;
        case 'warning':
            typeMessage = 'warning';
            break;
        case 'danger':
            typeMessage = 'danger';
            break;
        default:
            typeMessage = 'info';
    }
    var message = '<div class="container-fluid"><div class="row"><div class="col-xs-12"><div class="alert alert-' + typeMessage + ' text-center" role="alert"><p class="h4">';
    message += modalMessage;
    message += '</p></div></div></div></div>';
    return message;
};

function showMessageType(type, message, delay) {
    if (delay == undefined)
        delay = 6;
    var htmlMessage = GetMessageType(type, message);
    $(mensajesexp).stop(true, true).slideUp(0); //.html(htmlMessage).slideDown(600).delay(5000).slideUp(600);
    $(mensajesexp).html(htmlMessage);
    $(mensajesexp).slideDown(600).delay(delay * 1000).slideUp(600);
}

jQuery(function (t) {


    $("#BtnAltaUsuario").click(function () {
        var elemento = document.getElementById("BtnAltaUsuario");
        elemento.style.display = 'none';
        var nombre = $("#form1-q-name").val();
        var apepat = $("#form1-q-apapaterno").val();
        var apemat = $("#form1-q-apemat").val();
        var email = $("#form1-q-email").val();
        var telefono = $("#form2-q-tel").val();
        var password = $("#form2-q-pass").val();

        if (nombre != "" && apepat != "" && apemat != "" && email != "", telefono != "", password!="" ) {

            var registros;
           
            $.post(_apiUX + 'api/values', 
                {
                Nombre: nombre,
                ApPaterno: apepat,
                ApMaterno: apemat,
                Email: email,
                Password: password,
                Telefono:telefono
                }, null, "json").done(function (data) {

                      
                        registros = data.Nombre;
                        
                        showMessageType("success", "¡Hola " + registros + " ahora vas a recibir un email para completar tu registro!");   
                        limpiarFormulario();
                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    showMessageType("warning", "Problemas" + textStatus);
                    limpiarFormulario();
                    
                 
                });
        } else
        {
            showMessageType("warning", "Sorry Todos Los campos son obligatorios...");
            muestraBTN();
        }
        
        
    });

    function muestraBTN()
    {
        var elemento = document.getElementById("BtnAltaUsuario");
        elemento.style.display = 'block';
    }

    function limpiarFormulario()
    {

        $("#form1-q-name").val("");
        $("#form1-q-apapaterno").val("");
        $("#form1-q-apemat").val("");
        $("#form1-q-email").val("");
        $("#form2-q-tel").val("");
        $("#form2-q-pass").val("");
        var elemento = document.getElementById("BtnAltaUsuario");
        elemento.style.display = 'block';
    }
})