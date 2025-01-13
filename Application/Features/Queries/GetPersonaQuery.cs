using Application.Dto;
using Infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public class GetPersonaQuery : IRequest<List<GetPersonaDto>>
    {
    }

    public class GetPersonaQueryHandler : IRequestHandler<GetPersonaQuery, List<GetPersonaDto>>
    {
        private readonly PersonasDBContext _context;

        public GetPersonaQueryHandler(PersonasDBContext context)
        {
            _context = context;
        }

        public async Task<List<GetPersonaDto>> Handle(GetPersonaQuery request, CancellationToken cancellationToken)
        {
            var personasData = await _context.Personas.AsNoTracking().ToListAsync();

            var personasResponse = personasData.Select(p => new GetPersonaDto
            {
                Id = p.Id,
                Nombres = p.Nombres,
                Apellidos = p.Apellidos,
                FechaNacimiento = p.FechaNacimiento.ToString("yyyy-MM-dd"),
                Telefono = p.Identificacion,
                CiudadOrigen = p.CiudadOrigen,
                PaisOrigen = p.PaisOrigen,
                Direccion = p.Direccion
            }).ToList();

            return personasResponse;
        }
    }
}
