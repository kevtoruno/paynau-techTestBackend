using Amazon.Lambda.Core;
using Application;
using Application.Dto;
using Application.Features.Queries;
using Infraestructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace PersonaGet;

public class Function
{
    private IMediator _mediator;
    public Function()
    {
        var services = new ServiceCollection();

        services.AddInfrastructure();
        services.AddApplicationLayer();

        var serviceProvider = services.BuildServiceProvider();
        _mediator = serviceProvider.GetRequiredService<IMediator>();
    }

    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input">The event for the Lambda function handler to process.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    public async Task<List<GetPersonaDto>> FunctionHandler(GetPersonaQuery getPersonaQuery, ILambdaContext context)
    {
        try
        {           
            return await _mediator.Send(getPersonaQuery);
        }
        catch (Exception ex)
        {
            context.Logger.LogLine($"Error: {ex.Message}");
            return new List<GetPersonaDto>();
        }
    }
}