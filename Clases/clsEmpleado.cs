using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Modelos;

namespace InmoviliariaWeb.Clases
{
    public class clsEmpleado
    {
        private DBInmobiliariaEntities dbSuper = new DBInmobiliariaEntities();
        public Empleado _empleado { get; set; }

        public List<ViewGridEmpleado> ListarProductos()
        {
            return (from Em in dbSuper.Set<Empleado>()
                    join TT in dbSuper.Set<Tipo_Tel>()
                    on Em.tipo_tel equals TT.id_tipo_tel
                    join SE in dbSuper.Set<Sede>()
                     on Em.sede equals SE.id_Sede
                    join GE in dbSuper.Set<Genero>()
                     on Em.genero equals GE.genero1
                    join Ca in dbSuper.Set<Cargo>()
                     on Em.cargo equals Ca.id_cargo
                    join TC in dbSuper.Set<TiposContrato>()
                     on Em.tipo_contrato equals TC.id_tipo_contrato


                    select new ViewGridEmpleado
                    {
                        id_empleado = Em.id_empleado,
                        nombre = Em.nombre,
                        apellido = Em.apellido,
                        email = Em.email,
                        telefononu = Em.telefono,
                        tipo_tel = TT.id_tipo_tel,
                        telefono = TT.descripcion,
                        tipoC = TC.nombre,
                        tipo_contrato = TC.id_tipo_contrato,
                        genero = GE.genero1,
                        geners = GE.descripcion,
                        sedes = SE.descripcion,
                        sede = SE.id_Sede,
                        cargo = Ca.id_cargo,
                        cargos = Ca.descripcion

                    }).ToList();
        }
        public string Insertar()
        {
            dbSuper.Empleados.Add(_empleado);
            dbSuper.SaveChanges();
            return "Se insertó el producto: " + _empleado.nombre;
        }
       public string Eliminar()
        {
            Empleado empleado = dbSuper.Empleados.FirstOrDefault(p=> p.id_empleado == _empleado.id_empleado);
            dbSuper.Empleados.Remove(empleado);
            dbSuper.SaveChanges();
            return "";
        }

        public string Actualizar()
        {
            Empleado empleado = dbSuper.Empleados.FirstOrDefault(p => p.id_empleado == _empleado.id_empleado);
            empleado.nombre = _empleado.nombre;
            empleado.apellido = _empleado.apellido;
            empleado.email = _empleado.email;
            empleado.genero = _empleado.genero;
            empleado.tipo_tel = _empleado.tipo_tel;
            empleado.telefono = _empleado.telefono;
            empleado.cargo = _empleado.cargo;
            empleado.tipo_contrato = _empleado.tipo_contrato;
            empleado.sede = _empleado.sede;

            dbSuper.SaveChanges();
            return "Se actualizó el empleado con cedula: " + _empleado.id_empleado;
        }
    }
}