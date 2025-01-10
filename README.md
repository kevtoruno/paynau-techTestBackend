# Kevin Toruño Serpa prueba tecnica para Paynau

La arquitectura del backend cuenta de 4 funciones lambdas, y 2 librerias de clases:

Infraestructure: Aqui está la libreria de EF Core
Application: Aquí se encuentra la logica de negocio, basada en CQRS y Mediador
PersonaCreate: Función lambda para crear registros persona.
PersonaEdit: Función lambda para editar registros existentes de persona.
PersonaDelete: Funcion lambda para eliminar registros de persona.
PersonaEdit: Funcion lambda para editar registros de persona.
