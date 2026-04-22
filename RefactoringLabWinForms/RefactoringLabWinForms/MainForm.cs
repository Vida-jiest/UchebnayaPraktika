using System;
using System.ComponentModel;
using System.Windows.Forms;
using RefactoringLabWinForms.Models;
using RefactoringLabWinForms.Services;

namespace RefactoringLabWinForms
{
    public partial class MainForm : Form
    {
        private readonly EmployeeService _employeeService;
        private readonly BindingList<Employee> _employeeBindingList;

        public MainForm()
        {
            InitializeComponent();

            // Инициализация сервисов
            var repository = new EmployeeRepository();
            _employeeService = new EmployeeService(repository);

            // Настройка привязки данных
            _employeeBindingList = new BindingList<Employee>();
            dataGridViewEmployees.DataSource = _employeeBindingList;

            ConfigureDataGridView();
            LoadSampleData();
        }

        /// <summary>
        /// Настройка внешнего вида DataGridView
        /// </summary>
        private void ConfigureDataGridView()
        {
            dataGridViewEmployees.AutoGenerateColumns = true;
            dataGridViewEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEmployees.MultiSelect = false;
            dataGridViewEmployees.AllowUserToAddRows = false;
            dataGridViewEmployees.ReadOnly = true;
        }

        /// <summary>
        /// Загрузка тестовых данных
        /// </summary>
        private void LoadSampleData()
        {
            _employeeService.AddEmployee("Иванов Иван", 25, 50000, out _);
            _employeeService.AddEmployee("Петров Петр", 30, 60000, out _);
            _employeeService.AddEmployee("Сидорова Анна", 28, 55000, out _);
            RefreshEmployeeList();
        }

        /// <summary>
        /// Обновление списка сотрудников в UI
        /// </summary>
        private void RefreshEmployeeList()
        {
            _employeeBindingList.Clear();
            foreach (var employee in _employeeService.GetAllEmployees())
            {
                _employeeBindingList.Add(employee);
            }
        }

        /// <summary>
        /// Очистка полей ввода
        /// </summary>
        private void ClearInputFields()
        {
            textBoxName.Clear();
            textBoxAge.Clear();
            textBoxSalary.Clear();
            textBoxName.Focus();
        }

        /// <summary>
        /// Обработчик добавления сотрудника
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxName.Text.Trim();

                if (!int.TryParse(textBoxAge.Text, out int age))
                {
                    MessageBox.Show("Введите корректный возраст", "Ошибка ввода",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(textBoxSalary.Text, out decimal salary))
                {
                    MessageBox.Show("Введите корректную зарплату", "Ошибка ввода",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_employeeService.AddEmployee(name, age, salary, out string errorMessage))
                {
                    RefreshEmployeeList();
                    ClearInputFields();
                    MessageBox.Show("Сотрудник успешно добавлен", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(errorMessage, "Ошибка валидации",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик удаления сотрудника
        /// </summary>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника для удаления", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedEmployee = (Employee)dataGridViewEmployees.SelectedRows[0].DataBoundItem;

            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить сотрудника {selectedEmployee.Name}?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _employeeService.RemoveEmployee(selectedEmployee);
                RefreshEmployeeList();
            }
        }

        /// <summary>
        /// Обработчик расчета средней зарплаты
        /// </summary>
        private void buttonAverageSalary_Click(object sender, EventArgs e)
        {
            if (_employeeService.GetEmployeeCount() == 0)
            {
                MessageBox.Show("Список сотрудников пуст", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal averageSalary = _employeeService.CalculateAverageSalary();
            MessageBox.Show($"Средняя зарплата: {averageSalary:C}", "Результат расчета",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Обработчик поиска самого молодого сотрудника
        /// </summary>
        private void buttonYoungest_Click(object sender, EventArgs e)
        {
            bool flowControl = IsEmployeeListEmpty();
            if (!flowControl)
            {
                return;
            }

            var youngest = _employeeService.FindYoungestEmployee();

            if (youngest != null)
            {
                MessageBox.Show(
                    $"Самый молодой сотрудник:\n{youngest.Name}\nВозраст: {youngest.Age} лет",
                    "Результат поиска",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private bool IsEmployeeListEmpty()
        {
            if (_employeeService.GetEmployeeCount() == 0)
            {
                MessageBox.Show("Список сотрудников пуст", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
    }
}




//using System;
//using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//namespace RefactoringLabWinForms
//{
//    public partial class MainForm : Form
//    {
//        public MainForm()
//        {
//            InitializeComponent();
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            // Добавление сотрудника
//            string n = textBoxName.Text;
//            string a = textBox2.Text;
//            string s = textBox3.Text;

//            if (n != "" && a != "" && s != "")
//            {
//                dataGridViewEmplovees.Items.Add(n + "|" + a + "|" + s);
//                textBoxName.Text = "";
//                textBox2.Text = "";
//                textBox3.Text = "";
//            }
//            else
//            {
//                MessageBox.Show("Заполните все поля!");
//            }
//        }

//        private void button2_Click(object sender, EventArgs e)
//        {
//            // Расчет средней зарплаты
//            double sum = 0;
//            int count = 0;
//            for (int i = 0; i < dataGridViewEmplovees.Items.Count; i++)
//            {
//                string[] p = dataGridViewEmplovees.Items[i].ToString().Split('|');
//                sum += double.Parse(p[2]);
//                count++;
//            }
//            if (count > 0)
//            {
//                MessageBox.Show("Средняя зарплата: " + (sum / count).ToString());
//            }
//        }

//        private void button3_Click(object sender, EventArgs e)
//        {
//            // Поиск самого молодого
//            int min = 999;
//            string name = "";
//            for (int i = 0; i < dataGridViewEmplovees.Items.Count; i++)
//            {
//                string[] p = dataGridViewEmplovees.Items[i].ToString().Split('|');
//                int age = int.Parse(p[1]);
//                if (age < min)
//                {
//                    min = age;
//                    name = p[0];
//                }
//            }
//            if (name != "")
//            {
//                MessageBox.Show("Самый молодой: " + name + " (" + min + " лет)");
//            }
//        }

//        private void button4_Click(object sender, EventArgs e)
//        {
//            // Удаление выбранного
//            if (dataGridViewEmplovees.SelectedIndex >= 0)
//            {
//                dataGridViewEmplovees.Items.RemoveAt(dataGridViewEmplovees.SelectedIndex);
//            }
//        }
//    }
//}
