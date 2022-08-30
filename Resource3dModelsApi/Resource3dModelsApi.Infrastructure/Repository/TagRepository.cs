using Microsoft.EntityFrameworkCore;
using Resource3dModelsApi.Application.Repository;
using Resource3dModelsApi.Domain.Models;
using Resource3dModelsApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure.Repository
{
    public class TagRepository : ITagRepository
    {

        private readonly AppDbContext _context;

        public TagRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateTagsFor_3dmodel(string id,List<string> tags)
        {
            var model = await _context._3DModels.FirstOrDefaultAsync(o => o.Id == id);
            if (model != null)
            {
                foreach (var item in tags)
                {
                    
                    var tag = await _context.Tags.FirstOrDefaultAsync(o=>o.Title.ToLower() ==item.ToLower());
                    if (tag == null)
                    {
                        tag = new TagModel();
                        tag.Title = item.ToLower();
                        tag.Id = Guid.NewGuid().ToString();
                        var entry =await _context.Tags.AddAsync(tag);

                        var relationship = new Tags_Models_Relationship();
                        relationship.Id = Guid.NewGuid().ToString();
                        relationship.TagId = entry.Entity.Id;
                        relationship._3dModelId = id;

                        await _context.tags_Models_Relationships.AddAsync(relationship);
                    }
                    else
                    {
                        var relationship = new Tags_Models_Relationship();
                        relationship.Id = Guid.NewGuid().ToString();
                        relationship.TagId = tag.Id;
                        relationship._3dModelId = id;

                        await _context.tags_Models_Relationships.AddAsync(relationship);
                    }
                }
                return true;
            }
            throw new InvalidDataException("Model not found in db");
        }

        public async Task<bool> CreateTagsFor_3dmodel(_3dModel model, List<string> tags)
        {
            var modelFromDb = await _context._3DModels.FirstOrDefaultAsync(o => o.Id == model.Id);
            if (modelFromDb != null)
            {
                foreach (var item in tags)
                {
                    var tag = await _context.Tags.FirstOrDefaultAsync(o => o.Title.ToLower() == item.ToLower());
                    if (tag == null)
                    {
                        tag = new TagModel();
                        tag.Title = item.ToLower();
                        tag.Id = Guid.NewGuid().ToString();
                        var entry = await _context.Tags.AddAsync(tag);

                        var relationship = new Tags_Models_Relationship();
                        relationship.Id = Guid.NewGuid().ToString();
                        relationship.TagId = entry.Entity.Id;
                        relationship._3dModelId = modelFromDb.Id;

                        await _context.tags_Models_Relationships.AddAsync(relationship);
                    }
                    else
                    {
                        var relationship = new Tags_Models_Relationship();
                        relationship.Id = Guid.NewGuid().ToString();
                        relationship.TagId = tag.Id;
                        relationship._3dModelId = modelFromDb.Id;

                        await _context.tags_Models_Relationships.AddAsync(relationship);
                    }
                }
                return true;
            }
            throw new InvalidDataException("Model not found in db");
        }

        public async Task<bool> DeleteRelationships(string modelId)
        {
            var relationships = _context.tags_Models_Relationships.Where(o => o._3dModelId == modelId);
            if (relationships != null)
            {
                _context.tags_Models_Relationships.RemoveRange(relationships);
                return true;
            }
            return false;
        }

        public Task<bool> UpdateTagsFor_3dmodel(string modelId, List<string> tags)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TagModel> GetTagsBySybstring(string Substring, int count = 5)=> _context.Tags.Where(x => x.Title.ToLower().Contains(Substring.ToLower())).Take(5);
    }
}
