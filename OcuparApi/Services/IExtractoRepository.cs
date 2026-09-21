namespace OcuparApi.Services
{
    public interface IExtractoRepository
    {
        Task<int> LoadCajaSocialExtractoAsync(string cajaSocialJson);
    }
}
