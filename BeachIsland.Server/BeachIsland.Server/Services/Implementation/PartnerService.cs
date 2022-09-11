namespace BeachIsland.Server.Services.Implementation
{
    using System.Threading.Tasks;

    using BeachIsland.Server.Data;
    using BeachIsland.Server.Data.Models;
    using BeachIsland.Server.Models.Partner;
    using BeachIsland.Server.Services.Interfaces;

    public class PartnerService : IPartnerService
    {
        private readonly BeachIslandDbContext data;

        public PartnerService(BeachIslandDbContext data)
        {
            this.data = data;
        }

        public async Task<int> BecomePartner(RegisterPartnerRequestDto partnerRequestDto, string userId)
        {
            var partner = new Partner(partnerRequestDto.Name, partnerRequestDto.PhoneNumber, userId);

            await this.data.Partners.AddAsync(partner);
            await this.data.SaveChangesAsync();

            return partner.Id;
        }

        public bool isPartner(string userId)
        {
            return this.data.Partners
                .Any(x => x.UserId == userId);
        }

        public int PartnerId(string userId)
        {
            var partnerId = this.data.Partners
               .Where(p => p.UserId == userId)
               .Select(p => p.Id)
               .FirstOrDefault();

            return partnerId;
        }
    }
}
