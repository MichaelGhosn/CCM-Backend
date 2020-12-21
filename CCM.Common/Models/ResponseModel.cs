using System;

namespace CCM.Application.Models
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        
        public String Description { get; set; }
    }
}