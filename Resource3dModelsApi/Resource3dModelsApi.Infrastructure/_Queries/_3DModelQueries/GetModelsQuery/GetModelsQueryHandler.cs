using MediatR;
using Microsoft.Extensions.Configuration;
using Resource3dModelsApi.Application.Repository;
using Resource3dModelsApi.Application.Services.FileResourceServices;
using Resource3dModelsApi.Domain.Models;
using Resource3dModelsApi.Domain.ViewModel._3dModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Infrastructure._Queries._3DModelQueries.GetModelsQuery
{
    public class GetModelsQueryHandler : IRequestHandler<GetModelsQuery, IQueryable<MainModel3D>>
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

        public async Task<IQueryable<MainModel3D>> Handle(GetModelsQuery request, CancellationToken cancellationToken)
        {
            var res = selectRepository.SelectPageWithUseAutomapper<MainModel3D, _3dModel>(request.SearchString,request.Category,request.page);

            var Token = configuration["FileServiceConfiguration:Token"];

            foreach(var x in res)
            {
                var url =await fileResourceService.GetFileLink(Token,x.Title,x.FileTitleWithoutExtension);
                if (!string.IsNullOrEmpty(url))
                    x.ModelURL = url;
                else
                    x.ModelURL="";
            }

            return res;
        }
    }
}
