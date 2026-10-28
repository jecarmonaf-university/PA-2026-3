namespace ParqueaderoAutomaticoWinForms;

public class FormParqueadero : Form
{
    private const int TotalEspacios = 20;
    private const decimal TarifaPorMinuto = 100m;

    private readonly string[] sedes =
    {
        "Fac. Ingeniería (Calle 40)",
        "Facultad Tecnológica",
        "Sede Bosa (Porvenir)",
        "Sede Macarena"
    };

    private readonly Dictionary<string, DatosSede> datosSedes = new();
    private string sedeActual = "Fac. Ingeniería (Calle 40)";

    private readonly Label lblSedeTitulo = new();
    private readonly Label lblSedeTabla = new();
    private readonly Label lblTotal = new();
    private readonly Label lblDisponibles = new();
    private readonly Label lblOcupados = new();
    private readonly Label lblBarreraEntrada = new();
    private readonly Label lblBarreraSalida = new();
    private readonly TextBox txtPlacaEntrada = new();
    private readonly TextBox txtPlacaSalida = new();
    private readonly Label lblMensajeEntrada = new();
    private readonly Label lblMensajeSalida = new();
    private readonly ComboBox cmbSedes = new();
    private readonly TableLayoutPanel panelEspacios = new();
    private readonly DataGridView tabla = new();
    private readonly System.Windows.Forms.Timer timerEntrada = new();
    private readonly System.Windows.Forms.Timer timerSalida = new();

    public FormParqueadero()
    {
        foreach (string sede in sedes)
            datosSedes[sede] = new DatosSede(TotalEspacios);

        Text = "Parqueadero Automático";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(1000, 760);
        Size = new Size(1120, 900);
        BackColor = Color.White;
        Font = new Font("Arial", 9);

        ConstruirInterfaz();
        ActualizarInterfaz();

        timerEntrada.Interval = 3000;
        timerEntrada.Tick += (_, _) =>
        {
            lblBarreraEntrada.Text = "Cerrada";
            timerEntrada.Stop();
        };
        timerSalida.Interval = 3000;
        timerSalida.Tick += (_, _) =>
        {
            lblBarreraSalida.Text = "Cerrada";
            timerSalida.Stop();
        };
    }

    private void ConstruirInterfaz()
    {
        var raiz = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 4,
            BackColor = Color.White,
            Margin = Padding.Empty,
            Padding = Padding.Empty
        };
        raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
        raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 55));
        raiz.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
        Controls.Add(raiz);

        var encabezado = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
        var titulo = new Label
        {
            Text = "PARQUEADERO AUTOMÁTICO",
            Font = new Font("Arial", 20, FontStyle.Bold),
            Dock = DockStyle.Top,
            Height = 42,
            TextAlign = ContentAlignment.MiddleCenter
        };
        lblSedeTitulo.Text = sedeActual;
        lblSedeTitulo.Font = new Font("Arial", 9, FontStyle.Bold);
        var subtitulo = new Label
        {
            Text = "Sistema de gestión - ",
            Font = new Font("Arial", 9),
            Dock = DockStyle.Top,
            Height = 25,
            TextAlign = ContentAlignment.MiddleCenter
        };
        subtitulo.Controls.Add(lblSedeTitulo);
        // El nombre de la sede se muestra en una etiqueta centrada independiente.
        var subtexto = new Label
        {
            Text = "Sistema de gestión - " + sedeActual,
            Font = new Font("Arial", 9),
            Dock = DockStyle.Top,
            Height = 28,
            TextAlign = ContentAlignment.MiddleCenter,
            Name = "subtextoSede"
        };
        encabezado.Controls.Add(subtexto);
        encabezado.Controls.Add(titulo);
        raiz.Controls.Add(encabezado, 0, 0);

        var menu = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(119, 119, 119),
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            Padding = new Padding(20, 9, 10, 5)
        };
        cmbSedes.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbSedes.Width = 245;
        cmbSedes.Items.AddRange(sedes);
        cmbSedes.SelectedItem = sedeActual;
        cmbSedes.SelectedIndexChanged += (_, _) =>
        {
            if (cmbSedes.SelectedItem is string seleccion)
            {
                sedeActual = seleccion;
                foreach (Control c in encabezado.Controls)
                    if (c.Name == "subtextoSede") c.Text = "Sistema de gestión - " + sedeActual;
                ActualizarInterfaz();
                lblMensajeEntrada.Text = "";
                lblMensajeSalida.Text = "";
                txtPlacaEntrada.Clear();
                txtPlacaSalida.Clear();
            }
        };
        menu.Controls.Add(cmbSedes);
        menu.Controls.Add(CrearBotonMenu("Parqueadero", () => panelEspacios.Focus()));
        menu.Controls.Add(CrearBotonMenu("Registros", () => tabla.Focus()));
        var salir = CrearBotonMenu("Cerrar Sesión", () => Close());
        salir.ForeColor = Color.FromArgb(255, 179, 179);
        salir.Font = new Font("Arial", 9, FontStyle.Bold);
        menu.Controls.Add(salir);
        raiz.Controls.Add(menu, 0, 1);

        var contenido = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 1,
            BackColor = Color.White,
            Padding = Padding.Empty,
            Margin = Padding.Empty
        };
        contenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
        contenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
        raiz.Controls.Add(contenido, 0, 2);

        var parqueadero = new Panel { Dock = DockStyle.Fill, Padding = new Padding(16), BackColor = Color.White };
        contenido.Controls.Add(parqueadero, 0, 0);
        var tituloEspacios = new Label
        {
            Text = "Espacios del parqueadero",
            Font = new Font("Arial", 14, FontStyle.Bold),
            Dock = DockStyle.Top,
            Height = 40,
            TextAlign = ContentAlignment.MiddleLeft
        };
        parqueadero.Controls.Add(tituloEspacios);

        var formularioEntrada = new Panel
        {
            Dock = DockStyle.Top,
            Height = 130,
            BackColor = Color.FromArgb(238, 238, 238),
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(12)
        };
        parqueadero.Controls.Add(formularioEntrada);
        var lblEntrada = new Label
        {
            Text = "Registrar entrada de vehículo",
            Font = new Font("Arial", 11, FontStyle.Bold),
            Dock = DockStyle.Top,
            Height = 32
        };
        formularioEntrada.Controls.Add(lblEntrada);
        txtPlacaEntrada.PlaceholderText = "Ingrese la placa del vehículo";
        txtPlacaEntrada.CharacterCasing = CharacterCasing.Upper;
        txtPlacaEntrada.MaxLength = 6;
        txtPlacaEntrada.Dock = DockStyle.Top;
        txtPlacaEntrada.Height = 28;
        formularioEntrada.Controls.Add(txtPlacaEntrada);
        var btnEntrada = CrearBoton("Registrar entrada", 106, 30);
        btnEntrada.Dock = DockStyle.Top;
        btnEntrada.Margin = new Padding(0, 7, 0, 0);
        btnEntrada.Click += (_, _) => RegistrarEntrada();
        formularioEntrada.Controls.Add(btnEntrada);
        lblMensajeEntrada.Dock = DockStyle.Top;
        lblMensajeEntrada.Height = 28;
        formularioEntrada.Controls.Add(lblMensajeEntrada);

        panelEspacios.Dock = DockStyle.Fill;
        panelEspacios.ColumnCount = 5;
        panelEspacios.RowCount = 4;
        panelEspacios.Padding = new Padding(0, 12, 0, 0);
        panelEspacios.Margin = Padding.Empty;
        for (int c = 0; c < 5; c++)
            panelEspacios.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
        for (int r = 0; r < 4; r++)
            panelEspacios.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
        parqueadero.Controls.Add(panelEspacios);

        var informacion = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(221, 221, 221),
            Padding = new Padding(14)
        };
        contenido.Controls.Add(informacion, 1, 0);

        var cajaGeneral = CrearCajaInfo("Información general");
        lblTotal.Text = "Espacios totales: 20";
        lblDisponibles.Text = "Disponibles: 20";
        lblOcupados.Text = "Ocupados: 0";
        cajaGeneral.Controls.Add(CrearInfoLabel("Tarifa: $100 / min", 42));
        cajaGeneral.Controls.Add(lblTotal);
        cajaGeneral.Controls.Add(lblDisponibles);
        cajaGeneral.Controls.Add(lblOcupados);
        informacion.Controls.Add(cajaGeneral);

        var cajaSensores = CrearCajaInfo("Sensores y Barreras");
        lblBarreraEntrada.Text = "Barrera Entrada: Cerrada";
        lblBarreraSalida.Text = "Barrera Salida: Cerrada";
        cajaSensores.Controls.Add(lblBarreraEntrada);
        cajaSensores.Controls.Add(lblBarreraSalida);
        cajaSensores.Height = 120;
        cajaSensores.Top = 190;
        informacion.Controls.Add(cajaSensores);

        var cajaSalida = CrearCajaInfo("Registrar salida");
        cajaSalida.Height = 145;
        cajaSalida.Top = 325;
        txtPlacaSalida.PlaceholderText = "Ingrese la placa";
        txtPlacaSalida.CharacterCasing = CharacterCasing.Upper;
        txtPlacaSalida.MaxLength = 6;
        txtPlacaSalida.Dock = DockStyle.Top;
        txtPlacaSalida.Height = 28;
        var btnSalida = CrearBoton("Registrar salida", 105, 30);
        btnSalida.Dock = DockStyle.Top;
        btnSalida.Click += (_, _) => RegistrarSalida();
        cajaSalida.Controls.Add(txtPlacaSalida);
        cajaSalida.Controls.Add(btnSalida);
        cajaSalida.Controls.Add(lblMensajeSalida);
        lblMensajeSalida.Dock = DockStyle.Top;
        lblMensajeSalida.Height = 35;
        informacion.Controls.Add(cajaSalida);

        var registrosPanel = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(16, 8, 16, 8),
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle
        };
        raiz.RowStyles[2].SizeType = SizeType.Percent;
        // El área de registros queda dentro del contenido principal, debajo de los espacios.
        var principal = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 2,
            Margin = Padding.Empty,
            Padding = Padding.Empty
        };
        principal.RowStyles.Add(new RowStyle(SizeType.Percent, 68));
        principal.RowStyles.Add(new RowStyle(SizeType.Percent, 32));
        raiz.Controls.Remove(contenido);
        raiz.Controls.Add(principal, 0, 2);
        principal.Controls.Add(contenido, 0, 0);
        principal.Controls.Add(registrosPanel, 0, 1);

        var tituloRegistros = new Label
        {
            Text = "Registro de vehículos",
            Font = new Font("Arial", 13, FontStyle.Bold),
            Dock = DockStyle.Top,
            Height = 32
        };
        lblSedeTabla.Text = sedeActual;
        tituloRegistros.Controls.Add(lblSedeTabla);
        registrosPanel.Controls.Add(tituloRegistros);

        tabla.Dock = DockStyle.Fill;
        tabla.AllowUserToAddRows = false;
        tabla.AllowUserToDeleteRows = false;
        tabla.ReadOnly = true;
        tabla.RowHeadersVisible = false;
        tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        tabla.BackgroundColor = Color.White;
        tabla.BorderStyle = BorderStyle.None;
        tabla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(85, 85, 85);
        tabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        tabla.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
        tabla.EnableHeadersVisualStyles = false;
        tabla.Columns.Add("Placa", "Placa");
        tabla.Columns.Add("Entrada", "Hora entrada");
        tabla.Columns.Add("Salida", "Hora salida");
        tabla.Columns.Add("Espacio", "Espacio");
        tabla.Columns.Add("Estado", "Estado");
        tabla.Columns.Add("Tarifa", "Tarifa");
        registrosPanel.Controls.Add(tabla);

        var pie = new Label
        {
            Text = "Parqueadero Automático - Universidad Distrital",
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(51, 51, 51),
            ForeColor = Color.White,
            TextAlign = ContentAlignment.MiddleCenter
        };
        raiz.Controls.Add(pie, 0, 3);
    }

    private Button CrearBotonMenu(string texto, Action accion)
    {
        var boton = new Button
        {
            Text = texto,
            AutoSize = true,
            Height = 32,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(119, 119, 119),
            ForeColor = Color.White,
            Margin = new Padding(2, 2, 2, 2),
            Cursor = Cursors.Hand
        };
        boton.FlatAppearance.BorderSize = 0;
        boton.Click += (_, _) => accion();
        return boton;
    }

    private Button CrearBoton(string texto, int ancho, int alto)
    {
        var boton = new Button
        {
            Text = texto,
            Size = new Size(ancho, alto),
            BackColor = Color.FromArgb(85, 85, 85),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        boton.FlatAppearance.BorderSize = 0;
        return boton;
    }

    private Panel CrearCajaInfo(string titulo)
    {
        var caja = new Panel
        {
            Dock = DockStyle.Top,
            Height = 180,
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(12),
            Margin = new Padding(0, 0, 0, 12)
        };
        var etiqueta = new Label
        {
            Text = titulo,
            Font = new Font("Arial", 11, FontStyle.Bold),
            Dock = DockStyle.Top,
            Height = 38
        };
        caja.Controls.Add(etiqueta);
        return caja;
    }

    private Label CrearInfoLabel(string texto, int alto = 28)
    {
        return new Label
        {
            Text = texto,
            Dock = DockStyle.Top,
            Height = alto,
            TextAlign = ContentAlignment.MiddleLeft
        };
    }

    private DatosSede DatosActuales => datosSedes[sedeActual];

    private static bool PlacaValida(string placa)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(placa, @"^[A-Z]{3}[0-9]{3}$")
            || System.Text.RegularExpressions.Regex.IsMatch(placa, @"^[A-Z]{3}[0-9]{2}[A-Z]$");
    }

    private void RegistrarEntrada()
    {
        string placa = txtPlacaEntrada.Text.Trim().ToUpperInvariant();
        if (!PlacaValida(placa))
        {
            MostrarMensaje(lblMensajeEntrada, "Placa inválida. Use AAA999 o AAA99A.", false);
            return;
        }

        if (DatosActuales.Registros.Any(r => r.Placa == placa && r.Estado == "Ocupado"))
        {
            MostrarMensaje(lblMensajeEntrada, "El vehículo ya está dentro de esta sede.", false);
            return;
        }

        var espacio = DatosActuales.Espacios.FirstOrDefault(e => !e.Ocupado);
        if (espacio == null)
        {
            MostrarMensaje(lblMensajeEntrada, "El parqueadero de esta sede está lleno.", false);
            return;
        }

        espacio.Ocupado = true;
        espacio.Placa = placa;
        DatosActuales.Registros.Add(new RegistroVehiculo
        {
            Placa = placa,
            FechaEntrada = DateTime.Now,
            Espacio = espacio.Numero,
            Estado = "Ocupado"
        });

        txtPlacaEntrada.Clear();
        ActualizarInterfaz();
        AbrirBarrera(true);
        MostrarMensaje(lblMensajeEntrada, $"Entrada registrada. Espacio {espacio.Numero}.", true);
    }

    private void RegistrarSalida()
    {
        string placa = txtPlacaSalida.Text.Trim().ToUpperInvariant();
        if (string.IsNullOrWhiteSpace(placa))
        {
            MostrarMensaje(lblMensajeSalida, "Por favor ingrese una placa.", false);
            return;
        }

        var registro = DatosActuales.Registros.LastOrDefault(r => r.Placa == placa && r.Estado == "Ocupado");
        if (registro == null)
        {
            MostrarMensaje(lblMensajeSalida, "Vehículo no encontrado en esta sede o ya salió.", false);
            return;
        }

        DateTime ahora = DateTime.Now;
        registro.FechaSalida = ahora;
        registro.Estado = "Finalizado";
        int minutos = Math.Max(1, (int)Math.Ceiling((ahora - registro.FechaEntrada).TotalMinutes));
        registro.TarifaAplicada = minutos * TarifaPorMinuto;

        var espacio = DatosActuales.Espacios.FirstOrDefault(e => e.Numero == registro.Espacio);
        if (espacio != null)
        {
            espacio.Ocupado = false;
            espacio.Placa = "";
        }

        txtPlacaSalida.Clear();
        ActualizarInterfaz();
        AbrirBarrera(false);
        MostrarMensaje(lblMensajeSalida, $"Salida exitosa. {placa} | {minutos} min | Total: ${registro.TarifaAplicada:0}", true);
    }

    private void ActualizarInterfaz()
    {
        panelEspacios.SuspendLayout();
        panelEspacios.Controls.Clear();

        foreach (var espacio in DatosActuales.Espacios)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(4),
                BackColor = espacio.Ocupado ? Color.FromArgb(247, 204, 204) : Color.FromArgb(217, 247, 217),
                BorderStyle = BorderStyle.FixedSingle
            };
            var contenido = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 9),
                Text = $"Espacio {espacio.Numero}\n{(espacio.Ocupado ? espacio.Placa : "Disponible")}"
            };
            contenido.ForeColor = espacio.Ocupado ? Color.Red : Color.Green;
            panel.Controls.Add(contenido);
            panelEspacios.Controls.Add(panel);
        }
        panelEspacios.ResumeLayout();

        int ocupados = DatosActuales.Espacios.Count(e => e.Ocupado);
        lblTotal.Text = $"Espacios totales: {TotalEspacios}";
        lblDisponibles.Text = $"Disponibles: {TotalEspacios - ocupados}";
        lblOcupados.Text = $"Ocupados: {ocupados}";
        lblSedeTabla.Text = sedeActual;

        // Actualizar el título del registro conservando la etiqueta y sin depender de controles HTML.
        if (tabla.Parent is Panel p)
        {
            var titulo = p.Controls.OfType<Label>().FirstOrDefault();
            if (titulo != null) titulo.Text = $"Registro de vehículos ({sedeActual})";
        }

        tabla.Rows.Clear();
        foreach (var r in DatosActuales.Registros)
        {
            int indice = tabla.Rows.Add(r.Placa, r.HoraEntrada, r.HoraSalida, r.Espacio, r.Estado, r.TarifaTexto);
            tabla.Rows[indice].Cells["Estado"].Style.ForeColor =
                r.Estado == "Ocupado" ? Color.Red : Color.Green;
            tabla.Rows[indice].Cells["Estado"].Style.Font = new Font("Arial", 9, FontStyle.Bold);
        }
    }

    private void AbrirBarrera(bool entrada)
    {
        var etiqueta = entrada ? lblBarreraEntrada : lblBarreraSalida;
        etiqueta.Text = entrada ? "Barrera Entrada: Abierta (Detectado)" : "Barrera Salida: Abierta (Detectado)";
        var timer = entrada ? timerEntrada : timerSalida;
        timer.Stop();
        timer.Start();
    }

    private void MostrarMensaje(Label etiqueta, string texto, bool exito)
    {
        etiqueta.Text = texto;
        etiqueta.ForeColor = exito ? Color.DarkGreen : Color.Red;
    }
}
