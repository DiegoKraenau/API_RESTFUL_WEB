using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RapiSolver.Entity;
using RapiSolver.Repository.context;
using RapiSolver.Repository.ViewModel;

namespace RapiSolver.Repository.implementation
{
    public class CustomerRepository : ICustomerRepository
    {

        private ApplicationDbContext context;

        public CustomerRepository (ApplicationDbContext context) {
            this.context = context;
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Customer Get(int id)
        {
            var result = new Customer();
            try
            {
                result = context.customers.Find(id);
            }

            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Customer> GetAll()
        {
            var result = new  List<Customer>();
            try{
                result = context.customers.ToList();

            }
            catch(System.Exception){
                throw;
            }
            return result;
        }

        public IEnumerable<CustomerViewModel> GetAllCustomers()
        {
            var customers = context.customers
                .Include (o => o.Usuario)
                .Include(o=>o.Location)
                .OrderByDescending (o => o.CustomerId)
                .Take (10)
                .ToList ();

            return customers.Select (o => new CustomerViewModel {
                    CustomerId = o.CustomerId,
                    Name = o.Name,
                    LastName = o.LastName,
                    Email = o.Email,
                    Phone=o.Phone,
                    Age=o.Age,
                    Genger=o.Genger,
                    UsuarioId=o.UsuarioId,
                    LocationId=o.LocationId,
                    UserName=o.Usuario.UserName,
                    Country=o.Location.Country
             });
        }

        public IEnumerable<CustomerViewModel> GetCustomerByUserId(int id)
        {
            var customers = context.customers
                .Include (o => o.Usuario)
                .Include(o=>o.Location)
                .OrderByDescending (o => o.CustomerId)
                .Where(o=>o.UsuarioId==id)
                .ToList ();

            return customers.Select (o => new CustomerViewModel {
                    CustomerId = o.CustomerId,
                    Name = o.Name,
                    LastName = o.LastName,
                    Email = o.Email,
                    Phone=o.Phone,
                    Age=o.Age,
                    Genger=o.Genger,
                    UsuarioId=o.UsuarioId,
                    LocationId=o.LocationId,
                    UserName=o.Usuario.UserName,
                    Country=o.Location.Country
             });throw new System.NotImplementedException();
        }

        public bool Save(Customer entity)
        {
             try
            {
                
                Usuario u1=new Usuario();
                u1.UserName=entity.Email;
                u1.UserPassword=entity.Contraseña;
                u1.RolId=1;
                u1.Rol=context.roles.Find(u1.RolId);

                context.Add(u1);
                context.SaveChanges();

                entity.UsuarioId=context.usuarios.Single(x=>x.UserName==entity.Email).UsuarioId;

                Location l1=new Location();
                l1.Country=entity.Country;
                l1.City=entity.City;
                l1.State=entity.State;
                l1.Address=entity.Address;

                context.Add(l1);
                context.SaveChanges();
        
                entity.Location=l1;
                entity.LocationId=1;
               
                entity.Usuario=context.usuarios.Find(entity.UsuarioId);
                
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public bool Update(Customer entity)
        {
              try
            {
                Customer c1=context.customers.Find(entity.CustomerId);
                Usuario u1=context.usuarios.Find(c1.UsuarioId);
                u1.UserName=entity.Email;
                u1.UserPassword=entity.Contraseña;
                u1.RolId=1;
                u1.Rol=context.roles.Find(u1.RolId);
                context.Update(u1);
                context.SaveChanges();

                
                Location l1=context.locations.Find(c1.LocationId);
                l1.Country=entity.Country;
                l1.City=entity.City;
                l1.State=entity.State;
                l1.Address=entity.Address;

                context.Update(l1);
                context.SaveChanges();

                c1.Genger=entity.Genger;
                c1.LastName=entity.LastName;
                c1.Name=entity.Name;
                c1.Phone=entity.Phone;
                c1.Age=entity.Age;
                c1.Email=entity.Email;
                c1.Contraseña=entity.Contraseña;
                c1.City=entity.City;
                c1.Country=entity.Country;
                c1.State=entity.State;
                c1.Address=entity.Address;

                
                
                context.Update(c1);
                context.SaveChanges();
                
                

                
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public bool ValidarSubscripcion(int id)
        {
           
            try{
                Customer c1=context.customers.Where(x=>x.UsuarioId==id).FirstOrDefault();
                Usuario u1=context.usuarios.Find(c1.UsuarioId);
                u1.RolId=2;
                u1.Rol=context.roles.Find(2);
                context.Update(u1);
                context.SaveChanges();
                Supplier s1=new Supplier();
                s1.Address=c1.Address;
                s1.Age=c1.Age;
                s1.City=c1.City;
                s1.Contraseña=c1.Contraseña;
                s1.Country=c1.Country;
                s1.Email=c1.Email;
                s1.Genger=c1.Genger;
                s1.LastName=c1.LastName;
                s1.Location=c1.Location;
                s1.LocationId=c1.LocationId;
                s1.Name=c1.Name;
                s1.Phone=c1.Phone;
                s1.State=c1.State;
                s1.Usuario=c1.Usuario;
                s1.UsuarioId=c1.UsuarioId;
                context.Remove(c1);
                context.SaveChanges();
                context.Add(s1);
                context.SaveChanges();



            }
            catch(System.Exception){
                return false;
            }
            return true;
        }
    }
}