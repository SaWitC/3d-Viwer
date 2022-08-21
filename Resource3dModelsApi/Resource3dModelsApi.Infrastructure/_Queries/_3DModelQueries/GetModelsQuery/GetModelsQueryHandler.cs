using MediatR;
using Microsoft.Extensions.Configuration;
using Resource3dModelsApi.Application.Repository;
using Resource3dModelsApi.Application.Services.FileResourceServices;
using Resource3dModelsApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Queries._3DModelQueries.GetModelsQuery
{
    public class GetModelsQueryHandler : IRequestHandler<GetModelsQuery, IEnumerable<string>>
    {

        private readonly ISelectRepository selectRepository;
        private readonly IFileResourceService fileResourceService;
        private readonly IConfiguration configuration;
        public GetModelsQueryHandler(ISelectRepository selectRepository, IFileResourceService fileResourceService,IConfiguration configuration)
        {
            this.selectRepository = selectRepository;
            this.fileResourceService = fileResourceService;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<string>> Handle(GetModelsQuery request, CancellationToken cancellationToken)
        {
            var res = selectRepository.Select<_3dModel>(request.page);

            List<string> urls = new List<string>();
            var Token = configuration["FileServiceConfiguration:Token"];

            foreach(var x in res)
            {
                var url =await fileResourceService.GetFileLink(Token,x.Title,x.FileTitleWithoutExtension);
                if (!string.IsNullOrEmpty(url))
                    urls.Add(url);
                else
                    urls.Add("Fille load exception");
            }

            return urls;
        }
    }
}
