using BaseFramework.AL.Validation.Db;
using BaseFramework.DL.Middleware;
using BaseFramework.DL.Middleware.Auth;
using BaseFramework.DL.Module.Controller;
using BaseFramework.DL.Module.Validator;
using Core.DL.Module.Http;
using Core.DL.Module.Validator;
using Newtonsoft.Json.Linq;

namespace BaseFramework.AL.Controller.Item {
    public class ItemCrudController : BaseController {
        protected override IMiddleware[] Middleware() => new IMiddleware[] {
            new JwtMiddleware()
        };
        
        public ItemCrudController() {
            Get("/api/v1/item/get", _ => {
                var errors = ValidationProcessor.Process(Request, new IValidatorRule[] {
                    new ExistsInTable("item_guid", "items", "guid"),
                });

                if (errors.Count > 0) {
                    return HttpResponse.Errors(errors);
                }

                return HttpResponse.Data(new JObject() {
                    ["message"] = "ok"
                });
            });
        }
    }
}