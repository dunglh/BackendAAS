using DungLH.Util.WpfCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class MainWindowViewModel : ViewModelBase
    {
        public RelayCommand LoadDataCommand { get; set; }

        public MainWindowViewModel()
        {
            this.LoadDataCommand = new RelayCommand(this.LoadData, null);
        }

        public void LoadData(object data)
        {

        }
    }
}
