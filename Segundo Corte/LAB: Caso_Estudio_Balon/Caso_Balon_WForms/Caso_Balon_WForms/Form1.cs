using Caso_Balon_WForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Caso_Balon_WForms
{
    public partial class Form1 : Form
    {
        // Guardamos los balones creados aquí
        private Dictionary<string, Balon> inventario = new Dictionary<string, Balon>();

        public Form1()
        {
            InitializeComponent();

            // Llenamos el desplegable al iniciar
            cboTipo.Items.Add("Fútbol");
            cboTipo.Items.Add("Baloncesto");
            cboTipo.Items.Add("Fútbol Americano");
            cboTipo.Items.Add("Voleibol");
            cboTipo.SelectedIndex = 0; // Selecciona el primero por defecto

            // Asignamos los eventos de los botones
            btnCrear.Click += BtnCrear_Click;
            btnInflar.Click += BtnInflar_Click;
            btnColor.Click += BtnColor_Click;
            cboTipo.SelectedIndexChanged += CboTipo_SelectedIndexChanged;
        }

        private void CboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Autocompletar datos de ejemplo según el deporte
            if (cboTipo.Text == "Fútbol") { txtMaterial.Text = "Sintético"; numCapacidad.Value = 5; txtForma.Text = "Esférica"; }
            if (cboTipo.Text == "Baloncesto") { txtMaterial.Text = "Caucho"; numCapacidad.Value = 8; txtForma.Text = "Esférica"; }
            if (cboTipo.Text == "Fútbol Americano") { txtMaterial.Text = "Cuero"; numCapacidad.Value = 10; txtForma.Text = "Ovoide"; }
            if (cboTipo.Text == "Voleibol") { txtMaterial.Text = "Cuero flexible"; numCapacidad.Value = 4; txtForma.Text = "Esférica"; }

            MostrarBalon();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            string tipo = cboTipo.Text;
            string mat = txtMaterial.Text;
            int cap = (int)numCapacidad.Value;
            string forma = txtForma.Text;

            if (tipo == "Fútbol") inventario[tipo] = new Futbol(mat, cap, forma);
            if (tipo == "Baloncesto") inventario[tipo] = new Basket(mat, cap, forma);
            if (tipo == "Fútbol Americano") inventario[tipo] = new FutbolAmericano(mat, cap, forma);
            if (tipo == "Voleibol") inventario[tipo] = new Volley(mat, cap, forma);

            MessageBox.Show("Balón creado con éxito.");
            MostrarBalon();
        }

        private void BtnInflar_Click(object sender, EventArgs e)
        {
            string tipo = cboTipo.Text;
            if (inventario.ContainsKey(tipo))
            {
                inventario[tipo].Inflar();
                MostrarBalon();
            }
            else
            {
                MessageBox.Show("Primero debes crear este balón.");
            }
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            string tipo = cboTipo.Text;
            if (inventario.ContainsKey(tipo))
            {
                inventario[tipo].CambiarColor(txtColor.Text);
                MostrarBalon();
            }
            else
            {
                MessageBox.Show("Primero debes crear este balón.");
            }
        }

        private void MostrarBalon()
        {
            string tipo = cboTipo.Text;
            if (inventario.ContainsKey(tipo))
            {
                rtbPantalla.Text = inventario[tipo].Detalles();
            }
            else
            {
                rtbPantalla.Text = "No hay un balón de este tipo creado todavía.";
            }
        }

       
    }
}