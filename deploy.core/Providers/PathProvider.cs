using System.IO;
using deploy.core.Providers.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace deploy.core.Providers
{
    public class PathProvider : IPathProvider
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PathProvider(IWebHostEnvironment hostingEnvironment) {
            _hostingEnvironment = hostingEnvironment;
        }

        public string MapPath(string path) {
            return Path.Combine(_hostingEnvironment.ContentRootPath, path);
        }
    }
}