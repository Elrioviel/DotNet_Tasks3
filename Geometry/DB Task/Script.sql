CREATE TABLE Products (
	[ID_Product] [int] IDENTITY(1,1) NOT NULL,
	[Product_Name] [nchar](150) NOT NULL,
)
GO

ALTER TABLE Products
ADD CONSTRAINT PK_Product_ProductID PRIMARY KEY CLUSTERED (ID_Product)
GO

CREATE TABLE Categories(
	[ID_Category] [int] IDENTITY(1,1) NOT NULL,
	[Category_Name] [nchar](150) NOT NULL,
)
GO

ALTER TABLE Categories
ADD CONSTRAINT PK_Category_CategoryID PRIMARY KEY CLUSTERED (ID_Category)
GO

INSERT INTO Products (Product_Name) VALUES
('Sausage'),
('Lettuce'),
('Apple'),
('Orange'),
('Ham'),
('Potato'),
('Milk')
GO

INSERT INTO Categories (Category_Name) VALUES
('Vegetable'),
('Fruit'),
('Meat')
GO

CREATE TABLE ProductsCategories (
	ID_Product int NOT NULL,
	ID_Category int NOT NULL,
	FOREIGN KEY (ID_Product) REFERENCES Products(ID_Product),
	FOREIGN KEY (ID_Category) REFERENCES Categories(ID_Category)
	ON UPDATE CASCADE
	ON DELETE CASCADE
);

INSERT INTO ProductsCategories (ID_Product, ID_Category) VALUES
(1, 3),
(2, 1),
(3, 2),
(4, 2),
(5, 3),
(6, 1)
GO

SELECT P.Product_Name, C.Category_Name
FROM Products P
LEFT JOIN ProductsCategories PC
    ON P.ID_Product = PC.ID_Product
LEFT JOIN Categories C
    ON PC.ID_Category = C.ID_Category
