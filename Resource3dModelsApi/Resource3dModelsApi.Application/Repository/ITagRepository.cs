using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Application.Repository
{
    public interface ITagRepository
    {
        Task<bool> CreateTagsFor_3dmodel(string modelId, List<string> tags);
        Task<bool> CreateTagsFor_3dmodel(_3dModel model, List<string> tags);

        Task<bool>UpdateTagsFor_3dmodel(string modelId, List<string> tags);

        Task<bool> DeleteRelationships(string modelId);
        IEnumerable<TagModel> GetTagsBySybstring(string Substring,int count=5);
    }
}
