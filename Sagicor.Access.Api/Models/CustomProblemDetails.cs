using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Sagicor.Access.Api.Models
{
    public class CustomProblemDetails : ProblemDetails
    {
        //public bool Success { get; set; }
        //public string System { get; set; } = "Sagicor Access System API";
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
