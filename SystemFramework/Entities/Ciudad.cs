namespace AppCore.SystemFramework.Entities
{
    public class Ciudad
    {
        #region Atributes

        private int _codigo;
        private string _descripcion;

        #endregion

        #region Properties

        public int codigo { get { return _codigo; } set { _codigo = value; } }
        public string descripcion { get { return _descripcion; } set { _descripcion = value; } }

        #endregion
    }
}
