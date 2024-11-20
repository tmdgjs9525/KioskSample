using System.Windows;
using System.Windows.Controls;

namespace KioskSample.Core
{
    public class ViewLocator : DataTemplateSelector
    {
        public override DataTemplate? SelectTemplate(object? item, DependencyObject container)
        {
            if (item == null)
                return null;

            var viewModelName = item.GetType().FullName!;
            var viewName = viewModelName.Replace("ViewModel", "View", StringComparison.Ordinal);
            var viewType = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .FirstOrDefault(t => t.FullName == viewName);

            if (viewType != null)
            {
                // 동적으로 DataTemplate 생성
                var factory = new FrameworkElementFactory(viewType);
                var template = new DataTemplate
                {
                    VisualTree = factory
                };
                return template;
            }

            // 기본 처리 (매칭되지 않을 경우)
            var defaultFactory = new FrameworkElementFactory(typeof(Label));
            defaultFactory.SetValue(Label.ContentProperty, $"Not Found: {viewName}");

            return new DataTemplate
            {
                VisualTree = defaultFactory
            };
        }
    }
}
