# 运行环境
## net6.0 mysql 
# 使用插件
## Sqlsugar，Sqlsugar.IOC
# 配置修改
## 如果修改数据库，需要两步：
### 1.修改代码配置：
``` 
    InterviewQuestions.Migration\DBDependencyInjection.cs

        SugarIocServices.AddSqlSugar(new IocConfig()
            {
                //ConfigId="db01"  多租户用到
                ConnectionString = configuration.GetSection($"ConnectionString:{dbname}").Value,
                DbType = IocDbType.MySql,//数据库类型修改
                IsAutoCloseConnection = true//自动释放
            }) ; //多个库就传List<IocConfig>
```
### 2. 修改数据库连接：
InterviewQuestions.API/appsettings.json下
``` 
 "ConnectionString": {
    "defalut": "Data Source=localhost;User ID=tomorrow;Password=tomorrow;Database=tomorrow;Allow User Variables=True;Charset=utf8;"
  }
```
