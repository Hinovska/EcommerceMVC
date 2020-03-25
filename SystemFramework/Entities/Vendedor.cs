namespace AppCore.SystemFramework.Entities
{
    public class Vendedor
    {
        #region Atributes

        private int _codigo;
        private string _nombres;
        private string _apellidos;
        private long _numero_identificacion;
        private int _codigo_ciudad;

        #endregion

        #region Properties

        public int codigo { get { return _codigo; } set { _codigo = value; } }
        public string nombres { get { return _nombres; } set { _nombres = value; } }
        public string apellidos { get { return _apellidos; } set { _apellidos = value; } }
        public long numero_identificacion { get { return _numero_identificacion; } set { _numero_identificacion = value; } }
        public int codigo_ciudad { get { return _codigo_ciudad; } set { _codigo_ciudad = value; } }

        #endregion
    }
}
