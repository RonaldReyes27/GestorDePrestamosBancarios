namespace CapaPresent.UserControls
{
    partial class UC_Clientes
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panelTools = new Guna.UI2.WinForms.Guna2Panel();
            btnBuscarCliente = new Guna.UI2.WinForms.Guna2CircleButton();
            txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            cbBuscarPor = new Guna.UI2.WinForms.Guna2ComboBox();
            btnNuevoCliente = new Guna.UI2.WinForms.Guna2Button();
            dgvClientes = new Guna.UI2.WinForms.Guna2DataGridView();
            ColIdCliente = new DataGridViewTextBoxColumn();
            ColNombre = new DataGridViewTextBoxColumn();
            ColCiudad = new DataGridViewTextBoxColumn();
            ColCorreo = new DataGridViewTextBoxColumn();
            ColTelefono = new DataGridViewTextBoxColumn();
            panelTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.FromArgb(30, 47, 75);
            guna2HtmlLabel1.Location = new Point(15, 9);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(211, 39);
            guna2HtmlLabel1.TabIndex = 4;
            guna2HtmlLabel1.Text = "Lista de Clientes";
            // 
            // panelTools
            // 
            panelTools.BackColor = Color.White;
            panelTools.Controls.Add(btnBuscarCliente);
            panelTools.Controls.Add(txtBuscar);
            panelTools.Controls.Add(guna2HtmlLabel2);
            panelTools.Controls.Add(guna2HtmlLabel1);
            panelTools.Controls.Add(cbBuscarPor);
            panelTools.Controls.Add(btnNuevoCliente);
            panelTools.CustomizableEdges = customizableEdges8;
            panelTools.Dock = DockStyle.Top;
            panelTools.Location = new Point(0, 0);
            panelTools.Name = "panelTools";
            panelTools.ShadowDecoration.CustomizableEdges = customizableEdges9;
            panelTools.Size = new Size(952, 119);
            panelTools.TabIndex = 5;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.DisabledState.BorderColor = Color.DarkGray;
            btnBuscarCliente.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBuscarCliente.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBuscarCliente.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBuscarCliente.FillColor = Color.Gray;
            btnBuscarCliente.Font = new Font("Segoe UI", 9F);
            btnBuscarCliente.ForeColor = Color.White;
            btnBuscarCliente.Image = Properties.Resources.buscar;
            btnBuscarCliente.ImageSize = new Size(35, 35);
            btnBuscarCliente.Location = new Point(766, 60);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btnBuscarCliente.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnBuscarCliente.Size = new Size(42, 43);
            btnBuscarCliente.TabIndex = 5;
            btnBuscarCliente.Click += btnBuscarCliente_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.BorderRadius = 8;
            txtBuscar.CustomizableEdges = customizableEdges2;
            txtBuscar.DefaultText = "";
            txtBuscar.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtBuscar.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtBuscar.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtBuscar.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtBuscar.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBuscar.Font = new Font("Segoe UI", 9F);
            txtBuscar.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBuscar.Location = new Point(548, 67);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por...";
            txtBuscar.SelectedText = "";
            txtBuscar.ShadowDecoration.CustomizableEdges = customizableEdges3;
            txtBuscar.Size = new Size(212, 36);
            txtBuscar.TabIndex = 3;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(278, 70);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(109, 27);
            guna2HtmlLabel2.TabIndex = 2;
            guna2HtmlLabel2.Text = "Buscar Por :";
            // 
            // cbBuscarPor
            // 
            cbBuscarPor.BackColor = Color.Transparent;
            cbBuscarPor.BorderRadius = 8;
            cbBuscarPor.CustomizableEdges = customizableEdges4;
            cbBuscarPor.DrawMode = DrawMode.OwnerDrawFixed;
            cbBuscarPor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBuscarPor.FocusedColor = Color.FromArgb(94, 148, 255);
            cbBuscarPor.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbBuscarPor.Font = new Font("Segoe UI", 10F);
            cbBuscarPor.ForeColor = Color.FromArgb(68, 88, 112);
            cbBuscarPor.ItemHeight = 30;
            cbBuscarPor.Location = new Point(393, 67);
            cbBuscarPor.Name = "cbBuscarPor";
            cbBuscarPor.ShadowDecoration.CustomizableEdges = customizableEdges5;
            cbBuscarPor.Size = new Size(140, 36);
            cbBuscarPor.TabIndex = 1;
            // 
            // btnNuevoCliente
            // 
            btnNuevoCliente.BorderRadius = 8;
            btnNuevoCliente.CustomizableEdges = customizableEdges6;
            btnNuevoCliente.DisabledState.BorderColor = Color.DarkGray;
            btnNuevoCliente.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNuevoCliente.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNuevoCliente.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNuevoCliente.FillColor = Color.FromArgb(46, 204, 113);
            btnNuevoCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevoCliente.ForeColor = Color.White;
            btnNuevoCliente.Image = Properties.Resources.Book;
            btnNuevoCliente.ImageAlign = HorizontalAlignment.Left;
            btnNuevoCliente.ImageSize = new Size(25, 25);
            btnNuevoCliente.Location = new Point(15, 63);
            btnNuevoCliente.Name = "btnNuevoCliente";
            btnNuevoCliente.ShadowDecoration.CustomizableEdges = customizableEdges7;
            btnNuevoCliente.Size = new Size(180, 45);
            btnNuevoCliente.TabIndex = 0;
            btnNuevoCliente.Text = "Nuevo Cliente";
            btnNuevoCliente.TextAlign = HorizontalAlignment.Left;
            btnNuevoCliente.Click += btnNuevoCliente_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvClientes.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvClientes.ColumnHeadersHeight = 17;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { ColIdCliente, ColNombre, ColCiudad, ColCorreo, ColTelefono });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvClientes.DefaultCellStyle = dataGridViewCellStyle3;
            dgvClientes.GridColor = Color.FromArgb(231, 229, 255);
            dgvClientes.Location = new Point(15, 114);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.Size = new Size(925, 478);
            dgvClientes.TabIndex = 4;
            dgvClientes.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvClientes.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvClientes.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvClientes.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvClientes.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvClientes.ThemeStyle.BackColor = SystemColors.ButtonFace;
            dgvClientes.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvClientes.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvClientes.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvClientes.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvClientes.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvClientes.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvClientes.ThemeStyle.HeaderStyle.Height = 17;
            dgvClientes.ThemeStyle.ReadOnly = true;
            dgvClientes.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvClientes.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvClientes.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvClientes.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvClientes.ThemeStyle.RowsStyle.Height = 25;
            dgvClientes.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvClientes.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvClientes.CellContentClick += dgvClientes_CellContentClick;
            // 
            // ColIdCliente
            // 
            ColIdCliente.DataPropertyName = "IdCliente";
            ColIdCliente.HeaderText = "ID";
            ColIdCliente.Name = "ColIdCliente";
            ColIdCliente.ReadOnly = true;
            // 
            // ColNombre
            // 
            ColNombre.DataPropertyName = "Nombre";
            ColNombre.HeaderText = "Nombre";
            ColNombre.Name = "ColNombre";
            ColNombre.ReadOnly = true;
            // 
            // ColCiudad
            // 
            ColCiudad.DataPropertyName = "Ciudad";
            ColCiudad.HeaderText = "Ciudad";
            ColCiudad.Name = "ColCiudad";
            ColCiudad.ReadOnly = true;
            // 
            // ColCorreo
            // 
            ColCorreo.DataPropertyName = "CorreoElectronico";
            ColCorreo.HeaderText = "Correo";
            ColCorreo.Name = "ColCorreo";
            ColCorreo.ReadOnly = true;
            // 
            // ColTelefono
            // 
            ColTelefono.DataPropertyName = "Telefono";
            ColTelefono.HeaderText = "Telefono";
            ColTelefono.Name = "ColTelefono";
            ColTelefono.ReadOnly = true;
            // 
            // UC_Clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvClientes);
            Controls.Add(panelTools);
            Name = "UC_Clientes";
            Size = new Size(952, 606);
            panelTools.ResumeLayout(false);
            panelTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Panel panelTools;
        private Guna.UI2.WinForms.Guna2Button btnNuevoCliente;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2ComboBox cbBuscarPor;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private Guna.UI2.WinForms.Guna2DataGridView dgvClientes;
        private Guna.UI2.WinForms.Guna2CircleButton btnBuscarCliente;
        private DataGridViewTextBoxColumn ColIdCliente;
        private DataGridViewTextBoxColumn ColNombre;
        private DataGridViewTextBoxColumn ColCiudad;
        private DataGridViewTextBoxColumn ColCorreo;
        private DataGridViewTextBoxColumn ColTelefono;
    }
}
