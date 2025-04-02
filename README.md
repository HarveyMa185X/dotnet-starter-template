# dotnet-starter-template



## 项目简介

个人自用的.NET后端开发模板，采用领域驱动设计(DDD)和命令查询职责分离(CQRS)模式，结合EF Core和Dapper实现高效的数据操作。
项目结构简洁易懂，适合.NET新手作为开发启动模板。

### 核心特性

- **领域驱动设计(DDD)** - 围绕业务领域构建系统，使代码更贴近业务需求
- **命令查询职责分离(CQRS)** - 分离读操作和写操作，优化各自的性能和扩展性
- **混合ORM策略** - 使用Dapper进行高效查询，EF Core进行便捷的写入操作
- **模块化设计** - 清晰的项目结构，便于维护和扩展

## 项目结构

```
GeneralDevelopmentTemplate
├── GDT.API                  # API层，提供HTTP接口
│   ├── Connected Services   # 外部服务连接
│   ├── Controllers          # API控制器
│   ├── Extensions           # API扩展方法
│   └── Filter               # API过滤器
│
├── GDT.Application          # 应用层，处理业务逻辑
│   ├── Commands             # 命令处理（写操作）
│   ├── DTOs                 # 数据传输对象
│   ├── Queries              # 查询处理（读操作）
│   └── Services             # 应用服务
│
├── GDT.Core                 # 核心层，包含共享组件
│   ├── Common               # 通用组件
│   ├── Exceptions           # 异常定义
│   └── Utils                # 工具类
│
├── GDT.Domain               # 领域层，包含业务规则和实体
│   ├── Aggregates           # 聚合根
│   ├── Events               # 领域事件
│   └── SeedWork             # 领域基础工作
│
└── GDT.Infrastructure       # 基础设施层，提供技术支持
    ├── Data                 # 数据访问
    ├── DependencyInjection  # 依赖注入配置
    └── Identity             # 身份认证
```

## 技术栈

- **.NET 8** - 最新的.NET平台
- **ASP.NET Core** - Web API框架
- **Entity Framework Core** - ORM框架，用于数据写入
- **Dapper** - 轻量级ORM，用于高效查询
- **MediatR** - 中介者模式实现，处理命令和查询
- **FluentValidation** - 请求验证
- **Serilog** - 结构化日志
- **Swagger/OpenAPI** - API文档

## 架构模式

### CQRS (命令查询职责分离)

项目采用CQRS模式将读操作和写操作分离：

- **Command (命令)** - 处理数据修改操作，使用EF Core进行数据写入
- **Query (查询)** - 处理数据查询操作，使用Dapper进行高效查询

### DDD (领域驱动设计)

通过DDD原则组织代码，主要体现在：

- **聚合根** - 在`Domain/Aggregates`中定义核心业务实体
- **领域事件** - 在`Domain/Events`中处理业务事件
- **值对象** - 确保领域模型的完整性和不变性

## 贡献指南

欢迎贡献代码、报告问题或提出改进建议。

## 许可证

[MIT License](LICENSE)