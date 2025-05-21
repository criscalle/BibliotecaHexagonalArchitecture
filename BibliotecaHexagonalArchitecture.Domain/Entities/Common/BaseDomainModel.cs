namespace BibliotecaHexagonalArchitecture.Domain.Entities.Common;

public abstract class BaseDomainModel
{
    public int Id { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
