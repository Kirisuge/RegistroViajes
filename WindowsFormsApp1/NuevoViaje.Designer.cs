namespace WindowsFormsApp1
{
    partial class NuevoViaje
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dTPSalida = new System.Windows.Forms.DateTimePicker();
            this.cBSalida = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textTarifa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cBDestino = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textCapacidad = new System.Windows.Forms.TextBox();
            this.btnCrearViaje = new System.Windows.Forms.Button();
            this.cBHoraSalida = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-5, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 87);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nuevo Viaje";
            // 
            // dTPSalida
            // 
            this.dTPSalida.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPSalida.Location = new System.Drawing.Point(32, 254);
            this.dTPSalida.Name = "dTPSalida";
            this.dTPSalida.Size = new System.Drawing.Size(311, 27);
            this.dTPSalida.TabIndex = 1;
            this.dTPSalida.ValueChanged += new System.EventHandler(this.dTPSalida_ValueChanged);
            // 
            // cBSalida
            // 
            this.cBSalida.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBSalida.FormattingEnabled = true;
            this.cBSalida.Items.AddRange(new object[] {
            "Samaná",
            "Punta Cana",
            "Santiago",
            "Barahona"});
            this.cBSalida.Location = new System.Drawing.Point(32, 163);
            this.cBSalida.Name = "cBSalida";
            this.cBSalida.Size = new System.Drawing.Size(192, 31);
            this.cBSalida.TabIndex = 3;
            this.cBSalida.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 223);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dia de salida:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(379, 223);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hora de salida:";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 305);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tarifa:";
            // 
            // textTarifa
            // 
            this.textTarifa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.textTarifa.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTarifa.Location = new System.Drawing.Point(32, 335);
            this.textTarifa.Margin = new System.Windows.Forms.Padding(2);
            this.textTarifa.Name = "textTarifa";
            this.textTarifa.Size = new System.Drawing.Size(227, 27);
            this.textTarifa.TabIndex = 8;
            this.textTarifa.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "Sucursal de salida:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cBDestino
            // 
            this.cBDestino.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBDestino.FormattingEnabled = true;
            this.cBDestino.Items.AddRange(new object[] {
            "Samaná",
            "Punta Cana",
            "Santiago",
            "Barahona"});
            this.cBDestino.Location = new System.Drawing.Point(384, 163);
            this.cBDestino.Name = "cBDestino";
            this.cBDestino.Size = new System.Drawing.Size(192, 31);
            this.cBDestino.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(379, 132);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "Destino:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 388);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 28);
            this.label7.TabIndex = 12;
            this.label7.Text = "Capacidad:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // textCapacidad
            // 
            this.textCapacidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.textCapacidad.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCapacidad.Location = new System.Drawing.Point(32, 418);
            this.textCapacidad.Margin = new System.Windows.Forms.Padding(2);
            this.textCapacidad.Name = "textCapacidad";
            this.textCapacidad.Size = new System.Drawing.Size(227, 27);
            this.textCapacidad.TabIndex = 13;
            // 
            // btnCrearViaje
            // 
            this.btnCrearViaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.btnCrearViaje.FlatAppearance.BorderSize = 0;
            this.btnCrearViaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearViaje.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearViaje.ForeColor = System.Drawing.Color.White;
            this.btnCrearViaje.Location = new System.Drawing.Point(595, 441);
            this.btnCrearViaje.Name = "btnCrearViaje";
            this.btnCrearViaje.Size = new System.Drawing.Size(167, 53);
            this.btnCrearViaje.TabIndex = 14;
            this.btnCrearViaje.Text = "Crear viaje";
            this.btnCrearViaje.UseVisualStyleBackColor = false;
            this.btnCrearViaje.Click += new System.EventHandler(this.btnCrearViaje_Click);
            // 
            // cBHoraSalida
            // 
            this.cBHoraSalida.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBHoraSalida.FormattingEnabled = true;
            this.cBHoraSalida.Items.AddRange(new object[] {
            "7:00",
            "8:00",
            "9:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00"});
            this.cBHoraSalida.Location = new System.Drawing.Point(384, 250);
            this.cBHoraSalida.Name = "cBHoraSalida";
            this.cBHoraSalida.Size = new System.Drawing.Size(192, 31);
            this.cBHoraSalida.TabIndex = 15;
            // 
            // NuevoViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(796, 521);
            this.Controls.Add(this.cBHoraSalida);
            this.Controls.Add(this.btnCrearViaje);
            this.Controls.Add(this.textCapacidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cBDestino);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textTarifa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cBSalida);
            this.Controls.Add(this.dTPSalida);
            this.Controls.Add(this.panel1);
            this.Name = "NuevoViaje";
            this.Text = "NuevoViaje";
            this.Load += new System.EventHandler(this.NuevoViaje_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dTPSalida;
        private System.Windows.Forms.ComboBox cBSalida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textTarifa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cBDestino;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textCapacidad;
        private System.Windows.Forms.Button btnCrearViaje;
        private System.Windows.Forms.ComboBox cBHoraSalida;
    }
}