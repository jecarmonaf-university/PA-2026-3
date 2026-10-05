using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Caso_Balon;

namespace Caso_Balon_WForms
{
    public partial class Form1 : Form
    {
        // Diccionario para almacenar las instancias creadas
        private Dictionary<string, Balon> inventario = new Dictionary<string, Balon>();

        public Form1()
        {
            InitializeComponent();

            // Cargar los tipos de balón en el ComboBox
            cboTipo.Items.Add("Fútbol");
            cboTipo.Items.Add("Baloncesto");
            cboTipo.Items.Add("Fútbol Americano");
            cboTipo.Items.Add("Voleibol");
            cboTipo.SelectedIndex = 0;

            // Eventos
            btnCrear.Click += BtnCrear_Click;
            btnInflar.Click += BtnInflar_Click;
            btnColor.Click += BtnColor_Click;
            cboTipo.SelectedIndexChanged += CboTipo_SelectedIndexChanged;
        }

        private void CboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Autocompletar campos con valores predeterminados
            if (cboTipo.Text == "Fútbol") { txtMaterial.Text = "Sintético"; numCapacidad.Value = 5; txtForma.Text = "Esférica"; }
            if (cboTipo.Text == "Baloncesto") { txtMaterial.Text = "Caucho"; numCapacidad.Value = 8; txtForma.Text = "Esférica"; }
            if (cboTipo.Text == "Fútbol Americano") { txtMaterial.Text = "Cuero"; numCapacidad.Value = 10; txtForma.Text = "Esferoide Prolado"; }
            if (cboTipo.Text == "Voleibol") { txtMaterial.Text = "Cuero Sintético"; numCapacidad.Value = 6; txtForma.Text = "Esférica"; }

            MostrarBalon();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            string tipo = cboTipo.Text;
            string mat = txtMaterial.Text;
            int cap = (int)numCapacidad.Value;
            string forma = txtForma.Text;
            string color = txtColor.Text;

            Balon nuevoBalon = null;

            if (tipo == "Fútbol") nuevoBalon = new Futbol(mat, cap, forma);
            if (tipo == "Baloncesto") nuevoBalon = new Basket(mat, cap, forma);
            if (tipo == "Fútbol Americano") nuevoBalon = new FutbolAmericano(mat, cap, forma);
            if (tipo == "Voleibol") nuevoBalon = new Volley(mat, cap, forma);

            if (nuevoBalon != null)
            {
                // Si el usuario ingresó un color en la caja de texto, se actualiza
                if (!string.IsNullOrWhiteSpace(color))
                {
                    nuevoBalon.CambiarColor(color);
                }

                inventario[tipo] = nuevoBalon;
                MessageBox.Show($"Balón de {tipo} creado con éxito.");
                MostrarBalon();
            }
        }

        private void BtnInflar_Click(object sender, EventArgs e)
        {
            string tipo = cboTipo.Text;
            if (inventario.ContainsKey(tipo))
            {
                Balon balon = inventario[tipo];

                // Verificamos si la capacidad actual es menor a la capacidad máxima
                if (balon.GetCapActual() < balon.GetCapacidad())
                {
                    balon.Inflar(); // Aumenta la capacidad en 1[cite: 1]
                    lblEstado.Text = "Inflando..."; // Mostramos el label de acción
                    MostrarBalon();

                    // Si después de inflar llegó a su capacidad máxima[cite: 1]
                    if (balon.GetCapActual() == balon.GetCapacidad())
                    {
                        lblEstado.Text = "Balón inflado en su totalidad.";
                        btnInflar.Enabled = false; // Bloquea el botón
                        MessageBox.Show("Balón inflado en su totalidad.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
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
                if (!string.IsNullOrWhiteSpace(txtColor.Text))
                {
                    inventario[tipo].CambiarColor(txtColor.Text);
                    MostrarBalon();
                }
                else
                {
                    MessageBox.Show("Escribe un color en la casilla de texto antes de presionar el botón.");
                }
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
                Balon balon = inventario[tipo];
                rtbPantalla.Text = balon.ToString();

                // Evaluamos el estado del balón seleccionado para ajustar el botón y el label
                if (balon.GetCapActual() >= balon.GetCapacidad())
                {
                    btnInflar.Enabled = false;
                    lblEstado.Text = "Balón inflado en su totalidad.";
                }
                else
                {
                    btnInflar.Enabled = true;
                    lblEstado.Text = ""; // Limpiamos el texto si aún se puede inflar
                }
            }
            else
            {
                rtbPantalla.Text = "No hay un balón de este tipo creado todavía.";
                btnInflar.Enabled = true; // Habilitamos por defecto para cuando se cree

                // Si el label existe, lo limpiamos
                if (lblEstado != null)
                {
                    lblEstado.Text = "";
                }
            }
        }
    }
}