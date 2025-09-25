using Invoicer_API.DTOs;
using Invoicer_API.Enums;
using Invoicer_API.Models;
using Invoicer_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateInvoice([FromBody] CreateInvoiceRequest request)
    {
        try
        {
            var id = await _invoiceService.CreateInvoiceAsync(request);
            return Ok(id);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{invoiceId}/status")]
    public async Task<IActionResult> ChangeStatus(Guid invoiceId, [FromBody] InvoiceStatus newStatus)
    {
        var updatedInvoice = await _invoiceService.ChangeInvoiceStatusAsync(invoiceId, newStatus);
        return Ok(updatedInvoice);
    }

    [HttpDelete("{invoiceId}")]
    public async Task<IActionResult> Delete(Guid invoiceId)
    {
        var deleted = await _invoiceService.DeleteInvoiceAsync(invoiceId);

        if (!deleted)
            return NotFound($"Invoice with ID {invoiceId} not found.");

        return NoContent();
    }

    [HttpGet("{invoiceId}")]
    public async Task<IActionResult> GetById(Guid invoiceId)
    {
        var invoice = await _invoiceService.GetInvoiceByIdAsync(invoiceId);

        if (invoice == null)
            return NotFound($"Invoice with ID {invoiceId} not found.");

        return Ok(invoice);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var invoices = await _invoiceService.GetInvoiceListAsync();
        return Ok(invoices);

    }

    [HttpPut("{invoiceId}")]
    public async Task<IActionResult> EditInvoice(Guid invoiceId, [FromBody] Invoice editedInvoice)
    {
        if (invoiceId != editedInvoice.Id)
            return BadRequest("Invoice ID mismatch.");

        var updatedInvoice = await _invoiceService.EditInvoiceAsync(editedInvoice);

        if (updatedInvoice == null)
            return NotFound($"Invoice with ID {invoiceId} not found.");

        return Ok(updatedInvoice);
    }


    [HttpPut("{invoiceId}/archive")]
    public async Task<IActionResult> Archive(Guid invoiceId)
    {
        var archivedInvoice = await _invoiceService.ArchiveInvoiceAsync(invoiceId);

        if (archivedInvoice == null)
            return NotFound($"Invoice with ID {invoiceId} not found.");

        return Ok(archivedInvoice);
    }
}
