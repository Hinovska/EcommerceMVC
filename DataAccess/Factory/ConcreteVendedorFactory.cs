using AppCore.DataAccess.DataEntities;
using AppCore.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sfEntities = AppCore.SystemFramework.Entities;

namespace AppCore.DataAccess.Factory
{
    public class ConcreteVendedorFactory : VendedorFactory
    {
        public override IDatabase<sfEntities.Vendedor> GetInstance()
        {
            return new DataAccess.DataEntities.Vendedor();
        }

    }
}
