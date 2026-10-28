namespace ParqueaderoAutomaticoWinForms;

public class FormLogin : Form
{
    private readonly TextBox txtUsuario = new();
    private readonly TextBox txtClave = new();
    private readonly Label lblMensaje = new();

    public FormLogin()
    {
        Text = "Acceso al Sistema";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(440, 330);
        MinimumSize = new Size(440, 330);
        BackColor = Color.FromArgb(68, 68, 68);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;

        var panel = new Panel
        {
            BackColor = Color.White,
            Size = new Size(340, 250),
            Location = new Point(50, 40),
            BorderStyle = BorderStyle.FixedSingle
        };
        Controls.Add(panel);

        var titulo = new Label
        {
            Text = "Acceso al Sistema",
            Font = new Font("Arial", 16, FontStyle.Bold),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(15, 18),
            Size = new Size(308, 35)
        };
        panel.Controls.Add(titulo);

        txtUsuario.PlaceholderText = "Usuario (admin)";
        txtUsuario.Location = new Point(25, 72);
        txtUsuario.Size = new Size(288, 30);
        txtUsuario.Font = new Font("Arial", 10);
        panel.Controls.Add(txtUsuario);

        txtClave.PlaceholderText = "Contraseña (1234)";
        txtClave.UseSystemPasswordChar = true;
        txtClave.Location = new Point(25, 115);
        txtClave.Size = new Size(288, 30);
        txtClave.Font = new Font("Arial", 10);
        txtClave.KeyDown += (_, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                IniciarSesion();
            }
        };
        panel.Controls.Add(txtClave);

        var btnIngresar = new Button
        {
            Text = "Ingresar",
            Location = new Point(25, 160),
            Size = new Size(288, 38),
            BackColor = Color.FromArgb(85, 85, 85),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Arial", 10, FontStyle.Bold)
        };
        btnIngresar.FlatAppearance.BorderSize = 0;
        btnIngresar.Click += (_, _) => IniciarSesion();
        panel.Controls.Add(btnIngresar);

        lblMensaje.Location = new Point(20, 205);
        lblMensaje.Size = new Size(300, 30);
        lblMensaje.ForeColor = Color.Red;
        lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
        panel.Controls.Add(lblMensaje);

        AcceptButton = btnIngresar;
    }

    private void IniciarSesion()
    {
        if (txtUsuario.Text.Trim() == "admin" && txtClave.Text == "1234")
        {
            Hide();
            using var principal = new FormParqueadero();
            principal.ShowDialog();
            Close();
        }
        else
        {
            lblMensaje.Text = "Usuario o contraseña incorrectos.";
        }
    }
}
