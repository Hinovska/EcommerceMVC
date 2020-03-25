using AppCore.DataAccess.Interface;
using System.Collections.Generic;
using System.Linq;
using sfEntities = AppCore.SystemFramework.Entities;

namespace AppCore.DataAccess.DataEntities
{
    public class Ciudad : IDatabase<sfEntities.Ciudad>
    {
        public sfEntities.Ciudad Insert(sfEntities.Ciudad objCiudad)
        {
            sfEntities.Ciudad result = null;
            using (var context = new DBModel.EcommerceEntities())
            {
                System.Data.Objects.ObjectParameter newid = new System.Data.Objects.ObjectParameter("CODIGO", 0);
                var std = context.ins_CIUDAD(newid, objCiudad.descripcion);
                if (std > 0)
                {
                    objCiudad.codigo = (int)newid.Value;
                    result = objCiudad;
                }        
            }
            return result;
        }

        public sfEntities.Ciudad Update(sfEntities.Ciudad objCiudad)
        {
            sfEntities.Ciudad result = null;
            using (var context = new DBModel.EcommerceEntities())
            {
                var std = context.upd_CIUDAD(objCiudad.codigo, objCiudad.descripcion);
                result = (std > 0) ? objCiudad : null;
            }
            return result;
        }

        public bool Delete(int codigo)
        {
            bool result = false;
            using (var context = new DBModel.EcommerceEntities())
            {
                var std = context.del_CIUDAD(codigo);
                result = (std > 0) ? true : false;
            }
            return result;
        }

        public sfEntities.Ciudad Get(int codigo)
        {
            sfEntities.Ciudad result = null;
            using (var context = new DBModel.EcommerceEntities())
            {
                var std = context.get_CIUDAD(codigo);
                var item = std.FirstOrDefault<DBModel.get_CIUDAD_Result>();
                if (item != null)
                {
                    result = new sfEntities.Ciudad() { codigo = item.CODIGO, descripcion = item.DESCRIPCION };
                }
            }
            return result;
        }

        public List<sfEntities.Ciudad> List()
        {
            List<sfEntities.Ciudad> result;
            using (var context = new DBModel.EcommerceEntities())
            {
                var std = context.lst_CIUDAD();
                result = new List<sfEntities.Ciudad>();
                foreach (var item in std)
                {
                    result.Add(new sfEntities.Ciudad()
                    {
                        codigo = item.CODIGO,
                        descripcion = item.DESCRIPCION
                    });
                }
            }
            return result;
        }
    }
}
