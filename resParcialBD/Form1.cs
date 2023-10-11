using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace resParcialBD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbDataAdapter da;
        string cadena_conexion = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Vendedores.mdb";
        string archivo = "Gastos.txt";

        private void limpiar()
        {
            txtIDGasto.Text = "";
            txtImporte.Text = "";
            cmbTipoGasto.SelectedIndex = 0;
            cmbVendedor.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Gasto gastos = new Gasto();

            gastos.IDGasto = int.Parse(txtIDGasto.Text);
            gastos.legajo = int.Parse(gastos.convertir_a_legajo(cadena_conexion, cmbVendedor.Text));
            gastos.TipoGasto = cmbTipoGasto.Text;
            gastos.importe = float.Parse(txtImporte.Text);
            
            if (gastos.idGasto_repetido(archivo, int.Parse(txtIDGasto.Text)))
            {
                MessageBox.Show("El id de gasto se encuentra repetido");
            }

            else
            {
                MessageBox.Show("Registro guardado exitosamente");
                gastos.grabar_gasto(gastos);
                limpiar();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            cargar_legajos();
        }

        private void cargar_legajos()
        {
            Conexion cnn = new Conexion();
            cnn.Conectar(cadena_conexion);

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Vendedor";
            cmd.CommandType = CommandType.TableDirect;
            cmd.Connection = cnn.CNN;

            da = new OleDbDataAdapter();
            da.SelectCommand = cmd;


            da.Fill(cnn.DS, "Vendedor");

            cmbVendedor.DisplayMember = "Nombre";
            cmbVendedor.ValueMember = "Legajo";
            cmbVendedor.DataSource = cnn.DS.Tables["Vendedor"];

            cnn.Desconectar();
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            Consultas frmConsultas = new Consultas();
            frmConsultas.ShowDialog();
        }

        private void txtIDGasto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
