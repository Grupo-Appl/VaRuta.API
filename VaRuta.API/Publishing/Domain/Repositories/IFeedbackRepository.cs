namespace VaRuta.API.Publishing.Domain.Repositories;

public interface IFeedbackRepository
{
    Task<IEnumerable<Feedback>> ListAsync();
    Task AddAsync(Feedback feedback);
    Task<Feedback> FindByIdAsync(int id);
    void Update(Feedback feedback);
    void Remove(Feedback feedback);
}