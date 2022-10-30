using Litethinking.NetInventory.Backend.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litethinking.NetInventory.Backend.Application.Contracts.Infrastructure
{
    public interface IAzureBlobStorageService
    {
        Task<bool> AzureBlobStorageUpload(AzureBlobStorage azureBlobStorage);
    }
}
