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
            sfEntities.Ciudad result;
            using (var context = new DBModel.EcommerceEntities())
            {
                System.Data.Objects.ObjectParameter newid = new System.Data.Objects.ObjectParameter("@CODIGO", 0);
                var std = context.ins_CIUDAD(newid, objCiudad.descripcion);
                objCiudad.codigo = (int)newid.Value;
                result = objCiudad;
            }
            return result;
        }

        public sfEntities.Ciudad Update(sfEntities.Ciudad objCiudad)
        {
            sfEntities.Ciudad result;
            using (var context = new DBModel.EcommerceEntities())
            {
                var std = context.upd_CIUDAD(objCiudad.codigo, objCiudad.descripcion);
                result = objCiudad;
            }
            return result;
        }

        public sfEntities.Ciudad Delete(int codigo)
        {
            using (var context = new DBModel.EcommerceEntities())
            {
                var std = context.del_CIUDAD(codigo);
            }
            return new sfEntities.Ciudad();
        }

        public sfEntities.Ciudad Get(int codigo)
        {
            sfEntities.Ciudad result;
            using (var context = new DBModel.EcommerceEntities())
            {
                var std = context.get_CIUDAD(codigo);
                result = new sfEntities.Ciudad() { codigo = std.First<DBModel.get_CIUDAD_Result>().CODIGO, descripcion = std.First<DBModel.get_CIUDAD_Result>().DESCRIPCION };
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
