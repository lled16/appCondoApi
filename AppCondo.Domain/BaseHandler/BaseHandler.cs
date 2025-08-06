using AppCondo.Domain.Porteiro;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCondo.Domain.BaseHandler
{
    public class BaseHandler
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<ValidationFailure>? Validations { get; set; } = null;
    }
}
