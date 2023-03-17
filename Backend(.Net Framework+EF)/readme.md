# 1. 简介

当前项目是宏睿软件工作室的后台系统源码，为了方便后面开发一些其他的项目，所以这个里面我们只保留了基础的后台表。如果需要一些前台的功能，需要自己添加。

# 2. 基础表如下：

## 1.身份表(Roles)

| 列名       | 中文名   | 数据类型    | 说明         |
| ---------- | -------- | ----------- | ------------ |
| Id         | 编号     | int         | 主键，自增长 |
| Title      | 身份名称 | varchar(50) | 非空，唯一   |
| CreateTime | 创建时间 | datetime    | 默认当前时间 |
| UpdateTime | 修改时间 | datetime    | 默认当前时间 |

## 2. 用户表（Users）

| 列名       | 中文名   | 数据类型    | 说明         |
| ---------- | -------- | ----------- | ------------ |
| Id         | 编号     | int         | 主键，自增长 |
| RealName   | 真实姓名 | varchar(50) | 非空         |
| BornDate   | 出生日期 | date        | 非空         |
| Gender     | 性别     | int         | 非空         |
| Email      | 邮箱地址 | varchar(50) | 非空         |
| Phone      | 联系电话 | varchar(50) | 非空         |
| Pwd        | 登入密码 | varcahr(50) | 非空         |
| QQNumber   | QQ号码   | varchar(50) | 非空         |
| WeChat     | 微信号码 | varchar(50) | 非空         |
| Photo      | 头像     | varchar(50) | 非空         |
| Images     | 小头像   | varchar(50) | 非空         |
| RolesId    | 身份编号 | int         | 外键，非空   |
| CreateTime | 创建时间 | datetime    | 默认当前时间 |
| UpdateTime | 修改时间 | datetime    | 默认当前时间 |

## 3. 系统菜单表（SystemMenus）

| 列名       | 中文名       | 数据类型    | 说明         |
| ---------- | ------------ | ----------- | ------------ |
| Id         | 编号         | int         | 主键，自增长 |
| Title      | 菜单名称     | varchar(50) | 非空         |
| Link       | 菜单链接     | varchar(50) | 非空         |
| Icons      | 菜单图标     | varchar(50) | 非空         |
| ParentId   | 父级菜单编号 | int         | 非空         |
| CreateTime | 创建时间     | datetime    | 默认当前时间 |
| UpdateTime | 修改时间     | datetime    | 默认当前时间 |

## 4. 权限分配表(UsersPermission)

| 列名       | 中文名       | 数据类型 | 说明         |
| ---------- | ------------ | -------- | ------------ |
| Id         | 编号         | int      | 主键，自增长 |
| RolesId    | 权限编号     | int      | 外键，非空   |
| MenusId    | 系统菜单编号 | int      | 外键，非空   |
| CreateTime | 创建时间     | datetime | 默认当前时间 |
| UpdateTime | 修改时间     | datetime | 默认当前时间 |

## 5. 版权信息表（Copyright）

| 列名       | 中文名     | 数据类型       | 说明         |
| ---------- | ---------- | -------------- | ------------ |
| Id         | 编号       | int            | 主键，自增长 |
| Title      | 版权名称   | nvarchar(50)   |              |
| Content    | 版权内容   | nvarchar(2000) |              |
| Phone      | 联系电话   | nvarchar(50)   |              |
| Tel        | 手机号     | nvarchar(50)   |              |
| Address    | 家庭住址   | nvarchar(50)   |              |
| Photo      | 版权图片   | nvarchar(50)   |              |
| Images     | 图篇       | nvarchar(50)   |              |
| Logo       | Logo图片   | nvarchar(50)   |              |
| SmallLogo  | 小Logo图片 | nvarcahr(50)   |              |
| Remark1    | 备注1      | nvarchar(2000) |              |
| Remark2    | 备注2      | nvarchar(2000) |              |
| CreateTime | 创建时间   | datetime       | 默认当前时间 |
| UpdateTime | 修改时间   | datetime       | 默认当前时间 |

## 6. 网站菜单表（WebMenus）

| 列名       | 中文名       | 数据类型    | 说明         |
| ---------- | ------------ | ----------- | ------------ |
| Id         | 编号         | int         | 主键，自增长 |
| Title      | 菜单名称     | varchar(50) | 非空         |
| Link       | 菜单链接     | varchar(50) | 非空         |
| Icons      | 菜单图标     | varchar(50) | 非空         |
| ParentId   | 父级菜单编号 | int         | 非空         |
| CreateTime | 创建时间     | datetime    | 默认当前时间 |
| UpdateTime | 修改时间     | datetime    | 默认当前时间 |

## 7. Seo优化表（Seos）

| 列名        | 中文名       | 数据类型       | 说明         |
| ----------- | ------------ | -------------- | ------------ |
| Id          | 编号         | int            | 主键，自增长 |
| Title       | 优化名称     | nvarchar(50)   | 非空         |
| Keyword     | 优化关键字   | nvarchar(500)  | 非空         |
| Description | 优化描述     | nvarchar(2000) | 非空         |
| MenusId     | 网站菜单编号 | int            | 非空         |
| CreateTime  | 创建时间     | datetime       | 默认当前时间 |
| UpdateTime  | 修改时间     | datetime       | 默认当前时间 |

## 8. 友情链接表（FriendLinks）

| 列名       | 中文名   | 数据类型      | 说明         |
| ---------- | -------- | ------------- | ------------ |
| Id         | 编号     | int           | 主键，自增长 |
| Title      | 链接名称 | nvarchar(50)  | 非空         |
| Link       | 链接路径 | varchar(2000) | 非空         |
| IsShow     | 是否展示 | int           | 非空         |
| CreateTime | 创建时间 | datetime      | 默认当前时间 |
| UpdateTime | 修改时间 | datetime      | 默认当前时间 |
