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

-- ���������� ������ � ������� Products
INSERT INTO Products (Product_Name, Product_Cost, Product_Description)
VALUES 
('�������', 800.00, '������ ������� � ������� ������� ������ � ������� �����������'),
('��������', 500.00, '����������� �������� � ������� �������� ����������'),
('�������', 300.00, '������ � ���������� ������� ��� ������������� �������������');
GO

-- ���������� ������ � ������� Stock
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

CREATE VIEW ���_��������
AS
SELECT 
	Product_ID AS �������������_��������,
	Product_Name AS ������������_��������,
	Product_Cost AS ���������_��������,
	Product_Description AS ��������_��������
FROM Products;
GO


CREATE VIEW ���_�����
AS
SELECT 
	Stock_ID AS �������������_������,
	Stock_Number_of_Products AS ����������_���������,
	Stock_Date_of_Receipt AS ����_�����������,
	ID_Product AS �������������_��������
FROM Stock;
GO

CREATE VIEW StockView
AS
SELECT 
    s.Stock_ID AS �������������_������,
    s.Stock_Number_of_Products AS ����������_���������,
    s.Stock_Date_of_Receipt AS ����_�����������,
    p.Product_Name AS ������������_��������
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
