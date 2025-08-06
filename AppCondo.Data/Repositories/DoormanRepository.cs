using AppCondo.Data.Context;
using AppCondo.Domain.Doorman;
using AppCondo.Domain.Interfaces;

namespace AppCondo.Data.Repositories
{
    public class DoormanRepository : IDoormanRepository
    {
        private readonly ApplicationDbContext _context;

        public DoormanRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Doorman> GetById(int id)
        {
            return _context.Doorman.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<Doorman> Create(Doorman porteiro)
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

        public async Task<bool> ActiveDoormanRegister(int id, string registrationId)
        {
            try
            {
                var doorman = await GetDoormanByIdAndRegistrationId(id, registrationId);

                if (doorman is not Doorman)
                    return false;

                var entity = _context.Doorman.Where(x => x.Id == id).FirstOrDefault();

                entity.Status = true;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<Doorman> GetDoormanByIdAndRegistrationId(int id, string registrationId)
        {
            try
            {
                return _context.Doorman.Where(x => x.Id == id && x.RegistrationId == registrationId).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
