using AppCore.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sfEntities = AppCore.SystemFramework.Entities;

namespace AppCore.DataAccess.DataEntities
{
    public class Vendedor : IDatabase<sfEntities.Vendedor>
    {
        public sfEntities.Vendedor Insert(sfEntities.Vendedor obj)
        {
            return new sfEntities.Vendedor();
        }
        public sfEntities.Vendedor Update(sfEntities.Vendedor obj)
        {
            return new sfEntities.Vendedor();
        }
        public sfEntities.Vendedor Delete(int codigo)
        {
            return new sfEntities.Vendedor();
        }
        public sfEntities.Vendedor Get(int codigo)
        {
            return new sfEntities.Vendedor();
        }
        public List<sfEntities.Vendedor> List()
        {
            return new List<sfEntities.Vendedor>();
        }
    }
}
