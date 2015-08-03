网站配置说明：
1.数据库需使用SQLServer2005以上
2.网站基于dotNETFramework2.0
3.如果index.html不是默认页面，需要在默认文档上添加index.html页面为默认文档
4.配置数据库时，修改配置文件中的连接字符串，connectionStrings节点下，Data Source设置为数据库服务器名称，Initial Catalog为数据库名称，
	默认是windows认证，如果使用sqlserver认证，需要在配置文件中去掉“Integrated Security=True”，并加上“uid=连接用户名;pwd=用户名对应密码”
5.数据库表创建：
	tabUser:用户表
			CREATE TABLE [dbo].[tabUser] (
				[userId]       INT            IDENTITY (1, 1) NOT NULL,
				[userName]     NVARCHAR (32)  NOT NULL,
				[userPassword] NVARCHAR (MAX) NULL,
				[addTime]      DATETIME       NULL,
				[isAdmin]      BIT            DEFAULT ((0)) NULL,
				PRIMARY KEY CLUSTERED ([userId] ASC)
			);

	tabItem: 作品表
			CREATE TABLE [dbo].[tabItem] (
				[itemId]        INT            IDENTITY (1, 1) NOT NULL,
				[itemName]      NVARCHAR (64)  NULL,
				[itemTypeId]    INT            NOT NULL,
				[itemAuthor]    NVARCHAR (64)  NULL,
				[itemDesc]      NVARCHAR (MAX) NULL,
				[itemPath]      NVARCHAR (MAX) NULL,
				[itemImagePath] NVARCHAR (MAX) NULL,
				[publishTime]   DATETIME       NULL,
				PRIMARY KEY CLUSTERED ([itemId] ASC)
			);

	tabCategory: 类别表
				CREATE TABLE [dbo].[tabCategory] (
					[categoryId]   INT            IDENTITY (1, 1) NOT NULL,
					[categoryName] NVARCHAR (MAX) NOT NULL,
					PRIMARY KEY CLUSTERED ([categoryId] ASC)
				);

6.添加管理员，用户表中首先添加一个数据，设置为总管理员，之后登录可以创建其他管理员，总管理员需要设置isAdmin字段为True（只有总管理员才可以添加其他管理员），用户的密码经过加密
			Admin888	   ----     对应的密码：957022623731639422188220244151638718844

7.添加类别，在表中直接添加或者在后台添加，由于前台js已经写死，所以要保证表中数据按以下呈现
		categoryId	categoryName
			1		山水
			2		人物
			3		花鸟
8.检查网站根目录是否有upload和works目录，并且upload目录下还需要有small和thumb目录，并要设置文件夹的权限为最高，因为在程序运行的过程中，要在这几个文件夹保存新文件，需要有足够的权限
9.在网站根目录下添加一个 servererror.log的文件，并设置权限为最高，至少为可修改（此文件用户记录网站错误日志）
