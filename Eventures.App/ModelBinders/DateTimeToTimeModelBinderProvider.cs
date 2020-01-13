using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Eventures.App.ModelBinders
{
    public class DateTimeToTimeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(string) && context.Metadata.Name == "Time") 
            {
                return new DateTimeToTimeModelBinder();
            }

            return null;
        }
    }
}
