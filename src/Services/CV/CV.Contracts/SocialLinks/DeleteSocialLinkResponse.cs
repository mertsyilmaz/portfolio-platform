using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Contracts.SocialLinks
{
    public class DeleteSocialLinkResponse
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
