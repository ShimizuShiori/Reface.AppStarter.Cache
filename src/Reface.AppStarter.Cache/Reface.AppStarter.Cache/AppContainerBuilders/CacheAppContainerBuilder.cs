using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reface.AppStarter.AppContainers;

namespace Reface.AppStarter.AppContainerBuilders
{
    public class CacheAppContainerBuilder : BaseAppContainerBuilder
    {
        private Dictionary<string, List<string>> depenedCacheToOtherCacheMap = new Dictionary<string, List<string>>();

        private void AddType(AttributeAndTypeInfo info)
        {

        }

        public override IAppContainer Build(AppSetup setup)
        {
            throw new NotImplementedException();
        }
    }
}
