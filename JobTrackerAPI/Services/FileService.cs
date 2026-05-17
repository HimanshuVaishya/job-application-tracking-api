using JobTrackerAPI.Services.Interfaces;

namespace JobTrackerAPI.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;
        public FileService(IWebHostEnvironment environment)
        {
            this._environment = environment;
        }
        public async Task<string> SaveResumeAsync(IFormFile pFile)
        {
            if (pFile == null || pFile.Length == 0)
                throw new Exception("Resume is required");

            var allowedExtensions = new[] { ".pdf", ".doc", ".docx" };

            var extension = Path.GetExtension(pFile.FileName).ToLower();

            if (!allowedExtensions.Contains(extension))
                throw new Exception("Only PDF/DOC/DOCX files allowed");

            var uploadPath = Path.Combine(_environment.ContentRootPath, "Uploads", "Resumes");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var fileName = $"{Guid.NewGuid()}_{pFile.FileName}";

            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await pFile.CopyToAsync(stream);
            }

            return $"Uploads/Resumes/{fileName}";
        }
    }
}
