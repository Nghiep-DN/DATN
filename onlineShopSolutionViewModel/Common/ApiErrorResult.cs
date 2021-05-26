using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.ViewModel.Common
{
    public class ApiErrorResult<T>:ApiResult<T>
    {
        //1 mang message
        public string[] ValidationErrors { get; set; }
        public ApiErrorResult()
        {

        }
        public ApiErrorResult(string message)
        {
            IsSuccessed = false;
            Message = message;
        }
        public ApiErrorResult(string[] validationErrors)
        {
            IsSuccessed = false;
            ValidationErrors = validationErrors;
        }
    }
}
