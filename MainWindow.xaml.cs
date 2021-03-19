using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tutorial.SqlConn;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Tutorial.SqlConn
{
    class DBMySQLUtils
    {

        public static MySqlConnection
                 GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }

    }
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "194.28.213.54";
            int port = 3306;
            string database = "help_log";
            string username = "root";
            string password = "awds12qe";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }

    }
}

namespace Journal_Admin
{
    public class RelayCommand : ICommand
    {
        private System.Action action;
        public RelayCommand(System.Action action) => this.action = action;
        public bool CanExecute(object parameter) => true;
#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
        public void Execute(object parameter) => action();
    }

    public class RequestViewModel
    {
        public RequestViewModel(int id, string appeal, string cabinet, string date, string answer)
        {
            ID = id;
            Обращение = appeal;
            Кабинет = cabinet;
            Дата = date;
            Ответ = answer;
        }
        public int ID { get; set; }
        public string Обращение { get; set; }
        public string Кабинет { get; set; }
        public string Дата { get; set; }
        public string Ответ { get; set; }
    }

    public class MainViewModel
    {
        public ObservableCollection<RequestViewModel> Requests { get; set; } = new ObservableCollection<RequestViewModel>();

        public ObservableCollection<RequestViewModel> DoneRequests { get; set; } = new ObservableCollection<RequestViewModel>();
        public RequestViewModel SelectedPerson { get; set; }

        public ICommand DoneRowCommand { get; set; }
        public ICommand DeleteRowCommand { get; set; }
        public ICommand GetRowInfoCommand { get; set; }

        public ICommand ExportToExcelCommand { get; set; }

        public MainViewModel()
        {
            ExportToExcelCommand = new RelayCommand(ExportToExcel);
            DoneRowCommand = new RelayCommand(DoneRow);
            DeleteRowCommand = new RelayCommand(DeleteRow);
            GetRowInfoCommand = new RelayCommand(GetRowInfo);
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM appeal;";

                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    if ((reader[4].ToString() == "Рассмотрено") || (reader[4].ToString() == "Рассмотренно") || (reader[4].ToString() == "рассмотрено") || (reader[4].ToString() == "рассмотрено"))
                        DoneRequests.Add(new RequestViewModel((int)reader[0], reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString()));
                    else
                        Requests.Add(new RequestViewModel((int)reader[0], reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString()));

                    count++;
                }
                if (count == 0)
                {
                    MessageBox.Show("Обращений нет!");                 
                }
                reader.Close();

                conn.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Unable to connect to any of the specified MySQL hosts.")
                {
                    MessageBox.Show("Не удалось подключиться к серверу!");
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ExportToExcel()
        {
            if (SelectedPerson != null)
            {
                string path = Path.Combine(System.Windows.Forms.Application.StartupPath, "Рассмотренные обращения.xlsx");
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWb = xlApp.Workbooks.Open(path); //открываем Excel файл
                Excel.Worksheet xlSht = xlWb.Sheets[1]; //первый лист в файле
                int iLastRow = xlSht.Cells[xlSht.Rows.Count, "A"].End[Excel.XlDirection.xlUp].Row + 1;  //последняя заполненная строка в столбце A
                xlSht.Cells[iLastRow, "A"].Value = SelectedPerson.Обращение.ToString();
                xlSht.Cells[iLastRow, "B"].Value = SelectedPerson.Кабинет.ToString();
                xlSht.Cells[iLastRow, "C"].Value = SelectedPerson.Дата.ToString();
                xlSht.Cells[iLastRow, "D"].Value = SelectedPerson.Ответ.ToString();
                //xlApp.Visible = true;
                xlWb.Close(true); //закрыть и сохранить книгу
                xlApp.Quit();
                MessageBox.Show("Обращение успешно экспортировано!");
            }
        }
        private void DoneRow() 
        {
            if (SelectedPerson != null) 
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                try
                {
                    conn.Open();
                    string sql = "UPDATE appeal SET comment = 'Рассмотрено' WHERE ID = " + SelectedPerson.ID.ToString() + ";";
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                    conn.Close();
                    SelectedPerson.Ответ = "Рассмотрено";
                    DoneRequests.Add(new RequestViewModel(SelectedPerson.ID, SelectedPerson.Обращение, SelectedPerson.Кабинет, SelectedPerson.Дата, SelectedPerson.Ответ));
                    Requests.Remove(SelectedPerson);
                }
                catch { }
            }
        }
        private void DeleteRow()
        {
            if (SelectedPerson != null)
            {
                MessageBoxResult dialogResult = MessageBox.Show("Удалить запись?", "Подтверждение удаления", MessageBoxButton.YesNo);

                if (dialogResult == MessageBoxResult.Yes)  // error is here
                {
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM appeal WHERE ID = " + SelectedPerson.ID.ToString() + ";";
                        MySqlCommand command = new MySqlCommand(sql, conn);
                        MySqlDataReader reader = command.ExecuteReader();
                        reader.Close();

                        conn.Close();
                        DoneRequests.Remove(SelectedPerson);
                        Requests.Remove(SelectedPerson);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "Unable to connect to any of the specified MySQL hosts.")
                        {
                            MessageBox.Show("Не удалось подключиться к серверу!");
                        }
                        else
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
                else { }
            }
        }
        private void GetRowInfo()
        {
            if (SelectedPerson != null)
                MessageBox.Show($"Проблема: {SelectedPerson.Обращение}\nКабинет: {SelectedPerson.Кабинет}\nОтвет: {SelectedPerson.Ответ}");
        }
    }

    public partial class MainWindow : Window
    {
        private MainViewModel MainViewModel { get; } = new MainViewModel();
        public MainWindow()
            {
                InitializeComponent();
                DataContext = MainViewModel;


        }
        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "ID")
            {
                e.Cancel = true;
            }

        }
    }
}
