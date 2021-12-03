using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trimania.Shared.Api
{
    public class CustomResponse<TResponse>
    {
        public CustomResponse()
        {
        }

        public TResponse Data { get; private set; }
        public string Message { get; private set; }
        public string ErrorMessage { get; private set; }
        public bool Success { get { return string.IsNullOrEmpty(this.ErrorMessage); } }

        public void SetError(string message)
        {
            this.Message = null;
            this.ErrorMessage = message;
        }

        public void SetData(TResponse data, string message)
        {
            this.Data = data;
            this.Message = message;
            this.ErrorMessage = null;
        }
    }
}
