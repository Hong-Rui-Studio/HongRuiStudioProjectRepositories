insert into Roles(Title,CreateTime,UpdateTime) values('��������Ա',GETDATE(),GETDATE())

insert into Users(RealName,BornDate,Gender,Email,Phone,Photo,Images,Pwd,RolesId,CreateTime,UpdateTime,QQNumber,WeChat)
values('Darcforst','1989-07-05',1,'admin@qq.com','15909811609','202301290959403485.jpg','202301290959403485_sm.jpg','0192023a7bbd73250516f069df18b500',1,GETDATE(),GETDATE(),'366624796','366624796')

insert into SystemMenus(Title,Link,Icons,ParentId,CreateTime,UpdateTime)
values('ϵͳ����','#','lnr-cog',0,GETDATE(),GETDATE()),
('��վ����','#','lnr-earth',0,GETDATE(),GETDATE()),
('�Ż�����','#','lnr-cloud',0,GETDATE(),GETDATE()),
('��Ȩ����','#','lnr-lock',0,GETDATE(),GETDATE()),
('�����Ϣ����','../../../Manager/RolesManager/List','',1,GETDATE(),GETDATE()),
('�û���Ϣ����','../../../Manager/UsersManager/List','',1,GETDATE(),GETDATE()),
('�û�Ȩ�޷������','../../../Manager/UsersPermissionManager/List','',1,GETDATE(),GETDATE()),
('ϵͳ�˵�����','../../../Manager/SystemMenusManager/List','',1,GETDATE(),GETDATE()),
('��վ�˵�����','../../../Manager/WebMenusManager/List','',2,GETDATE(),GETDATE()),
('Seo�Ż�����','../../../Manager/SeosManager/List','',3,GETDATE(),GETDATE()),
('�������ӹ���','../../../Manager/FriendLinksManager/List','',3,GETDATE(),GETDATE()),
('��Ȩ��Ϣ����','../../../Manager/CopyrightManager/Info','',4,GETDATE(),GETDATE())

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