namespace SchoolManagement.Infrastructure.CloudServices.Interfaces
{
    public interface IFileStorageService
    {
        void UploadFile(byte[] data, int offset, int length);
    }
}
