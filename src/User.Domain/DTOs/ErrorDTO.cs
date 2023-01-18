using System;

namespace User.Domain.DTOs
{
    public class ErrorDTO : BaseDTO
    {
        public DateTime Date { get; set; }
        public string Message { get; set; }

        public ErrorDTO()
        {

        }

        public ErrorDTO(string message)
        {
            Message = message;
            Date = DateTime.Now;
        }
    }
}
