using System;
using System.Collections.Generic;
using System.Linq;
using KenticoCloud.Delivery;

namespace KcNetSdkSmallProjectExample.Models
{
    public class CustomTypeProvider : ITypeProvider
    {
        private static readonly Dictionary<Type, string> _codenames = new Dictionary<Type, string>
        {
            {typeof(Person), "person"},
            {typeof(Repository), "repository"},
            {typeof(Session), "session"},
            {typeof(Step), "step"},
            {typeof(Training), "training"},
            {typeof(Website), "website"}
        };

        public Type GetType(string contentType)
        {
            return _codenames.Keys.FirstOrDefault(type => GetCodename(type).Equals(contentType));
        }

        public string GetCodename(Type contentType)
        {
            return _codenames.TryGetValue(contentType, out var codename) ? codename : null;
        }
    }
}