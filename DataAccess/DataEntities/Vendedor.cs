using AppCore.DataAccess.Interface;
using System.Collections.Generic;
using System.Linq;
using sfEntities = AppCore.SystemFramework.Entities;

namespace AppCore.DataAccess.DataEntities
{
    public class Vendedor : IDatabase<sfEntities.Vendedor>
    {
        public sfEntities.Vendedor Insert(sfEntities.Vendedor objVendedor)
        {
            sfEntities.Vendedor result = null;
            using (var context = new DBModel.EcommerceEntities())
            {
                System.Data.Objects.ObjectParameter newid = new System.Data.Objects.ObjectParameter("CODIGO", 0);
                var std = context.ins_VENDEDOR(newid, objVendedor.nombres, objVendedor.apellidos, objVendedor.numero_identificacion, objVendedor.codigo_ciudad);
                if (std > 0)
                {
                    objVendedor.codigo = (int)newid.Value;
                    //Get para vaidar las mayusculas de nombre y apellido (Removible por performance)
                    result = this.Get(objVendedor.codigo);
                }
            }
            return result;
        }

        public sfEntities.Vendedor Update(sfEntities.Vendedor objVendedor)
        {
            sfEntities.Vendedor result = null;
            using (var context = new DBModel.EcommerceEntities())
            {
                var std = context.upd_VENDEDOR(objVendedor.codigo, objVendedor.nombres, objVendedor.apellidos, objVendedor.numero_identificacion, objVendedor.codigo_ciudad);
                //Get para vaidar las mayusculas de nombre y apellido (Removible por performance)
                result = (std > 0) ? this.Get(objVendedor.codigo) : null;
            }
            return result;
        }

        public bool Delete(int codigo)
        {
            bool result = false;
            using (var context = new DBModel.EcommerceEntities())
            {
                var std = context.del_VENDEDOR(codigo);
                result = (std > 0) ? true : false;
            }
            return result;
        }

        public sfEntities.Vendedor Get(int codigo)
        {
            sfEntities.Vendedor result = null;
            using (var context = new DBModel.EcommerceEntities())
            {
                var std = context.get_VENDEDOR(codigo);
                var item = std.FirstOrDefault<DBModel.get_VENDEDOR_Result>();
                if (item != null)
                {
                    result = new sfEntities.Vendedor()
                    {
                        codigo = item.CODIGO,
                        nombres = item.NOMBRE,
                        apellidos = item.APELLIDO,
                        numero_identificacion = item.NUMERO_IDENTIFICACION,
                        codigo_ciudad = item.CODIGO_CIUDAD
                    };
                }
            }
            return result;
        }

        public List<sfEntities.Vendedor> List()
        {
            List<sfEntities.Vendedor> result;
            using (var context = new DBModel.EcommerceEntities())
            {
                var std = context.lst_VENDEDOR();
                result = new List<sfEntities.Vendedor>();
                foreach (var item in std)
                {
                    result.Add(new sfEntities.Vendedor()
                    {
                        codigo = item.CODIGO,
                        nombres = item.NOMBRE,
                        apellidos = item.APELLIDO,
                        numero_identificacion = item.NUMERO_IDENTIFICACION,
                        codigo_ciudad = item.CODIGO_CIUDAD
                    });
                }
            }
            return result;
        }
    }
}
