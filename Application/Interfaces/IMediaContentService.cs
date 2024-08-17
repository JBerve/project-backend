using System.Collections.Generic;
using System.Threading.Tasks;
using Continuum.Core.Entities;

namespace Continuum.Application.Interfaces
{
    public interface IMediaContentService
    {
        Task<MediaContent> GetMediaContentByIdAsync(int id);
        Task<IEnumerable<MediaContent>> GetAllMediaContentsAsync(int clientId);
        Task AddMediaContentAsync(MediaContent mediaContent);
        Task UpdateMediaContentAsync(MediaContent mediaContent);
        Task DeleteMediaContentAsync(int id);
    }
}