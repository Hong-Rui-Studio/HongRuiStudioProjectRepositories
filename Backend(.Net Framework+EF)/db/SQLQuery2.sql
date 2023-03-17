insert into Roles(Title,CreateTime,UpdateTime) values('超级管理员',GETDATE(),GETDATE())

insert into Users(RealName,BornDate,Gender,Email,Phone,Photo,Images,Pwd,RolesId,CreateTime,UpdateTime,QQNumber,WeChat)
values('Darcforst','1989-07-05',1,'admin@qq.com','15909811609','202301290959403485.jpg','202301290959403485_sm.jpg','0192023a7bbd73250516f069df18b500',1,GETDATE(),GETDATE(),'366624796','366624796')

insert into SystemMenus(Title,Link,Icons,ParentId,CreateTime,UpdateTime)
values('系统设置','#','lnr-cog',0,GETDATE(),GETDATE()),
('网站设置','#','lnr-earth',0,GETDATE(),GETDATE()),
('优化设置','#','lnr-cloud',0,GETDATE(),GETDATE()),
('版权设置','#','lnr-lock',0,GETDATE(),GETDATE()),
('身份信息管理','../../../Manager/RolesManager/List','',1,GETDATE(),GETDATE()),
('用户信息管理','../../../Manager/UsersManager/List','',1,GETDATE(),GETDATE()),
('用户权限分配管理','../../../Manager/UsersPermissionManager/List','',1,GETDATE(),GETDATE()),
('系统菜单管理','../../../Manager/SystemMenusManager/List','',1,GETDATE(),GETDATE()),
('网站菜单管理','../../../Manager/WebMenusManager/List','',2,GETDATE(),GETDATE()),
('Seo优化管理','../../../Manager/SeosManager/List','',3,GETDATE(),GETDATE()),
('友情链接管理','../../../Manager/FriendLinksManager/List','',3,GETDATE(),GETDATE()),
('版权信息管理','../../../Manager/CopyrightManager/Info','',4,GETDATE(),GETDATE())

select * from Roles
select * from SystemMenus

insert into UsersPermissions(RolesId,MenusId,CreateTime,UpdateTime)
values(1,1,GETDATE(),GETDATE()),
(1,2,GETDATE(),GETDATE()),
(1,3,GETDATE(),GETDATE()),
(1,4,GETDATE(),GETDATE()),
(1,5,GETDATE(),GETDATE()),
(1,6,GETDATE(),GETDATE()),
(1,7,GETDATE(),GETDATE()),
(1,8,GETDATE(),GETDATE()),
(1,9,GETDATE(),GETDATE()),
(1,10,GETDATE(),GETDATE()),
(1,11,GETDATE(),GETDATE()),
(1,12,GETDATE(),GETDATE())