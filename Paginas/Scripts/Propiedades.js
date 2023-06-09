var oTabla = $("#tblPropiedades").DataTable();
$(document).ready(function () {
    $('#btnBuscar').click(function () {
        Consultar();
    });
    $('#tblPropiedades tbody').on('click', 'tr', function () {
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
    //Invoca el llenado de la tabla
    LlenarComboCiudad();
    //Invocar el llenado del combo
    LlenarComboPropiedad();
    //Invocar el llenado del combo
    LlenarComboDepartamento();
    //Invocar el llenado del combo
    LlenarComboTipoPropiedad();
    //Invocar el llenado del combo
    LlenarComboEstacionamiento();
    //Invocar el llenado del combo
    LlenarComboEstado();
    //Invocar el llenado del combo
    LlenarComboTipoContrato();
    //Invoca el llenado de la tabla
    LlenarTablaPropiedades();

});

function Consultar() {
    //invoca el servicion
    let idPropiedad = $("#txtid_propiedad").val();
    alert(idPropiedad)
    $.ajax({
        type: "GET",
        url: "http://localhost:51789//api/Propiedad?idPropiedad=" + idPropiedad,
        contentType: "json",
        data: null,
        dataType: "json",
        success: function (rpta) {
            $("#txtDireccion").val(rpta.direccion);
            $("#cboCiudad").val(rpta.ciudad);
            $("#cboDepartamento").val(rpta.departamento);
            $("#cboTipoPropiedad").val(rpta.tipo_propiedad);
            $("#txtNumHabitaciones").val(rpta.num_habitaciones);
            $("#txtNumBanos").val(rpta.num_banos);
            $("#cboEstacionamiento").val(rpta.estacionamiento);
            $("#cboEstado").val(rpta.estado);
            $("#cboTipoContrato").val(rpta.tipo_contrato);
            $("#txtPrecioInicial").val(rpta.precio_inicial);
            $("#cboComision").val(rpta.comision);
            $("#txtPrecioFinal").val(rpta.precio_final);
        },
        error: function (errRpta) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errRpta);
        }
    });
}

function EjecutarComando(Comando) {
    let id_propiedad = $("#txtid_propiedad").val();
    let direccion = $("#txtDireccion").val();
    let ciudad = $("#cboCiudad").val();
    let departamento = $("#cboDepartamento").val();
    let tipo_propiedad = $("#cboTipoPropiedad").val();
    let num_habitaciones = $("#txtNumHabitaciones").val();
    let num_banos = $("#txtNumBanos").val();
    let estacionamiento = $("#cboEstacionamiento").val();
    let estado = $("#cboEstado").val();
    let tipo_contrato = $("#cboTipoContrato").val();
    let precio_inicial = $("#txtPrecioInicial").val();
    let comision = $("#cboComision").val();
    let DatosPropiedad = {
        id_propiedad: id_propiedad,
        direccion: direccion,
        ciudad: ciudad,
        departamento: departamento,
        tipo_propiedad: tipo_propiedad,
        num_habitaciones: num_habitaciones,
        num_banos: num_banos,
        estacionamiento: estacionamiento,
        estado: estado,
        tipo_contrato: tipo_contrato,
        precio_inicial: precio_inicial,
        comision: comision,
        precio_final: 0,
        Comando: Comando,
    }
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorPropiedad.ashx",
        contentType: "json",
        data: JSON.stringify(DatosPropiedad),
        success: function (rpta) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(rpta);
            LlenarTablaPropiedades();
        },
        error: function (errRpta) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errRpta);
        }
    });
}
function EditarFila(DatosFila) {
    $("#txtid_propiedad").val(DatosFila.find('td:eq(0)').text());
    $("#txtDireccion").val(DatosFila.find('td:eq(1)').text());
    $("#cboCiudad").val(DatosFila.find('td:eq(2)').text());
    $("#cboDepartamento").val(DatosFila.find('td:eq(3)').text());
    $("#cboTipoPropiedad").val(DatosFila.find('td:eq(4)').text());
    $("#txtNumHabitaciones").val(DatosFila.find('td:eq(5)').text());
    $("#txtNumBanos").val(DatosFila.find('td:eq(6)').text());
    $("#cboEstacionamiento").val(DatosFila.find('td:eq(7)').text());
    $("#cboEstado").val(DatosFila.find('td:eq(8)').text());
    $("#cboTipoContrato").val(DatosFila.find('td:eq(9)').text());
    $("#txtPrecioInicial").val(DatosFila.find('td:eq(10)').text());
    $("#cboComision").val(DatosFila.find('td:eq(11)').text());
    $("#txtPrecioFinal").val(DatosFila.find('td:eq(12)').text());
}
function LlenarComboPropiedad() {
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorCombosPropiedad.ashx",
        contentType: "json",
        data: null,
        success: function (rpta) {
            //Crear un objeto JSON con la información
            DatosCombo = JSON.parse(rpta);
            for (let op = 0; op < rpta.length; op++) {
                $("#cboComision").append('<option value=' + DatosCombo[op].id_comision + '>' + DatosCombo[op].descricion + '</options>');
            }
        },
        error: function (errCliente) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errCliente);
        }
    });
}

function LlenarComboCiudad() {
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorCiudad.ashx",
        contentType: "json",
        data: null,
        success: function (rpta) {
            //Crear un objeto JSON con la información
            DatosCombo = JSON.parse(rpta);
            for (let op = 0; op < rpta.length; op++) {
                $("#cboCiudad").append('<option value=' + DatosCombo[op].id_ciudad + '>' + DatosCombo[op].descripcion + '</options>');
            }
        },
        error: function (errCliente) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errCliente);
        }
    });
}

function LlenarComboDepartamento() {
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorDepartamento.ashx",
        contentType: "json",
        data: null,
        success: function (rpta) {
            //Crear un objeto JSON con la información
            DatosCombo = JSON.parse(rpta);
            for (let op = 0; op < rpta.length; op++) {
                $("#cboDepartamento").append('<option value=' + DatosCombo[op].id_departamento + '>' + DatosCombo[op].descripcion + '</options>');
            }
        },
        error: function (errCliente) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errCliente);
        }
    });
}

function LlenarComboTipoPropiedad() {
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorTipoPropiedad.ashx",
        contentType: "json",
        data: null,
        success: function (rpta) {
            //Crear un objeto JSON con la información
            DatosCombo = JSON.parse(rpta);
            for (let op = 0; op < rpta.length; op++) {
                $("#cboTipoPropiedad").append('<option value=' + DatosCombo[op].id_tipo_propiedad + '>' + DatosCombo[op].nombre + '</options>');
            }
        },
        error: function (errCliente) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errCliente);
        }
    });
}


function LlenarComboEstacionamiento() {
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorEstacionamiento.ashx",
        contentType: "json",
        data: null,
        success: function (rpta) {
            //Crear un objeto JSON con la información
            DatosCombo = JSON.parse(rpta);
            for (let op = 0; op < rpta.length; op++) {
                $("#cboEstacionamiento").append('<option value=' + DatosCombo[op].id_estacionamiento + '>' + DatosCombo[op].descripcion + '</options>');
            }
        },
        error: function (errCliente) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errCliente);
        }
    });
}


function LlenarComboEstado() {
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorEstado.ashx",
        contentType: "json",
        data: null,
        success: function (rpta) {
            //Crear un objeto JSON con la información
            DatosCombo = JSON.parse(rpta);
            for (let op = 0; op < rpta.length; op++) {
                $("#cboEstado").append('<option value=' + DatosCombo[op].id_estado_propiedad + '>' + DatosCombo[op].descripcion + '</options>');
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
        url: "../Controladores/ControladorTipoContratoProp.ashx",
        contentType: "json",
        data: null,
        success: function (rpta) {
            //Crear un objeto JSON con la información
            DatosCombo = JSON.parse(rpta);
            for (let op = 0; op < rpta.length; op++) {
                $("#cboTipoContrato").append('<option value=' + DatosCombo[op].id_tipo_contrato + '>' + DatosCombo[op].nombre + '</options>');
            }
        },
        error: function (errCliente) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errCliente);
        }
    });
}


function LlenarTablaPropiedades() {
    let DatosPropiedad = {
        id_propiedad: 0,
        direccion: "",
        ciudad: 0,
        departamento: 0,
        tipo_propiedad: 0,
        num_habitaciones: 0,
        num_banos: 0,
        estacionamiento: 0,
        estado: 0,
        tipo_contrato: 0,
        precio_inicial: 0,
        comision: 0,
        precio_final: 0,
        Comando: "LlenarGrid",
    }
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorPropiedad.ashx",
        contentType: "json",
        data: JSON.stringify(DatosPropiedad),
        success: function (rpta) {
            LlenarGrid_JSON(JSON.parse(rpta), "#tblPropiedades");
            /*
            //Crear un objeto JSON con la información
            Datos = JSON.parse(rpta);
            //Llenar la tabla
            var columns = [];
            columnNames = Object.keys(Datos[0]);
            for (var i in columnNames) {
                columns.push({
                    data: columnNames[i],
                    title: columnNames[i]
                });
            }

            $("#tblVenta").DataTable({
                data: Datos,
                columns: columns,
                destroy: true
            });
            */
        },
        error: function (errRpta) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errRpta);
        }
    });
}