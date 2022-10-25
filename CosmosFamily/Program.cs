using CosmosFamily.Domain.Models;
using CosmosFamily.Domain.Services;
using CosmosFamily.Services;
using Microsoft.Azure.Cosmos;

try
{
    Console.WriteLine("Beginning operations...\n");
    var secretReader = new SecretsReader();
    var cosmosDbSettings = secretReader.ReadSection<CosmosDb>("CosmosDb");
    CosmosService p = new(cosmosDbSettings);
    await p.GetStartedDemoAsync();
}
catch (CosmosException de)
{
    Exception baseException = de.GetBaseException();
    Console.WriteLine($"{de.StatusCode} error occurred: {de}");
}
catch (Exception e)
{
    Console.WriteLine($"Error: {e}");
}
finally
{
    Console.WriteLine("End of demo, press any key to exit.");
    Console.ReadKey();
}
