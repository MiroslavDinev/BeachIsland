namespace BeachIsland.Server.Services.Interfaces
{
    using BeachIsland.Server.Models.Partner;

    public interface IPartnerService
    {
        bool isPartner(string userId);
        Task<int> BecomePartner(RegisterPartnerRequestDto partnerRequestDto, string userId);
        int PartnerId(string userId);
    }
}
