using InterviewQuestions.ViewModel.framework;
using InterviewQuestions.ViewModel.Orders;

namespace InterviewQuestions.BLL
{
    public interface IOrdersBLL
    {
        BaseResponse GetOrder(OrderQueryViewModel order);
        BaseResponse PostOrder(OrderSearchViewModel order, string code);
    }
}