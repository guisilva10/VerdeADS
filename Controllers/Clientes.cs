using Microsoft.AspNetCore.Mvc;

using projetopim.Services;


namespace projetopim.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClienteService _clienteService;

        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        
        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteService.GetAllClientes();
            return View(clientes); 
        }

     
        public IActionResult Criar()
        {
            return View(new Cliente());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Cliente clientes)
        {
            
            if (ModelState.IsValid)
            {
                await _clienteService.CreateCliente(clientes); 
                return RedirectToAction(nameof(Index));  
            }
            return View(clientes);  
        }

        public async Task<IActionResult> Editar(int id)
        {
            var cliente = await _clienteService.GetClienteById(id);
            if (cliente == null)
            {
                return NotFound(); 
            }
            return View(cliente); 
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Cliente clientes)
        {
            if (ModelState.IsValid)
            {
                await _clienteService.UpdateCliente(clientes); 
                return RedirectToAction(nameof(Index));
            }
            return View(clientes); 
        }
  
        public async Task<IActionResult> ApagarConfirmacao(int id)
        {
            var clientes = await _clienteService.GetClienteById(id);
            if (clientes == null)
            {
                return NotFound(); 
            }
            return View(clientes); 
        }


        [HttpPost, ActionName("ApagarConfirmacao")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apagar(int id)
        {
            await _clienteService.DeleteCliente(id); 
            return RedirectToAction(nameof(Index)); 
        }
    }
}
