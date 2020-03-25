using AppCore.DataAccess.Factory;
using AppCore.DataAccess.Interface;
using System.Collections.Generic;
using sfEntities = AppCore.SystemFramework.Entities;

namespace AppCore.BusinessRules.Ecommerce
{
    public class Ciudad
    {
        public int Insert(sfEntities.Ciudad objCiudad)
        {
            sfEntities.Ciudad result;
            CiudadFactory factory = new ConcreteCiudadFactory();
            IDatabase<sfEntities.Ciudad> city = factory.GetInstance();
            result = city.Insert(objCiudad);
            return result.codigo;
        }

        public bool Update(sfEntities.Ciudad objCiudad)
        {
            bool result = false;
            CiudadFactory factory = new ConcreteCiudadFactory();
            IDatabase<sfEntities.Ciudad> city = factory.GetInstance();
            city.Update(objCiudad);
            return result;
        }

        public int Delete(int codigo)
        {
            sfEntities.Ciudad result;
            CiudadFactory factory = new ConcreteCiudadFactory();
            IDatabase<sfEntities.Ciudad> city = factory.GetInstance();
            result = city.Delete(codigo);
            return result.codigo;
        }

        public sfEntities.Ciudad Get(int codigo)
        {
            sfEntities.Ciudad result;
            CiudadFactory factory = new ConcreteCiudadFactory();
            IDatabase<sfEntities.Ciudad> city = factory.GetInstance();
            result = city.Get(codigo);
            return result;
        }

        public List<sfEntities.Ciudad> List()
        {
            List<sfEntities.Ciudad> result;
            CiudadFactory factory = new ConcreteCiudadFactory();
            IDatabase<sfEntities.Ciudad> city = factory.GetInstance();
            result = city.List();
            return result;
        }
    }
}
