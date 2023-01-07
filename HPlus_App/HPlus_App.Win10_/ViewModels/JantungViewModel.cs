using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HPlus_App.Win10.Models;
using System.Threading.Tasks;
using System.Linq;

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
            ReadCommand = new command(async () => await ReadJantungAsync(true));
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

        private async Task InitJantungAsync()
        {
            await Task.Run(() =>{
                DataJantung = new ObservableCollection<Jantung>
                {
                    new Jantung { Uid_j = 1, Name = "Aritmia",  Description = "gangguan pada irama jantung. Irama jantung pada penderita aritmia bisa terlalu cepat, terlalu lambat, atau tidak beraturan. Aritmia terjadi ketika rangsangan listrik yang mengatur detak jantung terganggu, sehingga jantung tidak bekerja dengan baik.", Obat="Obat-obatan yang diresepkan dokter untuk mengatasi aritmia adalah obat antiaritmia. Dokter juga akan meresepkan warfarin untuk menurunkan risiko terjadinya penggumpalan darah." },
                    new Jantung { Uid_j = 2, Name = "Kardiomiopati",  Description = "gangguan pada otot jantung. Kondisi ini menyebabkan kelainan pada bentuk dan kekuatan otot jantung (misalnya otot jantung menjadi lebih besar dan kaku), sehingga tidak dapat memompa darah ke seluruh tubuh dengan baik.", Obat="Penderita kardiomiopati ringan yang belum mengalami gejala apapun dianjurkan untuk menerapkan pola hidup sehat"},
                    new Jantung { Uid_j = 3, Name = "Gagal Jantung", Description = "kondisi saat pompa jantung melemah, sehingga tidak mampu mengalirkan darah yang cukup ke seluruh tubuh. Kondisi ini juga dikenal dengan istilah gagal jantung kongestif. ", Obat="Penderita disarankan untuk membatasi aktivitas, menjalani pola hidup sehat, serta akan diberikan obat-obatan sesuai kondisi yang diderita atau berdasarkan penyebab gagal jantung yang dialami."},
                   
                };
            });
        }

        private async Task ReadJantungAsync(bool asnew = false)
        {
            if (asnew)
            {
                await InitJantungAsync();
            }
            else
            {
                OnReload?.Invoke();
            }
        }
        private async Task<Jantung> ReadJantungAsync(int uid)
        {
            await Task.Delay(0);
            return DataJantung.Where(model => model.Uid_j.Equals(uid)).SingleOrDefault();
        }
        private async Task CreateJantungAsync()
        {
            DataJantung.Add(ModelJantung);
            Console.WriteLine(DataJantung);
            await ReadJantungAsync();
        }
        private async Task UpdateJantungAsync()
        {
            var data = ModelJantung;
            DataJantung.Remove(ReadJantungAsync(data.Uid_j).Result);
            DataJantung.Add(ModelJantung);
            await ReadJantungAsync();
        }
        private async Task DeleteJantungAsync()
        {
            DataJantung.Remove(ModelJantung);
            await ReadJantungAsync();
        }

    }
}
