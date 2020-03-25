using AppCore.DataAccess.Factory;
using AppCore.DataAccess.Interface;
using System.Collections.Generic;
using sfEntities = AppCore.SystemFramework.Entities;

namespace AppCore.BusinessRules.Ecommerce
{
    public class Ciudad
    {
        private CiudadFactory factory;
        private IDatabase<sfEntities.Ciudad> city;

        public Ciudad()
        {
            this.factory = new AgentCiudadFactory();
            this.city = factory.GetInstance();
        }

        public sfEntities.Ciudad Insert(sfEntities.Ciudad objCiudad)
        {
            sfEntities.Ciudad result = city.Insert(objCiudad);
            return result;
        }

        public sfEntities.Ciudad Update(sfEntities.Ciudad objCiudad)
        {
            sfEntities.Ciudad result = city.Update(objCiudad);
            return result;
        }

        public bool Delete(int codigo)
        {
            bool result = city.Delete(codigo);
            return result;
        }

        public sfEntities.Ciudad Get(int codigo)
        {
            sfEntities.Ciudad result = city.Get(codigo);
            return result;
        }

        public List<sfEntities.Ciudad> List()
        {
            List<sfEntities.Ciudad> result = city.List();
            return result;
        }
    }
}
