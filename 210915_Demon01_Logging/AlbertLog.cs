using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210915_Demon01_Logging
{
    /// <remarks> This interface is used for recording log.</remarks>
    interface IAlbertLog
    {
        void InitData();
        void OperateDataError();
    }
}
