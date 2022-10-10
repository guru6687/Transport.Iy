using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Iy.Helper
{
    public class JsonContractResolver
    {
        class DynamicMappingResolver : DefaultContractResolver
        {
            private Dictionary<Type, Dictionary<string, string>> memberNameToJsonNameMap;

            public DynamicMappingResolver(Dictionary<Type, Dictionary<string, string>> memberNameToJsonNameMap)
            {
                this.memberNameToJsonNameMap = memberNameToJsonNameMap;
            }

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty prop = base.CreateProperty(member, memberSerialization);
                Dictionary<string, string> dict;
                string jsonName;
                if (memberNameToJsonNameMap.TryGetValue(member.DeclaringType, out dict) &&
                    dict.TryGetValue(member.Name, out jsonName))
                {
                    prop.PropertyName = jsonName;
                }
                return prop;
            }
        }
    }
}
