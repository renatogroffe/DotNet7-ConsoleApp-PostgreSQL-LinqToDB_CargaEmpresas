using LinqToDB.Mapping;

namespace ConsoleAppDadosFuncionarios.Data;

[Table("Funcionarios")]
public class Funcionario
{
    [PrimaryKey, Identity]
    public int Id { get; set; }

    [Column]
    public string? Nome { get; set; }

    [Column]
    public string? Email { get; set; }

    [Column]
    public string? Cidade { get; set; }

    [Column]
    public string? Pais { get; set; }
}