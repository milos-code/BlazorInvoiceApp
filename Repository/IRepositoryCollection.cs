namespace BlazorInvoiceApp.Repository
{
    public interface IRepositoryCollection
    {
        IInvoiceRepository Invoice { get; }
        ICustomerRepository Customer { get; }
        IInvoiceTermsRepository InvoiceTerms { get; }
        IInvoiceLineItemRepository InvoiceLineItem { get; }

        Task<int> Save();
    }
}
