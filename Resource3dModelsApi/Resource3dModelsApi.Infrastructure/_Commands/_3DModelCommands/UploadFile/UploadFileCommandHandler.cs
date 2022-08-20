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

namespace Resource3dModelsApi.Infrastructure._Commands._3DModelCommands.UploadFile
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, bool>
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IConfiguration _configuration;
        private readonly IFileResourceService _fileResourceService;
        public UploadFileCommandHandler(IBaseRepository baseRepository , IConfiguration configuration, IFileResourceService fileResourceService)
        {
            _baseRepository = baseRepository;
            _configuration = configuration;
            _fileResourceService = fileResourceService;
        }

        public async Task<bool> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            var model = await _baseRepository.GetByIdAsync<_3dModel>(request.id);
            if (model != null)
            {
                var folderName = model.Title + model.Id.ToString();

                var Token = _configuration["FileServiceConfiguration:Token"];

                var UploadRes = await _fileResourceService.CreateFile(Token, model.Title, request.file, Path.GetFileNameWithoutExtension(request.file.FileName));
                if (UploadRes)
                {
                    model.IsFileUploaded = true;
                    await _baseRepository.UpdateAsync<_3dModel>(model, model.Id);
                    await _baseRepository.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
