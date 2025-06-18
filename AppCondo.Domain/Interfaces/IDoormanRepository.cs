using AppCondo.Domain.Porteiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCondo.Domain.Interfaces
{
    public interface IDoormanRepository
    {
        Task<DoormanModel> GetById(int id);
        Task<DoormanModel> Create(DoormanModel porteiro);
    }
}
