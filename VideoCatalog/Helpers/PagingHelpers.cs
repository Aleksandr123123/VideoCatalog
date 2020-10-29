using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoCatalog.Helpers
{
    public static class PagingHelpers
    {
        public static IHtmlContent PageLinks(this IHtmlHelper html,
            PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            var asd = new TagBuilder("a");
            for (int i = pageInfo.PageNumber == 1 ? pageInfo.PageNumber : pageInfo.PageNumber - 1; i <= pageInfo.TotalPages && i <= pageInfo.PageNumber + 4; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml.Append(i.ToString());

                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default"); 
                asd.InnerHtml.AppendHtml(tag);
            }
            return asd;
        }
    }
}
