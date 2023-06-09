using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using InmoviliariaWeb.Modelos;

namespace InmoviliariaWeb.Clases
{
    public class clsCliente
    {
        DBInmobiliariaEntities dbCliente = new DBInmobiliariaEntities();
        public Cliente cliente = new Cliente();
        public List<Cliente> LlenarGrid()
        {
            return dbCliente.Clientes
                   .OrderByDescending(p => p.id_cliente)
                   .ToList();
        }
        public string Eliminar()
        {
            Cliente cliente_Elim = dbCliente.Clientes.FirstOrDefault(p => p.id_cliente == cliente.id_cliente);
            dbCliente.Clientes.Remove(cliente_Elim);
            dbCliente.SaveChanges();
            return "Se eliminó el cliente: " + cliente.nombre;
        }
        public string Insertar()
        {
            try
            {
                dbCliente.Clientes.Add(cliente);
                dbCliente.SaveChanges();
                return "Se insertó el cliente con documento: " + cliente.id_cliente;
            }
            catch (Exception)
            {

                throw new Exception("Error: El cliente con identificacion " + cliente.id_cliente + " ya esta almacenado en la base de datos");
            }
            
        }
        public string Actualizar()
        {
                Cliente _cliente = dbCliente.Clientes.FirstOrDefault(p => p.id_cliente == cliente.id_cliente);

                if (_cliente == null)
                {
                  throw new Exception("Error: No se pudo actualizar el cliente con identificacion " + cliente.id_cliente + ". El cliente no existe en la base de datos.");
                }

                _cliente.nombre = cliente.nombre;
                _cliente.apellido = cliente.apellido;
                _cliente.email = cliente.email;
                _cliente.genero = cliente.genero;
                _cliente.direccion = cliente.direccion;
                _cliente.ciudad = cliente.ciudad;

                dbCliente.Entry(_cliente).State = EntityState.Modified;

                dbCliente.SaveChanges();

                return "Se actualizó el cliente con identificacion: " + cliente.id_cliente;
            
        }
    }
}

