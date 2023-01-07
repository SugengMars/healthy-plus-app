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
    public class LambungViewModel : BaseViewModel
    {
        public LambungViewModel()
        {
            datalambung = new ObservableCollection<Lambung>();
            modellambung = new Lambung();

            CreateCommand = new command(async () => await CreateLambungAsync());
            UpdateCommand = new command(async () => await UpdateLambungAsync());
            DeleteCommand = new command(async () => await DeleteLambungAsync());
            ReadCommand = new command(async () => await ReadLambungAsync(true));
            ReadCommand.Execute(null);
        }

        public ICommand CreateCommand { get; set; }
        public ICommand ReadCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ObservableCollection<Lambung> DataLambung
        {
            get
            {
                return datalambung;
            }
            set
            {
                SetProperty(ref datalambung, value);
            }
        }

        public Lambung ModelLambung
        {
            get
            {
                return modellambung;
            }
            set
            {
                SetProperty(ref modellambung, value);
            }
        }

        public event Action OnReload;

        private ObservableCollection<Lambung> datalambung;
        private Lambung modellambung;

        //private async Task InitLambungAsync()
        //{
        //    await Task.Run(() => {
        //        DataLambung = new ObservableCollection<Lambung> {
        //            new Lambung { Uid = 2, Name = "Gastritis", Description = "merupakan peradangan pada lambung akibat asam lambung yang merusak lapisan pelindung dinding lambung. ", Obat = "Promag"},
        //            new Lambung { Uid = 2, Name = "Tukak Lambung", Description = "luka yang terdapat pada dinding lambung akibat terkikisnya lapisan lambung ", Obat = "Promag"},
        //            new Lambung { Uid = 2, Name = "Dispepsia", Description = "kumpulan gejala yang muncul akibat adanya penyakit di bagian perut atas. ", Obat = "Promag"},
        //        };
        //    });
        //}

        private async Task ReadLambungAsync(bool asnew = false)
        {
            //if (asnew)
            //{
            //    await InitLambungAsync();
            //}
            //else
            //{
            //    OnReload?.Invoke();
            //}
        }

        private async Task<Lambung> ReadLambungAsync(int uid)
        {
            await Task.Delay(0);
            return DataLambung.Where(model => model.Uid.Equals(uid)).SingleOrDefault();
        }

        private async Task CreateLambungAsync()
        {
            DataLambung.Add(ModelLambung);
            await ReadLambungAsync();
        }

        private async Task UpdateLambungAsync()
        {
            var data = ModelLambung;
            DataLambung.Remove(ReadLambungAsync(data.Uid).Result);
            DataLambung.Add(data);
            await ReadLambungAsync();
        }

        private async Task DeleteLambungAsync()
        {
            DataLambung.Remove(ModelLambung);
            await ReadLambungAsync();
        }
    }
}
