using Application.Dto;
using Infraestructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class DeletePersonaCommand : IRequest<DeletePersonaDto>
    {
        public int Id { get; set; }
    }

    public class DeletePersonaQueryHandler : IRequestHandler<DeletePersonaCommand, DeletePersonaDto>
    {
        private readonly PersonasDBContext _context;

        public DeletePersonaQueryHandler(PersonasDBContext context)
        {
            _context = context;
        }

        public async Task<DeletePersonaDto> Handle(DeletePersonaCommand request, CancellationToken cancellationToken)
        {
            var persona = await _context.Personas.FindAsync(request.Id);

            if (persona == null)
            {
                return new DeletePersonaDto
                {
                    ResultMessage = "No se encontró persona."
                };
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeletePersonaDto
            {
                ResultMessage = "Persona eliminada correctamente."
            };
        }
    }
}
