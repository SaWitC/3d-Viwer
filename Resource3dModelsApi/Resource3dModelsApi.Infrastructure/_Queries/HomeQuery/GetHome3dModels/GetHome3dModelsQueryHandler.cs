using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Resource3dModelsApi.Application.Services.FileResourceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Queries.HomeQuery.GetHome3dModels
{
    public class GetHome3dModelsQueryHandler : IRequestHandler<GetHome3dModelsQuery, List<string>>
    {
        private readonly IFileResourceService fileResourceService;
        private readonly IConfiguration configuration;
        public GetHome3dModelsQueryHandler(IFileResourceService fileResourceService, IConfiguration configuration)
        {
            this.fileResourceService = fileResourceService;
            this.configuration = configuration;
        }

        public async Task<List<string>> Handle(GetHome3dModelsQuery request, CancellationToken cancellationToken)
        {

            var Token = configuration["FileServiceConfiguration:Token"];

            var DirPath = configuration["FileServiceConfiguration:RootDirecoryPath"];
            var ListOfLinks = await fileResourceService.GetlinksOfAllFilesFromDirectory(Token, DirPath);
            return ListOfLinks;

        }
    }
}
