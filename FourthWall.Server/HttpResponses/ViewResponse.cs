using System;
using System.IO;
using RazorEngine;
using RazorEngine.Templating;

namespace FourthWall.Server.HttpResponses
{
    public class ViewResponse : HtmlResponse
    {
        public ViewResponse(string viewName, object model = null): base(ParseView(viewName, model))
        {
            
        }

        private static string ParseView(string viewName, object model)
        {
            model = model ?? new {};
            const string viewPath = "C:\\Dev\\FourthWall\\FourthWall.Server\\Content\\Views\\";
            var fullPath = Path.Combine(viewPath, viewName);
            var template = File.ReadAllText(fullPath);
            var result = Engine.Razor.RunCompile(template, "templateKey", null, model);
            return result;
        }
    }
}