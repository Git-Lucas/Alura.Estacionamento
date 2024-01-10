using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Tests;

public class PatioTeste
{
    private readonly Veiculo _veiculo;
    private readonly Patio _estacionamento;

    public PatioTeste()
    {
        _veiculo = new Veiculo();
        _estacionamento = new Patio();
    }

    [Fact]
    public void FaturamentoSucesso()
    {
        _veiculo.Placa = "HHH-9999";
        _estacionamento.RegistrarEntradaVeiculo(_veiculo);

        _estacionamento.RegistrarSaidaVeiculo(_veiculo.Placa);

        Assert.Equal(2, _estacionamento.TotalFaturado());
    }

    [Fact]
    public void PesquisaVeiculoSucesso()
    {
        _veiculo.Placa = "HAD-9822";
        _estacionamento.RegistrarEntradaVeiculo(_veiculo);

        Veiculo veiculoRetornadoPorPlaca = _estacionamento.PesquisaVeiculoPorPlaca(_veiculo.Placa);

        Assert.Equal(_veiculo.Placa, veiculoRetornadoPorPlaca.Placa);
    }

    [Fact]
    public void AlteraVeiculoEstacionamentoPorPlacaSucesso()
    {
        _veiculo.Placa = "HNM-7368";
        _veiculo.Proprietario = "Lucas";
        _estacionamento.RegistrarEntradaVeiculo(_veiculo);
        Veiculo requisicaoAlterarVeiculo = new()
        {
            Placa = "HNM-7368",
            Proprietario = "Edson"
        };

        Veiculo veiculoAlterado = _estacionamento.AlteraDadosVeiculoPorPlaca(requisicaoAlterarVeiculo);

        Assert.Equal(requisicaoAlterarVeiculo.Proprietario, veiculoAlterado.Proprietario);
    }
}
