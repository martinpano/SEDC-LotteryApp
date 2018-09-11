using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Mapper
{
    public static class Mapper
    {
        public static T2 Map<T1, T2>(this T1 dbModel)
        {
            var model = Activator.CreateInstance<T2>();

            foreach (var propertyInfo in dbModel.GetType().GetProperties())
            {
                var property = model.GetType().GetProperty(propertyInfo.Name);


               if (property != null)
                {
                    var propertyValue = propertyInfo.GetValue(dbModel, null);
                    if(propertyValue is string || propertyValue is DateTime)
                    {
                        property.SetValue(model, propertyValue);
                    }
                    else
                    {
                        var t1 = propertyValue.GetType();
                        var t2 = property.GetValue(model, null).GetType();
                        var method = typeof(Mapper).GetMethod("Map");

                        if(method != null)
                        {
                            var generic = method.MakeGenericMethod(t1, t2);
                            var result = generic.Invoke(null, new[] { propertyValue });
                            property.SetValue(model, result);
                        }
                    }
                }
            }
            return model;
        }
    }
}
