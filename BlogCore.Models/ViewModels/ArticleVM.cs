using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Web.Mvc;

namespace BlogCore.Models.ViewModels
{
    public class ArticleVM
    {
        public Article Article {  get; set; }
        public IEnumerable<SelectListItem> ListaCategorias {  get; set; }
    }
}
