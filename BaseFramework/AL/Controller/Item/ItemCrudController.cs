using System;
using BaseFramework.AL.Validation.Db;
using BaseFramework.DL.Middleware;
using BaseFramework.DL.Middleware.Auth;
using BaseFramework.DL.Module.Controller;
using BaseFramework.DL.Module.Validator;
using BaseFramework.DL.Repository.Item;
using BaseFramework.PL.Transformer.Item;
using Core.DL.Module.Http;
using Core.DL.Module.Validator;

namespace BaseFramework.AL.Controller.Item {
    public class ItemCrudController : BaseController {
        protected override IMiddleware[] Middleware() => new IMiddleware[] {
            new JwtMiddleware()
        };
        
        public ItemCrudController() {
            Post("/api/v1/item/create", _ => {
                var errors = ValidationProcessor.Process(Request, new IValidatorRule[] { });
                if (errors.Count > 0) {
                    return HttpResponse.Errors(errors);
                }

                var item = ItemRepository.CreateAndGet((string) Request.Query["title"], (float) Request.Query["price"]);

                return HttpResponse.Item("item", new ItemTransformer().Transform(item));
            });
            
            Get("/api/v1/item/get", _ => {
                var errors = ValidationProcessor.Process(Request, new IValidatorRule[] {
                    new ExistsInTable("item_guid", "items", "guid"),
                });
                if (errors.Count > 0) {
                    return HttpResponse.Errors(errors);
                }

                return HttpResponse.Item("item", new ItemTransformer().Transform(
                    ItemRepository.FindByGuid(Request.Query["item_guid"])
                ));
            });
            
            Patch("/api/v1/item/edit", _ => {
                var errors = ValidationProcessor.Process(Request, new IValidatorRule[] {
                    new ExistsInTable("item_guid", "items", "guid"),
                });
                if (errors.Count > 0) {
                    return HttpResponse.Errors(errors);
                }

                var item = ItemRepository.FindByGuid((string) Request.Query["item_guid"]);
                item.title = (string) Request.Query["title"] ?? item.title;
                item.price = (decimal?) Request.Query["price"] ?? item.price;
                item = item.Save().Refresh();

                return HttpResponse.Item("item", new ItemTransformer().Transform(item));
            });
            
            Delete("/api/v1/item/delete", _ => {
                var errors = ValidationProcessor.Process(Request, new IValidatorRule[] {
                    new ExistsInTable("item_guid", "items", "guid"),
                });
                if (errors.Count > 0) {
                    return HttpResponse.Errors(errors);
                }

                var item = ItemRepository.FindByGuid((string) Request.Query["item_guid"]);
                
                item.Delete();
                
                return HttpResponse.Item("item", new ItemTransformer().Transform(item));
            });
        }
    }
}