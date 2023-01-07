using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HPlus_App.Win10.Models;
using System.Threading.Tasks;
using System.Linq;
namespace HPlus_App.Win10.ViewModels
{
    class TulangViewModel : BaseViewModel
    {
        public TulangViewModel()
        {
            datatulang = new ObservableCollection<Tulang>();
            modeltulang = new Tulang();

            CreateCommand = new command(async () => await CreateTulangAsync());
            UpdateCommand = new command(async () => await UpdateTulangAsync());
            DeleteCommand = new command(async () => await DeleteTulangAsync());
            ReadCommand = new command(async () => await ReadTulangAsync(true));
            ReadCommand.Execute(null);
        }

        public ICommand CreateCommand { get; set; }
        public ICommand ReadCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ObservableCollection<Tulang> DataTulang
        {
            get
            {
                return datatulang;
            }
            set
            {
                SetProperty(ref datatulang, value);
            }
        }

        public Tulang ModelTulang
        {
            get
            {
                return modeltulang;
            }
            set
            {
                SetProperty(ref modeltulang, value);
            }
        }

        public event Action OnReload;

        private ObservableCollection<Tulang> datatulang;
        private Tulang modeltulang;

        private async Task InitTulangAsync()
        {
            await Task.Run(() => {
                DataTulang = new ObservableCollection<Tulang> {
                    new Tulang { Uid = 1, Name = "Paget", Description = "Penyakit Paget merupakan penyakit tulang yang menyebabkan tulang di bagian tubuh tertentu tumbuh lebih besar dan tebal.", Obat ="--"},
                    new Tulang { Uid = 2, Name = "Osteoarthritis", Description = "Salah satu penyakit artritis yang paling umum terjadi adalah osteoarthritis atau radang sendi. Penyakit ini terjadi ketika bantalan yang ada di antara ujung tulang mengalami “keausan", Obat="-"},
                    new Tulang { Uid = 2, Name = "Rheumatoid Arthritis", Description = "penyakit radang sendi yang disebabkan oleh sistem imunitas tubuh. Sistem imun yang seharusnya berperan dalam membunuh mikroorganisme berbahaya yang masuk ke dalam tubuh, justru berbalik menyerang sel sehat yang ada di persendian.", Obat="-"},
                    new Tulang { Uid = 3, Name = "Osteoporosis", Description = ". Penyakit ini membuat tulang kehilangan kepadatannya, sehingga menyebabkan tulang jadi sangat lemah dan rapuh. " , Obat="-==="},
                };
            });
        }

        private async Task ReadTulangAsync(bool asnew = false)
        {
            if (asnew)
            {
                await InitTulangAsync();
            }
            else
            {
                OnReload?.Invoke();
            }
        }

        private async Task<Tulang> ReadTulangAsync(int uid)
        {
            await Task.Delay(0);
            return DataTulang.Where(model => model.Uid.Equals(uid)).SingleOrDefault();
        }

        private async Task CreateTulangAsync()
        {
            DataTulang.Add(ModelTulang);
            await ReadTulangAsync();
        }

        private async Task UpdateTulangAsync()
        {
            var data = ModelTulang;
            DataTulang.Remove(ReadTulangAsync(data.Uid).Result);
            DataTulang.Add(data);
            await ReadTulangAsync();
        }

        private async Task DeleteTulangAsync()
        {
            DataTulang.Remove(ModelTulang);
            await ReadTulangAsync();
        }
    }
}
