using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Collections.API.Helpers
{
    /// <summary>
    /// Helper class to convert an object into dictionary with JSON paths as the keys
    /// Modified from code found on SO: http://stackoverflow.com/a/27749909
    /// </summary>
    public static class ObjectToJsonDictionary
    {
        /// <summary>
        /// Walks the tokens.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public static IEnumerable<JToken> WalkTokens(this JToken node)
        {
            if (node == null)
            {
                yield break;
            }

            yield return node;

            foreach (var child in node.Children())
            {
                foreach (var childNode in child.WalkTokens())
                {
                    yield return childNode;
                }
            }
        }

        /// <summary>
        /// Converts the .
        /// </summary>
        /// <param name="objectToConvert">The object to convert.</param>
        /// <returns></returns>
        public static JToken ObjectToJToken(object objectToConvert)
        {
            var jsonString = JsonConvert.SerializeObject(objectToConvert, Formatting.Indented);

            var jToken = JToken.Parse(jsonString);

            return jToken;
        }

        /// <summary>
        /// Maps the JToken .
        /// </summary>
        /// <param name="root">The root.</param>
        /// <returns></returns>
        public static IDictionary<string, object> ToValueDictionary(this object root)
        {
            var convertRoot = ObjectToJToken(root);

            var walkedRoot = convertRoot.WalkTokens().OfType<JValue>().ToDictionary(value => value.Path, value => value.Value);

            foreach (var item in walkedRoot.Where(i => i.Value == null).ToList())
            {
                walkedRoot.Remove(item.Key);
            }

            return walkedRoot;
        }
    }
}