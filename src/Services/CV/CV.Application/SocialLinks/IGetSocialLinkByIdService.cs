using CV.Contracts.SocialLinks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.SocialLinks
{
    public interface IGetSocialLinkByIdService
    {
        Task<GetSocialLinkByIdResponse?> GetByIdAsync(Guid id);
    }
}
