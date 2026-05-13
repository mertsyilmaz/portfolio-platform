namespace CV.Application.Certificates
{
    public interface IDeleteCertificateService
    {
        Task DeleteAsync(Guid id);
    }
}
