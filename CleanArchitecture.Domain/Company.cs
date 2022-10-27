using Litethinking.NetInventory.Backend.Domain.Common;


namespace Litethinking.NetInventory.Backend.Domain
{
    public class Company : BaseDomainModel
    {
        public int Id { get; set; }
        public string NIT { get; set; }
        public string CompanyName { get; set; }
    }
}
