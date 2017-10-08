using MongoDB.Bson;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using Publishers.API.Controllers;

namespace Publishers.API.ModelBinder
{
    /// <summary>
    /// This is the model binder to bind the request's object id with the id parameter of the <see cref="BooksController"/>.
    /// It parses the string which is an object id and then passes the <see cref="ObjectId"/> to <see cref="BooksController.GetById(ObjectId)"/> 
    /// method.
    /// </summary>
    public class ObjectIdModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(ObjectId))
            {
                return false;
            }

            var val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (val == null)
            {
                return false;
            }

            var id = val.RawValue as string;
            ObjectId result;
            if (ObjectId.TryParse(id, out result))
            {
                bindingContext.Model = result;
                return true;
            }

            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Cannot parse ObjectId");

            return false;
        }
    }
}
