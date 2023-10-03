using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using OutroTeste.Models;

namespace OutroTeste.Controllers
{
    public class CentroAtendimentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CentroAtendimentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var centroAtendimentos = _context.CentroAtendimentos.ToList();
            return View(centroAtendimentos);
        }

        [Route("CentroAtendimento/Especialidades/{id}")]
        public IActionResult Especialidades([FromRoute] short id)


        {
            var centroAtendimento = _context.CentroAtendimentos.FirstOrDefault(c => c.idCentroAtendimento == id);
            if (centroAtendimento == null)
            {
                return NotFound();
            }

            var especialidades = _context.Especialidades
                .Where(e => e.idCentroAtendimento == id)
                .ToList();

            ViewBag.CentroAtendimentoNome = centroAtendimento.nmCentroAtendimento;

            return View(especialidades);
        }

        [Route("CentroAtendimento/Servicos/{id}")]
        public IActionResult Servicos([FromRoute] short id)
        {
            var especialidade = _context.Especialidades
                .Include(e => e.Servicos) // Inclui os serviços relacionados
                .FirstOrDefault(e => e.idEspecialidade == id);

            if (especialidade == null)
            {
                return NotFound();
            }

            ViewBag.EspecialidadeNome = especialidade.nmEspecialidade;

            return View(especialidade.Servicos.ToList());
        }
        [Route("CentroAtendimento/UnidadesAtendimento")]
        public IActionResult UnidadesAtendimento([FromQuery] short centroId, [FromQuery] short servicoId)
        {
            Console.WriteLine($"centroId: {centroId}, servicoId: {servicoId}");


            var unidadesAtendimento = _context.UnidadeAtendimentos
                //.Where(u => u.idCentroAtendimento ==(short) centroId)
                .ToList();

            ViewBag.ServicoId = servicoId; // Para usar na view
            return View(unidadesAtendimento);
        }


    }
}
