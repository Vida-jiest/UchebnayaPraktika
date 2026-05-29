using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AircraftPartsLibrary;

namespace AircraftPartsManager
{
    public partial class MainForm : Form
    {
        private IPartRepository _repository;
        private DataGridView dgvParts;
        private Button btnAdd, btnEdit, btnDelete, btnRefresh;
        private TextBox txtSearch;
        private Label lblSearch, lblStats;
        private ComboBox cmbStatusFilter;
        private Label lblFilter;

        public MainForm()
        {
            InitializeComponent();
            _repository = new JsonPartRepository("parts.json");
            LoadParts();
        }

        private void InitializeComponent()
        {
            this.dgvParts = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblStats = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).BeginInit();
            this.SuspendLayout();

            // dgvParts
            this.dgvParts.Location = new System.Drawing.Point(12, 70);
            this.dgvParts.Size = new System.Drawing.Size(860, 430);
            this.dgvParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvParts.BackgroundColor = System.Drawing.Color.White;
            this.dgvParts.RowHeadersVisible = false;
            this.dgvParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParts.AllowUserToAddRows = false;
            this.dgvParts.ReadOnly = true;
            this.dgvParts.RowTemplate.Height = 35;
            // Двойной клик для редактирования
            this.dgvParts.DoubleClick += new System.EventHandler(this.BtnEdit_Click);

            // btnAdd
            this.btnAdd.Text = "➕ Добавить";
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Size = new System.Drawing.Size(110, 40);
            this.btnAdd.Location = new System.Drawing.Point(12, 515);
            this.btnAdd.Cursor = Cursors.Hand;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            // btnEdit
            this.btnEdit.Text = "✏️ Редактировать";
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Size = new System.Drawing.Size(120, 40);
            this.btnEdit.Location = new System.Drawing.Point(132, 515);
            this.btnEdit.Cursor = Cursors.Hand;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);

            // btnDelete
            this.btnDelete.Text = "🗑️ Удалить";
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.Location = new System.Drawing.Point(262, 515);
            this.btnDelete.Cursor = Cursors.Hand;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            // btnRefresh
            this.btnRefresh.Text = "🔄 Обновить";
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Size = new System.Drawing.Size(100, 40);
            this.btnRefresh.Location = new System.Drawing.Point(372, 515);
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);

            // lblSearch
            this.lblSearch.Text = "🔍 Поиск:";
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lblSearch.Location = new System.Drawing.Point(12, 15);
            this.lblSearch.Size = new System.Drawing.Size(60, 25);

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(75, 12);
            this.txtSearch.Size = new System.Drawing.Size(200, 27);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10);
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            // lblFilter
            this.lblFilter.Text = "📊 Фильтр по статусу:";
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 10);
            this.lblFilter.Location = new System.Drawing.Point(290, 15);
            this.lblFilter.Size = new System.Drawing.Size(130, 25);

            // cmbStatusFilter
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.Font = new System.Drawing.Font("Segoe UI", 10);
            this.cmbStatusFilter.Location = new System.Drawing.Point(425, 12);
            this.cmbStatusFilter.Size = new System.Drawing.Size(150, 28);
            this.cmbStatusFilter.Items.AddRange(new object[] { "Все", "На складе", "Установлена", "Списана" });
            this.cmbStatusFilter.SelectedIndex = 0;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.CmbStatusFilter_SelectedIndexChanged);

            // lblStats
            this.lblStats.Text = "📊 Всего: 0  |  📦 На складе: 0  |  ✈️ Установлено: 0  |  ⚠️ Списано: 0";
            this.lblStats.Font = new System.Drawing.Font("Segoe UI", 9);
            this.lblStats.ForeColor = System.Drawing.Color.Gray;
            this.lblStats.Location = new System.Drawing.Point(500, 520);
            this.lblStats.Size = new System.Drawing.Size(380, 25);
            this.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // Контекстное меню
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem editItem = new ToolStripMenuItem("✏️ Редактировать");
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("🗑️ Удалить");
            ToolStripMenuItem copyItem = new ToolStripMenuItem("📋 Копировать номер детали");

            editItem.Click += (s, e) => BtnEdit_Click(null, null);
            deleteItem.Click += (s, e) => BtnDelete_Click(null, null);
            copyItem.Click += (s, e) =>
            {
                if (dgvParts.SelectedRows.Count > 0)
                {
                    var part = (Part)dgvParts.SelectedRows[0].DataBoundItem;
                    Clipboard.SetText(part.PartNumber);
                    MessageBox.Show("Номер детали скопирован в буфер обмена.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            contextMenu.Items.Add(editItem);
            contextMenu.Items.Add(deleteItem);
            contextMenu.Items.Add(copyItem);
            this.dgvParts.ContextMenuStrip = contextMenu;

            // MainForm
            this.ClientSize = new System.Drawing.Size(900, 570);
            this.Controls.Add(this.dgvParts);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cmbStatusFilter);
            this.Controls.Add(this.lblStats);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Система учёта деталей самолётов";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Горячие клавиши
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    BtnRefresh_Click(null, null);
                    return true;
                case Keys.Control | Keys.N:
                    BtnAdd_Click(null, null);
                    return true;
                case Keys.Control | Keys.E:
                    BtnEdit_Click(null, null);
                    return true;
                case Keys.Delete:
                    BtnDelete_Click(null, null);
                    return true;
                case Keys.Control | Keys.F:
                    txtSearch.Focus();
                    txtSearch.SelectAll();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void LoadParts()
        {
            var parts = _repository.GetAll().ToList();

            string searchText = txtSearch.Text;
            if (!string.IsNullOrEmpty(searchText))
            {
                parts = parts.Where(p => p.PartNumber.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                          p.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            if (cmbStatusFilter.SelectedIndex > 0)
            {
                PartStatus status;
                switch (cmbStatusFilter.SelectedItem.ToString())
                {
                    case "На складе": status = PartStatus.НаСкладе; break;
                    case "Установлена": status = PartStatus.Установлена; break;
                    case "Списана": status = PartStatus.Списана; break;
                    default: status = PartStatus.НаСкладе; break;
                }
                parts = parts.Where(p => p.Status == status).ToList();
            }

            dgvParts.DataSource = null;
            dgvParts.DataSource = parts;

            if (dgvParts.Columns["Id"] != null) dgvParts.Columns["Id"].HeaderText = "ID";
            if (dgvParts.Columns["Name"] != null) dgvParts.Columns["Name"].HeaderText = "Наименование";
            if (dgvParts.Columns["PartNumber"] != null) dgvParts.Columns["PartNumber"].HeaderText = "Номер детали";
            if (dgvParts.Columns["Type"] != null)
            {
                dgvParts.Columns["Type"].HeaderText = "Тип";
                dgvParts.CellFormatting -= DgvParts_CellFormatting;
                dgvParts.CellFormatting += DgvParts_CellFormatting;
            }
            if (dgvParts.Columns["ManufactureDate"] != null)
            {
                dgvParts.Columns["ManufactureDate"].HeaderText = "Дата изготовления";
                dgvParts.Columns["ManufactureDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }
            if (dgvParts.Columns["Status"] != null) dgvParts.Columns["Status"].HeaderText = "Статус";
            if (dgvParts.Columns["AircraftId"] != null) dgvParts.Columns["AircraftId"].HeaderText = "Борт самолёта";
            if (dgvParts.Columns["Description"] != null) dgvParts.Columns["Description"].HeaderText = "Описание";

            var all = _repository.GetAll();
            int total = all.Count();
            int inStock = all.Count(p => p.Status == PartStatus.НаСкладе);
            int installed = all.Count(p => p.Status == PartStatus.Установлена);
            int scrapped = all.Count(p => p.Status == PartStatus.Списана);

            lblStats.Text = $"📊 Всего: {total}  |  📦 На складе: {inStock}  |  ✈️ Установлено: {installed}  |  ⚠️ Списано: {scrapped}";
        }

        private void DgvParts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvParts.Columns[e.ColumnIndex].Name == "Type" && e.Value != null)
            {
                string type = e.Value.ToString();
                switch (type)
                {
                    case "Фюзеляж": e.Value = "✈️ Фюзеляж"; break;
                    case "Крыло": e.Value = "🪽 Крыло"; break;
                    case "Двигатель": e.Value = "⚙️ Двигатель"; break;
                    case "Шасси": e.Value = "🛞 Шасси"; break;
                    case "Авионика": e.Value = "📡 Авионика"; break;
                    case "Другое": e.Value = "📦 Другое"; break;
                }
            }

            if (dgvParts.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();
                switch (status)
                {
                    case "НаСкладе":
                        e.Value = "📦 На складе";
                        e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(25, 135, 84);
                        e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        break;
                    case "Установлена":
                        e.Value = "✈️ Установлена";
                        e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(13, 110, 253);
                        e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        break;
                    case "Списана":
                        e.Value = "⚠️ Списана";
                        e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
                        e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        break;
                }
            }
        }

        private void CmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadParts();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadParts();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var editForm = new PartEditForm(null, _repository);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                _repository.Add(editForm.Part);
                LoadParts();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvParts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите деталь для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var selectedPart = (Part)dgvParts.SelectedRows[0].DataBoundItem;
            var editForm = new PartEditForm(selectedPart, _repository);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                _repository.Update(editForm.Part);
                LoadParts();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvParts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите деталь для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var part = (Part)dgvParts.SelectedRows[0].DataBoundItem;
            DialogResult result = MessageBox.Show($"Удалить деталь '{part.Name}' (№{part.PartNumber})?\n\nЭто действие нельзя отменить.", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                _repository.Delete(part.Id);
                LoadParts();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbStatusFilter.SelectedIndex = 0;
            LoadParts();
        }
    }
}