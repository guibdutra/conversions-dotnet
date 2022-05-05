namespace Conversions.Api.Models;

public class ErrorException
{
    public bool Erro => true;
    public string? Mensagem { get; set; }
}