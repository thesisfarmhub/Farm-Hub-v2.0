--FARM HUB--

Create Database FarmHub;
go
Use FarmHub;
go


Create Table STATUS_TRANS
(
	Id_StatusTrans tinyint not null primary key identity(1,1),
	Name_StatusTrans nvarchar(20)
);

-- FARMER --

-- Đăng ký tài khoản -- ✔

-- Authentication -- 
Create Table USER_KIND
(
	Id_UserKind tinyint not null primary key identity(1,1),
	Name_UserKind nvarchar(10)
	-- Foreign Key --
);

Create Table USER_AUTHENTICATION
(
	Id_User int not null primary key identity(1,1),
	Id_UserKind tinyint,
	Name_User varchar(50),
	Password_User varchar(50),
	Created_Date datetime,
	Penalty tinyint,
	Status_User tinyint not null,
	Is_Deleted bit
	-- Foreign Key --
	Foreign Key (Id_UserKind) references USER_KIND(Id_UserKind)
);

Create Table FARMER 
(
	Id_Farmer int not null primary key identity(1,1),
	Id_User int,
	Name_Farmer nvarchar(50),
	Birthday_Farmer datetime,
	Gender_Farmer bit,
	Address_Farmer nvarchar(200),
	Telephone_Farmer nvarchar(10),
	Email_Farmer nvarchar(100),
	Is_Deleted bit
	-- Foreign Key --
	Foreign Key (Id_User) references USER_AUTHENTICATION(Id_User)
);

--Create Table FARMER_REGISTER
--(
--	Id_FarmerRegister int not null primary key identity(1,1),
--	Id_User int ,
--	Id_Farmer int,

--	Foreign Key (Id_User) references USER_AUTHENTICATION(Id_User),
--	Foreign Key (Id_Farmer) references FARMER(Id_Farmer)
--);

-- Nhập tiêu chí phân loại nông sản và thông tin các loại giống -- ✔
--Create Table CLASSIFICATION
--(
--	Id_Classification int not null primary key identity(1,1),
--	Name_Classification nvarchar(50),
--	Packing_Specifications nvarchar(50),
--	Color_Classification nvarchar(50),
--	Weight_Classification int,
--	Size_Classification nvarchar(50),
--	Is_Deleted bit
--	-- Foreign Key --
--);

 --Nhập thông tin nông sản sẽ trồng ở Nông Trại -- ✔
Create Table PRODUCT_KIND
(
	Id_ProductKind int not null primary key identity(1,1),
	Name_ProductKind nvarchar(50),
	Is_Deleted bit
	-- Foreign Key -- 
);
 --Có các Kind_Product: Hạt các loại, Rau, Củ, Quả, Nấm

Create Table MASS_UNIT
(
	Id_MassUnit tinyint not null primary key identity(1,1),
	Name_MassUnit nvarchar(10),
	Weight_To_Kg int,
	Is_Deleted bit
	-- Foreign Key -- 
);

-- Nhập thông tin nông trại -- ✔
Create Table FARM
(
	Id_Farm int not null primary key identity(1,1),
	Id_Farmer int,
	Name_Farm nvarchar(50),
	Address_Farm nvarchar(200),
	City_Farm nvarchar(50),
	Acreage int,
	Description_Farm nvarchar(250),
	Is_Deleted bit
	-- Foreign Key --
	Foreign Key (Id_Farmer) references FARMER(Id_Farmer)
);

Create Table SEED
(
	Id_Seed int not null primary key identity(1,1),
	Name_Seed nvarchar(50),
	Code_Seed nvarchar(50),
	Is_Deleted bit
	-- Foreign Key -- 	
);

Create Table PRODUCT
(
	Id_Product int not null primary key identity(1,1),
	Id_ProductKind int,
	Name_Product nvarchar(50),
	Image_Product varchar(200),
	Is_Deleted bit
	-- Foreign Key --
	Foreign Key (Id_ProductKind) references PRODUCT_KIND(Id_ProductKind)
);

Create table PRODUCT_DETAIL
(
	Id_ProductDetail int not null primary key identity(1,1),
	Id_Product int,
	Id_Farm int,
	Id_Seed int,
	Geography_Location nvarchar(50),
	Image_ProductDetail varchar(200),
	Min_Mass int,
	--Crop--
	Name_Crop nvarchar(50),
	Start_Time datetime,
	End_Time datetime,
	Harvest_StartTime datetime,
	Harvest_EndTime datetime,
	Quantity_Expected int,
	--Crop--	
	Is_Deleted bit
	-- Foreign Key --
	Foreign Key (Id_Product) references PRODUCT(Id_Product),
	Foreign Key (Id_Farm) references FARM(Id_Farm),
	Foreign Key (Id_Seed) references SEED(Id_Seed)
);

-- Một Farm có thể trồng nhiều Product khác nhau, một Product có thể được trồng ở nhiều nông trại khác nhau => quan hệ nhiều nhiều
-- => Tạo bảng trung gian FarmDetail ✔
--Create Table FARM_DETAIL
--(
--	Id_FarmDetail int not null primary key identity(1,1),
--	Id_Farm int,
--	Id_ProductDetail int,
--	Is_Deleted bit
--	-- Foreign Key --
--	Foreign Key (Id_Farm) references FARM(Id_Farm),
--	Foreign Key (Id_ProductDetail) references PRODUCT_DETAIL(Id_ProductDetail)
--);

-- Xem lịch sử giá giao dịch của các vụ mùa trước -- ✔
Create Table MARKET_TRANS_HIS
(
	Id_MarketTransHis int not null primary key identity(1,1),
	Id_ProductDetail int,
	Id_MassUnit tinyint,
	City_Market nvarchar(50),
	Average_TransPrice int,
	Average_OfferPrice int,
	Average_PurchasePrice int,
	Product_SupplyQuantity int,
	-- Foreign Key --
	Foreign Key (Id_ProductDetail) references PRODUCT_DETAIL(Id_ProductDetail),
	Foreign Key (Id_MassUnit) references MASS_UNIT(Id_MassUnit)
);



-- Đặt bán theo vụ mùa -- ✔
Create Table SALE_OFFER
(
	Id_SaleOffer int not null primary key identity(1,1),
	Id_Farm int,
	Id_MassUnit tinyint,
	Id_ProductDetail int,
	Date_SaleOffer datetime,
	Price_Offer int,
	Quantity_SaleOffer int,	
	Remain_SaleQuantity int,
	Can_Bargain bit,
	Paying_Time tinyint,
	Delivering_Time tinyint,
	Number_Of_Orders tinyint,	
	Is_Deleted bit
	-- Foreign Key --
	Foreign Key (Id_Farm) references FARM(Id_Farm),
	Foreign Key (Id_MassUnit) references MASS_UNIT(Id_MassUnit),
	Foreign Key (Id_ProductDetail) references PRODUCT_DETAIL(Id_ProductDetail)
);

-- SalesOfferDetail ✔
Create Table SALE_OFFER_DETAIL
(
	Id_SaleOfferDetail int not null primary key identity(1,1),
	Id_SaleOffer int,	
	Quantity_SaleOfferDetail int,
	Fine int,			
	Is_Deleted bit
	--Date_SaleOfferDetail datetime,
	--Total_Money int,
	--Id_StatusTrans tinyint,
	-- Foreign Key --
	Foreign Key (Id_SaleOffer) references SALE_OFFER(Id_SaleOffer)
	--Foreign Key (Id_StatusTrans) references Status_Trans(Id_StatusTrans)
);

--TRADER--

-- Đăng ký tài khoản -- ✔
Create Table TRADER
(
	Id_Trader int not null primary key identity(1,1),
	Id_User int,
	Name_Trader nvarchar(50),
	Birthday_Trader datetime,
	Gender_Trader bit,
	Address_Trader nvarchar(200),
	Telephone_Trader nvarchar(10),
	Email_Trader nvarchar(100),
	Is_Deleted bit
	-- Foreign Key --
	Foreign Key (Id_User) references USER_AUTHENTICATION(Id_User)
 )
--Create Table TRADER_REGISTER
--(
--	Id_TraderRegister int not null primary key identity(1,1),
--	Id_User int,
--	Id_Trader int,

--	Foreign Key (Id_User) references USER_AUTHENTICATION(Id_User),
--	Foreign Key (Id_Trader) references TRADER(Id_Trader)
--);

-- Đặt mua theo vụ mùa -- ✔
Create Table PURCHASE_OFFER
(
	Id_PurchasesOffer int not null primary key identity(1,1),
	Id_Trader int,
	Id_MassUnit tinyint,
	Id_Product int,
	Id_Seed int,
	Date_PurchaseOffer datetime,
	Price_Purchase int,
	Quantity_PurchaseOffer int,	
	Remain_PurchaseQuantity int,
	Can_Bargain bit,
	Paying_Time tinyint,
	Delivering_Time tinyint,
	Number_Of_Orders tinyint,
	Is_Deleted bit
	-- Foreign Key --
	Foreign Key (Id_Trader) references TRADER(Id_Trader),
	Foreign Key (Id_MassUnit) references MASS_UNIT(Id_MassUnit),
	Foreign Key (Id_Product) references PRODUCT(Id_Product),
	Foreign Key (Id_Seed) references SEED(Id_Seed)

);

Create Table PURCHASE_OFFER_DETAIL
(
	Id_PurchaseOfferDetail int not null primary key identity(1,1),
	Id_PurchasesOffer int,		
	Quantity_PurchaseOfferDetail int,
	Fine int,		
	Is_Deleted bit
	--Total_Money int,
	--Date_PurchaseOfferDetail datetime,
	--Id_StatusTrans tinyint,
	-- Foreign Key --
	Foreign Key (Id_PurchasesOffer) references PURCHASE_OFFER(Id_PurchasesOffer),
	--Foreign Key (Id_StatusTrans) references Status_Trans(Id_StatusTrans)
);

-- Phiếu Mua Hàng -- ✔
Create Table TRANSACTION_ORDER
(
	Id_TransactionOrder int not null primary key identity(1,1),
	Id_SaleOfferDetail int,
	Id_PurchaseOfferDetail int,
	Id_ProductDetail int,	
	Image_Invoice varchar(200),	
	Transaction_Date datetime,
	Transaction_Mass int,
	Transaction_Unitmass nvarchar(10),
	Transaction_Price int,
	Transaction_TotalMoney int,
	Paying_Time tinyint,
	Delivering_Time tinyint,
	--DeliverTime int,
	Id_StatusTrans tinyint,
	Is_Deleted bit
	-- Foreign Key --
	Foreign Key (Id_SaleOfferDetail) references SALE_OFFER_DETAIL(Id_SaleOfferDetail),
	Foreign Key (Id_PurchaseOfferDetail) references PURCHASE_OFFER_DETAIL(Id_PurchaseOfferDetail),
	Foreign Key (Id_ProductDetail) references PRODUCT_DETAIL(Id_ProductDetail),
	Foreign Key (Id_StatusTrans) references Status_Trans(Id_StatusTrans)
);

Create Table TRADER_PREFERENCE
(
	Id_TraderPreference int not null primary key identity(1,1),
	Id_Trader int,
	Created_Date datetime
	-- Foreign Key --
	Foreign Key (Id_Trader) references TRADER(Id_Trader)
	
);

Create Table TRADER_PREFERENCE_DETAIL
(
	Id_TraderPreferenceDetail int not null primary key identity(1,1),
	Id_TraderPreference int,
	Id_ProductKind int,
	--PriceFrom int,
	--PriceTo int,
	Is_Deleted bit	
	-- Foreign Key --
	Foreign Key (Id_TraderPreference) references TRADER_PREFERENCE(Id_TraderPreference),
	Foreign Key (Id_ProductKind) references PRODUCT_KIND(Id_ProductKind)
);



Create Table FARMER_PREFERENCE
(
	Id_FarmerPreference int not null primary key identity(1,1),
	Id_Farmer int,
	Created_Date datetime
	-- Foreign Key --
	Foreign Key (Id_Farmer) references FARMER(Id_Farmer)
	
);

Create Table FARMER_PREFERENCE_DETAIL
(
	Id_FarmerPreferenceDetail int not null primary key identity(1,1),
	Id_FarmerPreference int,
	Id_Product int,
	--PriceFrom int,
	--PriceTo int,
	Is_Deleted bit
	-- Foreign Key --
	Foreign Key (Id_FarmerPreference) references FARMER_PREFERENCE(Id_FarmerPreference),
	Foreign Key (Id_Product) references PRODUCT(Id_Product)
);

Create Table TOPIC(
	Id_Topic int not null primary key identity(1,1),
	Name_Topic nvarchar(50),
)

Create Table FEED_BACK(
	Id_FeedBack int not null primary key identity(1,1),
	Id_User int,
	Id_Topic int,
	Title_FeedBack nvarchar(50),
	Id_Transaction int,
	Description_FeedBack nvarchar(200),
	Is_Deleted bit
	-- Foreign Key --
	Foreign key(Id_User) references USER_AUTHENTICATION(Id_User),
	Foreign key(Id_Topic) references TOPIC(Id_Topic)
);
	
-----------------------------------Stotre Procedure------------------------------------------

--Insert into PURCHASE_OFFER_DETAIL
go
Create Proc CreatePurchaseDetail @Id_PurchasesOffer int ,@Quantity_PurchaseOfferDetail int 
as
	begin
		
		insert into PURCHASE_OFFER_DETAIL(Id_PurchasesOffer,Quantity_PurchaseOfferDetail)
		values (@Id_PurchasesOffer,@Quantity_PurchaseOfferDetail)
		 
	end

--Insert into SALE_OFFER_DETAIL
go
Create Proc CreateSaleDetail @Id_SaleOffer int ,@Quantity_SaleOfferDetail int
as
	begin
	
		insert into SALE_OFFER_DETAIL(Id_SaleOffer,Quantity_SaleOfferDetail)
		values (@Id_SaleOffer,@Quantity_SaleOfferDetail)
		
	end

--Insert into Transaction
go

Create Proc CreateTransactionOrder @Id_SaleOfferDetail int,@Id_PurchaseOfferDetail int ,@Id_ProductDetail int ,@Transaction_Mass int,@Transaction_Unitmass nvarchar(10),@Transaction_Price int ,@Transaction_TotalMoney int,@Paying_Time tinyint,@Delivering_Time tinyint,@Id_StatusTrans tinyint
as
	
	begin
		insert into TRANSACTION_ORDER(Id_SaleOfferDetail,Id_PurchaseOfferDetail,Id_ProductDetail,Transaction_Date,Transaction_Mass,Transaction_Unitmass,Transaction_Price,Transaction_TotalMoney,Paying_Time,Delivering_Time,Id_StatusTrans,Is_Deleted)
		values (@Id_SaleOfferDetail,@Id_PurchaseOfferDetail,@Id_ProductDetail,CURRENT_TIMESTAMP,@Transaction_Mass,@Transaction_Unitmass,@Transaction_Price,@Transaction_TotalMoney,@Paying_Time,@Delivering_Time,@Id_StatusTrans,0)
	end
	