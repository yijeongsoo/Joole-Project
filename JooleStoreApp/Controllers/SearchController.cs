using JooleStore_DAL;
using JooleStore_Service;
using JooleStoreApp.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JooleStoreApp.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OnSearch(FormCollection form) 
        {
                TempData["subcategoryId"] = form["subcategory"];
                //getting subcategoryid from search page
                int subcategoryId = int.Parse(Request.Form["subcategory"]);
                Service service = new Service();
                List<Product> list = service.getSubcategoryProducts(subcategoryId);
                List<ProductM> prodList = new List<ProductM>();

                foreach (Product prod in list)
                {
                    Dictionary<string, List<Tuple<int, string, string>>> properties = service.GetProductProperties(prod.ProductId);

                    List<Tuple<int, string, string>> techSpec = properties["techSpec"];
                    List<Tuple<int, string, string>> typeProp = properties["type"];
                    List<PropertyViewM> techSpec1 = new List<PropertyViewM>();
                    List<PropertyViewM> typeProp1 = new List<PropertyViewM>();
                    foreach (Tuple<int, string, string> tup in techSpec)
                    {
                        PropertyViewM vm = new PropertyViewM { Id = tup.Item1, Name = tup.Item2, Value = tup.Item3 };
                        techSpec1.Add(vm);
                    }
                    foreach (Tuple<int, string, string> tup in typeProp)
                    {
                        PropertyViewM vm = new PropertyViewM { Id = tup.Item1, Name = tup.Item2, Value = tup.Item3 };
                        typeProp1.Add(vm);
                    }
                    ProductM newProd = new ProductM
                    {
                        ManufacturerId = prod.ManufacturerId,
                        ProductId = prod.ProductId,
                        ProductImage = prod.ProductImage,
                        ProductName = prod.ProductName,
                        Series = prod.Series,
                        Model = prod.Model,
                        ModelYear = prod.ModelYear,
                        SubcategoryId = prod.SubcategoryId,
                        techSpec = techSpec1,
                        typeProp = typeProp1
                    };
                    prodList.Add(newProd);
                }

                List<tblTypeRange> list2 = service.getFilterType(subcategoryId);
                List<tblTypeRangeM> listFilterType = new List<tblTypeRangeM>();
                foreach (tblTypeRange type in list2)
                {
                    tblTypeRangeM newTypeFilter = new tblTypeRangeM
                    {
                        TypeName = type.TypeName,
                        TypeOptions = type.TypeOptions.Split(',')
                    };
                    listFilterType.Add(newTypeFilter);
                }

                List<tblTechSpecRange> list3 = service.getFilterTechSpec(subcategoryId);
                List<tblTechSpecRangeM> listFilterTechSpec = new List<tblTechSpecRangeM>();
                foreach (tblTechSpecRange type in list3)
                {
                    string propertyName = service.GetPropertyNameById(type.PropertyId);
                    tblTechSpecRangeM newTechSpecFilter = new tblTechSpecRangeM
                    {
                        MinValue = type.MinValue,
                        MaxValue = type.MaxValue,
                        PropertyId = type.PropertyId,
                        PropertyName = propertyName
                    };
                    listFilterTechSpec.Add(newTechSpecFilter);
                }

            if (Request.Form["isFilter"] == null)
            {
                SearchResultViewModel viewModel = new SearchResultViewModel
                {
                    Products = prodList,
                    TechSpecFilterList = listFilterTechSpec,
                    TypeRangeFilterList = listFilterType
                };
                return View("SearchResult", viewModel);
            }
            else {
                List<int> toRemove = new List<int>();
                for(int i=0; i< prodList.Count();i++) 
                {
                    foreach(PropertyViewM prop in prodList[i].typeProp) 
                    {
                        System.Diagnostics.Debug.WriteLine("Property value: "+prop.Value);
                        System.Diagnostics.Debug.WriteLine("Value from the form: " + Request.Form[prop.Name]);
                        if (!Request.Form[prop.Name].Equals("All")) {
                            if (!prop.Value.Equals(Request.Form[prop.Name]))
                            {
                                toRemove.Add(i);
                                break;
                            }
                        }
                    }
                    foreach (PropertyViewM prop in prodList[i].techSpec) 
                    {
                        
                        System.Diagnostics.Debug.WriteLine("Property value: " + prop.Value);
                        System.Diagnostics.Debug.WriteLine("Value from the form: " + Request.Form[prop.Name]);
                        if (int.Parse(prop.Value) > int.Parse(Request.Form[prop.Name])) 
                        {
                            toRemove.Add(i);
                            break;
                        }
                    }
                }
                if (toRemove.Any())
                {

                    int offset = 0;
                    for (int j = 0; j < toRemove.Count(); j++)
                    {
                           int index = toRemove[j];
                            prodList.RemoveAt(index - offset);
                            offset++;
                        //System.Diagnostics.Debug.WriteLine(index);
                    }
                }
                SearchResultViewModel viewModel = new SearchResultViewModel
                {
                    Products = prodList,
                    TechSpecFilterList = listFilterTechSpec,
                    TypeRangeFilterList = listFilterType
                };
                return View("SearchResult", viewModel);
            }
                
           
        }

        public ActionResult Compare(int product1Id = 2, int product2Id = 3)
        {
            return RedirectToAction("CompareProduct", "CompareProduct", new { product1Id, product2Id });
        }
    }
}