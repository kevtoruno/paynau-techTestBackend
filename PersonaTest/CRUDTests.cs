using Amazon.Lambda.TestUtilities;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;

namespace PersonaTest
{
    public class CRUDTests
    {
        private readonly ITestOutputHelper _Testoutput;

        public CRUDTests(ITestOutputHelper output)
        {
            _Testoutput = output;
        }

        [Fact]
        public async Task ShouldCompleteCRUDFlow()
        {
            _Testoutput.WriteLine($"-----Inicializando flujo CRUD-----");

            await CreateLambda_ShouldStorePersonIdForOtherTests();
            await GetLambda_ShouldContainNewRecordCreated();
            await UpdateLambda_ShouldUpdateNombresAndTelefono();
            await DeleteLambda_ShouldDeletePerson();
        }

        private async Task CreateLambda_ShouldStorePersonIdForOtherTests()
        {
            _Testoutput.WriteLine($"Creando registro persona");

            //Arrange
            var context = new TestLambdaContext();
            var createFunction = new PersonaCreate.Function();
            var request = new Application.Features.Commands.CreatePersonaCommand
            {
                Nombres = PersonaDataTest.Nombres,
                Apellidos = PersonaDataTest.Apellidos,
                Telefono = PersonaDataTest.Telefono,
                CiudadOrigen = PersonaDataTest.CiudadOrigen,
                PaisOrigen = PersonaDataTest.PaisOrigen,
                Direccion = PersonaDataTest.Direccion,
                FechaNacimiento = PersonaDataTest.FechaNacimiento
            };

            //Act
            var response = await createFunction.FunctionHandler(request, context);

            //Assert
            Assert.True(response.Id > 0);
            Assert.NotNull(response);
            Assert.Equal(0, response.ErrorCode);

            // Store the ID for other tests
            PersonaDataTest.Id = response.Id;
            _Testoutput.WriteLine($"-Registro persona exitoso, ID: {response.Id}");
        }

        private async Task GetLambda_ShouldContainNewRecordCreated()
        {
            _Testoutput.WriteLine($"Obteniendo listado de personas");
            //Arrange
            var context = new TestLambdaContext();
            var function = new PersonaGet.Function();
            var request = new Application.Features.Queries.GetPersonaQuery();

            //Act
            var response = await function.FunctionHandler(request, context);

            //Assert
            Assert.NotEmpty(response);
            Assert.Contains(response, r => r.Id == PersonaDataTest.Id);
            _Testoutput.WriteLine($"-Se han devuelto: {response.Count} registros, incluyendo el nuevo registro");
        }

        private async Task UpdateLambda_ShouldUpdateNombresAndTelefono()
        {
            _Testoutput.WriteLine($"Actuializando Nombres y Telefono de la Persona");
            //Arrange
            var context = new TestLambdaContext();
            var function = new PersonaEdit.Function();
            var request = new Application.Features.Commands.EditPersonaCommand()
            {
                Id = PersonaDataTest.Id,
                Nombres = "Joaquin",
                Apellidos = PersonaDataTest.Apellidos,
                Telefono = "87875523",
                CiudadOrigen = PersonaDataTest.CiudadOrigen,
                PaisOrigen = PersonaDataTest.PaisOrigen,
                Direccion = PersonaDataTest.Direccion,
                FechaNacimiento = PersonaDataTest.FechaNacimiento
            };

            //Act
            var response = await function.FunctionHandler(request, context);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(200, response.ErrorCode);
            Assert.True(response.Id == PersonaDataTest.Id);
            Assert.True(response.Nombres == "Joaquin");
            Assert.True(response.Telefono == "87875523");

            _Testoutput.WriteLine($"-Se actualizaron Nombres y Telefono de la persona con Id: {response.Id}");
        }

        private async Task DeleteLambda_ShouldDeletePerson()
        {
            _Testoutput.WriteLine($"Eliminando registro Persona");

            //Arrange
            var context = new TestLambdaContext();
            var function = new PersonaDelete.Function();
            var request = new Application.Features.Commands.DeletePersonaCommand()
            {
                Id = PersonaDataTest.Id,
            };

            //Act
            var response = await function.FunctionHandler(request, context);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(200, response.ErrorCode);
            _Testoutput.WriteLine($"-Se eliminó la persona con Id: {response.Id}");
        }
    }
}