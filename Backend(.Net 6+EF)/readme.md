# 1. 简介

该项目是宏睿游戏工作室后台框架.net 6版本，主要是为了方便之后书写mvc项目，能够大量的重新应用。

# 2. 数据库设计

### （1）身份表（Roles）

| 列名       | 中文名   | 数据类型     | 描述               |
| ---------- | -------- | ------------ | ------------------ |
| Id         | 编号     | Guid         | 主键               |
| Title      | 身份名称 | nvarchar(50) | 非空               |
| CreateTime | 创建时间 | datetime     | 非空，默认当前时间 |
| UpdateTime | 修改时间 | datetime     | 非空，默认当前时间 |

### （2）用户表（Users）

| 列名       | 中文名   | 数据类型     | 描述               |
| ---------- | -------- | ------------ | ------------------ |
| Id         | 编号     | Guid         | 主键               |
| RealName   | 真实姓名 | nvarchar(50) | 非空               |
| BornDate   | 出生日期 | date         | 非空               |
| Gender     | 性别     | int          | 非空               |
| Email      | 邮箱地址 | varchar(50)  | 非空               |
| Phone      | 联系电话 | varchar(50)  | 非空               |
| Pass       | 用户密码 | varchar(50)  | 非空               |
| QQNum      | QQ号码   | varchar(50)  | 非空               |
| WeChat     | 微信号   | varchar(50)  | 非空               |
| Photo      | 头像     | varchar(50)  | 非空               |
| Images     | 小头像   | varchar(50)  | 非空               |
| Address    | 家庭住址 | varchar(50)  |                    |
| RolesId    | 身份编号 | Guid         | 非空               |
| CreateTime | 创建时间 | datetime     | 非空，默认当前时间 |
| UpdateTime | 修改时间 | datetime     | 非空，默认当前时间 |

### （3）系统菜单表（SystemMenus）

| 列名       | 中文名       | 数据类型     | 描述               |
| ---------- | ------------ | ------------ | ------------------ |
| Id         | 编号         | Guid         | 主键               |
| Title      | 菜单名称     | nvarchar(50) | 非空               |
| Link       | 菜单连接     | varchar(50)  | 非空               |
| Icons      | 菜单图标     | varchar(50)  |                    |
| ParentId   | 父级菜单编号 | Guid         | 非空               |
| CreateTime | 创建时间     | datetime     | 非空，默认当前时间 |
| UpdateTime | 修改时间     | datetime     | 非空，默认当前时间 |

### （4）权限分配表（UsersPermission）

| 列名       | 中文名       | 数据类型 | 描述               |
| ---------- | ------------ | -------- | ------------------ |
| Id         | 编号         | Guid     | 主键               |
| RolesId    | 身份编号     | Guid     | 非空               |
| MenusId    | 系统菜单编号 | Guid     | 非空               |
| CreateTime | 创建时间     | datetime | 非空，默认当前时间 |
| UpdateTime | 修改时间     | datetime | 非空，默认当前时间 |

### （5）网站菜单表（WebMenus）

| 列名       | 中文名       | 数据类型     | 描述               |
| ---------- | ------------ | ------------ | ------------------ |
| Id         | 编号         | Guid         | 主键               |
| Title      | 网站菜单名称 | nvarchar(50) | 非空               |
| Link       | 网站菜单连接 | varcahr(50)  | 非空               |
| Icons      | 网站菜单图标 | varchar(50)  |                    |
| ParentId   | 父级菜单编号 | Guid         | 非空               |
| CreateTime | 创建时间     | datetime     | 非空，默认当前时间 |
| UpdateTime | 修改时间     | datetime     | 非空，默认当前时间 |

### （6）Seo优化表（Seos）

| 列名        | 中文名     | 数据类型       | 描述               |
| ----------- | ---------- | -------------- | ------------------ |
| Id          | 编号       | Guid           | 主键               |
| Title       | 网站名称   | nvarchar(50)   | 非空               |
| Keyword     | 优化关键字 | nvarchar(500)  | 非空               |
| Description | 优化描述   | nvarchar(2000) | 非空               |
| MenusId     | 网站编号   | Guid           | 非空               |
| CreateTime  | 创建时间   | datetime       | 非空，默认当前时间 |
| UpdateTime  | 修改时间   | datetime       | 非空，默认当前时间 |

### （7）友情链接（FriendLinks）

| 列名       | 中文名       | 数据类型     | 描述               |
| ---------- | ------------ | ------------ | ------------------ |
| Id         | 编号         | Guid         | 主键               |
| Title      | 友情链接名称 | nvarchar(50) | 非空               |
| Link       | 链接路径     | varchar(50)  | 非空               |
| IsShow     | 是否显示     | bit          | 非空               |
| CreateTime | 创建时间     | datetime     | 非空，默认当前时间 |
| UpdateTime | 修改时间     | datetime     | 非空，默认当前时间 |

### （8）版权信息表（Copyright）

| 列名       | 中文名     | 数据类型       | 描述               |
| ---------- | ---------- | -------------- | ------------------ |
| Id         | 编号       | Guid           | 主键               |
| Title      | 版权名称   | nvarchar(50)   |                    |
| Content    | 版权内容   | nvarchar(2000) |                    |
| Phone      | 联系电话   | varchar(50)    |                    |
| Tel        | 座机       | varchar(50)    |                    |
| Address    | 联系地址   | varchar(50)    |                    |
| Photo      | 版权图片   | varchar(50)    |                    |
| Images     | 版权图片2  | varchar(50)    |                    |
| Logo       | Logo图片   | varchar(50)    |                    |
| SmallLogo  | 小logo图片 | varchar(50)    |                    |
| Email      | 邮件地址   | varchar(50)    |                    |
| Remark1    | 备注1      | nvarchar(2000) |                    |
| Remark2    | 备注2      | nvarchar(2000) |                    |
| CreateTime | 创建时间   | datetime       | 非空，默认当前时间 |
| UpdateTime | 修改时间   | datetime       | 非空，默认当前时间 |