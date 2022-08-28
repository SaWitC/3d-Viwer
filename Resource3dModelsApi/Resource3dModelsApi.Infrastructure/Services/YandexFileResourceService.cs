using Microsoft.AspNetCore.Http;
using Resource3dModelsApi.Application.Services.FileResourceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexDisk.Client.Http;
using YandexDisk.Client.Protocol;

namespace Resource3dModelsApi.Infrastructure.Services
{
    public class YandexFileResourceService : IFileResourceService
    {
        //token
        //y0_AgAAAABgW19JAAhUuwAAAADMcpP4J8qUXPnCTkS08i7VLN64i8DSYOg
        //public async Task<bool> CreateFile(string token,string DiskFolderPath, IFormFile file ,string FileNameWithoutExtension )
        //{
        //    try
        //    {
        //        var api = new DiskHttpApi(token);

        //        var rootFolderData = await api.MetaInfo.GetInfoAsync(new ResourceRequest { Path = "/" });

        //        if (!rootFolderData.Embedded.Items.Any(i => i.Type == ResourceType.Dir && i.Name.Equals(DiskFolderPath)))
        //        {
        //            await api.Commands.CreateDictionaryAsync("/" + DiskFolderPath);
        //        }

        //        string extenshion = Path.GetExtension(file.FileName);//расширение

        //        var link = await api.Files.GetUploadLinkAsync("/" + DiskFolderPath + "/" + FileNameWithoutExtension + extenshion, overwrite: true);
        //        using (var fs = file.OpenReadStream())
        //        {
        //            await api.Files.UploadAsync(link, fs);
        //        }

        //        //var testFolder = await api.MetaInfo.GetInfoAsync(new ResourceRequest { Path = "/" + DiskFolderPath });

        //        //foreach (var item in testFolder.Embedded.Items)
        //        //{
        //        //    if (item.Name.Contains(File.Name))
        //        //    {
        //        //        return await api.Files.GetDownloadLinkAsync(item.Path);
        //        //    }
        //        //}
        //        // return null;

        //        return true;
        //    }
        //    catch
        //    {
        //         return false;
        //    }
        //}

        public async Task<bool> DeleteFile(string Token, string DiskFolderPath)
        {
            try
            {
                var api = new DiskHttpApi(Token);

                //          var rootFolderData = await api.MetaInfo.GetInfoAsync(new ResourceRequest { Path="/"});

                //            var testFolder = await api.MetaInfo.GetInfoAsync(new ResourceRequest { Path = "/" + DiskFolderPath });

                await api.Commands.DeleteAsync(new DeleteFileRequest { Path = "/" + DiskFolderPath });
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public async Task<string> GetFileLink(string Token, string DiskFolderPath, string fileNameNotExtension)
        {
            try
            {
                var api = new DiskHttpApi(Token);

                var testFolder = await api.MetaInfo.GetInfoAsync(new ResourceRequest { Path = "/" + DiskFolderPath });

                foreach (var item in testFolder.Embedded.Items)
                {
                    if (item.Name.Contains(fileNameNotExtension))
                    {
                        var link = await api.Files.GetDownloadLinkAsync(item.Path);
                        return link.Href;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CreateFile(string token, string DiskFolderPath, IFormFile file, string FileNameWithoutExtension,bool RemoveAlloldFiles)
        {
            try
             {
                var api = new DiskHttpApi(token);

                var rootFolderData = await api.MetaInfo.GetInfoAsync(new ResourceRequest { Path = "/" });

                try
                {

                    var DeleteLink = await api.Commands.DeleteAsync(new DeleteFileRequest { Path ="/"+DiskFolderPath});

                    if (DeleteLink.HttpStatusCode == System.Net.HttpStatusCode.Accepted) ;
                    for(int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(1000);
                        var res = await api.Commands.GetOperationStatus(DeleteLink);
                        if (res.HttpStatusCode == 0)
                        {
                            await api.Commands.CreateDictionaryAsync("/" + DiskFolderPath + "/");
                            break;
                        }
                    }
                }
                catch
                {
                    //log
                }

                if (!rootFolderData.Embedded.Items.Any(i => i.Type == ResourceType.Dir && i.Name.Equals(DiskFolderPath)))
                {
                    await api.Commands.CreateDictionaryAsync("/" + DiskFolderPath+"/");
                }


                string extenshion = Path.GetExtension(file.FileName);//расширение

                var link = await api.Files.GetUploadLinkAsync("/" + DiskFolderPath + "/" + FileNameWithoutExtension + extenshion, overwrite: true);
                using (var fs = file.OpenReadStream())
                {
                    await api.Files.UploadAsync(link, fs);
                }

                //var testFolder = await api.MetaInfo.GetInfoAsync(new ResourceRequest { Path = "/" + DiskFolderPath });

                //foreach (var item in testFolder.Embedded.Items)
                //{
                //    if (item.Name.Contains(File.Name))
                //    {
                //        return await api.Files.GetDownloadLinkAsync(item.Path);
                //    }
                //}
                // return null;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<string>>GetlinksOfAllFilesFromDirectory(string Token,string DirPath)
        {
            var api = new DiskHttpApi(Token);

            var rootFolderData = await api.MetaInfo.GetInfoAsync(new ResourceRequest { Path = "/" });
            var listOfLinks = new List<string>();
            try
            {
                var testFolder = await api.MetaInfo.GetInfoAsync(new ResourceRequest { Path = "/" + DirPath });

                foreach (var item in testFolder.Embedded.Items)
                {
                    var link = await api.Files.GetDownloadLinkAsync(item.Path);
                    //return link.Href;
                    listOfLinks.Add(link.Href);
                }
                return listOfLinks;
            }
            catch
            {
                return null;
            }

        }


    }
}
