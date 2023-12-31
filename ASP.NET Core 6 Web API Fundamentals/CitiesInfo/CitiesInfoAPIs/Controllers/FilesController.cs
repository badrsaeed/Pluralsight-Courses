﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CitiesInfoAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ??
                throw new ArgumentNullException(nameof(_fileExtensionContentTypeProvider));
        }
        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            var filePath = "test.txt";
            if (!System.IO.File.Exists(filePath)) return NotFound();

            if(_fileExtensionContentTypeProvider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, contentType, Path.GetFileName(filePath));

        }
    }
}
