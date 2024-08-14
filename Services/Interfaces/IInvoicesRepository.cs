using CelsiaProject.Models;

namespace CelsiaProject.Services;

public interface IInvoicesRepository
{
    void AddInvoice(Invoice invoice);

    void UpdateInvoice(string id, Invoice invoice);

    void DeleteInvoice(string id);
}