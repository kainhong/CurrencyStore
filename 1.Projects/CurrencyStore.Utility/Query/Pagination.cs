using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.Utility.Query
{
    [Serializable]
    public class Pagination
    {
        private int _currentPageIndex;
        public int CurrentPageIndex
        {
            get
            {
                int result = this._currentPageIndex;

                if (this._currentPageIndex > 1 && this._currentPageIndex > this.PageCount)
                {
                    result = this.PageCount;
                }

                return result;
            }
            set { this._currentPageIndex = value; }
        }
        public int RowCount { get; set; }
        public int PageSize { get; set; }
        public int PageCount
        {
            get
            {
                return (int)(this.RowCount / this.PageSize) + ((this.RowCount % this.PageSize) == 0 ? 0 : 1);
            }
        }
        public Pagination()
        {
            this.CurrentPageIndex = 1;
            this.RowCount = 0;
            this.PageSize = 20;
        }
    }
}
