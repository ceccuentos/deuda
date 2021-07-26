using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;


namespace Aplicacion.Deuda
{

    public class ConsultaDeuda
    {
        public class ListaDeudaAutoventa : IRequest<List<Dominio.Deuda>> { }
        public class ManejadorAutoventa : IRequestHandler<ListaDeudaAutoventa, List<Dominio.Deuda>>
        {
            private readonly DeudaContext _context;
            public ManejadorAutoventa(DeudaContext context)
            {
                _context = context;
            }
            public async Task<List<Dominio.Deuda>> Handle(ListaDeudaAutoventa request, CancellationToken cancellationToken)
            {
                var deuda = await _context.DeudaAutoventa.ToListAsync();
                return deuda;
            }
        }



    }
}
