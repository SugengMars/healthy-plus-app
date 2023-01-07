using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HPlus_App.Win10.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;
using System.ComponentModel;
//using HPlus_App.Setup;
//using HPlus_App.Models;
using System.Windows;

namespace HPlus_App.Win10.ViewModels
{
    public class JantungViewModel : BaseViewModel
    {
        
        public JantungViewModel()
        {
            datajantung = new ObservableCollection<Jantung>();
            modeljantung = new Jantung();

            CreateCommand = new command(async () => await CreateJantungAsync());
            UpdateCommand = new command(async () => await UpdateJantungAsync());
            DeleteCommand = new command(async () => await DeleteJantungAsync());
            ReadCommand = new command(async () => await ReadJantungAsync());
            ReadCommand.Execute(null);
        }
        public ICommand CreateCommand { get; set; }
        public ICommand ReadCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ObservableCollection<Jantung> DataJantung
        {
            get
            {
                return datajantung;
            }
            set
            {
                SetProperty(ref datajantung, value);
            }
        }
        public Jantung ModelJantung
        {
            get
            {
                return modeljantung;
            }
            set
            {
                SetProperty(ref modeljantung, value);
            }
        }
        public event Action OnReload;

        private ObservableCollection<Jantung> datajantung;
        private Jantung modeljantung;

        
        private async Task ReadJantungAsync()
        {
            await Task.Delay(0);

            OpenConnection();
            await Task.Delay(0);
            var query = "SELECT * FROM jantung";
            var sqlcmd = new SqlCommand(query, SqlConnect);
            var sqlresult = sqlcmd.ExecuteReader();

            if (sqlresult.HasRows)
            {
                datajantung.Clear();
                while (sqlresult.Read())
                {
                    datajantung.Add(new Jantung
                    {
                        Uid_j = sqlresult[0].ToString(),
                        Name = sqlresult[1].ToString(),
                        Description = sqlresult[2].ToString(),
                        Obat = sqlresult[3].ToString()
                    });
                }
            }
            CloseConnection();
            OnReload?.Invoke();
        }
        private async Task<Jantung> ReadJantungAsync(string uid)
        {
            await Task.Delay(0);
            return DataJantung.Where(model => model.Uid_j.Equals(uid)).SingleOrDefault();
        }
        private async Task CreateJantungAsync()
        {
            //DataJantung.Add(ModelJantung);
            //Console.WriteLine(DataJantung);
            if (IsValidating())
            {
                try
                {
                    OpenConnection();
                    var query = $"INSERT INTO jantung VALUES (" +
                                $"'{modeljantung.Uid_j}', " +
                                $"'{modeljantung.Name}', " +
                                $"'{modeljantung.Description}'," +
                                $"'{modeljantung.Obat}')";
                    var sqlcmd = new SqlCommand(query, SqlConnect);
                    sqlcmd.ExecuteNonQuery();
                    CloseConnection();
                    await ReadJantungAsync();
                    MessageBox.Show("Sucessfully registerd", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            await ReadJantungAsync();
        }
        private async Task UpdateJantungAsync()
        {
            // var data = ModelJantung;
            // DataJantung.Remove(ReadJantungAsync(data.Uid_j).Result);
            //DataJantung.Add(ModelJantung);
            try
            {
                OpenConnection();
                var query = $"UPDATE JANTUNG set name=" +
                            $"'{modeljantung.Name}' , " +
                            $"Description = '{modeljantung.Description}', " +
                            $"Obat = '{modeljantung.Obat}' " +
                            "WHERE uid_j=" +
                            $"'{modeljantung.Uid_j}'";
                var sqlcmd = new SqlCommand(query, SqlConnect);
                sqlcmd.ExecuteNonQuery();
                CloseConnection();
                await ReadJantungAsync();
                MessageBox.Show("Sucessfully Update", "Data Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            await ReadJantungAsync();
        }
        private async Task DeleteJantungAsync()
        {
            //DataJantung.Remove(ModelJantung);
            try
            {
                OpenConnection();
                var query = $"DELETE FROM Jantung WHERE uid_j=" +
                            $"'{modeljantung.Uid_j}'";
                var sqlcmd = new SqlCommand(query, SqlConnect);
                sqlcmd.ExecuteNonQuery();
                CloseConnection();
                await ReadJantungAsync();
                MessageBox.Show("Sucessfully Deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            await ReadJantungAsync();
        }
        private bool IsValidating()
        {
            var flag = true;
            if (modeljantung.Uid_j == null)
            {
                MessageBox.Show("uid can't null !", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                flag = false;
            }
            else if (modeljantung.Name == null)
            {
                MessageBox.Show("Name can't null !", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                flag = false;
            }
            else if (modeljantung.Description == null)
            {
                    MessageBox.Show("Description cannot empty!!!", "Warning",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                flag = false;
            }
            else if (modeljantung.Obat == null)
            {
                MessageBox.Show("Obatcannot empty!!!", "Warning",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                flag = false;
            }
            return flag;
        }
        private async Task InsertDataAsync()
        {
            
        }

        private async Task DeleteDataAsync()
        {
            
        }
        private async Task UpdateAsync()
        {
           

        }

    }
}
