using KenticoCloud.Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KcNetSdkSmallProjectExample.Resolvers
{
    // Sample resolver implementation
    public class CustomContentLinkUrlResolver : IContentLinkUrlResolver
    {
        public string ResolveLinkUrl(ContentLink link)
        {
            // Resolves URLs to content items based on the 'accessory' content type
            if (link.ContentTypeCodename == "website")
            {
                return $"/website/{link.Codename}";
            }

            return ResolveBrokenLinkUrl();
        }

        public string ResolveBrokenLinkUrl()
        {
            // Resolves URLs to unavailable content items
            return "/404";
        }
    }
}
