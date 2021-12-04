using MediatR;
using Dapper;
using System.Threading;
using System.Threading.Tasks;
using TriMania.Application.ShoppingContext.Queries.OrdersReport.Output;
using TriMania.Infra.Database;
using System.Collections.Generic;
using System.Linq;

namespace TriMania.Application.ShoppingContext.Queries.OrdersReport
{
    public class OrdersReportHandler : IRequestHandler<OrdersReportQuery, OrderReportDto>
    {
        private readonly IMySqlConnection _sqlConnectionFactory;

        public OrdersReportHandler(IMySqlConnection sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<OrderReportDto> Handle(OrdersReportQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.CreateNewConnection();

            var sql = @"SELECT 
                        c.OrderId as Id,
                        c.OrderId as Id,
                        b.Name as UserName, 
                        a.CreationDate as CreationDate, 
                        a.CancelDate as CancelDate, 
                        a.Status as Status, 
                        a.FinishedDate as FinishedDate, 
                        d.Name as Product, 
                        c.Price as Price, 
                        c.Quantity as Quantity
                        FROM trimania.Order a
                        INNER JOIN trimania.User b on a.UserId = b.Id
                        INNER JOIN trimania.OrderItem c on c.OrderId = a.Id
                        INNER JOIN trimania.Product d on c.ProductId = d.Id";

            var orderDictionary = new Dictionary<int, OrdersDto>();

            var orders = connection.Query<OrdersDto, ItemsDto, OrdersDto>(sql, (order, item) => {
                OrdersDto orderEntry;

                if (!orderDictionary.TryGetValue(order.Id, out orderEntry))
                {
                    orderEntry = order;
                    orderEntry.Items = new List<ItemsDto>();
                    orderDictionary.Add(orderEntry.Id, orderEntry);
                }

                orderEntry.Items.Add(item);
                return orderEntry;
            }, splitOn: "Id").Distinct().ToList();


            var totalSql = @"SELECT 
	                    sum(c.Price) as OrdersTotalValue, 
                        (select count(id) from trimania.Order where Status = 2) CancelledOrdersAmount, 
                        (select count(id) from trimania.Order where Status = 3) FinishedOrdersAmount
                    FROM trimania.Order a
                    INNER JOIN trimania.User b on a.UserId = b.Id
                    INNER JOIN trimania.OrderItem c on c.OrderId = a.Id
                    INNER JOIN trimania.Product d on c.ProductId = d.Id";

            var report = connection.QuerySingle<OrderReportDto>(totalSql);

            report.Orders = orders.AsList();

            return report;
        }
    }
}
