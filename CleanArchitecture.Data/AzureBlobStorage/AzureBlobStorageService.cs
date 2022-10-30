using Litethinking.NetInventory.Backend.Application.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litethinking.NetInventory.Backend.Infraestructure.AzureBlobStorage
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {
        public AzureBlobStorageService() { }

        public async Task<bool> AzureBlobStorageUpload(Application.Models.AzureBlobStorage email)
        {
            string valor = "Hola estoy en la libreria :D";
            return true;
        }
            
    }
}
