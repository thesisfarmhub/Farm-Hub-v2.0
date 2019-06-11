--INSERT DATA FARMHUB--

use FarmHub
go

Set xact_abort on
go 

begin tran	
	
		--Status--
	
	Insert into STATUS_TRANS(Name_StatusTrans) values(N'Đã Chuyển Tiền') 
	Insert into STATUS_TRANS(Name_StatusTrans) values(N'Đã Nhận Tiền')
	Insert into STATUS_TRANS(Name_StatusTrans) values(N'Đã Chuyển Tiền Lại')
	Insert into STATUS_TRANS(Name_StatusTrans) values(N'Chưa Nhận Được Tiền ')
	Insert into STATUS_TRANS(Name_StatusTrans) values(N'Gia Hạn Giao Tiền')

	Insert into STATUS_TRANS(Name_StatusTrans) values(N'Sẵn Sàng Giao Hàng')
	Insert into STATUS_TRANS(Name_StatusTrans) values(N'Gia Hạn Giao Hàng')
	Insert into STATUS_TRANS(Name_StatusTrans) values(N'Chưa Nhận Được Hàng ')
	Insert into STATUS_TRANS(Name_StatusTrans) values(N'Đã Nhận Được Hàng ')
	
	Insert into STATUS_TRANS(Name_StatusTrans) values(N'Mới Thiết Lập')
	Insert into STATUS_TRANS(Name_StatusTrans) values(N'Bên Mua Đặt Lại')
	Insert into STATUS_TRANS(Name_StatusTrans) values(N'Bên Bán Đặt Lại')
	Insert into STATUS_TRANS(Name_StatusTrans) values(N'Đã Đồng Ý')
	Insert into STATUS_TRANS(Name_StatusTrans) values(N'Đã Từ Chối')

	Insert into STATUS_TRANS(Name_StatusTrans) values(N'Bên Mua Hủy ')
	Insert into STATUS_TRANS(Name_StatusTrans) values(N'Bên Bán Hủy ')	


	--USER_KIND--
	Insert into USER_KIND (Name_UserKind) values ('Farmer')
	Insert into USER_KIND (Name_UserKind) values ('Trader')
	Insert into USER_KIND (Name_UserKind) values ('Admin')
	Insert into USER_KIND (Name_UserKind) values ('Mod')

	--USER_AUTHENTICATION--
	Insert into USER_AUTHENTICATION values (1,'farmer1','202cb962ac59075b964b07152d234b70',1/1/2019,1,1,0)
	Insert into USER_AUTHENTICATION values (1,'farmer2','202cb962ac59075b964b07152d234b70',1/1/2019,1,0,0)
	Insert into USER_AUTHENTICATION values (1,'farmer3','202cb962ac59075b964b07152d234b70',1/1/2019,5,2,0)

	Insert into USER_AUTHENTICATION values (2,'trader1','202cb962ac59075b964b07152d234b70',1/1/2019,1,1,0)
	Insert into USER_AUTHENTICATION values (2,'trader2','202cb962ac59075b964b07152d234b70',1/1/2019,1,0,0)
	Insert into USER_AUTHENTICATION values (2,'trader3','202cb962ac59075b964b07152d234b70',1/1/2019,3,2,0)

	Insert into USER_AUTHENTICATION values (3,'admin','202cb962ac59075b964b07152d234b70',1/1/2019,7,0,0 )

	Insert into USER_AUTHENTICATION values (4,'mod1','202cb962ac59075b964b07152d234b70',1/1/2019,7,0,0 )
	Insert into USER_AUTHENTICATION values (4,'mod2','202cb962ac59075b964b07152d234b70',1/1/2019,7,0,0 )
	Insert into USER_AUTHENTICATION values (4,'mod3','202cb962ac59075b964b07152d234b70',1/1/2019,7,0,0 )

	--FARMER--
	Insert into FARMER (Id_User,Name_Farmer,Birthday_Farmer,Gender_Farmer,Address_Farmer,Telephone_Farmer,Email_Farmer,Is_Deleted) 
	values (1,N'Lý Minh Duy',1/1/2019,1,N'Gò Vấp',0817777777,'lyminhduy@gmail.com',0)
	Insert into FARMER (Id_User,Name_Farmer,Birthday_Farmer,Gender_Farmer,Address_Farmer,Telephone_Farmer,Email_Farmer,Is_Deleted) 
	values (2,N'Nguyễn Sam Huân',1/1/2019,1,N'Hóc Môn',0817777777,'samhuan1123@gmail.com',0)
	Insert into FARMER (Id_User,Name_Farmer,Birthday_Farmer,Gender_Farmer,Address_Farmer,Telephone_Farmer,Email_Farmer,Is_Deleted) 
	values (3,N'Nguyễn Anh Tuấn',1/1/2019,1,N'Cách Mạng Tháng Tám',0817777777,'tuananh05061997@gmail.com',0)

	--TRADER--
	Insert into TRADER (Id_User,Name_Trader,Birthday_Trader,Gender_Trader,Address_Trader,Telephone_Trader,Email_Trader,Is_Deleted) 
	values (4,N'Nguyễn Minh Chiến',1/1/2019,1,N'Gò Vấp',0817999999,'chiennguyen7749@gmail.com',0)
	Insert into TRADER (Id_User,Name_Trader,Birthday_Trader,Gender_Trader,Address_Trader,Telephone_Trader,Email_Trader,Is_Deleted) 
	values (5,N'Trần Anh Khoa',1/1/2019,1,N'Tân Bình',0817999999,'trananhkhoa97@gmail.com',0)
	Insert into TRADER (Id_User,Name_Trader,Birthday_Trader,Gender_Trader,Address_Trader,Telephone_Trader,Email_Trader,Is_Deleted) 
	values (6,N'Trần Minh Hà',1/1/2019,1,N'Huế',0817999999,'minhhatran123@gmail.com',0)

	--MASS_UNIT--
	Insert into MASS_UNIT(Name_MassUnit,Weight_To_Kg,Is_Deleted) values (N'Tấn', 1000,0)
	Insert into MASS_UNIT(Name_MassUnit,Weight_To_Kg,Is_Deleted) values (N'Tạ', 100,0)
	Insert into MASS_UNIT(Name_MassUnit,Weight_To_Kg,Is_Deleted) values (N'Yến', 10,0)
	Insert into MASS_UNIT(Name_MassUnit,Weight_To_Kg,Is_Deleted) values (N'Kg', 1,0)

	--FARM--
	Insert into FARM (Id_Farmer,Name_Farm,Address_Farm,City_Farm,Acreage,Description_Farm,Is_Deleted)
	values (1,N'Nông Trại Vạn Lục',N'Gò Vấp',N'Hồ Chí Minh',100,N'Trang trại có thế mạnh thiên nhiên ban tặng (đất đai màu mỡ, lượng mưa dồi dào) quanh năm và những cánh đồng cỏ xanh sạch',0)
	Insert into FARM (Id_Farmer,Name_Farm,Address_Farm,City_Farm,Acreage,Description_Farm,Is_Deleted)
	values (1,N'Nông Trại Kim Điền',N'Đồng Bằng Sông Cửu Long',N'Đồng Bằng Sông Cửu Long',100,N'Là nơi được gọi là vựa lúa của Việt Nam',0)
	Insert into FARM (Id_Farmer,Name_Farm,Address_Farm,City_Farm,Acreage,Description_Farm,Is_Deleted)
	values (1,N'Nông Trại Đà Lạt',N'Đà Lạt',N'Đà Lạt',100,N'Đà lạt không chỉ nổi tiếng với phong cảnh nên thơ hữu tình, với đặc tính khí hậu chiều lòng người mà còn nổi tiếng bởi sức hút từ những mặt hàng nông sản tươi ngon và vô cùng đa dạng phong phú',0)

	--PRODUCT_KIND--
	Insert into PRODUCT_KIND(Name_ProductKind,Is_Deleted) values (N'Quả',0)
	Insert into PRODUCT_KIND(Name_ProductKind,Is_Deleted) values (N'Rau',0)
	Insert into PRODUCT_KIND(Name_ProductKind,Is_Deleted) values (N'Củ',0)
	Insert into PRODUCT_KIND(Name_ProductKind,Is_Deleted) values (N'Nấm',0)
	Insert into PRODUCT_KIND(Name_ProductKind,Is_Deleted) values (N'Hạt các loại',0)

	--PRODUCT--

	--Quả--
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (1,N'Dưa Hấu','/Data/Image/Farmer/Base/watermelon.jpeg', 0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (1,N'Táo','/Data/Image/Farmer/Base/apple.jpeg',0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (1,N'Sầu Riêng','/Data/Image/Farmer/Base/durian.jpeg',0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (1,N'Cam','/Data/Image/Farmer/Base/orange.jpeg',0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (1,N'Chuối','/Data/Image/Farmer/Base/banana.jpeg',0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (1,N'Nho','/Data/Image/Farmer/Base/grapes.jpeg',0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (1,N'Dâu','/Data/Image/Farmer/Base/strawberry.jpeg',0)

	--Rau--
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (2,N'Đậu','/Data/Image/Farmer/Base/beans.jpeg',0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (2,N'Cải Bắp','/Data/Image/Farmer/Base/cabbage.jpeg',0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (2,N'Rau Muống','/Data/Image/Farmer/Base/water-spinach.jpeg',0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (2,N'Bông cải xanh','/Data/Image/Farmer/Base/broccoli.jpeg',0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (2,N'Cà Chua','/Data/Image/Farmer/Base/tomato.jpeg',0)

	--Củ--
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (3,N'Củ Khoai Tây','/Data/Image/Farmer/Base/potato.jpeg',0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (3,N'Củ Cải Đỏ','/Data/Image/Farmer/Base/radish.jpeg',0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (3,N'Củ Cà Rốt','/Data/Image/Farmer/Base/carrot.jpeg',0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (3,N'Củ Dền','/Data/Image/Farmer/Base/beetroot.jpeg',0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (3,N'Củ Su Hào','/Data/Image/Farmer/Base/kohlrabi-bulbs.jpeg',0)

	--Nấm--
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (4,N'Nấm Hương','/Data/Image/Farmer/Base/shiitake.jpeg', 0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (4,N'Nấm Mộc Nhĩ','/Data/Image/Farmer/Base/fungus.jpeg', 0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (4,N'Nấm Rơm','/Data/Image/Farmer/Base/mushroom.jpeg', 0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (4,N'Nấm Linh Chi','/Data/Image/Farmer/Base/lingzhi-mushroom.jpeg', 0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (4,N'Nấm Kim Châm','/Data/Image/Farmer/Base/enokitake.jpeg', 0)

	--Các Loại Hạt--
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (5,N'Hạt Hạnh Nhân','/Data/Image/Farmer/Base/almond.jpeg', 0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (5,N'Hạt Điều','/Data/Image/Farmer/Base/cashew.jpeg', 0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (5,N'Hạt Hồ Đào','/Data/Image/Farmer/Base/pecan.jpeg', 0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (5,N'Hạt Dẻ','/Data/Image/Farmer/Base/chestnut.jpeg', 0)
	Insert into PRODUCT (Id_ProductKind,Name_Product,Image_Product,Is_Deleted) values (5,N'Hạt Đậu Phộng','/Data/Image/Farmer/Base/peanut.jpeg', 0)

	--SEED--

	--Dưa Hấu--
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (1, N'Không Hạt','SDA001',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (1, N'Khổng Lồ','SDA002',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (1, N'Lai F1','SDA003',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (1, N'Ruột Vàng','SDA004',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (1, N'Tí Hon','SDA005',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (1, N'Vỏ Vàng','SDA006',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (1, N'Hắc Mĩ Nhân','SDA007',0)

	--Táo--
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (2, N'Đài Loan','SDB001',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (2, N'Thái Lan','SDB002',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (2, N'Đào Vàng','SDB003',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (2, N'Mèo','SDB004',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (2, N'Gia Lộc','SDB005',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (2, N'Kiku','SDB006',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (2, N'Fuji','SDB007',0)

	--Sầu Riêng--
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (3, N'Khổ Qua','SDC001',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (3, N'Cái Mơn','SDC002',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (3, N'Ruột Đỏ','SDC003',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (3, N'Musang King','SDC004',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (3, N'Monthong Thái','SDC005',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (3, N'Ri6','SDC006',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (3, N'Dona','SDC007',0)

	--Cam--
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (4, N'Cao Phong Hòa Bình','SDD001',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (4, N'Sành Hà Giang','SDD002',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (4, N'Bù Hà Tĩnh','SDD003',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (4, N'Khe Mây Hà Tĩnh','SDD004',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (4, N'Xoàn Lai Vung','SDD005',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (4, N'Sành Hàm Yên','SDD006',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (4, N'Vinh','SDD007',0)

	--Chuối--
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (5, N'Tiêu','SDE001',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (5, N'Ngự','SDE002',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (5, N'Sứ','SDE003',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (5, N'Tiêu Hồng','SDE004',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (5, N'Tây Thái','SDE005',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (5, N'Cau','SDE006',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (5, N'Gạo','SDE007',0)

	--Nho--
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (6, N'Xanh Ninh Thuận','SDF001',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (6, N'Đỏ Ninh Thuận','SDF002',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (6, N'Đen Ninh Thuận','SDF003',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (6, N'Pháp','SDF004',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (6, N'Không Hạt','SDF005',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (6, N'Mỹ','SDF006',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (6, N'Syrah','SDF007',0)

	--Dâu--
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (7, N'Tây Chịu Nhiệt','SDG001',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (7,N'Nhật Bản','SDG002',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (7,N'New Zealand','SDG003',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (7,N'Mỹ Đã','SDG004',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (7,N'Trắng','SDG005',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (7,N'Khổng Lồ','SDG006',0)
	Insert into SEED (Id_Product,Name_Seed,Code_Seed,Is_Deleted) values (7,N'Hàn Quốc','SDG007',0)

	--PRODUCT_DETAIL--

	--Vạn Lục--

	--Dưa Hấu--
	Insert into PRODUCT_DETAIL values (1,1,1,N'Long An','/Data/Image/Farmer/Base/watermelon1.jpeg',100,N'Chính Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,200,0)
	Insert into PRODUCT_DETAIL values (1,1,2,N'Long An','/Data/Image/Farmer/Base/watermelon2.jpeg',50,N'Trái Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,300,0)
	Insert into PRODUCT_DETAIL values (1,1,3,N'Long An','/Data/Image/Farmer/Base/watermelon3.jpeg',100,N'Chính Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,200,0)

	--Táo--
	Insert into PRODUCT_DETAIL values (2,1,8,N'Đà Lạt','/Data/Image/Farmer/Base/apple1.jpeg',50,N'Trái Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,400,0)	
	Insert into PRODUCT_DETAIL values (2,1,9,N'Đà Lạt','/Data/Image/Farmer/Base/apple2.jpeg',100,N'Chính Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,400,0)	
	Insert into PRODUCT_DETAIL values (2,1,10,N'Đà Lạt','/Data/Image/Farmer/Base/apple3.jpeg',50,N'Trái Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,200,0)
	
	--Sầu Riêng--
	Insert into PRODUCT_DETAIL values (3,1,15,N'Tiền Giang','/Data/Image/Farmer/Base/durian1.jpeg',100,N'Chính Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,200,0)	
	Insert into PRODUCT_DETAIL values (3,1,16,N'Tiền Giang','/Data/Image/Farmer/Base/durian2.jpeg',50,N'Trái Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,300,0)	
	Insert into PRODUCT_DETAIL values (3,1,17,N'Tiền Giang','/Data/Image/Farmer/Base/durian3.jpeg',100,N'Chính Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,600,0)
		
	--Kim Điền--

	--Cam--
	Insert into PRODUCT_DETAIL values (4,2,22,N'Hà Tĩnh','/Data/Image/Farmer/Base/orange1.jpeg',50,N'Trái Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,200,0)
	Insert into PRODUCT_DETAIL values (4,2,23,N'Hà Tĩnh','/Data/Image/Farmer/Base/orange2.jpeg',100,N'Chính Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,300,0)
	Insert into PRODUCT_DETAIL values (4,2,24,N'Hà Tĩnh','/Data/Image/Farmer/Base/orange3.jpeg',50,N'Trái Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,400,0)

	--Chuối--
	Insert into PRODUCT_DETAIL values (5,2,29,N'Hà Nam','/Data/Image/Farmer/Base/banana1.jpeg',100,N'Chính Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,500,0)
	Insert into PRODUCT_DETAIL values (5,2,30,N'Hà Nam','/Data/Image/Farmer/Base/banana2.jpeg',50,N'Trái Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,200,0)
	Insert into PRODUCT_DETAIL values (5,2,31,N'Hà Nam','/Data/Image/Farmer/Base/banana3.jpeg',100,N'Chính Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,300,0)

	--Nho--
	Insert into PRODUCT_DETAIL values (6,2,36,N'Ninh Thuận','/Data/Image/Farmer/Base/grapes1.jpeg',50,N'Trái Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,300,0)
	Insert into PRODUCT_DETAIL values (6,2,37,N'Ninh Thuận','/Data/Image/Farmer/Base/grapes2.jpeg',100,N'Chính Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,100,0)
	Insert into PRODUCT_DETAIL values (6,2,38,N'Ninh Thuận','/Data/Image/Farmer/Base/grapes3.jpeg',50,N'Trái Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,200,0)

	--Dâu--
	Insert into PRODUCT_DETAIL values (7,2,43,N'Đà Lạt','/Data/Image/Farmer/Base/strawberry1.jpeg',50,N'Trái Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,300,0)
	Insert into PRODUCT_DETAIL values (7,2,44,N'Đà Lạt','/Data/Image/Farmer/Base/strawberry2.jpeg',100,N'Chính Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,200,0)
	Insert into PRODUCT_DETAIL values (7,2,45,N'Đà Lạt','/Data/Image/Farmer/Base/strawberry3.jpeg',50,N'Trái Vụ',1/1/2019,1/2/2019,1/3/2019,1/4/2019,400,0)
	
	--** SALE_OFFER **--

	--** SALE_OFFER_DETAIL **--

	--** PURCHASE_OFFER **--	

	--** PURCHASE_OFFER_DETAIL **--

	--** TRANSACTION_ORDER **--

	-----------------------------------------------------------------------------------------------------------------------------------------------------------------

	-- ID_Farm = 1, ID_ProductDetails = 1 , ID_Seed = 1, ID_Product = 1, ID_Trader = 1 => DƯA HẤU
	Insert into SALE_OFFER values (1, 1, 1, 1/1/2019, 10000, 100, 10, 0, 3, 3, 2, 0) -- ID = 1
	Insert into SALE_OFFER_DETAIL values (1, 45, 0, 0) -- ID = 1
	Insert into SALE_OFFER_DETAIL values (1, 45, 0, 0) -- ID = 2

	Insert into PURCHASE_OFFER values (1, 1, 1, 1, 1/1/2019, 10000, 45, 0, 0, 3, 3, 1, 0) -- ID = 1
	Insert into PURCHASE_OFFER_DETAIL values (1, 45, 0, 0) -- ID = 1

	Insert into PURCHASE_OFFER values (1, 1, 1, 1, 2/2/2019, 10000, 45, 0, 0, 3, 3, 1, 0) -- ID = 2
	Insert into PURCHASE_OFFER_DETAIL values (2, 45, 0, 0) -- ID = 2

	Insert into TRANSACTION_ORDER values (1, 1, 1, '\Data\Image\Trader\Invoices\xxxxxxx', 1/1/2019, 45, N'Tấn', 10000, 450000, 3, 3, 1, 0)
	Insert into TRANSACTION_ORDER values (2, 2, 1, '\Data\Image\Trader\Invoices\xxxxxxx', 1/1/2019, 45, N'Tấn', 10000, 45000, 3, 3, 2, 0)
	-----------------------------------------------------------------------------------------------------------------------------------------------------------------

	--ID_Farm = 1, ID_ProductDetails = 2, ID_Seed = 2, ID_Product = 1, ID_Trader = 1 => DƯA HẤU
	Insert into SALE_OFFER values (1, 1, 2, 2/2/2019, 20000, 200, 20, 1, 4, 4, 1, 0) -- ID = 2
	Insert into SALE_OFFER_DETAIL values (2, 100, 0, 0) -- ID = 3

	Insert into PURCHASE_OFFER values (1, 1, 1, 2, 2/2/2019, 20000, 180, 0, 0, 4, 4, 1, 0) -- ID =  3
	Insert into PURCHASE_OFFER_DETAIL values (3, 180, 100000, 0) -- ID = 3

	Insert into TRANSACTION_ORDER values (3, 3, 2, '\Data\Image\Trader\Invoices\xxxxxxx', 2/2/2019, 180, N'Tấn', 20000, 370000, 4, 4, 3, 0)
	-----------------------------------------------------------------------------------------------------------------------------------------------------------------

	--ID_Farm = 1, ID_ProductDetails = 3, ID_Seed = 3, ID_Product = 1, ID_Trader = 1 => DƯA HẤU
	Insert into SALE_OFFER values (1, 1, 3, 3/3/2019, 30000, 300, 30, 1, 5, 5, 3, 0) -- ID = 3
	Insert into SALE_OFFER_DETAIL values (3, 100, 100000, 0) -- ID = 4
	Insert into SALE_OFFER_DETAIL values (3, 120, 200000, 0 )-- ID = 5
	Insert into SALE_OFFER_DETAIL values (3, 50, 0, 0)-- ID = 6

	Insert into PURCHASE_OFFER values (1, 1, 1, 3, 3/3/2019, 30000, 100, 0, 0, 6, 6, 1, 0 )-- ID = 4
	Insert into PURCHASE_OFFER_DETAIL values (4, 100, 0, 0)-- ID = 4

	Insert into PURCHASE_OFFER values (1, 1, 1, 3, 4/4/2019, 30000, 120, 0, 0 , 6, 6, 1, 0)-- ID = 5
	Insert into PURCHASE_OFFER_DETAIL values (5, 120, 0, 0)-- ID = 5

	Insert into PURCHASE_OFFER values (1, 1, 1, 3, 5/5/2019, 30000, 50, 0, 0, 6, 6, 1, 0)-- ID = 6
	Insert into PURCHASE_OFFER_DETAIL values (6, 50, 0, 0)-- ID = 6

	Insert into TRANSACTION_ORDER values (4, 4, 3, '\Data\Image\Trader\Invoices\xxxxxxx', 5/5/2019, 100, N'Tấn', 30000, 490000, 6, 6, 4, 0)
	Insert into TRANSACTION_ORDER values (5, 5, 3, '\Data\Image\Trader\Invoices\xxxxxxx', 6/6/2019, 120, N'Tấn', 30000, 570000, 6, 6, 5, 0)
	Insert into TRANSACTION_ORDER values (6, 6, 3, '\Data\Image\Trader\Invoices\xxxxxxx', 7/7/2019, 50, N'Tấn', 30000, 63000, 6, 6, 6, 0)
	-----------------------------------------------------------------------------------------------------------------------------------------------------------------

	--ID_Farm = 2, ID_ProductDetails = 10, ID_Seed = 22, ID_Product = 4, ID_Trader = 1
	Insert into SALE_OFFER values (2, 1, 10, 5/5/2019, 40000, 400, 40, 0, 7, 7, 5, 0) -- ID = 4
	Insert into SALE_OFFER_DETAIL values (4, 40, 100000, 0) -- ID = 7
	Insert into SALE_OFFER_DETAIL values (4, 100, 0, 0) -- ID = 8
	Insert into SALE_OFFER_DETAIL values (4, 60, 200000, 0) -- ID = 9
	Insert into SALE_OFFER_DETAIL values (4, 120, 0, 0) -- ID = 10
	Insert into SALE_OFFER_DETAIL values (4, 70, 0, 0) -- ID = 11

	Insert into PURCHASE_OFFER values (1, 1, 4, 22, 6/6/2019, 40000, 80, 40, 1, 7, 7, 1, 0) -- ID = 7
	Insert into PURCHASE_OFFER_DETAIL values (7, 40, 100000, 0) -- ID = 7

	Insert into PURCHASE_OFFER values (1, 1, 4, 22, 7/7/2019, 30000, 200, 100, 0, 7, 7, 1, 0) -- ID = 8
	Insert into PURCHASE_OFFER_DETAIL values (8, 100, 20000, 0) -- ID = 8

	Insert into PURCHASE_OFFER values (1, 1, 4, 22, 8/8/2019, 25000, 160, 100, 0, 7, 7, 1, 0) -- ID = 9
	Insert into PURCHASE_OFFER_DETAIL values (9, 60, 50000, 0) -- ID = 9

	Insert into PURCHASE_OFFER values (1, 1, 4, 22, 9/9/2019, 30000, 220, 100, 1, 7, 7, 1, 0) -- ID = 10
	Insert into PURCHASE_OFFER_DETAIL values (10, 120, 0, 0) -- ID = 10

	Insert into PURCHASE_OFFER values (1, 1, 4, 22, 10/10/2019, 40000, 270, 200, 1, 7, 7, 1, 0) -- ID = 11
	Insert into PURCHASE_OFFER_DETAIL values (11, 70, 30000, 0) -- ID = 11

	Insert into TRANSACTION_ORDER values (7, 7, 10, '\Data\Image\Trader\Invoices\xxxxxxx', 5/5/2019, 40, N'Tấn', 40000, 550000, 7, 7, 7, 0)
	Insert into TRANSACTION_ORDER values (8, 8, 10, '\Data\Image\Trader\Invoices\xxxxxxx', 6/6/2019, 100, N'Tấn', 40000, 680000, 7, 7, 8, 0)
	Insert into TRANSACTION_ORDER values (9, 9, 10, '\Data\Image\Trader\Invoices\xxxxxxx', 7/6/2019, 60, N'Tấn', 30000, 749000, 7, 7, 9, 0)
	Insert into TRANSACTION_ORDER values (10, 10, 10, '\Data\Image\Trader\Invoices\xxxxxxx', 8/7/2019, 120, N'Tấn', 30000, 880000, 7, 7, 10, 0)
	Insert into TRANSACTION_ORDER values (11, 11, 10, '\Data\Image\Trader\Invoices\xxxxxxx', 8/7/2019, 70, N'Tấn', 30000,630000, 7, 7, 11, 0)
	-----------------------------------------------------------------------------------------------------------------------------------------------------------------

	----ID_Farm = 1, ID_ProductDetails = 4, ID_Seed = 8, ID_Product = 2, ID_Trader = 1
	Insert into SALE_OFFER values (1, 1, 4, 4/4/2019, 25000, 500, 50, 1, 7, 7, 2, 0) -- ID = 5
	Insert into SALE_OFFER_DETAIL values (5, 200, 200000, 0) -- ID = 12
	Insert into SALE_OFFER_DETAIL values (5, 250, 0, 0) -- ID = 13

	Insert into PURCHASE_OFFER values (1, 1, 2, 8, 4/4/2019, 15000, 280, 80, 1, 7, 7, 1, 0) -- ID = 12
	Insert into PURCHASE_OFFER_DETAIL values (12, 200, 100000, 0) -- ID = 12

	Insert into PURCHASE_OFFER values (1, 1, 2, 8, 6/6/2019, 20000, 300, 50, 1, 7, 7, 1, 0) -- ID = 13
	Insert into PURCHASE_OFFER_DETAIL values (13, 250, 0, 0) -- ID = 13

	Insert into TRANSACTION_ORDER values (12, 12, 4, '\Data\Image\Trader\Invoices\xxxxxxx', 8/8/2019, 200, N'Tấn', 25000, 550000, 7, 7, 12, 0)
	Insert into TRANSACTION_ORDER values (13, 13, 4, '\Data\Image\Trader\Invoices\xxxxxxx', 9/9/2019, 250, N'Tấn', 25000, 650000, 7, 7, 13, 0)
	-----------------------------------------------------------------------------------------------------------------------------------------------------------------

	----ID_Farm = 1, ID_ProductDetails = 5, ID_Seed = 9, ID_Product = 2, ID_Trader = 1
	Insert into SALE_OFFER values (1, 1, 5, 5/5/2019, 30000, 400, 40, 1, 7, 7, 2, 0) -- ID = 6
	Insert into SALE_OFFER_DETAIL values (6, 120, 0, 0) -- ID = 14
	Insert into SALE_OFFER_DETAIL values (6, 140, 0, 0) -- ID = 15

	Insert into PURCHASE_OFFER values (1, 1, 2, 9, 6/6/2019, 30000, 180, 60, 1, 7, 7, 1, 0) -- ID = 14
	Insert into PURCHASE_OFFER_DETAIL values (14, 120, 130000, 0) -- ID = 14

	Insert into PURCHASE_OFFER values (1, 1, 2, 9, 6/6/2019, 30000, 240, 100, 0, 7, 7, 1, 0) -- ID = 15
	Insert into PURCHASE_OFFER_DETAIL values (15, 140, 200000, 0) -- ID = 15

	Insert into TRANSACTION_ORDER values (14, 14, 5, '\Data\Image\Trader\Invoices\xxxxxxx', 7/7/2019, 120, N'Tấn', 30000, 450000, 7, 7, 14, 0)
	Insert into TRANSACTION_ORDER values (15, 15, 5, '\Data\Image\Trader\Invoices\xxxxxxx', 8/8/2019, 140, N'Tấn', 30000, 550000, 7, 7, 15, 0)
	-----------------------------------------------------------------------------------------------------------------------------------------------------------------

	----ID_Farm = 1, ID_ProductDetails = 6, ID_Seed = 10, ID_Product = 2, ID_Trader = 1

	Insert into SALE_OFFER values (1, 1, 6, 3/3/2019, 40000, 300, 30, 1, 7, 7, 1, 0) -- ID = 7
	Insert into SALE_OFFER_DETAIL values (7, 270, 0, 0)-- ID = 16

	Insert into PURCHASE_OFFER values (1, 1, 2, 10, 5/5/2019, 35000, 300, 30, 1, 7, 7, 1, 0)-- ID = 16
	Insert into PURCHASE_OFFER_DETAIL values (16, 270, 200000, 0)-- ID = 16

	Insert into TRANSACTION_ORDER values (16, 16, 6, '\Data\Image\Trader\Invoices\xxxxxxx', 7/7/2019, 270, N'Tấn', 40000, 800000, 7, 7, 16, 0)
	-----------------------------------------------------------------------------------------------------------------------------------------------------------------

	--** TOPIC **--
	Insert into TOPIC (Name_Topic) values(N'Bổ sung thêm nông sản')
	Insert into TOPIC (Name_Topic) values(N'Bổ sung thêm hạt giống')
	Insert into TOPIC (Name_Topic) values(N'Lấy lại mật khẩu ')
	Insert into TOPIC (Name_Topic) values(N'Góp ý')
	Insert into TOPIC (Name_Topic) values(N'Tố cáo ')

	--** TRADER_PREFERENCE **--
	Insert into TRADER_PREFERENCE values (1, 1/1/2019)
	Insert into TRADER_PREFERENCE values (2, 2/2/2019)
	Insert into TRADER_PREFERENCE values (3, 3/3/2019)

	--** TRADER_PREFERENCE_DETAIL **--
	Insert into TRADER_PREFERENCE_DETAIL values (1, 1, 0)
	Insert into TRADER_PREFERENCE_DETAIL values (1, 2, 0)

	Insert into TRADER_PREFERENCE_DETAIL values (2, 3, 0)
	Insert into TRADER_PREFERENCE_DETAIL values (2, 4, 0)

	Insert into TRADER_PREFERENCE_DETAIL values (2, 5, 0)
	Insert into TRADER_PREFERENCE_DETAIL values (2, 1, 0)

	--** FEED_BACK **--

	--ID_User = 1 => Farmer 1--
	Insert into FEED_BACK values (1, 1, N'Bổ sung cây lúa', null, N'Các anh bổ sung giúp tôi cây lúa nữa', 0)
	Insert into FEED_BACK values (1, 2, N'Bổ sung giống lúa', null, N'Cây lúa tôi trồng ba loại là lúa ba lá Nghệ An, lúa ba tháng nước Nghệ An, lúa bằng muộn Nghệ An', 0)
	Insert into FEED_BACK values (1, 1, N'Bổ sung dưa leo', null, N'Tôi trồng thêm dưa leo', 0)
	Insert into FEED_BACK values (1, 2, N'Bổ sung giống dưa leo', null, N'Thêm cho tôi dưa leo đỏ, dưa leo khoai tây, dưa leo siêu trái', 0)
	Insert into FEED_BACK values (1, 4, N'Góp ý', null, N'Các anh bổ sung thông tin chậm quá, cần làm nhanh hơn nữa', 0)
	Insert into FEED_BACK values (1, 4, N'Góp ý', null, N'Các anh viết chữ to hơn được không ?', 0)
	Insert into FEED_BACK values (1, 4, N'Góp ý', null, N'Các anh đăng thêm tin về dự báo thời tiết được không ?', 0)

	--ID_User = 4 => Trader 1--
	Insert into FEED_BACK values (1, 1, N'Bổ sung', null, N'Thêm giúp tôi đậu nành nữa', 0)
	Insert into FEED_BACK values (1, 1, N'Bổ sung', null, N'Thêm khoai mỡ, thêm bắp', 0)
	Insert into FEED_BACK values (4, 4, N'Góp ý', null, N'Cho tôi tự thêm nông sản được không ?', 0)
	Insert into FEED_BACK values (4, 4, N'Góp ý', null, N'Các anh thêm phần bán hoa nữa được không ? ', 0)

commit tran