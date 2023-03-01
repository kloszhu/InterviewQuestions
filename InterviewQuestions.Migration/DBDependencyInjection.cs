using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Migration
{
    public static class DBDependencyInjection
    {
        public static void UseOrderDB_Mysql(this IServiceCollection services,IConfiguration configuration,string dbname="defalut" ) {


            // 10秒入门
            SugarIocServices.AddSqlSugar(new IocConfig()
            {
                //ConfigId="db01"  多租户用到
                ConnectionString = configuration.GetSection($"ConnectionString:{dbname}").Value,
                DbType = IocDbType.MySql,
                IsAutoCloseConnection = true//自动释放
            }) ; //多个库就传List<IocConfig>

            //配置参数
            SugarIocServices.ConfigurationSugar(db =>
            {
                db.Aop.OnLogExecuting = (sql, p) =>
                {
                    Console.WriteLine(sql);
                };
                //设置更多连接参数
                //db.CurrentConnectionConfig.XXXX=XXXX
                //db.CurrentConnectionConfig.MoreSettings=new ConnMoreSettings(){}
                //二级缓存设置
                //db.CurrentConnectionConfig.ConfigureExternalServices = new ConfigureExternalServices()
                //{
                // DataInfoCacheService = myCache //配置我们创建的缓存类
                //}
                //读写分离设置
                //laveConnectionConfigs = new List<SlaveConnectionConfig>(){...}

                /*多租户注意*/
                //单库是db.CurrentConnectionConfig 
                //多租户需要db.GetConnection(configId).CurrentConnectionConfig 
            });

            //CodeFirst请写这儿，与SugarIocServices.AddSqlSugar平级
            //DbScoped.SugarScope.CodeFirst<T>();
        }

        public static void UserOrderDB_Migration(this IServiceCollection services) {
            Type[] types = AppDomain.CurrentDomain.GetAssemblies().First(a=>a.FullName.StartsWith("InterviewQuestions.Migration"))
        .GetTypes().Where(it => it.FullName.Contains("InterviewQuestions.Migration.Entities"))//命名空间过滤，当然你也可以写其他条件过滤
        .ToArray();
            DbScoped.SugarScope.CodeFirst.InitTables(types);
        }
    }
}
