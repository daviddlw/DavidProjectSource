using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DavidMeeting
{
    public class DavidAlgorithm
    {
        #region 公共属性

        public AlgorithmSort AlgorithmSortBase { get; set; }

        #endregion

        #region 构造方法

        public DavidAlgorithm() 
        {
            this.AlgorithmSortBase = new AlgorithmSort();
        }

        #endregion
    }
}
