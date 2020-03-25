using AppCore.DataAccess.Factory;
using AppCore.DataAccess.Interface;
using System.Collections.Generic;
using sfEntities = AppCore.SystemFramework.Entities;

namespace AppCore.BusinessRules.Ecommerce
{
    public class Vendedor
    {
        public int Insert(sfEntities.Vendedor objVendedor)
        {
            sfEntities.Vendedor result;
            VendedorFactory factory = new ConcreteVendedorFactory();
            IDatabase<sfEntities.Vendedor> vendedor = factory.GetInstance();
            result = vendedor.Insert(objVendedor);
            return result.codigo;
        }

        public bool Update(sfEntities.Vendedor objVendedor)
        {
            bool result = false;
            VendedorFactory factory = new ConcreteVendedorFactory();
            IDatabase<sfEntities.Vendedor> vendedor = factory.GetInstance();
            vendedor.Update(objVendedor);
            return result;
        }

        public int Delete(int codigo)
        {
            sfEntities.Vendedor result;
            VendedorFactory factory = new ConcreteVendedorFactory();
            IDatabase<sfEntities.Vendedor> vendedor = factory.GetInstance();
            result = vendedor.Delete(codigo);
            return result.codigo;
        }

        public sfEntities.Vendedor Get(int codigo)
        {
            sfEntities.Vendedor result;
            VendedorFactory factory = new ConcreteVendedorFactory();
            IDatabase<sfEntities.Vendedor> vendedor = factory.GetInstance();
            result = vendedor.Get(codigo);
            return result;
        }

        public List<sfEntities.Vendedor> List()
        {
            List<sfEntities.Vendedor> result;
            VendedorFactory factory = new ConcreteVendedorFactory();
            IDatabase<sfEntities.Vendedor> vendedor = factory.GetInstance();
            result = vendedor.List();
            return result;
        }
    }
}
