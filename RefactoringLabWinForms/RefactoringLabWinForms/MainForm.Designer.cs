namespace RefactoringLabWinForms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxSalary = new System.Windows.Forms.TextBox();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelSalary = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.groupBoxEmployees = new System.Windows.Forms.GroupBox();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.buttonYoungest = new System.Windows.Forms.Button();
            this.buttonAverageSalary = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            this.groupBoxActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInput.Controls.Add(this.buttonAdd);
            this.groupBoxInput.Controls.Add(this.textBoxSalary);
            this.groupBoxInput.Controls.Add(this.textBoxAge);
            this.groupBoxInput.Controls.Add(this.textBoxName);
            this.groupBoxInput.Controls.Add(this.labelSalary);
            this.groupBoxInput.Controls.Add(this.labelAge);
            this.groupBoxInput.Controls.Add(this.labelName);
            this.groupBoxInput.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(660, 100);
            this.groupBoxInput.TabIndex = 0;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Добавление сотрудника";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(540, 25);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 60);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxSalary
            // 
            this.textBoxSalary.Location = new System.Drawing.Point(100, 65);
            this.textBoxSalary.Name = "textBoxSalary";
            this.textBoxSalary.Size = new System.Drawing.Size(420, 20);
            this.textBoxSalary.TabIndex = 2;
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(100, 45);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(420, 20);
            this.textBoxAge.TabIndex = 1;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(100, 25);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(420, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // labelSalary
            // 
            this.labelSalary.AutoSize = true;
            this.labelSalary.Location = new System.Drawing.Point(15, 68);
            this.labelSalary.Name = "labelSalary";
            this.labelSalary.Size = new System.Drawing.Size(58, 13);
            this.labelSalary.TabIndex = 2;
            this.labelSalary.Text = "Зарплата:";
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(15, 48);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(52, 13);
            this.labelAge.TabIndex = 1;
            this.labelAge.Text = "Возраст:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(15, 28);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(32, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Имя:";
            // 
            // groupBoxEmployees
            // 
            this.groupBoxEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEmployees.Controls.Add(this.dataGridViewEmployees);
            this.groupBoxEmployees.Location = new System.Drawing.Point(12, 118);
            this.groupBoxEmployees.Name = "groupBoxEmployees";
            this.groupBoxEmployees.Size = new System.Drawing.Size(660, 250);
            this.groupBoxEmployees.TabIndex = 1;
            this.groupBoxEmployees.TabStop = false;
            this.groupBoxEmployees.Text = "Список сотрудников";
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(15, 25);
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.Size = new System.Drawing.Size(625, 210);
            this.dataGridViewEmployees.TabIndex = 0;
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxActions.Controls.Add(this.buttonYoungest);
            this.groupBoxActions.Controls.Add(this.buttonAverageSalary);
            this.groupBoxActions.Controls.Add(this.buttonDelete);
            this.groupBoxActions.Location = new System.Drawing.Point(12, 374);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(660, 70);
            this.groupBoxActions.TabIndex = 2;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Действия";
            // 
            // buttonYoungest
            // 
            this.buttonYoungest.Location = new System.Drawing.Point(230, 25);
            this.buttonYoungest.Name = "buttonYoungest";
            this.buttonYoungest.Size = new System.Drawing.Size(200, 30);
            this.buttonYoungest.TabIndex = 2;
            this.buttonYoungest.Text = "Найти самого молодого";
            this.buttonYoungest.UseVisualStyleBackColor = true;
            this.buttonYoungest.Click += new System.EventHandler(this.buttonYoungest_Click);
            // 
            // buttonAverageSalary
            // 
            this.buttonAverageSalary.Location = new System.Drawing.Point(15, 25);
            this.buttonAverageSalary.Name = "buttonAverageSalary";
            this.buttonAverageSalary.Size = new System.Drawing.Size(200, 30);
            this.buttonAverageSalary.TabIndex = 1;
            this.buttonAverageSalary.Text = "Средняя зарплата";
            this.buttonAverageSalary.UseVisualStyleBackColor = true;
            this.buttonAverageSalary.Click += new System.EventHandler(this.buttonAverageSalary_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(540, 25);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(100, 30);
            this.buttonDelete.TabIndex = 0;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxEmployees);
            this.Controls.Add(this.groupBoxInput);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "s";
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.groupBoxEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            this.groupBoxActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.GroupBox groupBoxEmployees;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.TextBox textBoxSalary;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.Label labelSalary;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAverageSalary;
        private System.Windows.Forms.Button buttonYoungest;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
    }
}
















//namespace RefactoringLabWinForms
//{
//    partial class MainForm
//    {
//        private System.ComponentModel.IContainer components = null;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            this.textBoxName = new System.Windows.Forms.TextBox();
//            this.textBox2 = new System.Windows.Forms.TextBox();
//            this.textBox3 = new System.Windows.Forms.TextBox();
//            this.buttonAdd = new System.Windows.Forms.Button();
//            this.button2 = new System.Windows.Forms.Button();
//            this.button3 = new System.Windows.Forms.Button();
//            this.button4 = new System.Windows.Forms.Button();
//            this.dataGridViewEmplovees = new System.Windows.Forms.ListBox();
//            this.label1 = new System.Windows.Forms.Label();
//            this.label2 = new System.Windows.Forms.Label();
//            this.label3 = new System.Windows.Forms.Label();
//            this.SuspendLayout();
//            // 
//            // textBox1
//            // 
//            this.textBoxName.Location = new System.Drawing.Point(100, 20);
//            this.textBoxName.Name = "textBox1";
//            this.textBoxName.Size = new System.Drawing.Size(200, 20);
//            this.textBoxName.TabIndex = 0;
//            // 
//            // textBox2
//            // 
//            this.textBox2.Location = new System.Drawing.Point(100, 50);
//            this.textBox2.Name = "textBox2";
//            this.textBox2.Size = new System.Drawing.Size(200, 20);
//            this.textBox2.TabIndex = 1;
//            // 
//            // textBox3
//            // 
//            this.textBox3.Location = new System.Drawing.Point(100, 80);
//            this.textBox3.Name = "textBox3";
//            this.textBox3.Size = new System.Drawing.Size(200, 20);
//            this.textBox3.TabIndex = 2;
//            // 
//            // button1
//            // 
//            this.buttonAdd.Location = new System.Drawing.Point(320, 20);
//            this.buttonAdd.Name = "button1";
//            this.buttonAdd.Size = new System.Drawing.Size(100, 80);
//            this.buttonAdd.TabIndex = 3;
//            this.buttonAdd.Text = "Добавить";
//            this.buttonAdd.UseVisualStyleBackColor = true;
//            this.buttonAdd.Click += new System.EventHandler(this.button1_Click);
//            // 
//            // button2
//            // 
//            this.button2.Location = new System.Drawing.Point(20, 350);
//            this.button2.Name = "button2";
//            this.button2.Size = new System.Drawing.Size(130, 30);
//            this.button2.TabIndex = 4;
//            this.button2.Text = "Средняя зарплата";
//            this.button2.UseVisualStyleBackColor = true;
//            this.button2.Click += new System.EventHandler(this.button2_Click);
//            // 
//            // button3
//            // 
//            this.button3.Location = new System.Drawing.Point(160, 350);
//            this.button3.Name = "button3";
//            this.button3.Size = new System.Drawing.Size(130, 30);
//            this.button3.TabIndex = 5;
//            this.button3.Text = "Самый молодой";
//            this.button3.UseVisualStyleBackColor = true;
//            this.button3.Click += new System.EventHandler(this.button3_Click);
//            // 
//            // button4
//            // 
//            this.button4.Location = new System.Drawing.Point(300, 350);
//            this.button4.Name = "button4";
//            this.button4.Size = new System.Drawing.Size(120, 30);
//            this.button4.TabIndex = 6;
//            this.button4.Text = "Удалить";
//            this.button4.UseVisualStyleBackColor = true;
//            this.button4.Click += new System.EventHandler(this.button4_Click);
//            // 
//            // listBox1
//            // 
//            this.dataGridViewEmplovees.FormattingEnabled = true;
//            this.dataGridViewEmplovees.Location = new System.Drawing.Point(20, 120);
//            this.dataGridViewEmplovees.Name = "listBox1";
//            this.dataGridViewEmplovees.Size = new System.Drawing.Size(400, 212);
//            this.dataGridViewEmplovees.TabIndex = 7;
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Location = new System.Drawing.Point(20, 23);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(32, 13);
//            this.label1.TabIndex = 8;
//            this.label1.Text = "Имя:";
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Location = new System.Drawing.Point(20, 53);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(52, 13);
//            this.label2.TabIndex = 9;
//            this.label2.Text = "Возраст:";
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Location = new System.Drawing.Point(20, 83);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(58, 13);
//            this.label3.TabIndex = 10;
//            this.label3.Text = "Зарплата:";
//            // 
//            // Form1
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(444, 401);
//            this.Controls.Add(this.label3);
//            this.Controls.Add(this.label2);
//            this.Controls.Add(this.label1);
//            this.Controls.Add(this.dataGridViewEmplovees);
//            this.Controls.Add(this.button4);
//            this.Controls.Add(this.button3);
//            this.Controls.Add(this.button2);
//            this.Controls.Add(this.buttonAdd);
//            this.Controls.Add(this.textBox3);
//            this.Controls.Add(this.textBox2);
//            this.Controls.Add(this.textBoxName);
//            this.Name = "Form1";
//            this.Text = "Управление сотрудниками";
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }

//        private System.Windows.Forms.TextBox textBoxName;
//        private System.Windows.Forms.TextBox textBox2;
//        private System.Windows.Forms.TextBox textBox3;
//        private System.Windows.Forms.Button buttonAdd;
//        private System.Windows.Forms.Button button2;
//        private System.Windows.Forms.Button button3;
//        private System.Windows.Forms.Button button4;
//        private System.Windows.Forms.ListBox dataGridViewEmplovees;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Label label3;
//    }
//}
