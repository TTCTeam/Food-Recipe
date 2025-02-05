USE [master]
GO
/****** Object:  Database [FoodRecipes]    Script Date: 10/31/2020 4:13:14 PM ******/
CREATE DATABASE [FoodRecipes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FoodRecipes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FoodRecipes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FoodRecipes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FoodRecipes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FoodRecipes] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FoodRecipes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FoodRecipes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FoodRecipes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FoodRecipes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FoodRecipes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FoodRecipes] SET ARITHABORT OFF 
GO
ALTER DATABASE [FoodRecipes] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FoodRecipes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FoodRecipes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FoodRecipes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FoodRecipes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FoodRecipes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FoodRecipes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FoodRecipes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FoodRecipes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FoodRecipes] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FoodRecipes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FoodRecipes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FoodRecipes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FoodRecipes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FoodRecipes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FoodRecipes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FoodRecipes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FoodRecipes] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FoodRecipes] SET  MULTI_USER 
GO
ALTER DATABASE [FoodRecipes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FoodRecipes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FoodRecipes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FoodRecipes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FoodRecipes] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FoodRecipes] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FoodRecipes] SET QUERY_STORE = OFF
GO
USE [FoodRecipes]
GO
/****** Object:  FullTextCatalog [SearchFoodName]    Script Date: 10/31/2020 4:13:15 PM ******/
CREATE FULLTEXT CATALOG [SearchFoodName] WITH ACCENT_SENSITIVITY = OFF
GO
/****** Object:  Table [dbo].[FOOD]    Script Date: 10/31/2020 4:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FOOD](
	[FoodID] [int] NOT NULL,
	[FoodName] [nvarchar](50) NOT NULL,
	[CreateDate] [date] NULL,
	[IsFavor] [bit] NULL,
	[Type] [nvarchar](50) NULL,
	[Area] [nvarchar](50) NULL,
	[Ration] [tinyint] NULL,
 CONSTRAINT [PK_FOOD] PRIMARY KEY CLUSTERED 
(
	[FoodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FOODIMAGE]    Script Date: 10/31/2020 4:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FOODIMAGE](
	[FoodID] [int] NOT NULL,
	[Step] [tinyint] NOT NULL,
	[Ordinal] [tinyint] NOT NULL,
	[ImagePath] [nvarchar](200) NULL,
 CONSTRAINT [PK_FOODIMAGE] PRIMARY KEY CLUSTERED 
(
	[FoodID] ASC,
	[Step] ASC,
	[Ordinal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INGREDIENT]    Script Date: 10/31/2020 4:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INGREDIENT](
	[FoodID] [int] NOT NULL,
	[IngredientName] [nvarchar](50) NOT NULL,
	[Amount] [decimal](10, 2) NULL,
	[Unit] [nvarchar](20) NULL,
 CONSTRAINT [PK_INGREDIENT] PRIMARY KEY CLUSTERED 
(
	[FoodID] ASC,
	[IngredientName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RECIPE]    Script Date: 10/31/2020 4:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RECIPE](
	[FoodID] [int] NOT NULL,
	[Step] [tinyint] NOT NULL,
	[Content] [nvarchar](1000) NULL,
 CONSTRAINT [PK_RECIPE] PRIMARY KEY CLUSTERED 
(
	[FoodID] ASC,
	[Step] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[FOOD] ([FoodID], [FoodName], [CreateDate], [IsFavor], [Type], [Area], [Ration]) VALUES (1, N'Bánh Bột Lọc Trần Nhân Tôm', CAST(N'2020-10-24' AS Date), 0, N'Bánh', N'Miền Trung', 4)
INSERT [dbo].[FOOD] ([FoodID], [FoodName], [CreateDate], [IsFavor], [Type], [Area], [Ration]) VALUES (2, N'Cơm hến', CAST(N'2020-10-24' AS Date), 0, N'Cơm', N'Miền Trung', 4)
INSERT [dbo].[FOOD] ([FoodID], [FoodName], [CreateDate], [IsFavor], [Type], [Area], [Ration]) VALUES (3, N'Bánh xèo', CAST(N'2020-10-30' AS Date), 1, N'Bánh', N'Miền Nam', 2)
GO
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (1, N'Bột năng', CAST(200.00 AS Decimal(10, 2)), N'gr')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (1, N'Dầu ăn', CAST(1.00 AS Decimal(10, 2)), N'muỗng canh')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (1, N'Đường trắng', CAST(5.00 AS Decimal(10, 2)), N'muỗng canh')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (1, N'Hành lá', CAST(50.00 AS Decimal(10, 2)), N'gr')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (1, N'Hành tím băm', CAST(1.00 AS Decimal(10, 2)), N'muỗng cà phê')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (1, N'Hạt nêm', CAST(0.50 AS Decimal(10, 2)), N'muỗng cà phê')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (1, N'Muối', CAST(0.50 AS Decimal(10, 2)), N'muỗng cà phê')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (1, N'Nước mắm', CAST(4.00 AS Decimal(10, 2)), N'muỗng canh')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (1, N'Ớt băm', CAST(1.00 AS Decimal(10, 2)), N'muỗng cà phê')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (1, N'Tỏi băm', CAST(1.00 AS Decimal(10, 2)), N'muỗng cà phê')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (1, N'Tôm tươi', CAST(150.00 AS Decimal(10, 2)), N'gr')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Bắp chuối', CAST(60.00 AS Decimal(10, 2)), N'gr')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Bột ngọt', CAST(0.50 AS Decimal(10, 2)), N'muỗng canh')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Cơm nguội', CAST(450.00 AS Decimal(10, 2)), N'gr')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Da heo', CAST(50.00 AS Decimal(10, 2)), N'gr')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Dầu ăn', CAST(4.00 AS Decimal(10, 2)), N'muỗng canh')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Dầu điều', CAST(2.00 AS Decimal(10, 2)), N'muỗng canh')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Đậu phộng', CAST(80.00 AS Decimal(10, 2)), N'gr')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Dọc mùng', CAST(60.00 AS Decimal(10, 2)), N'gr')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Đường trắng', CAST(0.50 AS Decimal(10, 2)), N'muỗng canh')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Giá đỗ', CAST(60.00 AS Decimal(10, 2)), N'gr')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Gừng', CAST(5.00 AS Decimal(10, 2)), N'gr')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Hành tím', CAST(10.00 AS Decimal(10, 2)), N'gr')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Hạt nêm', CAST(0.50 AS Decimal(10, 2)), N'muỗng canh')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Hến', CAST(2.00 AS Decimal(10, 2)), N'kg')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Húng lũi', CAST(50.00 AS Decimal(10, 2)), N'gr')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Mắm ruốc', CAST(2.00 AS Decimal(10, 2)), N'muỗng canh')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Ngò rí', CAST(30.00 AS Decimal(10, 2)), N'gr')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Nước mắm', CAST(1.00 AS Decimal(10, 2)), N'muỗng canh')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Ớt', CAST(5.00 AS Decimal(10, 2)), N'gr')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Rau má', CAST(50.00 AS Decimal(10, 2)), N'gr')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Tiêu', CAST(0.50 AS Decimal(10, 2)), N'muỗng canh')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Tỏi', CAST(10.00 AS Decimal(10, 2)), N'gr')
INSERT [dbo].[INGREDIENT] ([FoodID], [IngredientName], [Amount], [Unit]) VALUES (2, N'Xoài xanh', CAST(60.00 AS Decimal(10, 2)), N'gr')
GO
INSERT [dbo].[RECIPE] ([FoodID], [Step], [Content]) VALUES (1, 0, N'Bánh Bột Lọc Trần Nhân Tôm là món ăn ngon nổi tiếng của ẩm thực Huế. Cách làm bánh bột lọc nhân tôm ngon có vỏ bánh trong suốt và dẻo dai, bao lấy phần nhân tôm đậm đà, chấm ăn cùng nước mắm mặn ngọt, cay thơm hấp dẫn. Đặc biệt, cách làm bánh bột lọc nhân tôm đơn giản này của Cooky giúp bạn vừa có món ăn ngon an toàn sức khỏe, vừa tiết kiệm nữa đấy.')
INSERT [dbo].[RECIPE] ([FoodID], [Step], [Content]) VALUES (1, 1, N'Cách làm bánh bột lọc: Đun sôi 300ml nước, cho 1 muỗng canh dầu ăn và 1/2 muỗng cà phê muối vào. Cho từ từ hỗn hợp nước sôi vào 200gr bột năng khuấy đều, trộn và nhồi đến khi nào khối bột hòa quyện không dính tay thì dừng lại.')
INSERT [dbo].[RECIPE] ([FoodID], [Step], [Content]) VALUES (1, 2, N'Trải bột ra cho đều trên giấy nến rồi cán thật mỏng, khoảng 1mm. Dùng khuôn cắt bột thành những hình tròn đều nhau.')
INSERT [dbo].[RECIPE] ([FoodID], [Step], [Content]) VALUES (1, 3, N'Làm nhân bánh bột lọc ngon: Xào 150gr tôm đất với 1 muỗng canh dầu ăn cùng với 1 muỗng cà phê hành tím, 1 muỗng cà phê tỏi băm và 1 muỗng cà phê hạt nêm khoảng 5 phút cho tôm chín.')
INSERT [dbo].[RECIPE] ([FoodID], [Step], [Content]) VALUES (1, 4, N'Cách gói bánh bột lọc: Đặt nhân tôm vào giữa miếng bột, xếp đôi lại rồi bóp chặt ở viền mép bột để nhân không bị rơi ra.')
INSERT [dbo].[RECIPE] ([FoodID], [Step], [Content]) VALUES (1, 5, N'Luộc bánh bột lọc nhân tôm với nước sôi có 1 muỗng canh dầu, sau 3 phút thấy bánh bột lọc nổi lên thì vớt bánh ra đặt vào tô nước đá 2 phút rồi lấy ra. Nước đá sẽ giúp bánh bột lọc trong và dai hơn.')
INSERT [dbo].[RECIPE] ([FoodID], [Step], [Content]) VALUES (1, 6, N'Pha nước chấm bánh bột lọc nhân tôm: Đun 50ml nước với 5 muỗng canh đường cho tan rồi thêm 4 muỗng canh nước mắm và 1 muỗng cà phê ớt băm. Khuấy đều cho hỗn hợp tan rồi tắt bếp là ta đã có chén nước mắm chấm cay ngọt và sệt.')
INSERT [dbo].[RECIPE] ([FoodID], [Step], [Content]) VALUES (1, 7, N'Bánh bột lọc nhân tôm xứ Huế dọn ra ăn kèm với mỡ hành, hành phi và nước mắm mặn ngọt, cay thơm. Vỏ bánh bột lọc dai dai, nhân tôm giòn sần sật sẽ khiến bạn muốn ăn mãi không dừng. Với cách làm bánh bột lọc trần nhân tôm đơn giản từ Cooky, bạn còn ngại gì không làm ngay bánh bột lọc trần nhân tôm ngay nào. Bánh bột lọc nên dùng lúc còn ấm ấm ngon hơn hẳn. Có thể bảo quản bánh bột lọc nhân tôm (đã nấu chín) trong ngăn mát tủ lạnh. Khi dùng sẽ đem hấp cho bánh bột lọc nóng là được nhé.')
INSERT [dbo].[RECIPE] ([FoodID], [Step], [Content]) VALUES (2, 0, N'Cùng thưởng thức món ngon tiến vua ngay tại nhà bằng cách học làm cơm hến xứ Huế cùng với Cooky. Với những hướng dẫn tỉ mỉ và cách làm chi tiết, bạn sẽ nắm rõ được những thành phần quan trọng và những cách kết hợp và xử lý nguyên liệu làm sao để có được một tô cơm hến thật đúng điệu và thơm ngon không khác gì bản gốc.')
INSERT [dbo].[RECIPE] ([FoodID], [Step], [Content]) VALUES (2, 1, N'Hến sử dụng khoảng 2kg còn nguyên vỏ, rửa qua một lần với nước sau đó đem ngâm hến với nước vo gạo khoảng từ 30 phút đến 1 tiếng cho hến nhả bớt cát. Thời gian ngâm càng lâu thì hến càng nhả cát nhiều hơn. Sau đó chắt ráo nước, rửa sơ hến với nước sạch. Đặt một nồi nước lạnh lên bếp, cho hến vào rồi mở lửa đun sôi. Dùng vá khuấy và đảo để thịt hến tách ra khỏi vỏ và nổi lên mặt nước, lúc này vớt phần thịt hến ra cho vào tô. Làm lần lượt như vậy cho đến khi trong nồi chỉ còn vỏ.')
INSERT [dbo].[RECIPE] ([FoodID], [Step], [Content]) VALUES (2, 2, N'Vớt bỏ phần vỏ hến, để nồi yên 1 chút cho phần cát còn sót lại lắng xuống đáy nồi. Lúc này mới đổ phần nước luộc hến vào một chiếc nồi khác, đổ từ từ cẩn thận để không làm khuấy động phần cát lắng phía dưới. Với 300ml nước luộc hến thì nêm vào 5gr gừng thái lát và 1/2 muỗng canh hạt nêm rồi khuấy đều. Gừng sẽ giúp cân bằng lại tính hàn của hến, phần nước luộc dùng làm canh để ăn kèm với cơm hến và mắm ruốc nên chỉ cần nêm gia vị thật nhẹ nhàng. Đun sôi nước canh và giữ nóng đến khi dùng.')
INSERT [dbo].[RECIPE] ([FoodID], [Step], [Content]) VALUES (2, 3, N'Tiếp theo là xào thịt hến: cho vào chảo 2 muỗng canh dầu ăn, khi dầu nóng thì thêm 10gr hành tím thái lát vào phi thơm. Sau đó cho thịt hến (khoảng 300gr) vào chảo, nêm 1 muỗng canh nước mắm, 1/2 muỗng canh đường, 1/2 muỗng canh bột ngọt, 1/2 muỗng canh tiêu, 15gr rau răm thái nhỏ rồi xào đều tay cho gia vị thấm vào thịt hến, dậy mùi rau răm thơm nồng.')
INSERT [dbo].[RECIPE] ([FoodID], [Step], [Content]) VALUES (2, 4, N'Làm mắm ruốc: đun nóng 2 muỗng canh dầu ăn, cho 10gr tỏi băm và 5gr ớt băm vào phi thơm. Tiếp theo cho 2 muỗng canh mắm ruốc vào chảo, làm dịu vị mắm ruốc với 3 muỗng canh nước luộc hến và 1 muỗng canh đường, khuấy đều rồi đun cho mắm ruốc sôi lên là được.')
INSERT [dbo].[RECIPE] ([FoodID], [Step], [Content]) VALUES (2, 5, N'Chuẩn bị những thành phần còn lại cho cơm hến: Với cơm hến truyền thống, phần cơm được dùng không phải là cơm vừa nấu nóng hổi mà phải sử dụng cơm nguội, hạt rời thì mới đúng kiểu. Tiếp theo là đậu phộng rang muối: cho 2 muỗng canh dầu điều vào chảo, sau đó thêm 80gr đậu phộng cùng 1/2 muỗng cà phê muối, rang đều tay với lửa nhỏ đến khi thấy đậu phộng lên màu đỏ cam đẹp mắt là được. Một thành phần khác không thể thiếu là da heo chiên giòn: da heo bạn mua loại sấy khô, lấy 50gr đem cắt thành những miếng vừa ăn cho vào chảo chiên ngập dầu đến khi vàng giòn là được.')
INSERT [dbo].[RECIPE] ([FoodID], [Step], [Content]) VALUES (2, 6, N'Phần cuối cùng mà không kém phần quan trọng đó là các loại rau ăn chung với cơm. Đầu tiên phải kể đến dọc mùng bào sợi, tiếp theo là xoài bào sợi hoặc khế chua, một chút giá luộc, một chút bắp chuối bào. Thêm những loại rau quen thuộc như húng lũi, rau má, ngò rí là trọn vẹn cho một tô cơm hến ngon miệng và đúng chất Huế.')
INSERT [dbo].[RECIPE] ([FoodID], [Step], [Content]) VALUES (2, 7, N'Khi ăn xới cơm nguội ra tô, xếp xen kẻ những thành phần đã chuẩn bị lên trên, dọn thêm 1 bát nước canh hến nóng hổi, rưới mắm ruốc lên trên, trộn đều rồi thưởng thức thôi. Cơm hến độc đáo với đa dạng những thành phần nguyên liệu tạo nên sự hấp dẫn cả về hình thức lẫn hương vị, đảm bảo ai được ăn một lần sẽ nhớ mãi không quên. Sau khi biết đến công thức này của Cooky, những khi nào nhớ Huế và muốn thưởng thức món cơm hến đặc biệt này thì hãy xắn tay vào bếp trổ tài nhé, tốn một ít thời gian nhưng thành phẩm mang lại sẽ khiến bạn và gia đình hài lòng lắm đấy.')
GO
ALTER TABLE [dbo].[FOODIMAGE]  WITH CHECK ADD  CONSTRAINT [FK_FOODIMAGE] FOREIGN KEY([FoodID], [Step])
REFERENCES [dbo].[RECIPE] ([FoodID], [Step])
GO
ALTER TABLE [dbo].[FOODIMAGE] CHECK CONSTRAINT [FK_FOODIMAGE]
GO
ALTER TABLE [dbo].[INGREDIENT]  WITH CHECK ADD  CONSTRAINT [FK_INGREDIENT] FOREIGN KEY([FoodID])
REFERENCES [dbo].[FOOD] ([FoodID])
GO
ALTER TABLE [dbo].[INGREDIENT] CHECK CONSTRAINT [FK_INGREDIENT]
GO
ALTER TABLE [dbo].[RECIPE]  WITH CHECK ADD  CONSTRAINT [FK_RECIPE] FOREIGN KEY([FoodID])
REFERENCES [dbo].[FOOD] ([FoodID])
GO
ALTER TABLE [dbo].[RECIPE] CHECK CONSTRAINT [FK_RECIPE]
GO
/****** Object:  StoredProcedure [dbo].[GetAllFoodImageAtStep]    Script Date: 10/31/2020 4:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetAllFoodImageAtStep] 
@foodID int, @step tinyint
as
BEGIN
select Ordinal, ImagePath
from FOODIMAGE
where FoodID=@foodID and Step=@step
order by Ordinal
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllIngredient]    Script Date: 10/31/2020 4:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllIngredient] @foodID int
as
begin
	select FoodID, IngredientName, Amount, Unit
	from INGREDIENT
	where FoodID=@foodID
end

GO
/****** Object:  StoredProcedure [dbo].[GetAllStepAtRecipe]    Script Date: 10/31/2020 4:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllStepAtRecipe] @foodID int
as
begin
	select FoodID, Step, Content
	from RECIPE
	where FoodID=@foodID
end
GO
/****** Object:  StoredProcedure [dbo].[GetNumOfFoodWithFilter]    Script Date: 10/31/2020 4:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetNumOfFoodWithFilter]
@searchName nvarchar(50) = null,
@type nvarchar(50) = null ,
@area nvarchar(50) = null 
as
begin


	if (@searchName is not null)
		begin
			select COUNT(*)
			from(
				(select FoodID
				from FOOD
				where ((@type is null) or (@type like N'%'+FOOD.Type+N'%')) and ((@area is null) or (@area like N'%'+FOOD.Area+N'%')))
				intersect
				(select FoodID
				from FOOD
				where freetext(FoodName, @searchName))) as SUBFOODTABLE
		end
	else
		begin
			select COUNT(*)
			from FOOD
			where ((@type is null) or (@type like N'%'+FOOD.Type+N'%')) and ((@area is null) or (@area like N'%'+FOOD.Area+N'%'))
		end


	
end
GO
/****** Object:  StoredProcedure [dbo].[GetPageOfFoodWithFilter]    Script Date: 10/31/2020 4:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetPageOfFoodWithFilter]
@pageIndex int,
@pageElements int,
@searchName nvarchar(50) = null,
@type nvarchar(50) = null ,
@area nvarchar(50) = null 
as
begin
	declare @selectRows int = @pageElements *  @pageIndex
	declare @exceptRows int = @pageElements *  (@pageIndex-1)

	declare @subFoodTable table ([FoodID] [int] NOT NULL,
	[FoodName] [nvarchar](50) NOT NULL,
	[CreateDate] [date] NULL,
	[IsFavor] [bit] NULL,
	[Type] [nvarchar](50) NULL,
	[Area] [nvarchar](50) NULL,
	[Ration] [tinyint] NULL)

	if (@searchName is not null)
		begin
			insert into @subFoodTable
			select *
			from FOOD
			where ((@type is null) or (@type like N'%'+FOOD.Type+N'%')) and ((@area is null) or (@area like N'%'+FOOD.Area+N'%'))
			intersect
			select *
			from FOOD
			where freetext(FoodName, @searchName)
		end
	else
		begin
			insert into @subFoodTable
			select *
			from FOOD
			where ((@type is null) or (@type like N'%'+FOOD.Type+N'%')) and ((@area is null) or (@area like N'%'+FOOD.Area+N'%'))
		end

	select top (@selectRows) * from @subFoodTable
	except
	select top (@exceptRows) * from @subFoodTable

	
end
GO
/****** Object:  StoredProcedure [dbo].[InsertFood]    Script Date: 10/31/2020 4:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertFood]
@name nvarchar(50),
@isFavor bit,
@type nvarchar(50),
@area nvarchar(50),
@ration tinyint
as
begin
	declare @foodID int = 0
	if ((select MAX(FoodID) from FOOD) is not null)
	begin
	select @foodID = MAX(FoodID) + 1 from FOOD
	end
	declare @createDate date = getdate()
	insert into FOOD(FoodID, FoodName, CreateDate, IsFavor, Type, Area, Ration) values (@foodID, @name, @createDate, @isFavor, @type, @area, @ration)
	select @foodID as FoodID
end
GO
/****** Object:  StoredProcedure [dbo].[InsertFoodImage]    Script Date: 10/31/2020 4:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertFoodImage]
@foodID int,
@step tinyint,
@ordinal tinyint,
@imagePath nvarchar(200)
as
begin
	insert into FOODIMAGE values (@foodID, @step,@ordinal,@imagePath)
end
GO
/****** Object:  StoredProcedure [dbo].[InsertFoodImagetest]    Script Date: 10/31/2020 4:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertFoodImagetest]
@step tinyint,
@ordinal tinyint,
@imagePath nvarchar(200)
as
begin
	declare @foodID int = 0
	if ((select MAX(FoodID) + 1 from FOODIMAGE) is not null)
	begin
	select @foodID = MAX(FoodID) + 1 from FOODIMAGE
	end
	insert into FOODIMAGE(FoodID, Step, Ordinal, ImagePath) values (@foodID, @step,@ordinal,@imagePath)
end
GO
/****** Object:  StoredProcedure [dbo].[InsertIngredient]    Script Date: 10/31/2020 4:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertIngredient]
@foodID int,
@name nvarchar(50),
@amount decimal(10,2),
@unit nvarchar(20)
as
begin
	insert into INGREDIENT(FoodID, IngredientName, Amount, Unit) values (@foodID, @name,@amount,@unit)
end
GO
/****** Object:  StoredProcedure [dbo].[InsertStep]    Script Date: 10/31/2020 4:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertStep]
@foodID int,
@step tinyint,
@content nvarchar(1000)
as
begin
	insert into RECIPE(FoodID, Step, Content) values (@foodID, @step,@content)
end
GO
/****** Object:  StoredProcedure [dbo].[SetFavor]    Script Date: 10/31/2020 4:13:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SetFavor](@foodID int, @isFavor bit)
as
begin
	update FOOD
	set IsFavor=@isFavor where FoodID=@foodID
end
GO
USE [master]
GO
ALTER DATABASE [FoodRecipes] SET  READ_WRITE 
GO
