using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Eventures.App.ModelBinders
{
    // Manual use
    public class DateTimeToTimeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult inputValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (DateTime.TryParse(inputValue.FirstValue, out DateTime dateTime))
            {
                bindingContext.Result = ModelBindingResult.Success(dateTime.ToString("HH:mm", CultureInfo.InvariantCulture));
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }

            return Task.CompletedTask;
        }
    }
}
