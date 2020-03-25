using System;
using System.Collections.Generic;
using System.Web.Http;
using brAplication = AppCore.BusinessRules.Ecommerce;
using sfEntities = AppCore.SystemFramework.Entities;

namespace AppCore.WebSite.WebAPI
{
    public class VendedorController : ApiController
    {
        private brAplication.Vendedor brVendedor;

        public VendedorController()
        {
            this.brVendedor = new brAplication.Vendedor();
        }

        // GET: api/Vendedor
        public IEnumerable<sfEntities.Vendedor> Get()
        {
            List<sfEntities.Vendedor> result = null;
            try
            {
                result = brVendedor.List();
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        // GET: api/Vendedor/5
        public sfEntities.Vendedor Get(int codigo)
        {
            sfEntities.Vendedor result = null;
            try
            {
                if (codigo > 0) { result = brVendedor.Get(codigo); }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        // POST: api/Vendedor
        [HttpPost]
        public sfEntities.Vendedor Post([FromBody]sfEntities.Vendedor objRequest)
        {
            sfEntities.Vendedor result = null;
            try
            {
                if (objRequest != null && brVendedor.Get(objRequest.codigo) == null) { result = brVendedor.Insert(objRequest); }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        // PUT: api/Vendedor/5
        public sfEntities.Vendedor Put(int codigo, [FromBody]sfEntities.Vendedor objRequest)
        {
            sfEntities.Vendedor result = null;
            try
            {
                if (codigo > 0 && objRequest != null && brVendedor.Get(codigo) != null)
                {
                    objRequest.codigo = codigo;
                    result = brVendedor.Update(objRequest);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        // DELETE: api/Vendedor/5
        public sfEntities.Vendedor Delete(int codigo)
        {
            sfEntities.Vendedor result = null;
            try
            {
                if (codigo > 0)
                {
                    result = brVendedor.Get(codigo);
                    if (result != null)
                    {
                        if (!brVendedor.Delete(codigo))
                        {
                            result = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }
}
