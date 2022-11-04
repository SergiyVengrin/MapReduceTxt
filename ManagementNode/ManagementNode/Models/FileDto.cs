using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementNode.Models 
{ 
    public sealed class FileDto
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
