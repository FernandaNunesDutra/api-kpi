using System;
using Xamarin.Forms.Xaml;

namespace AppKpi.markupextensions
{
    public abstract class MarkupExtension : IMarkupExtension
    {
        public string ResourceId { get; set; }

        public abstract object ProvideValue(IServiceProvider serviceProvider);
    }
}
