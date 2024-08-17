using System.Collections.Generic;
using System.Threading.Tasks;
using Continuum.Core.Entities;

namespace Continuum.Application.Interfaces
{
    public interface ISocialMediaService
    {
        Task<SocialMedia> GetSocialMediaByIdAsync(int id);
        Task<IEnumerable<SocialMedia>> GetAllSocialMediaAsync(int clientId);
        Task AddSocialMediaAsync(SocialMedia socialMedia);
        Task UpdateSocialMediaAsync(SocialMedia socialMedia);
        Task DeleteSocialMediaAsync(int id);
    }
}