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
    public class MataViewModel : BaseViewModel
    {
        public MataViewModel()
        {
            datamata = new ObservableCollection<Mata>();
            modelmata = new Mata();

            CreateCommand = new command(async () => await CreateMataAsync());
            UpdateCommand = new command(async () => await UpdateMataAsync());
            DeleteCommand = new command(async () => await DeleteMataAsync());
            ReadCommand = new command(async () => await ReadMataAsync(true));
            ReadCommand.Execute(null);
        }

        public ICommand CreateCommand { get; set; }
        public ICommand ReadCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ObservableCollection<Mata> DataMata
        {
            get
            {
                return datamata;
            }
            set
            {
                SetProperty(ref datamata, value);
            }
        }

        public Mata ModelMata
        {
            get
            {
                return modelmata;
            }
            set
            {
                SetProperty(ref modelmata, value);
            }
        }

        public event Action OnReload;

        private ObservableCollection<Mata> datamata;
        private Mata modelmata;

        private async Task InitMataAsync()
        {
            await Task.Run(() => {
                DataMata = new ObservableCollection<Mata> {
                    new Mata { Uid = 1, Name = "Konjungtivitis", Description = "Penyakit mata ini terjadi ketika jaringan lunak di sekitar mata meradang dan membuat mata merah, berair, perih, dan gatal. ", Obat="Pengobatan konjungtivitis berbeda-beda tergantung penyebabnya. Konjungtivitis bakteri diatasi dengan obat tetes mata atau salep mata antibiotik, sedangkan konjungtivitis alergi diatasi dengan obat antialergi."},
                    new Mata { Uid = 2, Name = "Katarak", Description = "Penyakit mata ini membuat lensa mata terlihat keruh sehingga pandangan menjadi kabur", Obat="Mengonsumsi makanan dengan kandungan nutrisi yang cukup dan gizi yang seimbang"},
                    new Mata { Uid = 3, Name = "Glaukomar", Description = "Glaukoma terjadi ketika saraf optik mata rusak sehingga penderitanya mengalami gangguan penglihatan, bahkan kebutaan. ", Obat="Pemberian obat tetes"},
                     };
            });
        }

        private async Task ReadMataAsync(bool asnew = false)
        {
            if (asnew)
            {
                await InitMataAsync();
            }
            else
            {
                OnReload?.Invoke();
            }
        }

        private async Task<Mata> ReadMataAsync(int uid)
        {
            await Task.Delay(0);
            return DataMata.Where(model => model.Uid.Equals(uid)).SingleOrDefault();
        }

        private async Task CreateMataAsync()
        {
            DataMata.Add(ModelMata);
            await ReadMataAsync();
        }

        private async Task UpdateMataAsync()
        {
            var data = ModelMata;
            DataMata.Remove(ReadMataAsync(data.Uid).Result);
            DataMata.Add(data);
            await ReadMataAsync();
        }

        private async Task DeleteMataAsync()
        {
            DataMata.Remove(ModelMata);
            await ReadMataAsync();
        }
    }
}
