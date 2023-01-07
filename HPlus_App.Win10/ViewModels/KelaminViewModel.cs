using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HPlus_App.Win10.Models;
using System.Threading.Tasks;
using System.Linq;

namespace HPlus_App.Win10.ViewModels
{
    public class KelaminViewModel : BaseViewModel
    {
        public KelaminViewModel()
        {
            datakelamin = new ObservableCollection<Kelamin>();
            modelkelamin = new Kelamin();

            CreateCommand = new command(async () => await CreateKelaminAsync());
            UpdateCommand = new command(async () => await UpdateKelaminAsync());
            DeleteCommand = new command(async () => await DeleteKelaminAsync());
            ReadCommand = new command(async () => await ReadKelaminAsync(true));
            ReadCommand.Execute(null);
        }
        public ICommand CreateCommand { get; set; }
        public ICommand ReadCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ObservableCollection<Kelamin> DataKelamin
        {
            get
            {
                return datakelamin;
            }
            set
            {
                SetProperty(ref datakelamin, value);
            }
        }
        public Kelamin ModelKelamin
        {
            get
            {
                return modelkelamin;
            }
            set
            {
                SetProperty(ref modelkelamin, value);
            }
        }
        public event Action OnReload;

        private ObservableCollection<Kelamin> datakelamin;
        private Kelamin modelkelamin;

        private async Task InitKelaminAsync()
        {
            await Task.Run(() => {
                DataKelamin = new ObservableCollection<Kelamin>
                {
                    new Kelamin { Uid_k = 1, Name = "Klamidia",  Description = "penyakit menular seksual yang disebabkan oleh infeksi bakteri. Chlamydia yang tidak segera diobati dapat meningkatkan risiko kemandulan, terutama pada wanita.", Obat="Chlamydia dapat diobati dengan antibiotik, seperti azithromycin atau doxycycline" },
                    new Kelamin { Uid_k = 2, Name = "Hepatitis",  Description = "peradangan pada hati atau liver. Hepatitis bisa disebabkan oleh infeksi virus, bisa juga disebabkan oleh kondisi atau penyakit lain, seperti kebiasaan mengonsumsi alkohol, penggunaan obat-obatan tertentu, atau penyakit autoimun. ", Obat="Hepatitis akibat infeksi virus bisa sembuh dengan sendirinya jika pasien memiliki sistem kekebalan tubuh yang baik"},
                    new Kelamin { Uid_k = 3, Name = "HIV (human immunodeficiency virus) ", Description = "virus yang merusak sistem kekebalan tubuh dengan menginfeksi dan menghancurkan sel CD4", Obat="Belum ada obatnya"},
                    new Kelamin { Uid_k = 4, Name = "Human papillomavirus (HPV) ", Description = "salah satu virus yang umum tertular lewat hubungan seksual tanpa kondom. Sama seperti yang lain, terkadang virus ini tidak menunjukkan tanda-tanda kemunculannya, tapi tetap ada beberapa tanda yang bisa Anda waspadai.", Obat="Melakukan pemeriksaan rutin "},
                };
            });
        }

        private async Task ReadKelaminAsync(bool asnew = false)
        {
            if (asnew)
            {
                await InitKelaminAsync();
            }
            else
            {
                OnReload?.Invoke();
            }
        }
        private async Task<Kelamin> ReadKelaminAsync(int uid)
        {
            await Task.Delay(0);
            return DataKelamin.Where(model => model.Uid_k.Equals(uid)).SingleOrDefault();
        }
        private async Task CreateKelaminAsync()
        {
            DataKelamin.Add(ModelKelamin);
            await ReadKelaminAsync();
        }
        private async Task UpdateKelaminAsync()
        {
            var data = ModelKelamin;
            DataKelamin.Remove(ReadKelaminAsync(data.Uid_k).Result);
            DataKelamin.Add(ModelKelamin);
            await ReadKelaminAsync();
        }
        private async Task DeleteKelaminAsync()
        {
            DataKelamin.Remove(ModelKelamin);
            await ReadKelaminAsync();
        }
    }
}
