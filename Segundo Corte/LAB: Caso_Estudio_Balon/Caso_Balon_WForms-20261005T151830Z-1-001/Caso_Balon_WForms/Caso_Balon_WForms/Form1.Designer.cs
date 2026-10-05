namespace Caso_Balon_WForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.numCapacidad = new System.Windows.Forms.NumericUpDown();
            this.txtForma = new System.Windows.Forms.TextBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnInflar = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.rtbPantalla = new System.Windows.Forms.RichTextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacidad)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(24, 36);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(100, 21);
            this.cboTipo.TabIndex = 0;
            this.cboTipo.Text = "Seleccionar";
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(24, 193);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(100, 20);
            this.txtMaterial.TabIndex = 1;
            // 
            // numCapacidad
            // 
            this.numCapacidad.Location = new System.Drawing.Point(24, 235);
            this.numCapacidad.Name = "numCapacidad";
            this.numCapacidad.Size = new System.Drawing.Size(100, 20);
            this.numCapacidad.TabIndex = 2;
            // 
            // txtForma
            // 
            this.txtForma.Location = new System.Drawing.Point(24, 151);
            this.txtForma.Name = "txtForma";
            this.txtForma.Size = new System.Drawing.Size(100, 20);
            this.txtForma.TabIndex = 3;
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(24, 312);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(100, 23);
            this.btnCrear.TabIndex = 4;
            this.btnCrear.Text = "Crear Balon";
            this.btnCrear.UseVisualStyleBackColor = true;
            // 
            // btnInflar
            // 
            this.btnInflar.Location = new System.Drawing.Point(24, 261);
            this.btnInflar.Name = "btnInflar";
            this.btnInflar.Size = new System.Drawing.Size(100, 23);
            this.btnInflar.TabIndex = 5;
            this.btnInflar.Text = "Inflar Balon";
            this.btnInflar.UseVisualStyleBackColor = true;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(24, 102);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(100, 23);
            this.btnColor.TabIndex = 6;
            this.btnColor.Text = "Cambiar Color";
            this.btnColor.UseVisualStyleBackColor = true;
            // 
            // rtbPantalla
            // 
            this.rtbPantalla.Location = new System.Drawing.Point(170, 83);
            this.rtbPantalla.Name = "rtbPantalla";
            this.rtbPantalla.Size = new System.Drawing.Size(155, 172);
            this.rtbPantalla.TabIndex = 8;
            this.rtbPantalla.Text = "";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(24, 76);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(100, 20);
            this.txtColor.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Seleccionar Balon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ingresar Color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ingresar Forma";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Ingresar Material";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Ingresar Capacidad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(226, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 15;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(202, 261);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 13);
            this.lblEstado.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 363);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.rtbPantalla);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnInflar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.txtForma);
            this.Controls.Add(this.numCapacidad);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.cboTipo);
            this.Name = "Form1";
            this.Text = "Balones";
            ((System.ComponentModel.ISupportInitialize)(this.numCapacidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.NumericUpDown numCapacidad;
        private System.Windows.Forms.TextBox txtForma;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnInflar;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.RichTextBox rtbPantalla;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblEstado;
    }
}

