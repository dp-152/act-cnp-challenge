using CnpChallenge.Domain.Model.ClienteModel;
using CnpChallenge.Infrastructure.Context;

namespace CnpChallenge.IntegrationTests.Helpers;

public static class DbSeedingHelper
{
    public static async Task SeedClientes(MainContext context, string dataset)
    {
        var data = await GetClientesDataset(dataset);
        SeedIds(data);
        context.Clientes.AddRange(data);
        await context.SaveChangesAsync();
    }

    public static async Task ResetClientes(MainContext context, string dataset)
    {
        context.ClienteEnderecos.RemoveRange(context.ClienteEnderecos);
        context.Clientes.RemoveRange(context.Clientes);
        await context.SaveChangesAsync();
        await SeedClientes(context, dataset);
    }

    public static async Task<List<Cliente>> GetClientesDataset(string dataset)
    {
        return await AssetsHelper.LoadJsonAsset<List<Cliente>>(dataset);
    }

    public static void SeedIds(List<Cliente> data)
    {
        var clienteId = 0;
        var clienteEnderecoId = 0;

        foreach (var cliente in data)
        {
            cliente.Id = ++clienteId;
            foreach (var endereco in cliente.Enderecos)
            {
                endereco.Id = ++clienteEnderecoId;
            }
        }
    }
}