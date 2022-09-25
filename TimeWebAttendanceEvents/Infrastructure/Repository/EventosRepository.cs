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

        public async Task<Evento> InsertEvent(Evento evento)
        {
            context.Evento.Add(evento);
            await context.SaveChangesAsync();
            return evento;
        }
    }
}
