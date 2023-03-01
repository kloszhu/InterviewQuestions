using InterviewQuestions.ViewModel.framework;
using Microsoft.AspNetCore.Mvc;

namespace InterviewQuestions.API.Controllers
{
    public class BaseController : ControllerBase
    {
        public IActionResult Result(ReturnContentStatus status,string content)
        {
            return StatusCode((int)status, content);
        }

        public IActionResult Result(BaseResponse response) {
            if (response.status== ReturnContentStatus.Data)
            {
                return Ok(response.data);
            }
            return StatusCode((int)response.status, response.content);
        }
    }
}
