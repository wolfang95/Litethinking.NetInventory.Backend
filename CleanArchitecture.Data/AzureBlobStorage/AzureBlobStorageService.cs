using Litethinking.NetInventory.Backend.Application.Contracts.Infrastructure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace Litethinking.NetInventory.Backend.Infraestructure.AzureBlobStorage
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {
        public AzureBlobStorageService() { }

        public async Task<bool> AzureBlobStorageUpload(Application.Models.AzureBlobStorage email)
        {
            string valor = "Hola estoy en la libreria :D";
            FileStream file = null;
            string containerRuta = "inventories";
            string conetcionString = "DefaultEndpointsProtocol=https;AccountName=litethinkingwolf;AccountKey=/GHjAZEgFbDjVjw1wtkorJMKt+nKq6tFpuy1sH7sc54Wp3iiApWtEqK4oJ6Q/yMKJfzyr8yd/45J+AStrEU3qA==;EndpointSuffix=core.windows.net";
            using (FileStream fs = new FileStream("test.htm", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine("<H1>Hello</H1>");

                }
                file = fs;
            }

            //FileStream fs = new FileStream("test.htm", FileMode.));

            /*

            StreamWriter w2 = new StreamWriter(file, Encoding.UTF8)
            {
                NewLine = "<H1>Hello2</H1>"
            };*/
            string fileName = "test.html";
            var container = GetContainer(containerRuta, conetcionString);
            //Stream fileS = GenerateStreamFromString(base64);
            var blockBlob = container.GetBlockBlobReference(fileName);
            await blockBlob.UploadTextAsync("<h1>Wolfang<h1>");
          
            //blockBlob.UploadFromStreamAsync(file);
            string url = "/" + containerRuta + "/" + fileName;
            return true;
        }

        private static CloudBlobContainer GetContainer(string containerRuta, string conectionstring)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(conectionstring);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerRuta);
            container.SetPermissionsAsync(
               new BlobContainerPermissions
               {
                   PublicAccess = BlobContainerPublicAccessType.Blob
               });
            return container;
        }
    }
}
