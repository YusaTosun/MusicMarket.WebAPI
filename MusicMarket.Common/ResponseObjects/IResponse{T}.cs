using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Common.ResponseObjects
{
    public interface IResponse<T>
    {
        List<CustomValidationError> ValidationErrors { get; set; }
        T Data { get; set; }
    }
}
