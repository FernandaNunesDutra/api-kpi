using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AppKpi.markupextensions
{
    [Preserve(AllMembers = true)]
    [ContentProperty("ResourceId")]
    public class EmbeddedImageGeneric : MarkupExtension
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

            return ImageSource.FromResource("AppKpi." + ResourceId);
        }
    }
}
