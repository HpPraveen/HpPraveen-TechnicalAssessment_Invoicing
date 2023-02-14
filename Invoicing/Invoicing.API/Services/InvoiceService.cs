using AutoMapper;
using Invoicing.API.Services.Interfaces;
using Invoicing.Domain.DTO;
using Invoicing.Infrastructure.UnitOfWork;

namespace Invoicing.API.Services
{
    internal class InvoiceService : IInvoiceService
    {
        private readonly IGenericUnitOfWork _genericUnitOfWork;
        private readonly IMapper _mapper;

        public InvoiceService(IGenericUnitOfWork genericUnitOfWork, IMapper mapper)
        {
            _genericUnitOfWork = genericUnitOfWork;
            _mapper = mapper;
        }

        public object CreateUpdateInvoice(InvoiceDto invoiceDto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteInvoice(string id)
        {
            throw new NotImplementedException();
        }

        public object GetInvoiceById(string id)
        {
            throw new NotImplementedException();
        }

        public object GetInvoices(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
