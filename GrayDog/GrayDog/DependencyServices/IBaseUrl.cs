using System;
using System.Collections.Generic;
using System.Text;

namespace GrayDog.DependencyServices
{
    public interface IBaseUrl
    {
        string Get();
        string GetHtml(string path);
    }
}
