using System.Collections.Generic;
using System.Threading.Tasks;
using Continuum.Core.Entities;

namespace Continuum.Core.Interfaces
{
    public interface ISocialMediaRepository
    {
        Task<SocialMedia> GetByIdAsync(int id);
        Task<IEnumerable<SocialMedia>> GetByClientIdAsync(int clientId);
        Task AddAsync(SocialMedia socialMedia);
        Task UpdateAsync(SocialMedia socialMedia);
        Task DeleteAsync(int id);
    }
}