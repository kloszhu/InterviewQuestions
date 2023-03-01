using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.ViewModel.framework
{
    public enum ReturnContentStatus
    {
        Exists = 204, Missing = 400, Created = 201,Data=200
    }
    public class BaseResponse
    {
        public ReturnContentStatus status { get; set; }
        public string content { get; set; }
        public object? data { get; set; }
        /// <summary>
        /// 204
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static BaseResponse Exists(string content) {
            return new BaseResponse { content = content, status = ReturnContentStatus.Exists };
        }
        /// <summary>
        /// 400
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static BaseResponse Missing(string content)
        {
            return new BaseResponse { content = content, status = ReturnContentStatus.Missing };
        }
        /// <summary>
        /// 201
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static BaseResponse Created(string content)
        {
            return new BaseResponse { content = content, status = ReturnContentStatus.Created };
        }

        public static BaseResponse Data(object data)
        {
            return new BaseResponse { data=data, status= ReturnContentStatus.Data };
        }

    }
}
