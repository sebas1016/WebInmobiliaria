using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Modelos;

namespace InmoviliariaWeb.Clases
{
    public class clsPropiedad
    {
        DBInmobiliariaEntities dbInmobiliaria = new DBInmobiliariaEntities();
        public Propiedade propiedades = new Propiedade();
        
        public List<Propiedade> LlenarGrid()
        {
            return dbInmobiliaria.Propiedades
                   .OrderByDescending(p => p.id_propiedad)
                   .ToList();
        }



        public string Insertar()
        {
            CalcularValorFinal();
            dbInmobiliaria.Propiedades.Add(propiedades);
            try
            {
                dbInmobiliaria.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                Console.WriteLine(e);
            }
            
            return "Se insertó la propiedad con ID: " + propiedades.id_propiedad;
        }


        public string Actualizar()
        {
            Propiedade propiedad_Actual = dbInmobiliaria.Propiedades.FirstOrDefault(p => p.id_propiedad == propiedades.id_propiedad);

            if (propiedad_Actual == null)
            {
                throw new Exception("Error: no se pudo actualizar la Propiedad con identificacion " + propiedades.id_propiedad + ". La propiedad no existe en la base de datos.");
            }

            propiedad_Actual.direccion = propiedades.direccion;
            propiedad_Actual.ciudad = propiedades.ciudad;
            propiedad_Actual.departamento = propiedades.departamento;
            propiedad_Actual.tipo_propiedad = propiedades.tipo_propiedad;
            propiedad_Actual.num_habitaciones = propiedades.num_habitaciones;
            propiedad_Actual.num_habitaciones = propiedades.num_habitaciones;
            propiedad_Actual.estacionamiento = propiedades.estacionamiento;
            propiedad_Actual.estado = propiedades.estado;
            propiedad_Actual.tipo_contrato = propiedades.tipo_contrato;
            propiedad_Actual.precio_inicial = propiedades.precio_inicial;
            CalcularValorFinal();
            propiedad_Actual.comision = propiedades.comision;
            propiedad_Actual.precio_final = propiedades.precio_final;

            
            dbInmobiliaria.Entry(propiedad_Actual).State = EntityState.Modified;
            dbInmobiliaria.SaveChanges();
            return "Se actualizó la propiedad con identificacion: " + propiedades.id_propiedad;
        }

        public string Eliminar()
        {
            Propiedade propiedad_Elim = dbInmobiliaria.Propiedades.FirstOrDefault(p => p.id_propiedad == propiedades.id_propiedad);
            dbInmobiliaria.Propiedades.Remove(propiedad_Elim);
            dbInmobiliaria.SaveChanges();
            return "Se elimino la Propiedad: " + propiedades.id_propiedad;
        }


        private void CalcularValorFinal()
        {
            double ValorUnitario;
            if (propiedades.precio_inicial <= 800000)
            {
                propiedades.comision = 1;
                ValorUnitario = 0.05;
            }
            else
            {
                if (propiedades.precio_inicial > 800000 && propiedades.precio_inicial <= 1500000 )
                {
                    propiedades.comision = 2;
                    ValorUnitario = 0.1;
                }
                else
                {
                    propiedades.comision = 3;
                    ValorUnitario = 0.15;
                }
            }

            propiedades.precio_final = Convert.ToInt32((propiedades.precio_inicial * ValorUnitario) + propiedades.precio_inicial);
        }

    }
}