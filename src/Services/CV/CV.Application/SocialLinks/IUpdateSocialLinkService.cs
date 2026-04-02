using CV.Contracts.SocialLinks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.SocialLinks
{
    public interface IUpdateSocialLinkService
    {
        Task<UpdateSocialLinkResponse?> UpdateAsync(Guid id, UpdateSocialLinkRequest request);
    }
}
