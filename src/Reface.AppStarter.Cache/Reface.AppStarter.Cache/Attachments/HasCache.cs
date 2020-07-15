using Reface.AppStarter.Attributes;
using System;

namespace Reface.AppStarter.Cache.Attachments
{
    [AttributeUsage(AttributeTargets.Class)]
    public class HasCache : MethodAttachmentAttribute
    {
        public HasCache()
        {
            this.AttributeTypes = new Type[]
            {
                typeof(CacheAttribute)
            };
        }
    }
}
