namespace ExamenBasicoSeleccion
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            labelTitulo = new Label();
            textBoxNombre = new TextBox();
            dataGridViewExamen = new DataGridView();
            IdExamen = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            comboBoxAccion = new ComboBox();
            numericUpDownIdExamen = new NumericUpDown();
            textBoxDescripcion = new TextBox();
            buttonAccion = new Button();
            labelAccion = new Label();
            labelIdExamen = new Label();
            labelNombre = new Label();
            labelDescripcion = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewExamen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownIdExamen).BeginInit();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitulo.Location = new Point(549, 9);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(103, 32);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Exámen";
            labelTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxNombre
            // 
            textBoxNombre.AcceptsTab = true;
            textBoxNombre.Cursor = Cursors.IBeam;
            textBoxNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxNombre.Location = new Point(420, 94);
            textBoxNombre.MaxLength = 255;
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(262, 29);
            textBoxNombre.TabIndex = 3;
            textBoxNombre.WordWrap = false;
            // 
            // dataGridViewExamen
            // 
            dataGridViewExamen.AllowUserToAddRows = false;
            dataGridViewExamen.AllowUserToDeleteRows = false;
            dataGridViewExamen.AllowUserToOrderColumns = true;
            dataGridViewExamen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewExamen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewExamen.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewExamen.BackgroundColor = Color.White;
            dataGridViewExamen.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewExamen.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewExamen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewExamen.Columns.AddRange(new DataGridViewColumn[] { IdExamen, Nombre, Descripcion });
            dataGridViewExamen.Location = new Point(12, 165);
            dataGridViewExamen.Name = "dataGridViewExamen";
            dataGridViewExamen.ReadOnly = true;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewExamen.RowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewExamen.Size = new Size(1160, 504);
            dataGridViewExamen.TabIndex = 0;
            // 
            // IdExamen
            // 
            IdExamen.HeaderText = "Identificador de exámen";
            IdExamen.Name = "IdExamen";
            IdExamen.ReadOnly = true;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            // 
            // Descripcion
            // 
            Descripcion.HeaderText = "Descripción";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            // 
            // comboBoxAccion
            // 
            comboBoxAccion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxAccion.FormattingEnabled = true;
            comboBoxAccion.Items.AddRange(new object[] { "Crear - DLL", "Crear - Web Service", "Actualizar - DLL", "Actualizar - Web Service", "Obtener - DLL", "Obtener - Web Service", "Eliminar - DLL", "Eliminar - Web Service" });
            comboBoxAccion.Location = new Point(12, 95);
            comboBoxAccion.Name = "comboBoxAccion";
            comboBoxAccion.Size = new Size(164, 29);
            comboBoxAccion.TabIndex = 1;
            comboBoxAccion.Text = "Crear - DLL";
            comboBoxAccion.SelectedIndexChanged += comboBoxAccion_SelectedIndexChanged;
            // 
            // numericUpDownIdExamen
            // 
            numericUpDownIdExamen.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDownIdExamen.Location = new Point(234, 95);
            numericUpDownIdExamen.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            numericUpDownIdExamen.Name = "numericUpDownIdExamen";
            numericUpDownIdExamen.Size = new Size(153, 29);
            numericUpDownIdExamen.TabIndex = 2;
            numericUpDownIdExamen.Visible = false;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.AcceptsTab = true;
            textBoxDescripcion.Cursor = Cursors.IBeam;
            textBoxDescripcion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxDescripcion.Location = new Point(719, 94);
            textBoxDescripcion.MaxLength = 255;
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(316, 29);
            textBoxDescripcion.TabIndex = 4;
            textBoxDescripcion.WordWrap = false;
            // 
            // buttonAccion
            // 
            buttonAccion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonAccion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonAccion.Location = new Point(1065, 92);
            buttonAccion.Name = "buttonAccion";
            buttonAccion.Size = new Size(107, 31);
            buttonAccion.TabIndex = 5;
            buttonAccion.Text = "Aceptar";
            buttonAccion.UseVisualStyleBackColor = true;
            buttonAccion.MouseClick += buttonAccion_MouseClick;
            // 
            // labelAccion
            // 
            labelAccion.AutoSize = true;
            labelAccion.Location = new Point(12, 77);
            labelAccion.Name = "labelAccion";
            labelAccion.Size = new Size(44, 15);
            labelAccion.TabIndex = 6;
            labelAccion.Text = "Acción";
            // 
            // labelIdExamen
            // 
            labelIdExamen.AutoSize = true;
            labelIdExamen.Location = new Point(234, 77);
            labelIdExamen.Name = "labelIdExamen";
            labelIdExamen.Size = new Size(135, 15);
            labelIdExamen.TabIndex = 7;
            labelIdExamen.Text = "Identificador de exámen";
            labelIdExamen.Visible = false;
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(420, 76);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(112, 15);
            labelNombre.TabIndex = 8;
            labelNombre.Text = "Nombre de exámen";
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(719, 76);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(130, 15);
            labelDescripcion.TabIndex = 9;
            labelDescripcion.Text = "Descripción de exámen";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 681);
            Controls.Add(labelDescripcion);
            Controls.Add(labelNombre);
            Controls.Add(labelIdExamen);
            Controls.Add(labelAccion);
            Controls.Add(buttonAccion);
            Controls.Add(textBoxDescripcion);
            Controls.Add(numericUpDownIdExamen);
            Controls.Add(comboBoxAccion);
            Controls.Add(dataGridViewExamen);
            Controls.Add(textBoxNombre);
            Controls.Add(labelTitulo);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Exámen";
            WindowState = FormWindowState.Maximized;
            FormClosing += MainForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridViewExamen).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownIdExamen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitulo;
        private TextBox textBoxNombre;
        private DataGridView dataGridViewExamen;
        private DataGridViewTextBoxColumn IdExamen;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Descripcion;
        private ComboBox comboBoxAccion;
        private NumericUpDown numericUpDownIdExamen;
        private TextBox textBoxDescripcion;
        private Button buttonAccion;
        private Label labelAccion;
        private Label labelIdExamen;
        private Label labelNombre;
        private Label labelDescripcion;
    }
}
