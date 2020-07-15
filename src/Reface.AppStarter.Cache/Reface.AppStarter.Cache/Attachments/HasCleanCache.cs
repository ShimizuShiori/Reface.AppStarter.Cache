using Reface.AppStarter.Attributes;
using System;

namespace Reface.AppStarter.Cache.Attachments
{
    [AttributeUsage(AttributeTargets.Class)]
    public class HasCleanCache : MethodAttachmentAttribute
    {
        public HasCleanCache()
        {
            this.AttributeTypes = new Type[] 
            { 
                typeof(CleanCacheAttribute)
            };
        }
    }
}
