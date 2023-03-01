
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewQuestions.BLL
{
    public static class BllDependencyInjection
    {
        public static void AddBLL(this IServiceCollection services) {
            //inject mapster
            var config = new TypeAdapterConfig();
            // var config = TypeAdapterConfig.GlobalSettings;
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            services.AddScoped<IOrdersBLL, OrdersBLL>();
        }
    }
}