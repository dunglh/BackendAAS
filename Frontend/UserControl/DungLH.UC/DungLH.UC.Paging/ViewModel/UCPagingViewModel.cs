using DungLH.Util.CommonLogging;
using DungLH.Util.Core;
using DungLH.Util.WpfCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungLH.UC.Paging.ViewModel
{
    class UCPagingViewModel : ViewModelBase
    {
        private int _start;
        private int _count;
        private int _pageSize;
        private int _currentPage;
        private int _totalCount;
        private int _pageCount;
        private int _preCount;
        private List<int> _listPageSize;

        public UCPagingViewModel()
        {

            this._pageSize = 100;
            this._preCount = 0;
            this._start = 0;
            this._currentPage = 1;
            this._pageCount = 1;
            this._listPageSize = new List<int>() { 10, 20, 50, 100, 200, 500, 1000, 2000, 5000 };
        }

        public string CurrentPageDisplay
        {
            get
            {
                return this._currentPage + "/" + this._pageCount;
            }
        }

        public int CurrentPage
        {
            get { return this._currentPage; }
            set { this._currentPage = value; }
        }

        public int TotalCount
        {
            get { return this._totalCount; }
            set { this._totalCount = value; }
        }

        public int Count
        {
            get { return this._count; }
            set { this._count = value; }
        }

        public int Start
        {
            get { return this._start; }
            set { this._start = value; }
        }

        public int PreCount
        {
            get { return this._preCount; }
            set { this._preCount = value; }
        }

        public int PageCount
        {
            get { return this._pageCount; }
            set { this._pageCount = value; }
        }

        public int DiffPage
        {
            get { return (this.PageCount - this.CurrentPage); }
        }

        public int PageSize
        {
            get { return this._pageSize; }
            set { this._pageSize = value; }
        }

        public string DisplayInfo
        {
            get
            {
                if (this._currentPage == this._pageCount)
                {
                    return (this._preCount + 1) + " - " + this._totalCount + "/" + this._totalCount;
                }
                else
                {
                    return (this._preCount + 1) + " - " + (this._currentPage * this._pageSize) + "/" + this._totalCount;
                }
            }
        }

        public List<int> ListPageSize
        {
            get { return this._listPageSize; }
        }

        public void FirstPage()
        {
            try
            {
                this.CurrentPage = 1;
                this.PreCount = 0;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        public void PreviousPage()
        {
            try
            {
                if (this.CurrentPage <= 1)
                {
                    this.CurrentPage = 1;
                    this.PreCount = 0;
                    return;
                }
                else
                {
                    this.CurrentPage = this.CurrentPage - 1;
                    this.PreCount = (this.CurrentPage - 1) * this.PageSize;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        public void NextPage()
        {
            try
            {
                if (this.CurrentPage >= this.PageCount)
                {
                    this.CurrentPage = this.PageCount;
                    this.PreCount = this.TotalCount;
                    return;
                }
                else
                {
                    this.CurrentPage = this.CurrentPage + 1;
                    this.PreCount = (this.CurrentPage - 1) * this.PageSize;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        public void LastPage()
        {
            try
            {
                this.CurrentPage = this.PageCount;
                this.PreCount = this.TotalCount;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        public void RefreshPage()
        {
            try
            {
                this.CurrentPage = 1;
                this.PreCount = 0;
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
            }
        }

        public CommonParam GetParam()
        {
            CommonParam commonParam = new CommonParam();
            commonParam.Count = this.TotalCount;
            commonParam.Start = this.PreCount;
            commonParam.Limit = this.PageSize;
            return commonParam;
        }

        public void RefreshAll()
        {
            var currentDis = this.CurrentPageDisplay;
            var current = this.CurrentPage;
            var total = this.TotalCount;
            var co = this.Count;
            var st = this.Start;
            var pre = this.PreCount;
            var pCount = this.PageCount;
            var diff = this.DiffPage;
            var pSize = this.PageSize;
            var dis = this.DisplayInfo;
        }
    }
}
