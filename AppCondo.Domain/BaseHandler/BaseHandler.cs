using FluentValidation.Results;

namespace AppCondo.Domain.BaseHandler
{
    public class BaseHandler
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<ValidationFailure>? Validations { get; set; } = null;
    }
}
