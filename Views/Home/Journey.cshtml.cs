using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace OBilet_Assignment.Views.Home
{
    public class Journey : PageModel
    {
        private readonly ILogger<Journey> _logger;

        public Journey(ILogger<Journey> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}