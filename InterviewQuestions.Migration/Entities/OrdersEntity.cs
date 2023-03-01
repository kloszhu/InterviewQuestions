

using SqlSugar;

namespace InterviewQuestions.Migration.Entities
{
    [SugarTable("m_order")]
    public class OrdersEntity
    {
        [SugarColumn(ColumnName ="id",IsIdentity =true,IsPrimaryKey =true)]
        public int Id { get; set; }
        [SugarColumn(IsNullable = false, ColumnDataType = "varchar(255)")]
        public string BuyerName { get; set; }
        [SugarColumn(IsNullable = false, ColumnDataType = "varchar(255)")]
        public string PurchaseOrderNumber { get; set; }
        [SugarColumn(IsNullable = false, ColumnDataType = "varchar(255)")]
        public string BillingZipCode { get; set; }
        [SugarColumn(IsNullable =false)]
        public decimal OrderAmount { get; set; }
        [SugarColumn(IsNullable = false)]
        public string code { get; set; }

    }
}
