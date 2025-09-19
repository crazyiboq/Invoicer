using Invoicer_API.Models;

namespace Invoicer_API.Services;

public class InvoiceServer : IInvoiceService
{
    public Task<Invoice> ArchiveInvoice()
    {
        throw new NotImplementedException();
    }

    public Task<Invoice> ChangeInvoiceStatus()
    {
        throw new NotImplementedException();
    }

    public Task<Invoice> CreateInvoice()
    {
        throw new NotImplementedException();
    }

    public Task<Invoice> DeleteInvoice()
    {
        throw new NotImplementedException();
    }

    public Task<Invoice> EditInvoice(Invoice editedInvoice)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Invoice>> GetInvoiceById()
    {
        throw new NotImplementedException();
    }

    public Task<Invoice> GetInvoiceList()
    {
        throw new NotImplementedException();
    }
}
