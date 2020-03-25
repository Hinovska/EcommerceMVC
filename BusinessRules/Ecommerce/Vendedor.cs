using AppCore.DataAccess.Factory;
using AppCore.DataAccess.Interface;
using System.Collections.Generic;
using sfEntities = AppCore.SystemFramework.Entities;

namespace AppCore.BusinessRules.Ecommerce
{
    public class Vendedor
    {

        private VendedorFactory factory;
        private IDatabase<sfEntities.Vendedor> vendedor;

        public Vendedor()
        {
            this.factory = new AgentVendedorFactory();
            this.vendedor = factory.GetInstance();
        }

        public sfEntities.Vendedor Insert(sfEntities.Vendedor objVendedor)
        {
            sfEntities.Vendedor result = vendedor.Insert(objVendedor);
            return result;
        }

        public sfEntities.Vendedor Update(sfEntities.Vendedor objVendedor)
        {
            sfEntities.Vendedor result = vendedor.Update(objVendedor);
            return result;
        }

        public bool Delete(int codigo)
        {
            bool result = vendedor.Delete(codigo);
            return result;
        }

        public sfEntities.Vendedor Get(int codigo)
        {
            sfEntities.Vendedor result = vendedor.Get(codigo);
            return result;
        }

        public List<sfEntities.Vendedor> List()
        {
            List<sfEntities.Vendedor> result = vendedor.List();
            return result;
        }
    }
}
