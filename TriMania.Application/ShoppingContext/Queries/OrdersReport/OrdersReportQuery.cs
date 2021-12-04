using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriMania.Application.ShoppingContext.Queries.OrdersReport.Output;
using TriMania.Domain.Shopping;

namespace TriMania.Application.ShoppingContext.Queries.OrdersReport
{
    public class OrdersReportQuery : IRequest<OrderReportDto>
    {
        public DateTime StartTerm { get; set; }
        public DateTime EndTerm { get; set; }
        public List<OrderStatus> Status { get; set; }
        public List<int> Users { get; set; }
    }
}
