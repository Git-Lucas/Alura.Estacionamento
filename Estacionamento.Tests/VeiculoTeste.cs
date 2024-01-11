using System;
using Xunit;

namespace Estacionamento.Tests;

public class VeiculoTeste
{
    private readonly Veiculo _veiculo;

    public VeiculoTeste()
    {
        _veiculo = new()
        {
            Tipo = TipoVeiculo.Automovel
        };
    }

    [Fact]
    [Trait("Funcionalidade", "Acelerar")]
    public void AceleraVeiculoComTempo10Sucesso()
    {
        _veiculo.Acelerar(10);

        Assert.Equal(100, _veiculo.VelocidadeAtual);
    }

    [Fact]
    [Trait("Propriedade", "Proprietário")]
    public void NomeProprietarioVeiculoComDoisCaracteresException()
    {
        string nomeProprietario = "Ab";

        Assert.Throws<FormatException>(
            () => _veiculo.Proprietario = nomeProprietario
        );
    }

    [Fact]
    public void DefinirPlacaVeiculoCom2CaracteresException()
    {
        string placa = "Ab";

        Assert.Throws<FormatException>(
            () => _veiculo.Placa = placa
        );
    }

    [Fact]
    public void QuartoCaractereDaPlacaException()
    {
        string placa = "ASDF8888";

        Assert.Throws<FormatException>(
            () => _veiculo.Placa = placa
        );
    }

    [Fact]
    public void MensagemDeExcecaoDoQuartoCaractereDaPlaca()
    {
        string placa = "ASDF8888";

        FormatException mensagem = Assert.Throws<FormatException>(
            () => _veiculo.Placa = placa
        );

        Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
    }

    [Fact]
    [Trait("Funcionalidade", "Frear")]
    public void FreiaVeiculoComTempo10Sucesso()
    {
        _veiculo.Frear(10);

        Assert.Equal(-150, _veiculo.VelocidadeAtual);
    }

    [Fact]
    public void AlteraDadosVeiculoPorPlacaSucesso()
    {
        Patio estacionamento = new();
        Veiculo veiculo = new()
        {
            Tipo = TipoVeiculo.Automovel,
            Proprietario = "José Silva",
            Placa = "ZXC-8524",
            Cor = "Verde",
            Modelo = "Opala"
        };
        estacionamento.RegistrarEntradaVeiculo(veiculo);
        Veiculo veiculoAlterado = new()
        {
            Tipo = TipoVeiculo.Automovel,
            Proprietario = "José Silva",
            Placa = "ZXC-8524",
            Cor = "Preto",
            Modelo = "Opala"
        };

        var alterado = estacionamento.AlteraDadosVeiculoPorPlaca(veiculoAlterado);

        Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
    }
}
