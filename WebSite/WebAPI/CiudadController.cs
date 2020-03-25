using System;
using System.Collections.Generic;
using System.Web.Http;
using brAplication = AppCore.BusinessRules.Ecommerce;
using sfEntities = AppCore.SystemFramework.Entities;

namespace AppCore.WebSite.WebAPI
{
    public class CiudadController : ApiController
    {

        private brAplication.Ciudad brCiudad;

        public CiudadController()
        {
            this.brCiudad = new brAplication.Ciudad();
        }

        // GET: api/Ciudad
        [HttpGet]
        public IEnumerable<sfEntities.Ciudad> Get()
        {
            List<sfEntities.Ciudad> result = null;
            try
            {
                result = brCiudad.List();
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        // GET: api/Ciudad/5
        [HttpGet]
        public sfEntities.Ciudad Get(int codigo)
        {
            sfEntities.Ciudad result = null;
            try
            {
                if (codigo > 0) { result = brCiudad.Get(codigo); }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        // POST: api/Ciudad
        [HttpPost]
        public sfEntities.Ciudad Post([FromBody]sfEntities.Ciudad objRequest)
        {
            sfEntities.Ciudad result = null;
            try
            {
                if (objRequest != null && brCiudad.Get(objRequest.codigo) == null) { result = brCiudad.Insert(objRequest); }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        // PUT: api/Ciudad/5
        [HttpPut]
        public sfEntities.Ciudad Put(int codigo, [FromBody]sfEntities.Ciudad objRequest)
        {
            sfEntities.Ciudad result = null;
            try
            {
                if (codigo > 0 && objRequest != null && brCiudad.Get(codigo) != null)
                {
                    objRequest.codigo = codigo;
                    result = brCiudad.Update(objRequest);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        // DELETE: api/Ciudad/5
        [HttpDelete]
        public sfEntities.Ciudad Delete(int codigo)
        {
            sfEntities.Ciudad result = null;
            try
            {
                if (codigo > 0)
                {
                    result = brCiudad.Get(codigo);
                    if (result != null)
                    {
                        if (!brCiudad.Delete(codigo))
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
