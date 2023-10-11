using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace resParcialBD
{
    public partial class Consultas : Form
    {
        public Consultas()
        {
            InitializeComponent();
        }

        string cadena_conexion = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Vendedores.mdb";
        OleDbDataAdapter da;

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            float total = 0;

            if (File.Exists("Gastos.txt"))
            {
                StreamReader archivo = File.OpenText("Gastos.txt");
                string leer = archivo.ReadLine();

                if (radioGeneral.Checked)
                {
                    while (leer != null)
                    {
                        string[] campos = leer.Split(',');

                        dataGridView1.Rows.Add(campos[0], campos[1], devolverNombre(int.Parse(campos[1])),
                            campos[2], campos[3]);

                        total += float.Parse(campos[3]);

                        leer = archivo.ReadLine();
                    }

                    txtTotal.Text = total.ToString();
                }

                else
                {
                    dataGridView1.Rows.Clear();
                    txtTotal.Text = "";
                    devolverDatos(comboBox1.Text);
                }

                archivo.Close();
            }

            else
            {
                MessageBox.Show("No existe ningun archivo para realizar consultas");
            }
        }

        private void devolverDatos(string tipoGasto)
        {
            StreamReader archivo = File.OpenText("Gastos.txt");
            string leer = archivo.ReadLine();

            float total = 0;

            while (leer != null)
            {
                string[] campos = leer.Split(',');

                if (campos[2].Trim() == tipoGasto.Trim())
                {
                    dataGridView1.Rows.Add(campos[0], campos[1], devolverNombre(int.Parse(campos[1])),
                        campos[2], campos[3]);

                    total += float.Parse(campos[3]);
                }

                leer = archivo.ReadLine();
            }

            archivo.Close();

            txtTotal.Text = total.ToString();
        }

        

        private string devolverNombre(int legajo)
        {

            string nombre = "";

            Conexion cnn = new Conexion();
            cnn.Conectar(cadena_conexion);

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Vendedor";
            cmd.CommandType = CommandType.TableDirect;
            cmd.Connection = cnn.CNN;

            OleDbDataReader dr;
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr.GetInt32(0) == legajo)
                    {
                        nombre = dr.GetString(1);
                    }
                }
            }

            return nombre;

            cnn.Desconectar();
        }

        private void Consultas_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Movilidad");
            comboBox1.Items.Add("Alquileres");
            comboBox1.Items.Add("Alojamiento");
            comboBox1.Items.Add("Comidas");

            comboBox1.Enabled = false;
        }

        private void radioTipo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioTipo.Checked)
            {
                comboBox1.Enabled = true;
            }

            else
            {
                comboBox1.Enabled = false;
            }
        }
    }
}
