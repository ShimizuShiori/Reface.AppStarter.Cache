using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reface.AppStarter.Cache.Tests
{
    public class CacheInfo
    {
        public CacheActions Action { get; private set; }
        public string Key { get; private set; }

        public CacheInfo(CacheActions action, string key)
        {
            Action = action;
            Key = key;
        }

        public override string ToString()
        {
            return $"{Action.ToString()}:{Key}";
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is CacheInfo)) return false;
            return this.GetHashCode() == obj.GetHashCode();
        }
    }
}
