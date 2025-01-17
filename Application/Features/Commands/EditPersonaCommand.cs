﻿using Application.Dto;
using Infraestructure;
using MediatR;

namespace Application.Features.Commands
{
    public class EditPersonaCommand : IRequest<PostPersonaDto>
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string PaisOrigen { get; set; }
        public string CiudadOrigen { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string EstadoCivil { get; set; }
    }

    public class EditPersonaCommandHandler : IRequestHandler<EditPersonaCommand, PostPersonaDto>
    {
        private readonly PersonasDBContext _context;
        public EditPersonaCommandHandler(PersonasDBContext context)
        {
            _context = context;
        }

        public async Task<PostPersonaDto> Handle(EditPersonaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var persona = await _context.Personas.FindAsync(request.Id);
                var personaResponse = new PostPersonaDto();

                if (persona == null)
                {
                    personaResponse.ResultMessage = "No se encontró persona.";
                    return personaResponse;
                }

                persona.Nombres = request.Nombres;
                persona.Apellidos = request.Apellidos;
                persona.FechaNacimiento = request.FechaNacimiento;
                persona.Identificacion = request.Telefono;
                persona.CiudadOrigen = request.CiudadOrigen;
                persona.PaisOrigen = request.PaisOrigen;
                persona.Direccion = request.Direccion;
            
                _context.Update(persona);
                await _context.SaveChangesAsync(cancellationToken);
        
                // Retornar los datos actualizados
                return new PostPersonaDto
                {
                    Id = persona.Id,
                    Nombres = persona.Nombres,
                    Apellidos = persona.Apellidos,
                    FechaNacimiento = persona.FechaNacimiento.ToString("yyyy-MM-dd"),
                    Telefono = persona.Identificacion,
                    CiudadOrigen = persona.CiudadOrigen,
                    PaisOrigen = persona.PaisOrigen,
                    Direccion = persona.Direccion,
                    ResultMessage = "Datos actualizados correctamente",
                    ErrorCode = 200
                };
            }
            catch (Exception ex)
            {
                return new PostPersonaDto { 
                    ErrorCode = 500, 
                    ResultMessage = $"Error no manejado: {ex.Message}" };
            }
            
        }
    }
}
