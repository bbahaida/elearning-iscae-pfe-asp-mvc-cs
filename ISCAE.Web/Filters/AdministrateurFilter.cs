﻿using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ISCAE.Web.Filters
{
    public class AdministrateurFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!(filterContext.RequestContext.HttpContext.Session["user"] is Administrateur))
            {
                if(filterContext.RequestContext.HttpContext.Session["user"] is Etudiant)
                {
                    filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "controller", "Etudiant" },
                    { "action", "Index" }
                });
                }
                else if (filterContext.RequestContext.HttpContext.Session["user"] is Professeur)
                {
                    filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "controller", "Professeur" },
                    { "action", "Index" }
                });
                }
                
            }
        }
    }
}