using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Application.Services.TagServices
{
    public interface ITagService
    {
         List<string> SplitToTags(string tagsString);
    }
}
