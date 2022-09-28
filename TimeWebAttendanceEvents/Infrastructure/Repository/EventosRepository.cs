using Microsoft.EntityFrameworkCore;
using TimeWebAttendanceEvents.Model;

namespace TimeWebAttendanceEvents.Infrastructure.Repository
{
    public class EventosRepository : IEventosRepository
    {
        private readonly ApplicationDbContext context;

        public EventosRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Evento>> GetEvent()
        {
            return await context.Evento.ToListAsync();
        }

        public async Task<Evento?> GetEventById(int id)
        {
            return await context.Evento.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Evento>?> GetEventByUserId(int UsuarioId, string date)
        {
            if (date == "")
            {
                return await context.Evento.Where(x => x.UsuarioId == UsuarioId &&
                    x.FechaAlta.Date >= DateTime.Now.AddDays(-10).Date && x.FechaAlta.Date <= DateTime.Now.Date).
                    OrderBy(x => x.FechaAlta).ToListAsync();
            }
            DateTime endDate = DateTime.Parse(date);
            return await context.Evento.Where(x => x.UsuarioId == UsuarioId && 
            (x.FechaAlta.Date >= endDate.AddDays(-10).Date && x.FechaAlta.Date <= endDate.Date)
            ).OrderBy(x => x.FechaAlta).ToListAsync();
        }
        public async Task<Evento> InsertEvent(Evento evento)
        {
            context.Evento.Add(evento);
            await context.SaveChangesAsync();
            return evento;
        }
    }
}
