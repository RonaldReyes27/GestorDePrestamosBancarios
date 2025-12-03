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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panelTools = new Guna.UI2.WinForms.Guna2Panel();
            txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            cmbFiltro = new Guna.UI2.WinForms.Guna2ComboBox();
            btnNuevoCliente = new Guna.UI2.WinForms.Guna2Button();
            dgvClientes = new Guna.UI2.WinForms.Guna2DataGridView();
            ColNombre = new DataGridViewTextBoxColumn();
            colTipoDoc = new DataGridViewTextBoxColumn();
            colDocumento = new DataGridViewTextBoxColumn();
            colCiudad = new DataGridViewTextBoxColumn();
            colCorreo = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            colEditar = new DataGridViewButtonColumn();
            colEliminar = new DataGridViewButtonColumn();
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
            panelTools.Controls.Add(txtBuscar);
            panelTools.Controls.Add(guna2HtmlLabel2);
            panelTools.Controls.Add(guna2HtmlLabel1);
            panelTools.Controls.Add(cmbFiltro);
            panelTools.Controls.Add(btnNuevoCliente);
            panelTools.CustomizableEdges = customizableEdges7;
            panelTools.Dock = DockStyle.Top;
            panelTools.Location = new Point(0, 0);
            panelTools.Name = "panelTools";
            panelTools.ShadowDecoration.CustomizableEdges = customizableEdges8;
            panelTools.Size = new Size(952, 119);
            panelTools.TabIndex = 5;
            // 
            // txtBuscar
            // 
            txtBuscar.BorderRadius = 8;
            txtBuscar.CustomizableEdges = customizableEdges1;
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
            txtBuscar.ShadowDecoration.CustomizableEdges = customizableEdges2;
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
            // cmbFiltro
            // 
            cmbFiltro.BackColor = Color.Transparent;
            cmbFiltro.BorderRadius = 8;
            cmbFiltro.CustomizableEdges = customizableEdges3;
            cmbFiltro.DrawMode = DrawMode.OwnerDrawFixed;
            cmbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltro.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbFiltro.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbFiltro.Font = new Font("Segoe UI", 10F);
            cmbFiltro.ForeColor = Color.FromArgb(68, 88, 112);
            cmbFiltro.ItemHeight = 30;
            cmbFiltro.Items.AddRange(new object[] { "Clientes", "Documentos", "Ciudad" });
            cmbFiltro.Location = new Point(393, 67);
            cmbFiltro.Name = "cmbFiltro";
            cmbFiltro.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cmbFiltro.Size = new Size(140, 36);
            cmbFiltro.TabIndex = 1;
            // 
            // btnNuevoCliente
            // 
            btnNuevoCliente.BorderRadius = 8;
            btnNuevoCliente.CustomizableEdges = customizableEdges5;
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
            btnNuevoCliente.ShadowDecoration.CustomizableEdges = customizableEdges6;
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
            dgvClientes.BackgroundColor = SystemColors.Window;
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
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { ColNombre, colTipoDoc, colDocumento, colCiudad, colCorreo, colTelefono, colEditar, colEliminar });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvClientes.DefaultCellStyle = dataGridViewCellStyle3;
            dgvClientes.GridColor = Color.FromArgb(231, 229, 255);
            dgvClientes.Location = new Point(0, 119);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.Size = new Size(951, 487);
            dgvClientes.TabIndex = 4;
            dgvClientes.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvClientes.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvClientes.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvClientes.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvClientes.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvClientes.ThemeStyle.BackColor = SystemColors.Window;
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
            // 
            // ColNombre
            // 
            ColNombre.HeaderText = "Nombre";
            ColNombre.Name = "ColNombre";
            ColNombre.ReadOnly = true;
            // 
            // colTipoDoc
            // 
            colTipoDoc.HeaderText = "T. Documento";
            colTipoDoc.Name = "colTipoDoc";
            colTipoDoc.ReadOnly = true;
            // 
            // colDocumento
            // 
            colDocumento.HeaderText = "Documento";
            colDocumento.Name = "colDocumento";
            colDocumento.ReadOnly = true;
            // 
            // colCiudad
            // 
            colCiudad.HeaderText = "Ciudad";
            colCiudad.Name = "colCiudad";
            colCiudad.ReadOnly = true;
            // 
            // colCorreo
            // 
            colCorreo.HeaderText = "Correo";
            colCorreo.Name = "colCorreo";
            colCorreo.ReadOnly = true;
            // 
            // colTelefono
            // 
            colTelefono.HeaderText = "Teléfono";
            colTelefono.Name = "colTelefono";
            colTelefono.ReadOnly = true;
            // 
            // colEditar
            // 
            colEditar.HeaderText = "✎";
            colEditar.Name = "colEditar";
            colEditar.ReadOnly = true;
            // 
            // colEliminar
            // 
            colEliminar.HeaderText = "🗑";
            colEliminar.Name = "colEliminar";
            colEliminar.ReadOnly = true;
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
        private Guna.UI2.WinForms.Guna2ComboBox cmbFiltro;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private Guna.UI2.WinForms.Guna2DataGridView dgvClientes;
        private DataGridViewTextBoxColumn ColNombre;
        private DataGridViewTextBoxColumn colTipoDoc;
        private DataGridViewTextBoxColumn colDocumento;
        private DataGridViewTextBoxColumn colCiudad;
        private DataGridViewTextBoxColumn colCorreo;
        private DataGridViewTextBoxColumn colTelefono;
        private DataGridViewButtonColumn colEditar;
        private DataGridViewButtonColumn colEliminar;
    }
}
