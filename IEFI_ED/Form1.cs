using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEFI_ED
{
    public partial class Form1 : Form
    {
        private Arbol arbol = new Arbol();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.Add("Oficial");
            cmbTipo.Items.Add("Soldado");
            cmbTipo.SelectedIndex = 0;
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoSeleccionado = cmbTipo.SelectedItem.ToString();
            CargarRangos(tipoSeleccionado);
        }

        private void CargarRangos(string tipo)
        {
            cmbRango.Items.Clear();

            if (tipo == "Oficial")
            {
                cmbRango.Items.Add("Coronel");
                cmbRango.Items.Add("Capitán");
                cmbRango.Items.Add("Teniente");
                cmbRango.Items.Add("Sargento");
                cmbRango.Enabled = true;
            }
            else if (tipo == "Soldado")
            {
                cmbRango.Items.Add("Soldado");
                cmbRango.SelectedIndex = 0;
                cmbRango.Enabled = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCodigo.Text, out int codigo))
            {
                MessageBox.Show("El código debe ser un valor numérico entero.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombre = txtNombre.Text.Trim();
            if (nombre.Length < 3)
            {
                MessageBox.Show("El nombre debe tener al menos 3 caracteres.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbTipo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbRango.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un rango.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tipo = cmbTipo.SelectedItem.ToString();
            string rango = cmbRango.SelectedItem.ToString();

            if (arbol.ExisteCodigo(arbol.Raiz, codigo))
            {
                MessageBox.Show($"El código {codigo} ya existe en el árbol.", "Error de Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            arbol.Insertar(codigo, nombre, tipo, rango);
            MessageBox.Show("Nodo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var nodos = arbol.Listar(arbol.Raiz);
            CargarGrilla(nodos);
        }

        private void CargarGrilla(List<Nodo> nodos)
        {
            grPersonajes.Rows.Clear();

            foreach (var nodo in nodos)
            {
                grPersonajes.Rows.Add(nodo.Codigo, nodo.Nombre, nodo.Tipo, nodo.Rango);
            }
        }
    }
}
