using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Data.SqlClient;


namespace HPlus_App.Win10.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public SqlConnection SqlConnect;
        public string SqlNotice;
        private readonly string dbserver;
        private readonly string dbname;
        public BaseViewModel()
        {
            SqlConnect = new SqlConnection();
            dbserver = @"LAPTOP-OD4256VB";
            dbname = "DB_HPLUS_PROJECT";
        }

        private void Notice_Handler(object sender, SqlInfoMessageEventArgs e)
        {
            SqlNotice = e.Message;
        }
        public bool OpenConnection()
        {
            //SqlConnect.ConnectionString = @"Data Source=LAPTOP-OD4256VB;Initial Catalog=DB_HPLUS_PROJECT;Integrated Security=True";
            SqlConnect.ConnectionString = $"Server={dbserver};Database={dbname};Trusted_Connection=yes";
            SqlConnect.InfoMessage += Notice_Handler;
            SqlConnect.FireInfoMessageEventOnUserErrors = true;
            SqlConnect.Open();
            return true;
        }
        public bool CloseConnection()
        {
            SqlConnect.InfoMessage -= Notice_Handler;
            SqlConnect.Close();
            return true;
        }

        public class command : ICommand
        {
            public command(Action cmdactionnone)
            {
                this.cmdactionnone = cmdactionnone;
            }
            public command(Action <object> cmdaction)
            {
                this.cmdaction = cmdaction;
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public void Execute(object parameter)
            {
                if (parameter != null)
                {
                    cmdaction(parameter);
                } else
                {
                    cmdactionnone();
                }
            }
            public event EventHandler CanExecuteChanged
            {
                add
                {
                    CommandManager.RequerySuggested += value;
                }
                remove
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
            private readonly Action cmdactionnone;
            private readonly Action<object> cmdaction;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;

            if (changed == null) return;
            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

    }
}
