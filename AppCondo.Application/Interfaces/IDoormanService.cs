using AppCondo.Application.DTO;
using AppCondo.Domain.BaseHandler;
using AppCondo.Domain.Porteiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCondo.Application.Interfaces
{
    public interface IDoormanService
    {
        Task<DoormanModel> GetById(int id);
        Task<DoormanModel> RegisterDoorman(DoormanDTO porteiroDTO);
    }
}
