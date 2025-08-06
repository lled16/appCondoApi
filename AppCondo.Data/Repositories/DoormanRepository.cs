using AppCondo.Data.Context;
using AppCondo.Domain.BaseHandler;
using AppCondo.Domain.Interfaces;
using AppCondo.Domain.Porteiro;

namespace AppCondo.Data.Repositories
{
    public class DoormanRepository : IDoormanRepository
    {
        private readonly ApplicationDbContext _context;

        public DoormanRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<DoormanModel> GetById(int id)
        {
            return _context.Doorman.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<DoormanModel> Create(DoormanModel porteiro)
        {
            try
            {
                _context.Doorman.Add(porteiro);

                _context.SaveChanges();

                return _context.Doorman.Where(x => x.Id == porteiro.Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
