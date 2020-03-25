using AppCore.DataAccess.Interface;
using sfEntities = AppCore.SystemFramework.Entities;


namespace AppCore.DataAccess.Factory
{
    public abstract class VendedorFactory
    {
        public abstract IDatabase<sfEntities.Vendedor> GetInstance();
    }
}
