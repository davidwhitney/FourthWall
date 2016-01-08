using System;

namespace FourthWall.Server.HttpResponses
{
    public class RazorResponse : HtmlResponse
    {
        public RazorResponse(string viewName): base(ParseView(viewName))
        {
            
        }

        private static string ParseView(string viewName)
        {
            throw new NotImplementedException();
        }
    }
}