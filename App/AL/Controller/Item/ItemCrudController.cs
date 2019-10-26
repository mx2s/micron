using System.Collections.Generic;
using App.DL.Repository.Item;
using App.PL.Item;
using Micron.AL.Validation.Db;
using Micron.DL.Middleware;
using Micron.DL.Middleware.Auth;
using Micron.DL.Module.Controller;
using Micron.DL.Module.Http;
using Micron.DL.Module.Validator;
using Nancy;

namespace App.AL.Controller.Item
{
    public class ItemCrudController : BaseController {
        protected override IMiddleware[] Middleware() => new IMiddleware[] {
            new JwtMiddleware()
        };

        private IReadOnlyCollection<HttpError> ValidateRequest(IValidatorRule[] validatorRules = null) {
            if (validatorRules == null) {
                validatorRules = new IValidatorRule[] {
                    new ExistsInTable("item_guid", "items", "guid"),
                };
            }

            var errors = ValidationProcessor.Process(Request, validatorRules);
            return errors;
        }

        public ItemCrudController() {
            Post("/api/v1/item/create", _ => {
                var errors = ValidateRequest(new IValidatorRule[] { });
                if (errors.Count > 0) {
                    return HttpResponse.Errors(errors);
                }

                var item = ItemRepository.CreateAndGet((string) Request.Query["title"], (float) Request.Query["price"]);

                return ReturnOne(item);
            });

            Get("/api/v1/item/get", _ => {
                var errors = ValidateRequest();

                if (errors.Count > 0) {
                    return HttpResponse.Errors(errors);
                }

                return ReturnOne(ItemRepository.FindByGuid(Request.Query["item_grid"]));
            });

            Patch("/api/v1/item/edit", _ => {
                var errors = ValidateRequest();

                if (errors.Count > 0) {
                    return HttpResponse.Errors(errors);
                }

                var item = ItemRepository.FindByGuid((string) Request.Query["item_guid"]);
                item.title = (string) Request.Query["title"] ?? item.title;
                item.price = (decimal?) Request.Query["price"] ?? item.price;
                item = item.Save().Refresh();

                return ReturnOne(item);
            });

            Delete("/api/v1/item/delete", _ => {
                var errors = ValidateRequest();

                if (errors.Count > 0) {
                    return HttpResponse.Errors(errors);
                }

                var item = ItemRepository.FindByGuid((string) Request.Query["item_guid"]);

                item.Delete();

                return ReturnOne(item);
            });
        }

        private static Response ReturnOne(DL.Model.Item.Item item, string key = "item") {
            var data = new ItemTransformer().Transform(item);
            return HttpResponse.Item(key, data);
        }
    }
}