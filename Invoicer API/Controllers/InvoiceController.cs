using Invoicer_API.Models;
using Invoicer_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Invoicer_API.Controllers;

public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _service;

    public InvoiceController(IInvoiceService service)
    {
        _service = service;
    }

    public async Task<ActionResult<Invoice>> Get()
    {
        throw new NotImplementedException();
    }
}
