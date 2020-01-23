using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileListingProject.Web.Models
{
    public class DataTablesAjaxRequestModel
    {
        private HttpRequest _request;

        private int Start
        {
            get
            {
                return Convert.ToInt32(_request.Query["start"]);
            }
        }
        public int Length
        {
            get
            {
                return Convert.ToInt32(_request.Query["length"]);
            }
        }

        public string SearchText
        {
            get
            {
                return _request.Query["search[value]"];
            }
        }

        public int sortingCols;

        public DataTablesAjaxRequestModel(HttpRequest request)
        {
            _request = request;
        }

        public int PageIndex
        {
            get
            {
                if (Length > 0)
                    return (Start / Length) + 1;
                else
                    return 1;
            }
        }

        public int PageSize
        {
            get
            {
                if (Length == 0)
                    return 10;
                else
                    return Length;
            }
        }

        public static object EmptyResult
        {
            get
            {
                return new
                {
                    draw = 1,
                    recordsTotal = 0,
                    recordsFiltered = 0,
                    data = (new string[] { }).ToArray()
                };
            }
        }

        //public ICollection<SortElement> GetSortElements(string[] columnNames)
        //{
        //    ICollection<SortElement> sortItems = new List<SortElement>();

        //    for (int i = 0; i < iSortingCols; i++)
        //    {
        //        int colIndex = 0;
        //        int.TryParse(HttpContext.Current.Request["iSortCol_" + i], out colIndex);
        //        if (HttpContext.Current.Request["bSortable_" + colIndex] == "true")
        //        {
        //            sortItems.Add(new SortElement(columnNames[colIndex],
        //                HttpContext.Current.Request["sSortDir_" + i] == "asc" ? SortOrder.Ascending : SortOrder.Descending));
        //        }
        //    }
        //    return sortItems;
        //}

        //public string GetSortText(string[] columnNames)
        //{
        //    StringBuilder sortText = new StringBuilder();
        //    for (int i = 0; i < iSortingCols; i++)
        //    {
        //        int colIndex = 0;
        //        int.TryParse(HttpContext.Current.Request["iSortCol_" + i], out colIndex);
        //        if (HttpContext.Current.Request["bSortable_" + colIndex] == "true")
        //        {
        //            sortText.Append(columnNames[colIndex]).Append(" ")
        //                .Append(HttpContext.Current.Request["sSortDir_" + i]).Append(" ");
        //        }
        //    }
        //    return sortText.ToString();
        //}    
    }
}
