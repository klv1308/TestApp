using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Models;
using TestApp.Services;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IEnumerable<Order> Orders;

        public OrderController(IDataSource source) : base()
        {
            Orders = source.Data;            
        }

        // GET: api/<OrderController>
        [HttpGet]
        public PagedResponce<Order> Get([FromQuery] FilterModel filters)
        { 
            IEnumerable<Order> pData = Orders;
            if (!String.IsNullOrWhiteSpace(filters.Name))
                pData = pData.Where(c => c.Name.Contains(filters.Name, StringComparison.OrdinalIgnoreCase));
            if (filters.Category != null)
                pData = pData.Where(c => c.Category == filters.Category);
            if (filters.Number != null)
                pData = pData.Where(c => c.Number == filters.Number);

            var totalPages = Math.Ceiling((double)pData.Count() / filters.PageSize);
            pData = pData.Skip((filters.PageNumber - 1) * filters.PageSize)
                .Take(filters.PageSize);
            var responce = new PagedResponce<Order>(pData, filters.PageNumber, filters.PageSize);
            responce.PrevPage = filters.PageNumber <= 1 ? null : filters.PageNumber - 1;
            responce.NextPage = filters.PageNumber >= totalPages ? null : filters.PageNumber + 1;
        
            return responce;
        }       
    }
}
