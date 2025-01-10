using Application.Dto;
using Infraestructure;
using Infraestructure.DataModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class CreatePersonaCommand : IRequest<PostPersonaDto>
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string PaisOrigen { get; set; }
        public string CiudadOrigen { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string EstadoCivil { get; set; }
    }

    public class CreatePersonaCommandHandler : IRequestHandler<CreatePersonaCommand, PostPersonaDto>
    {
        private readonly PersonasDBContext _context;
        public CreatePersonaCommandHandler(PersonasDBContext context)
        {
            _context = context;
        }

        public async Task<PostPersonaDto> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var persona = new Personas
                {
                    Nombres = request.Nombres,
                    Apellidos = request.Apellidos,
                    FechaNacimiento = request.FechaNacimiento,
                    Identificacion = request.Identificacion,
                    CiudadOrigen = request.CiudadOrigen,
                    PaisOrigen = request.PaisOrigen,
                    Direccion = request.Direccion,
                    EstadoCivil = request.EstadoCivil
                };

                _context.Personas.Add(persona);
                await _context.SaveChangesAsync(cancellationToken);

                return new PostPersonaDto
                {
                    Id = persona.Id,
                    Nombres = persona.Nombres,
                    Apellidos = persona.Apellidos,
                    FechaNacimiento = persona.FechaNacimiento.ToShortDateString(),
                    Identificacion = persona.Identificacion,
                    CiudadOrigen = persona.CiudadOrigen,
                    PaisOrigen = persona.PaisOrigen,
                    Direccion= persona.Direccion,
                    EstadoCivil = persona.EstadoCivil,
                    ResultMessage = "Persona creada exitosamente"
                };
            }
            catch (Exception ex)
            {
                return new PostPersonaDto { ResultMessage = ex.Message };
            }
            
        }
    }
}
