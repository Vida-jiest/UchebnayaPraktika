using System;
using System.Drawing;
using System.Windows.Forms;
using AircraftPartsLibrary;

namespace AircraftPartsManager
{
    public partial class PartEditForm : Form
    {
        public Part Part { get; private set; }
        private IPartRepository _repository;

        private TextBox txtName;
        private TextBox txtPartNumber;
        private TextBox txtAircraftId;
        private TextBox txtDescription;
        private ComboBox cmbType;
        private ComboBox cmbStatus;
        private DateTimePicker dtpManufactureDate;
        private Button btnSave;
        private Button btnCancel;
        private Panel headerPanel;
        private Label lblTitle;

        public PartEditForm(Part existingPart, IPartRepository repository)
        {
            _repository = repository;
            InitializeComponent();

            if (existingPart == null)
            {
                Part = new Part();
                lblTitle.Text = "➕ Новая деталь";
                this.Text = "Добавление детали";
            }
            else
            {
                Part = new Part();
                Part.Id = existingPart.Id;
                Part.Name = existingPart.Name;
                Part.PartNumber = existingPart.PartNumber;
                Part.Type = existingPart.Type;
                Part.ManufactureDate = existingPart.ManufactureDate;
                Part.Status = existingPart.Status;
                Part.AircraftId = existingPart.AircraftId;
                Part.Description = existingPart.Description;
                lblTitle.Text = "✏️ Редактирование детали";
                this.Text = "Редактирование детали";
            }

            LoadPartToControls();
        }

        private void InitializeComponent()
        {
            Color whiteBg = Color.White;
            Color lightGray = Color.FromArgb(248, 249, 250);
            Color accentBlue = Color.FromArgb(13, 110, 253);
            Color accentGreen = Color.FromArgb(25, 135, 84);
            Color textColor = Color.FromArgb(33, 37, 41);

            this.headerPanel = new Panel();
            this.lblTitle = new Label();
            this.txtName = new TextBox();
            this.txtPartNumber = new TextBox();
            this.txtAircraftId = new TextBox();
            this.txtDescription = new TextBox();
            this.cmbType = new ComboBox();
            this.cmbStatus = new ComboBox();
            this.dtpManufactureDate = new DateTimePicker();
            this.btnSave = new Button();
            this.btnCancel = new Button();

            // headerPanel
            this.headerPanel.BackColor = lightGray;
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Height = 70;

            // lblTitle
            this.lblTitle.Text = "Деталь самолёта";
            this.lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitle.ForeColor = accentBlue;
            this.lblTitle.Location = new Point(25, 25);
            this.lblTitle.Size = new Size(400, 30);

            this.headerPanel.Controls.Add(this.lblTitle);

            // Поля ввода
            this.txtName.BackColor = whiteBg;
            this.txtName.ForeColor = textColor;
            this.txtName.BorderStyle = BorderStyle.FixedSingle;
            this.txtName.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            this.txtPartNumber.BackColor = whiteBg;
            this.txtPartNumber.ForeColor = textColor;
            this.txtPartNumber.BorderStyle = BorderStyle.FixedSingle;
            this.txtPartNumber.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            this.txtAircraftId.BackColor = whiteBg;
            this.txtAircraftId.ForeColor = textColor;
            this.txtAircraftId.BorderStyle = BorderStyle.FixedSingle;
            this.txtAircraftId.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            this.txtDescription.BackColor = whiteBg;
            this.txtDescription.ForeColor = textColor;
            this.txtDescription.BorderStyle = BorderStyle.FixedSingle;
            this.txtDescription.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.txtDescription.Multiline = true;
            this.txtDescription.Height = 60;

            this.cmbType.BackColor = whiteBg;
            this.cmbType.ForeColor = textColor;
            this.cmbType.FlatStyle = FlatStyle.Flat;
            this.cmbType.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.cmbType.DropDownStyle = ComboBoxStyle.DropDownList;

            this.cmbStatus.BackColor = whiteBg;
            this.cmbStatus.ForeColor = textColor;
            this.cmbStatus.FlatStyle = FlatStyle.Flat;
            this.cmbStatus.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            this.dtpManufactureDate.Format = DateTimePickerFormat.Short;
            this.dtpManufactureDate.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // Кнопки
            this.btnSave.Text = "💾 Сохранить";
            this.btnSave.BackColor = accentGreen;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Size = new Size(120, 40);
            this.btnSave.Cursor = Cursors.Hand;
            this.btnSave.Click += new EventHandler(BtnSave_Click);

            this.btnCancel.Text = "❌ Отмена";
            this.btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Size = new Size(120, 40);
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.Click += new EventHandler(BtnCancel_Click);

            // Добавление контролов
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtAircraftId);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.dtpManufactureDate);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.txtPartNumber);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.headerPanel);

            // Позиционирование
            int y = 100;
            AddLabel("НАИМЕНОВАНИЕ:", 30, y);
            this.txtName.Location = new Point(180, y);
            this.txtName.Size = new Size(260, 27);
            y += 50;

            AddLabel("НОМЕР ДЕТАЛИ:", 30, y);
            this.txtPartNumber.Location = new Point(180, y);
            this.txtPartNumber.Size = new Size(260, 27);
            y += 50;

            AddLabel("ТИП:", 30, y);
            this.cmbType.Location = new Point(180, y);
            this.cmbType.Size = new Size(260, 28);
            y += 50;

            AddLabel("ДАТА ИЗГОТОВЛЕНИЯ:", 30, y);
            this.dtpManufactureDate.Location = new Point(180, y);
            this.dtpManufactureDate.Size = new Size(260, 27);
            y += 50;

            AddLabel("СТАТУС:", 30, y);
            this.cmbStatus.Location = new Point(180, y);
            this.cmbStatus.Size = new Size(260, 28);
            y += 50;

            AddLabel("БОРТ САМОЛЁТА:", 30, y);
            this.txtAircraftId.Location = new Point(180, y);
            this.txtAircraftId.Size = new Size(260, 27);
            y += 50;

            AddLabel("ОПИСАНИЕ:", 30, y);
            this.txtDescription.Location = new Point(180, y);
            this.txtDescription.Size = new Size(260, 60);
            y += 80;

            this.btnSave.Location = new Point(60, y);
            this.btnCancel.Location = new Point(210, y);

            this.BackColor = whiteBg;
            this.ClientSize = new Size(500, y + 80);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void AddLabel(string text, int x, int y)
        {
            Color textColor = Color.FromArgb(108, 117, 125);
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lbl.ForeColor = textColor;
            lbl.Location = new Point(x, y);
            lbl.Size = new Size(140, 25);
            this.Controls.Add(lbl);
        }

        private void LoadPartToControls()
        {
            this.txtName.Text = Part.Name;
            this.txtPartNumber.Text = Part.PartNumber;

            // Заполнение типов
            this.cmbType.Items.Clear();
            this.cmbType.Items.AddRange(new object[] { "Фюзеляж", "Крыло", "Двигатель", "Шасси", "Авионика", "Другое" });

            switch (Part.Type)
            {
                case PartType.Фюзеляж: this.cmbType.SelectedItem = "Фюзеляж"; break;
                case PartType.Крыло: this.cmbType.SelectedItem = "Крыло"; break;
                case PartType.Двигатель: this.cmbType.SelectedItem = "Двигатель"; break;
                case PartType.Шасси: this.cmbType.SelectedItem = "Шасси"; break;
                case PartType.Авионика: this.cmbType.SelectedItem = "Авионика"; break;
                case PartType.Другое: this.cmbType.SelectedItem = "Другое"; break;
            }

            this.dtpManufactureDate.Value = Part.ManufactureDate == DateTime.MinValue ? DateTime.Now : Part.ManufactureDate;

            // Заполнение статусов
            this.cmbStatus.Items.Clear();
            this.cmbStatus.Items.AddRange(new object[] { "На складе", "Установлена", "Списана" });

            switch (Part.Status)
            {
                case PartStatus.НаСкладе: this.cmbStatus.SelectedItem = "На складе"; break;
                case PartStatus.Установлена: this.cmbStatus.SelectedItem = "Установлена"; break;
                case PartStatus.Списана: this.cmbStatus.SelectedItem = "Списана"; break;
            }

            this.txtAircraftId.Text = Part.AircraftId;
            this.txtDescription.Text = Part.Description;

            this.cmbStatus.SelectedIndexChanged += CmbStatus_SelectedIndexChanged;
            UpdateAircraftIdEnabled();
        }

        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAircraftIdEnabled();
        }

        private void UpdateAircraftIdEnabled()
        {
            bool isInstalled = this.cmbStatus.SelectedItem != null && this.cmbStatus.SelectedItem.ToString() == "Установлена";
            this.txtAircraftId.Enabled = isInstalled;
            if (!isInstalled)
                this.txtAircraftId.Text = "";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(this.txtName.Text))
            {
                MessageBox.Show("Введите наименование детали.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtPartNumber.Text))
            {
                MessageBox.Show("Введите номер детали.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtPartNumber.Focus();
                return;
            }

            // Проверка уникальности номера (только для новой детали)
            if (Part.Id == 0)
            {
                var existing = _repository.GetByPartNumber(this.txtPartNumber.Text.Trim());
                if (existing != null)
                {
                    MessageBox.Show("Деталь с таким номером уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (this.cmbStatus.SelectedItem != null && this.cmbStatus.SelectedItem.ToString() == "Установлена" &&
                string.IsNullOrWhiteSpace(this.txtAircraftId.Text))
            {
                MessageBox.Show("Для установленной детали необходимо указать борт самолёта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtAircraftId.Focus();
                return;
            }

            // Сохранение
            Part.Name = this.txtName.Text.Trim();
            Part.PartNumber = this.txtPartNumber.Text.Trim();

            if (this.cmbType.SelectedItem != null)
            {
                switch (this.cmbType.SelectedItem.ToString())
                {
                    case "Фюзеляж": Part.Type = PartType.Фюзеляж; break;
                    case "Крыло": Part.Type = PartType.Крыло; break;
                    case "Двигатель": Part.Type = PartType.Двигатель; break;
                    case "Шасси": Part.Type = PartType.Шасси; break;
                    case "Авионика": Part.Type = PartType.Авионика; break;
                    default: Part.Type = PartType.Другое; break;
                }
            }

            Part.ManufactureDate = this.dtpManufactureDate.Value;

            if (this.cmbStatus.SelectedItem != null)
            {
                switch (this.cmbStatus.SelectedItem.ToString())
                {
                    case "На складе": Part.Status = PartStatus.НаСкладе; break;
                    case "Установлена": Part.Status = PartStatus.Установлена; break;
                    case "Списана": Part.Status = PartStatus.Списана; break;
                }
            }

            Part.AircraftId = string.IsNullOrWhiteSpace(this.txtAircraftId.Text) ? "" : this.txtAircraftId.Text.Trim();
            Part.Description = this.txtDescription.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}