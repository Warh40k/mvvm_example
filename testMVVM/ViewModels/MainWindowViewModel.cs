using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using testMVVM.Infrastructure.Commands;
using testMVVM.Models;
using testMVVM.ViewModels.Base;

namespace testMVVM.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        //График: если надо изменять точки, то возвращаем ObservableCollection, иначе перечисление

        #region ТестГрафика

        /// <summary> Тестовый набор данных для визуализации графиков </summary>

        private IEnumerable<DataPoint> _TestDataPoints;

        /// <summary> Тестовый набор данных для визуализации графиков </summary>

        public IEnumerable<DataPoint> TestDataPoints 
        {
            get => _TestDataPoints;
            set => Set(ref _TestDataPoints, value); 
        }

        #endregion

        #region Заголовок окна 

        private string _Title = "Поиск аномалий";

        /// <summary>  Заголовок окна </summary>
        public string Title
        {
            get => _Title;
            //set
            //{
            //    // 1) Можно так
            //    //if (Equals(_Title, value)) return;
            //    //_Title = value;
            //    //OnPropertyChanged();

            //    //2) Можно и так
            //    //Set(ref _Title, value);
            //}
            //3) Но самое жесткое
            set => Set(ref _Title, value);
        }

        #endregion

        #region Status: string - Статус программы

        ///<summary>Статус программы</summary>
        private string _Status = "Готово";

        public string Status { get => _Status; set => Set(ref _Status, value); }

        #endregion

        #region Команды

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new RelatedCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion

            var data_points = new List<DataPoint>((int)(360 / 0.1));

            for(var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);

                data_points.Add(new DataPoint { XValue = x, YValue = y });
            }

            TestDataPoints = data_points;
        }
    }
}
