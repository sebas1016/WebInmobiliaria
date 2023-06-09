var oTabla = $("#tblEmpleado").DataTable();
$(document).ready(function () {
    $('#tblEmpleado tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            oTabla.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            EditarFila($(this).closest('tr'));
        }
    });
    $("#bntInsertar").click(function () {
        EjecutarComando("Insertar");
    });
    $("#btnActualizar").click(function () {
        EjecutarComando("Actualizar");
    });
    $("#btnEliminar").click(function () {
        EjecutarComando("Eliminar");
    });
    
    LlenarComboCargo();
    LlenarComboGenero();
    LlenarComboSede();
    LlenarComboTipoContrato();
    LlenarComboTipoTelefono();

    //Invocar el llenado de la tabla
    LlenarTabla();

});
function EjecutarComando(Comando) {
    
    let id_empleado = $("#txtCedula").val();
    let nombre = $("#txtNombre").val();
    let apellido = $("#txtApellido").val();
    let email = $("#txtEmail").val();
    let tipo_tel = $("#cboTelefono").val();
    let telefono = $("#txtTelefono").val();
    let genero = $("#cboGenero").val();
    let cargo = $("#cboCargo").val(); 
    let tipo_contrato = $("#cboContrato").val(); 
    let sede = $("#cboSede").val();
    //let tipo_contrato = $("#cboContrato").val(); 
    let DatosEmpleado = {
        id_empleado: id_empleado,
        nombre: nombre,
        apellido: apellido,
        email: email,
        tipo_tel: tipo_tel,
        telefono: telefono,
        genero: genero,
        cargo: cargo,
        tipo_contrato: tipo_contrato,
        sede: sede,
        Comando: Comando,
   
    }
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorEmpleado.ashx",
        contentType: "json",
        data: JSON.stringify(DatosEmpleado),
        success: function (rpta) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(rpta);
            LlenarTabla();
        },
        error: function (errRpta) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errRpta);
        }
    });
}
function EditarFila(DatosFila) {
    $("#txtCedula").val(DatosFila.find('td:eq(0)').text());
    $("#txtNombre").val(DatosFila.find('td:eq(1)').text());
    $("#txtApellido").val(DatosFila.find('td:eq(2)').text());
    $("#txtEmail").val(DatosFila.find('td:eq(3)').text());
    $("#cboTelefono").val(DatosFila.find('td:eq(4)').text());
    $("#txtTelefono").val(DatosFila.find('td:eq(6)').text());
    $("#cboGenero").val(DatosFila.find('td:eq(7)').text());
    $("#cboSede").val(DatosFila.find('td:eq(13)').text());
    $("#cboCargo").val(DatosFila.find('td:eq(9)').text());
    $("#cboContrato").val(DatosFila.find('td:eq(11)').text());
    
}
function LlenarTabla() {
    let Datos = {
        id_empleado: 0,
        nombre: "",
        apellido: "",
        email: "",
        tipo_tel:0,
        telefono: "",
        telefononu: "",
        genero: 0,
        geners: "",
        cargo: 0,
        cargos: "",
        tipo_contrato:0,
        tipoC: "",
        sede: 0,
        sedes:"",
        Comando: "LlenarGrid"
        
    }
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorEmpleado.ashx",
        contentType: "json",
        data: JSON.stringify(Datos),
        success: function (rpta) {
            LlenarGrid_JSON(JSON.parse(rpta), "#tblEmpleado");
        },
        error: function (errRpta) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errRpta);
        }
    });
}
function LlenarComboCargo() {
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorCargo.ashx",
        contentType: "json",
        data: null,
        success: function (rpta) {
            //Crear un objeto JSON con la información
            Datos = JSON.parse(rpta);
            for (let op = 0; op < rpta.length; op++) {
                $("#cboCargo").append('<option value=' + Datos[op].id_cargo + '>' + Datos[op].descripcion + '</options>');
            }
        },
        error: function (errCliente) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errCliente);
        }
    });
}
function LlenarComboGenero() {
        $.ajax({
            type: "POST",
            url: "../Controladores/ControladorGenero.ashx",
            contentType: "json",
            data: null,
            success: function (rpta) {
                //Crear un objeto JSON con la información
                Datos = JSON.parse(rpta);
                for (let op = 0; op < rpta.length; op++) {
                    $("#cboGenero").append('<option value=' + Datos[op].genero1 + '>' + Datos[op].descripcion + '</options>');
                }
            },
            error: function (errCliente) {
                $("#dvMensaje").addClass("alert alert-danger");
                $("#dvMensaje").html(errCliente);
            }
        });
}
function LlenarComboSede() {
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorSede.ashx",
        contentType: "json",
        data: null,
        success: function (rpta) {
            //Crear un objeto JSON con la información
            Datos = JSON.parse(rpta);
            for (let op = 0; op < rpta.length; op++) {
                $("#cboSede").append('<option value=' + Datos[op].id_Sede + '>' + Datos[op].descripcion + '</options>');
            }
        },
        error: function (errCliente) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errCliente);
        }
    });
}
function LlenarComboTipoContrato() {
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorTipoContrato.ashx",
        contentType: "json",
        data: null,
        success: function (rpta) {
            //Crear un objeto JSON con la información
            Datos = JSON.parse(rpta);
            for (let op = 0; op < rpta.length; op++) {
                $("#cboContrato").append('<option value=' + Datos[op].id_tipo_contrato + '>' + Datos[op].nombre + '</options>');
            }
        },
        error: function (errCliente) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errCliente);
        }
    });
}
function LlenarComboTipoTelefono() {
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorTipoTelefono.ashx",
        contentType: "json",
        data: null,
        success: function (rpta) {
            //Crear un objeto JSON con la información
            Datos = JSON.parse(rpta);
            for (let op = 0; op < rpta.length; op++) {
                $("#cboTelefono").append('<option value=' + Datos[op].id_tipo_tel + '>' + Datos[op].descripcion + '</options>');
            }
        },
        error: function (errCliente) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errCliente);
        }
    });
}