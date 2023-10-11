using System.Data;
using System.Data.OleDb;

namespace resParcialBD
{
    class Conexion
    {
        // propiedades públicas de la clase
        public OleDbConnection CNN { get; set; }
        public DataSet DS { get; set; }

        // constructor de la clase
        public Conexion()
        {
            CNN = null;
            DS = null;
        }

        // Método Conectar
        public void Conectar(string CadenaConexion)
        {
            CNN = new OleDbConnection();
            CNN.ConnectionString = CadenaConexion;
            CNN.Open();
            DS = new DataSet();
        }

        // Método Desconectar
        public void Desconectar()
        {
            CNN.Close();
        }
    }
}