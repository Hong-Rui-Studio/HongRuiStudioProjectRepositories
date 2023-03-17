# 圣际宏原项目

## 1. 开发平台

.net 6 + EF Core + Sql Server 2014

## 2. 项目结构

| 项目名      | 原始练习项目的名字 | 说明               |
| ----------- | ------------------ | ------------------ |
| Entity      | Model              | 做数据库映射       |
| IRepository | IDAL               | 做数据访问层的接口 |
| Repository  | DAL                | 做数据访问层       |
| Commons     | Commons            | 做工具类库         |
| IServices   | IBLL               | 做业务逻辑接口     |
| Services    | BLL                | 做业务逻辑         |
| WebApp      | WebApp             | 做界面展示的       |

## 3. 开发流程

### 1. 先在Entity类库下引入EF Core

``` shell
install-package Microsoft.EntityFrameworkCore 
install-package Microsoft.EntityFrameworkCore.SqlServer
install-package Microsoft.EntityFrameworkCore.Tools
```

### 2. 前台数据库名字指明

| 序号 | 中文名           | 英文名                |
| ---- | ---------------- | --------------------- |
| 1    | 欢迎语           | WelcomeMsgs           |
| 2    | 联系我们         | Contacts              |
| 3    | 分店             | BranchStore           |
| 4    | 网站菜单（导航） | WebMenus              |
| 5    | 轮播图片         | Banners               |
| 6    | 企业优势         | Advantages            |
| 7    | 产品优势描述     | ProductAdvantages     |
| 8    | 产品优势详情     | ProductAdvantagesInfo |
| 9    | 案例展示         | Cases                 |
| 10   | 企业简介         | CompanyInfo           |
| 11   | 企业文化         | CompanyCultures       |
| 12   | 品牌理念         | Brand                 |
| 13   | 企业荣誉         | CompanyHonor          |
| 14   | 木窗文化         | WoodWindowCultures    |
| 15   | 木窗系统         | WoodWindowSystem      |
| 16   | 认证             | Authentications       |
| 17   | 产品配置类别     | ProductCategory       |
| 18   | 产品配置详情     | ProductCategoryInfo   |
| 19   | 提示消息         | Notices               |
| 20   | 新闻             | News                  |
| 21   | 友情链接         | FriendLink            |
| 22   | 销售网络         | SoleNets              |
| 23   | 技术体系         | TechnicalSystem       |
| 24   | 技术装备         | technicalEquipment    |
| 25   | 窗材类别         | WindowCategory        |
| 26   | 窗材详情         | WindowInfo            |
| 27   | 服务理念         | ServicesIdea          |
| 28   | 服务流程         | ServiceProcess        |
| 29   | 加盟优势         | FranchiseAdvantages   |
| 30   | 加盟标准         | JoiningStandard       |
| 31   | 加盟程序         | JoiningProgam         |
| 32   | 在线留言         | OnlineMsg             |
| 33   | 希望量尺时间     | MeasuringRulerTime    |
| 34   | 量尺房间         | MeasuringRulerHouse   |
| 35   | 装修阶段         | DecorationStage       |
| 36   | 装修类型         | DecorationCategory    |
| 37   | 户型             | HouseType             |
| 38   | 面积             | Areas                 |
| 39   | 在线下单         | Orders                |
| 40   | 身份表           | Roles                 |
| 41   | 管理员表         | Admins                |
| 42   | 系统菜单表       | SystemMenus           |
| 43   | 权限分配表       | AdminsPermission      |
| 44   | Seo优化表        | Seos                  |
| 45   | 版权信息表       | Copyright             |

