using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.Util.WpfCommon
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool? _closeWindow;
        public bool? CloseWindow
        {
            get
            {
                return _closeWindow;
            }
            set
            {
                _closeWindow = value;
                OnPropertyChanged("CloseWindow");
            }
        }


        /// <summary>
        /// True neu data != null.
        /// False neu nguoc lai.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected bool IsNotNull(Object data)
        {
            return (data != null);
        }

        /// <summary>
        /// True neu string != NullOrEmpty.
        /// False neu nguoc lai.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected bool IsNotNullOrEmpty(string data)
        {
            return (!String.IsNullOrEmpty(data));
        }

        /// <summary>
        /// Su dung de kiem tra list co du lieu.
        /// True neu listData != null && Count > 0.
        /// False neu nguoc lai.
        /// </summary>
        /// <param name="listData"></param>
        /// <returns></returns>
        protected bool IsNotNullOrEmpty(ICollection listData)
        {
            return (listData != null && listData.Count > 0);
        }

        /// <summary>
        /// Su dung de kiem tra cac truong ID trong CSDL.
        /// True neu id > 0.
        /// False neu nguoc lai.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected bool IsGreaterThanZero(long id)
        {
            return (id > 0);
        }

    }
}
