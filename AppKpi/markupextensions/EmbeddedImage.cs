
using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using AppKpi.util;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AppKpi.markupextensions
{
    [Preserve(AllMembers = true)]
    [ContentProperty("ResourceId")]
    public class EmbeddedImage : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var assembly = typeof(EmbeddedImage).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
            {
                if (res.Contains("logo"))
                    System.Diagnostics.Debug.WriteLine("found resource: " + res);
            }

            if (string.IsNullOrWhiteSpace(ResourceId))
                return null;

            var processedResourceId = ResourceId;
            if (Device.RuntimePlatform == Device.iOS && ResourceId.Count(f => f == '.') > 1)
            {
                var regex = new Regex(@"\.{1}(.*)");
                var match = regex.Match(processedResourceId);
                if (match.Success)
                {
                    processedResourceId = match.Groups[1].Captures[0].Value;
                }
            }

            var path = $"{PlatformUtils.GetProjectPath()}.{processedResourceId}";

            return ImageSource.FromResource(path);
        }
    }
}
