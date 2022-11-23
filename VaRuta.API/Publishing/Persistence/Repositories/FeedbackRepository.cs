using Microsoft.EntityFrameworkCore;
using VaRuta.API.Publishing.Domain;
using VaRuta.API.Publishing.Domain.Repositories;
using VaRuta.API.Shared.Persistence.Contexts;
using VaRuta.API.Shared.Persistence.Repositories;

namespace VaRuta.API.Publishing.Persistence.Repositories;

public class FeedbackRepository  : BaseRepository, IFeedbackRepository
{
    public FeedbackRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Feedback>> ListAsync()
    {
        return await _context.Feedbacks.ToListAsync();
    }
   
    public async Task AddAsync(Feedback feedback)
    {
        await _context.Feedbacks.AddAsync(feedback);
    }
    
    public async Task<Feedback> FindByIdAsync(int id)
    {
        return await _context.Feedbacks.FindAsync(id);
    }
    
    public void Update(Feedback feedback)
    {
        _context.Feedbacks.Update(feedback);
    }

    public void Remove(Feedback feedback)
    {
        _context.Feedbacks.Remove(feedback);
    }


    
}