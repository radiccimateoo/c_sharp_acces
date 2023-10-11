using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace resParcialBD
{

    internal class Gasto
    {
        public int IDGasto { get; set; }
        public int legajo { get; set; }
        public string TipoGasto { get; set; }
        public float importe { get; set; }

        public void grabar_gasto(Gasto gasto)
        {
            StreamWriter grabar = new StreamWriter("Gastos.txt", true);

            string mensaje = gasto.IDGasto.ToString() + "," + gasto.legajo.ToString() +
                "," + gasto.TipoGasto + "," + gasto.importe.ToString();

            grabar.WriteLine(mensaje);

            grabar.Close();
            grabar.Dispose();
        }

        public bool idGasto_repetido(string archivo, int id)
        {

            bool se_repite = false;

            if (File.Exists(archivo))
            {
                StreamReader leer_archivo = File.OpenText(archivo);
                string leer_linea = leer_archivo.ReadLine();

                while (leer_linea != null)
                {
                    string[] campos = leer_linea.Split(',');

                    if (campos[0].Trim() == id.ToString().Trim())
                    {
                        se_repite = true;
                    }

                    leer_linea = leer_archivo.ReadLine();
                }

                leer_archivo.Close();
            }

            return se_repite;
        }

        public string convertir_a_legajo(string cadena_conexion, string nombre_vendedor)
        {

            string nombre = "";

            Conexion cnn = new Conexion();
            cnn.Conectar(cadena_conexion);

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Vendedor";
            cmd.CommandType = CommandType.TableDirect;
            cmd.Connection = cnn.CNN;

            OleDbDataReader DR;
            DR = cmd.ExecuteReader();


            if (DR.HasRows)
            {
                while (DR.Read())
                {
                    if (DR.GetString(1) == nombre_vendedor)
                    {
                        nombre = DR.GetInt32(0).ToString() ;
                        break;
                    }
                }
            }

            cnn.Desconectar();

            return nombre;
        }
    }

}
