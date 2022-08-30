using Resource3dModelsApi.Application.Services.TagServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure.Services
{
    public class TagService:ITagService
    {
        public List<string> SplitToTags(string tagsString)
        {
            var tags = new List<string>();

            //tagsString = tagsString.Trim();
            tagsString = tagsString.Replace(" ","");
           
            var tagsv1 = tagsString.Split(new char[] { ',', '.', '#', '@' });
            foreach (var item in tagsv1)
            {
                if(!string.IsNullOrEmpty(item))
                    tags.Add(item);
            }

           //tags.AddRange(tagsv1);
            return tags;
        }
    }
}
