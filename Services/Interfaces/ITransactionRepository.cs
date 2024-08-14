using CelsiaProject.Models;

namespace CelsiaProject.Services;

public interface ITransactionRepository
{
    void AddTransaction(Transaction transaction);

    void UpdateTransaction(string id, Transaction transaction);

    void DeleteTransaction(string id);
}