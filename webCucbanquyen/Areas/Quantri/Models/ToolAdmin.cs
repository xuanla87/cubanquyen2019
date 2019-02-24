using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CucbanquyenData.Infrastructure;
using CucbanquyenData.Repositories;
using CucbanquyenModel.Models;
using CucbanquyenService;

namespace webCucbanquyen.Areas.Quantri.Models
{
    public class ToolAdmin
    {
        ICategoryService _categoryService;
        IDocumentTypeService _documentTypeService;
        public ToolAdmin(ICategoryService categoryService, IDocumentTypeService documentTypeService)
        {
            this._categoryService = categoryService;
            this._documentTypeService = documentTypeService;
        }
        public IEnumerable<SelectListItem> DocumentTypeSelectList()
        {
            var model = _documentTypeService.GetAll();
            List<SelectListItem> options = new List<SelectListItem>();
            var parents = model.Where(x => x.isTrash == false);
            foreach (var parent in parents)
            {
                options.Add(new SelectListItem()
                {
                    Value = parent.documentTypeId.ToString(),
                    Text = parent.documentTypeName
                });
            }
            return options;
        }
        public IEnumerable<SelectListItem> SlideDropdown(ISliderService _sildeService)
        {
            var model = _sildeService.GetAll().Where(x => x.isTrash == false);
            List<SelectListItem> options = new List<SelectListItem>();
            foreach (var item in model)
            {
                options.Add(new SelectListItem()
                {
                    Value = item.sliderId.ToString(),
                    Text = item.sliderName
                });
            }
            return options;
        }

        public IEnumerable<SelectListItem> MenuDropdown(IMenuService _menuService, int languageId)
        {
            var model = _menuService.GetAll().Where(x => x.parentId == null && x.isTrash == false && x.languageId == languageId);
            List<SelectListItem> options = new List<SelectListItem>();
            foreach (var item in model)
            {
                options.Add(new SelectListItem()
                {
                    Value = item.menuId.ToString(),
                    Text = item.menuName
                });
            }
            return options;
        }
        public IEnumerable<SelectListItem> DocumentTypeDropdown(int? id)
        {

            List<SelectListItem> options = new List<SelectListItem>();
            options.Add(new SelectListItem()
            {
                Value = "1",
                Text = "Luật",
                Selected = id.HasValue && id == 1
            });
            options.Add(new SelectListItem()
            {
                Value = "2",
                Text = "Văn bản dưới luật",
                Selected = id.HasValue && id == 2
            });
            return options;
        }
        public IEnumerable<SelectListItem> CategorySelectList(int? id, int? curentId, int languageId)
        {
            var model = _categoryService.GetAll().Where(x => x.isTrash == false);
            if (curentId.HasValue)
            {
                model = model.Where(x => x.categoryId != curentId.Value && x.parentId != curentId);
            }
            List<SelectListItem> options = new List<SelectListItem>();
            foreach (var item in model)
            {
                if (id.HasValue)
                {
                    options.Add(new SelectListItem()
                    {
                        Value = item.categoryId.ToString(),
                        Text = item.categoryName,
                        Selected = id.HasValue && item.categoryId == id
                    });
                    options.AddRange(SubDropdown(model, id, "--", item.categoryId, languageId));
                }
                else
                {
                    if (item.parentId == null)
                    {
                        options.Add(new SelectListItem()
                        {
                            Value = item.categoryId.ToString(),
                            Text = item.categoryName,
                            Selected = id.HasValue && item.categoryId == id
                        });
                        options.AddRange(SubDropdown(model, id, "--", item.categoryId, languageId));
                    }
                }
            }
            return options;
        }
        private IEnumerable<SelectListItem> SubDropdown(IEnumerable<Category> sub, int? id, string label, int? parentId, int languageId)
        {
            var children = sub.Where(x => x.parentId == parentId && x.isTrash == false);
            List<SelectListItem> options = new List<SelectListItem>();
            foreach (var child in children)
            {
                options.Add(new SelectListItem()
                {
                    Value = child.categoryId.ToString(),
                    Text = label + child.categoryName,
                    Selected = id.HasValue && child.categoryId == id
                });
                options.AddRange(SubDropdown(sub, id, label + "-", child.categoryId, languageId));
            }
            return options;
        }
        public IEnumerable<SelectListItem> LanguageSelectList()
        {
            List<SelectListItem> options = new List<SelectListItem>();
            options.Add(new SelectListItem()
            {
                Value = "1",
                Text = "Tiếng Việt"
            });
            options.Add(new SelectListItem()
            {
                Value = "2",
                Text = "Tiếng Anh"
            });
            return options;
        }

        public string SetUrl(string input)
        {
            return "";
        }
    }
}