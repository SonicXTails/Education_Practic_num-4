CREATE DATABASE Information_System_Of_Market;
GO

USE Information_System_Of_Market;
GO



CREATE TABLE Products(
	Product_ID					INT				PRIMARY KEY		IDENTITY(1,1),
	Product_Name				VARCHAR(100)	NOT NULL,
	Product_Cost				REAL			NOT NULL,
	Product_Description			TEXT			NOT NULL,
);
GO

CREATE TABLE Stock(
	Stock_ID					INT				PRIMARY KEY		IDENTITY(1,1),
	Stock_Number_of_Products	INT,
	Stock_Date_of_Receipt		DATETIME		NOT NULL,
	ID_Product					INT				NOT NULL,

	FOREIGN KEY (ID_Product) REFERENCES Products(Product_ID)
	
);
GO

-- Добавление данных в таблицу Products
INSERT INTO Products (Product_Name, Product_Cost, Product_Description)
VALUES 
('Ноутбук', 800.00, 'Мощный ноутбук с большим объемом памяти и быстрым процессором'),
('Смартфон', 500.00, 'Современный смартфон с камерой высокого разрешения'),
('Планшет', 300.00, 'Легкий и компактный планшет для повседневного использования');
GO

-- Добавление данных в таблицу Stock
INSERT INTO Stock (Stock_Number_of_Products, Stock_Date_of_Receipt, ID_Product)
VALUES 
(50, '2023-01-15T10:00:00', 1),
(100, '2023-01-16T11:30:00', 2),
(30, '2023-01-17T09:45:00', 3);
GO

CREATE TRIGGER trg_Product_Insert
ON Products
AFTER INSERT
AS
BEGIN
    INSERT INTO Stock (Stock_Number_of_Products, Stock_Date_of_Receipt, ID_Product)
    SELECT 0, GETDATE(), Product_ID
    FROM inserted;
END;
GO

CREATE VIEW Вид_Продукты
AS
SELECT 
	Product_ID AS Идентификатор_продукта,
	Product_Name AS Наименование_продукта,
	Product_Cost AS Стоимость_продукта,
	Product_Description AS Описание_продукта
FROM Products;
GO


CREATE VIEW Вид_Склад
AS
SELECT 
	Stock_ID AS Идентификатор_склада,
	Stock_Number_of_Products AS Количество_продуктов,
	Stock_Date_of_Receipt AS Дата_поступления,
	ID_Product AS Идентификатор_продукта
FROM Stock;
GO

CREATE VIEW StockView
AS
SELECT 
    s.Stock_ID AS Идентификатор_склада,
    s.Stock_Number_of_Products AS Количество_продуктов,
    s.Stock_Date_of_Receipt AS Дата_поступления,
    p.Product_Name AS Наименование_продукта
FROM Stock s
JOIN Products p ON s.ID_Product = p.Product_ID;
GO

CREATE TRIGGER trg_UpdateStockDate
ON Stock
AFTER UPDATE
AS
BEGIN
    IF UPDATE(Stock_Number_of_Products)
    BEGIN
        UPDATE Stock
        SET Stock_Date_of_Receipt = GETDATE()
        FROM Stock
        INNER JOIN inserted ON Stock.Stock_ID = inserted.Stock_ID;
    END
END;

SELECT MAX(ID_Product) AS Last_Product_ID
FROM Stock;
