using AppCore.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sfEntities = AppCore.SystemFramework.Entities;


namespace AppCore.DataAccess.Factory
{
    public abstract class CiudadFactory
    {
        public abstract IDatabase<sfEntities.Ciudad> GetInstance();
    }
}
