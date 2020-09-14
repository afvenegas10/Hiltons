using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hiltons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hilton.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(BookingController));

        [HttpGet]
        public async Task<Booking> GetAsync(int? limit)
        {
            log.Info("Hello logging world!");

            var response = new Booking
            {
                Date = DateTime.Now,
            };

            if(Request!=null && Request.Body != null)
            {
                using (var reader = new StreamReader(Request.Body))
                {
                    response.Request = await reader.ReadToEndAsync();
                }
            }           

            if (limit != null && limit > 0)
            {
                Random rnd = new Random();
                response.Response = rnd.Next(0, (int)limit).ToString();
            }
            else
            {
                response.Response = true.ToString();
            }

            return response;
        }
    }
}
