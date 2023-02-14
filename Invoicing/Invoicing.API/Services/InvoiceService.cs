﻿using AutoMapper;
using Invoicing.API.Services.Interfaces;
using Invoicing.Domain;
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

        public object GetInvoiceById(string id)
        {
            var invoiceDetails = _genericUnitOfWork.InvoiceRepository.Get(i => i.Id == id, includeProperties: "InvoiceLines").FirstOrDefault();
            return _mapper.Map<InvoiceDto>(invoiceDetails);
        }

        public object GetInvoices(int pageNumber, int pageSize)
        {
            static IOrderedQueryable<Invoice> OrderBy(IQueryable<Invoice> o) => o.OrderByDescending(i => i.SysCreatedOn);

            var invoices = _genericUnitOfWork.InvoiceRepository.GetPaging(
                includeProperties: "InvoiceLines", orderBy: OrderBy, pageNumber: pageNumber, pageSize: pageSize);

            var response = (ResponseDto)invoices;
            var totalInvoices = response.TotalRecords;
            var invoiceDto = _mapper.Map<List<InvoiceDto>>(response.Result);
            var responseResult = PaginationHelper.CreatePageResponse(invoiceDto, pageNumber, pageSize, totalInvoices, null);
            return responseResult;
        }

        public object CreateUpdateInvoice(InvoiceDto invoiceDto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteInvoice(string id)
        {
            throw new NotImplementedException();
        }

    }
}
