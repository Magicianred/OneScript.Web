﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using ScriptEngine.Machine.Contexts;

namespace OneScript.WebHost.Application
{
    [ContextClass("РезультатКомпонентаПредставление")]
    public class ViewComponentViewResult : IViewComponentResult
    {
        [ContextProperty("ИмяШаблона")]
        public string ViewName { get; set; }

        [ContextProperty("ДанныеПредставления")]
        public ViewDataDictionaryWrapper ViewData { get; set; }
        
        public void Execute(ViewComponentContext context)
        {
            var task = ExecuteAsync(context);
            task.GetAwaiter().GetResult();
        }

        public Task ExecuteAsync(ViewComponentContext context)
        {
            var result = new ViewViewComponentResult();
            result.ViewData = ViewData.GetDictionary();
            result.ViewName = ViewName;

            return result.ExecuteAsync(context);
        }
    }
}
