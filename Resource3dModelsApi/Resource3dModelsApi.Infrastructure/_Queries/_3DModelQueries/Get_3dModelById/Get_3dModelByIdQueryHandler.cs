using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

namespace Resource3dModelsApi.Infrastructure._Queries._3DModelQueries.Get_3dModelById
{
    public class Get_3dModelByIdQueryHandler : IRequestHandler<Get_3dModelByIdQuery, DetailsModel3D>
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly IFileResourceService _fileResourceService;
        private readonly IConfiguration _configuration;
        public Get_3dModelByIdQueryHandler(IBaseRepository baseRepository, IMapper mapper,IFileResourceService fileResource,IConfiguration configuration)
        {
            _fileResourceService = fileResource;
            _baseRepository = baseRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<DetailsModel3D> Handle(Get_3dModelByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _baseRepository.GetByIdAsync<_3dModel>(request.Id);
            if (res != null) {

                var detailsModel = _mapper.Map<DetailsModel3D>(res);

                var Token = _configuration["FileServiceConfiguration:Token"];

                detailsModel.ModelURL = await _fileResourceService.GetFileLink(Token, res.Title, res.FileTitleWithoutExtension);

                return detailsModel;
            }

            return null;
        }
    }
}
