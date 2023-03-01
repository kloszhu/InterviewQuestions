using InterviewQuestions.Migration.Entities;
using InterviewQuestions.ViewModel.framework;
using InterviewQuestions.ViewModel.Orders;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using SqlSugar;
namespace InterviewQuestions.BLL
{



    public class OrdersBLL : IOrdersBLL
    {
        public BaseResponse PostOrder(OrderSearchViewModel order, string code)
        {



            //step.1 If any field is missing, reject it with a http status code 400.

            if (string.IsNullOrWhiteSpace(order.PurchaseOrderNumber))
            {
                return BaseResponse.Missing("No BillingZipCode.");
            }


            //step.2 If PurchaseOrderNumber exists in the database, return http status code 204
            if (DbScoped.Sugar.Queryable<OrdersEntity>().Any(a => a.PurchaseOrderNumber == order.PurchaseOrderNumber))
            {

                return BaseResponse.Exists("No BillingZipCode");
            }
            var entity = order.Adapt<OrdersEntity>();
            entity.code = code;
            DbScoped.Sugar.Insertable<OrdersEntity>(entity).ExecuteCommand();
            return BaseResponse.Created("Order is Created");
        }

        public BaseResponse GetOrder(OrderQueryViewModel order)
        {
            var query= DbScoped.Sugar.Queryable<OrdersEntity>();
            if (!string.IsNullOrEmpty(order.BuyerName))
            {
                query.Where(a => a.BuyerName == order.BuyerName);
            }
            if (!string.IsNullOrEmpty(order.PurchaseOrderNumber))
            {
                query.Where(a => a.PurchaseOrderNumber == order.PurchaseOrderNumber);
            }
            if (!string.IsNullOrEmpty(order.BillingZipCode))
            {
                query.Where(a => a.BillingZipCode == order.BillingZipCode);
            }


            return BaseResponse.Data(query.ToList());
        }

    }
}
