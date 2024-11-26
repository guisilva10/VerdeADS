using Microsoft.EntityFrameworkCore;


namespace projetopim.Services
{
    public class ClienteService
    {
        private readonly ApplicationDbContext _context;

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }

    
        public async Task<List<Cliente>> GetAllClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

   
        public async Task CreateCliente(Cliente clientes)
        {
            _context.Clientes.Add(clientes);
            await _context.SaveChangesAsync();
        }

   
        public async Task UpdateCliente(Cliente clientes)
        {
            _context.Clientes.Update(clientes);
            await _context.SaveChangesAsync();
        }

  
        public async Task DeleteCliente(int id)
        {
            var clientes = await GetClienteById(id);
            if (clientes != null)
            {
                _context.Clientes.Remove(clientes);
                await _context.SaveChangesAsync();
            }
        }
    }
}
