using CreArtHub.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Shared.Data
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public string ErrorInfo { get; set; } = string.Empty;
    }
}

public class Response<T> : Response
{
    public T Value { get; set; }
}
