using MediatR;
using Microsoft.Extensions.Configuration;
using Resource3dModelsApi.Application.Services.FileResourceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Commands.HomeCommands.GetHome3dModels
{
    public class GetHome3dModelsCommandHandler : IRequestHandler<GetHome3dModelsCommand, List<string>>
    {
        private readonly IFileResourceService fileResourceService;
        private readonly IConfiguration configuration;
        public GetHome3dModelsCommandHandler(IFileResourceService fileResourceService,IConfiguration configuration)
        {
            this.fileResourceService = fileResourceService;
            this.configuration = configuration;
        }

        public async Task<List<string>> Handle(GetHome3dModelsCommand request, CancellationToken cancellationToken)
        {

            var Token = configuration["FileServiceConfiguration:Token"];

            var DirPath = configuration["FileServiceConfiguration:RootDirecoryPath"];
            var files =await fileResourceService.GetlinksOfAllFilesFromDirectory(Token,DirPath);
            return files;

        }
    }
}
