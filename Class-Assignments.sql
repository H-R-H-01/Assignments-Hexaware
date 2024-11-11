-- Class Assignments ( 1 - 4 )
-- Assignment 1 ( ER Diagram )
-- Assignment 2 : Online Book Store + Additional tasks
-- Assignment 3 : focused on Join
-- Assignment 4 : Subqueries
-- Assignment 5 : Grouping sets, Roll up, cube and merge

-- Create the database for an Online Book Store
CREATE DATABASE Bookstore

USE Bookstore

-- Creating tables
CREATE TABLE Books (
    ISBN VARCHAR(15) PRIMARY KEY,
    Title VARCHAR(100),
    PublicationDate DATE,
    Price DECIMAL(10, 2),
    PublisherID INT,
    FOREIGN KEY (PublisherID) REFERENCES Publisher(PublisherID)
)

CREATE TABLE Author (
    AuthorID INT PRIMARY KEY,
    AuthorName VARCHAR(50)
)

CREATE TABLE Publisher (
    PublisherID INT PRIMARY KEY,
    PublisherName VARCHAR(100),
    PublisherAddress VARCHAR(100),
    Contact VARCHAR(20)
)

CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Email VARCHAR(50),
    ContactNum VARCHAR(15)
)

CREATE TABLE OrderTable (
    OrderID INT PRIMARY KEY,
    UserID INT,
    OrderDate DATE,
    TotalAmount DECIMAL(10, 2),
    OrderStatus VARCHAR(50),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
)

CREATE TABLE OrderDetails (
    OrderID INT,
    ISBN VARCHAR(15),
    Quantity INT,
    Price DECIMAL(10, 2),
    PRIMARY KEY (OrderID, ISBN),
    FOREIGN KEY (OrderID) REFERENCES OrderTable(OrderID),
    FOREIGN KEY (ISBN) REFERENCES Books(ISBN)
)

-- Inserting sample data into Publisher and Author for referential integrity
INSERT INTO Publisher (PublisherID, PublisherName, PublisherAddress, Contact) VALUES
(1, 'Tech Books Ltd.', '123 Tech St, Cityville', '123-4567890'),
(2, 'Science Publications', '456 Science Ave, Knowledge City', '987-6543210'),
(3, 'Academic Press', '789 Academic Blvd, University Town', '555-1234567'),
(4, 'Literature Hub', '101 Lit Rd, Booktown', '321-6549870'),
(5, 'Music Books', '202 Music Ln, Melody City', '789-4561230')

INSERT INTO Author (AuthorID, AuthorName) VALUES
(1, 'John Doe'),
(2, 'Jane Smith'),
(3, 'Albert Einstein'),
(4, 'Isaac Newton')

-- Inserting sample data into Users
INSERT INTO Users (UserID, Email, ContactNum) VALUES
(1, 'user1@example.com', '555-1234'),
(2, 'user2@example.com', '555-5678'),
(3, 'user3@example.com', '555-9876')

-- Inserting sample data into Books
ALTER TABLE Books
ADD Genre VARCHAR(50)
INSERT INTO Books (ISBN, Title, PublicationDate, Price, PublisherID, Genre) VALUES
('no123', 'Intro to Tech', '2001-01-01', 99.99, 1, 'technology'),
('no124', 'Advanced Science', '2005-05-15', 120.00, 2, 'science'),
('no125', 'World Literature', '2010-08-20', 45.50, 1, 'literature'),
('no126', 'Modern Physics', '2015-03-30', 75.00, 3, 'science'),
('no127', 'Database Design', '2018-06-25', 60.00, 2, 'technology'),
('no128', 'Creative Writing', '2019-11-10', 39.99, 4, 'literature'),
('no129', 'Data Structures', '2020-01-15', 89.50, 1, 'technology'),
('no130', 'Classical Music', '2020-12-20', 50.00, 5, 'music'),
('no131', 'Environmental Science', '2021-04-12', 65.75, 2, 'science'),
('no132', 'AI and Robotics', '2022-09-05', 150.00, 3, 'technology')

-- Inserting sample data into OrderTable
INSERT INTO OrderTable (OrderID, UserID, OrderDate, TotalAmount, OrderStatus) VALUES
(1, 1, '2024-10-01', 199.99, 'pending'),
(2, 2, '2024-10-02', 99.50, 'completed'),
(3, 3, '2024-10-03', 79.99, 'pending')

-- Inserting sample data into OrderDetails (now the ISBN values match those from the Books table)
INSERT INTO OrderDetails (OrderID, ISBN, Quantity, Price) VALUES
(1, 'no123', 1, 99.99),
(2, 'no124', 1, 120.00),
(3, 'no125', 1, 45.50)

-- 5th Task - Add the Genre column and update prices for technology books
ALTER TABLE Books
ADD Genre VARCHAR(50)

-- Inserting Genre values for the books
UPDATE Books
SET Genre = 'technology' WHERE ISBN IN ('no123', 'no129', 'no132')
UPDATE Books
SET Genre = 'science' WHERE ISBN IN ('no124', 'no126', 'no131')
UPDATE Books
SET Genre = 'literature' WHERE ISBN IN ('no125', 'no128')
UPDATE Books
SET Genre = 'music' WHERE ISBN = 'no130'

-- Increase the price of all books in the "technology" genre by 6
UPDATE Books
SET Price = Price + 6
WHERE Genre = 'technology'

-- Additional tasks --

-- 1. List all books where price is greater than 28
SELECT * FROM Books
WHERE Price > 28

-- 2. List all books where PublisherID is 2
SELECT * FROM Books
WHERE PublisherID = 2

-- 3. Find all orders where status is "pending"
SELECT * FROM OrderTable
WHERE OrderStatus = 'pending'

-- 4. Change the price of the book with ISBN = 'no123' to 398
UPDATE Books
SET Price = 398
WHERE ISBN = 'no123'

-- 6. Delete a book with a specific ISBN (e.g., 'no123')
DELETE FROM Books
WHERE ISBN = 'no123'

-- 7. Get details of books published on or after January 1, 2022
SELECT * FROM Books
WHERE PublicationDate >= '2022-01-01'

-- 8. List all books where the genre is not "science"
SELECT * FROM Books
WHERE Genre <> 'science'

-- 9. List all customers with contact numbers that are not null
SELECT * FROM Users
WHERE ContactNum IS NOT NULL


--Assignment 3 (07-11-24)

-- 1. Count the total number of books in the bookstore
SELECT COUNT(*) AS TotalBooks FROM Books

-- 2. Find the average price of all books in the "Technology" genre
SELECT AVG(Price) AS AveragePrice FROM Books
WHERE Genre = 'technology'

-- 3. Get the total revenue generated from all orders
SELECT SUM(TotalAmount) AS TotalRevenue FROM OrderTable

-- 4. Find the minimum and maximum price of books in the "Fiction" genre
INSERT INTO Books (ISBN, Title, PublicationDate, Price, PublisherID, Genre) VALUES
('no1234561', 'Intro to Fiction', '2001-11-01', 99.99, 1, 'fiction')

SELECT MIN(Price) AS MinPrice, MAX(Price) AS MaxPrice FROM Books
WHERE Genre = 'fiction'

-- 5. Count the number of orders for each status (Pending, Shipped, Delivered)
SELECT OrderStatus, COUNT(*) AS OrderCount
FROM OrderTable
GROUP BY OrderStatus

-- 6. Get the month when each order was placed
SELECT OrderID, MONTH(OrderDate) AS OrderMonth FROM OrderTable

-- 7. Calculate the total revenue for each month
SELECT MONTH(OrderDate) AS OrderMonth, SUM(TotalAmount) AS MonthlyRevenue
FROM OrderTable
GROUP BY MONTH(OrderDate)

-- 8. List all books along with their publisher names
SELECT Books.ISBN, Books.Title, Publisher.PublisherName
FROM Books
JOIN Publisher ON Books.PublisherID = Publisher.PublisherID

-- 9. Retrieve all orders along with the names of the customers who placed them
SELECT OrderTable.OrderID, Users.Email AS CustomerEmail, OrderTable.TotalAmount
FROM OrderTable
JOIN Users ON OrderTable.UserID = Users.UserID

-- 10. Find all books that have been ordered at least once
SELECT DISTINCT Books.ISBN, Books.Title
FROM Books
JOIN OrderDetails ON Books.ISBN = OrderDetails.ISBN

-- 11. Retrieve a list of authors along with the titles of books they have written
-- There is no relation between authors and books, so creating a new table that establishes a relation between authors and books

CREATE TABLE AuthorBook (
    AuthorID INT,
    ISBN VARCHAR(15), --foreign key -> books
    PRIMARY KEY (AuthorID, ISBN),
    FOREIGN KEY (AuthorID) REFERENCES Author(AuthorID) ON DELETE CASCADE,
    FOREIGN KEY (ISBN) REFERENCES Books(ISBN) ON DELETE CASCADE
)
INSERT INTO AuthorBook (AuthorID, ISBN) VALUES 
(1, 'no123'),
(1, 'no127'),
(2, 'no124'),
(2, 'no125'),
(3, 'no126'),
(3, 'no132'),
(4, 'no131'),
(4, 'no130'),
(1, 'no132'),
(2, 'no132')

SELECT Author.AuthorName, Books.Title
FROM Author
JOIN AuthorBook ON Author.AuthorID = AuthorBook.AuthorID
JOIN Books ON AuthorBook.ISBN = Books.ISBN

-- 12. List all books along with their publisher names, including books with no publisher information
SELECT Books.ISBN, Books.Title, ISNULL(Publisher.PublisherName, 'No Publisher') AS PublisherName
FROM Books
LEFT JOIN Publisher ON Books.PublisherID = Publisher.PublisherID

-- 13. Retrieve all orders with their details, including orders with no items
SELECT OrderTable.OrderID, OrderTable.OrderDate, ISNULL(OrderDetails.ISBN, 'No items') AS ISBN, ISNULL(OrderDetails.Quantity, 0) AS Quantity
FROM OrderTable
LEFT JOIN OrderDetails ON OrderTable.OrderID = OrderDetails.OrderID

-- 14. Find all pairs of customers from the same city
-- Add City column to Users table as it doesn't exist
ALTER TABLE Users
ADD City VARCHAR(50)

UPDATE Users SET City = 'New York' WHERE UserID = 1
UPDATE Users SET City = 'Los Angeles' WHERE UserID = 2
UPDATE Users SET City = 'Chicago' WHERE UserID = 3

-- Retrieve pairs of customers from the same city
SELECT U1.Email AS Customer1, U2.Email AS Customer2, U1.City
FROM Users U1
JOIN Users U2 ON U1.City = U2.City AND U1.UserID < U2.UserID

SELECT City, COUNT(*)
FROM Users
GROUP BY City
HAVING COUNT(*) > 1

UPDATE Users SET City = 'Chicago' WHERE UserID = 2
UPDATE Users SET City = 'Chicago' WHERE UserID = 3

SELECT City, COUNT(*)
FROM Users
GROUP BY City

-- Assignment 4- Subqueries (08-11-24)
use Bookstore

-- 1. Find the title of the book with the highest price.
SELECT Title
FROM Books
WHERE Price = (SELECT MAX(Price) FROM Books)

-- 2. List all authors who have written books in the "fiction" genre.
	-- No connection between author and books table.. so creating a new table BookAuthor to establish a connection.
	CREATE TABLE BookAuthor (
    AuthorID INT,
    ISBN VARCHAR(15), 
    PRIMARY KEY (AuthorID, ISBN),
    FOREIGN KEY (AuthorID) REFERENCES Author(AuthorID),
    FOREIGN KEY (ISBN) REFERENCES Books(ISBN)
	)
	INSERT INTO BookAuthor (ISBN, AuthorID) VALUES
	('no123', 1),
	('no124', 2),
	('no125', 3),
	('no126', 4),
	('no127', 1),
	('no128', 2),
	('no129', 3),
	('no130', 4),
	('no131', 1),
	('no132', 2)

SELECT Title, Genre,
(SELECT AuthorName 
FROM Author
WHERE AuthorID = (SELECT AuthorID FROM BookAuthor WHERE ISBN = Books.ISBN)) AS AuthorName
FROM Books
WHERE Genre = 'technology'

-- 3. Find the titles of books that have never been ordered.
SELECT Title
FROM Books
WHERE ISBN NOT IN (
    SELECT ISBN
    FROM OrderDetails
)

-- 4. Get the names of customers who have placed orders totaling more than a specified amount.
SELECT Email,userID
FROM Users
WHERE UserID IN (
    SELECT UserID
    FROM OrderTable
    GROUP BY UserID
    HAVING SUM(TotalAmount) > 100
)
select  * from users

-- 5. List all books that cost more than the average price of all books.
SELECT Title
FROM Books
WHERE Price > (SELECT AVG(Price) FROM Books)

-- 6. Retrieve books published by the publisher with the fewest books.
SELECT Title
FROM Books
WHERE PublisherID = (
    SELECT TOP 1 PublisherID
    FROM Books
    GROUP BY PublisherID
    ORDER BY COUNT(*) ASC)

-- 7. Find the average quantity of books per order.
SELECT AVG(Quantity) AS AvgQuantity
FROM OrderDetails

-- 8. Display each book's title and its rank by price (highest to lowest).
SELECT Title, 
(SELECT COUNT(*) FROM Books AS B2 WHERE B2.Price > B1.Price) + 1 AS Rank
FROM Books AS B1
ORDER BY Rank

-- 9. Find customers who have placed more orders than the average orders per customer.
SELECT Email
FROM Users
WHERE UserID IN (SELECT UserID
				FROM OrderTable
				GROUP BY UserID
				HAVING COUNT(OrderID) > (SELECT AVG(OrderCount)
										FROM (SELECT UserID, COUNT(OrderID) AS OrderCount FROM OrderTable GROUP BY UserID) AS OrderCounts)
)

-- 10. List all books along with the number of orders using a correlated subquery.
SELECT Title,
(SELECT COUNT(*) FROM OrderDetails WHERE Books.ISBN = OrderDetails.ISBN) AS OrderCount
FROM Books


-- Assignment 5 -- Grouping set, roll up,  cube and merge

-- 1. Get the total sales amount by month and genre. including totals for each genre across all months and for each month across all genres.
SELECT FORMAT(O.OrderDate, 'yyyy-MM') AS Month, B.Genre, SUM(OD.Quantity * B.Price) AS TotalSales
FROM OrderTable AS O
JOIN OrderDetails AS OD ON O.OrderID = OD.OrderID
JOIN Books AS B ON OD.ISBN = B.ISBN
GROUP BY ROLLUP(FORMAT(O.OrderDate, 'yyyy-MM'), B.Genre)
ORDER BY Month, Genre

-- 2. Show the total quantity sold and total sales revenue for each publisher and genre, including totals by publisher, by genre, and overall
SELECT P.PublisherName, B.Genre, SUM(OD.Quantity) AS TotalQuantitySold, SUM(OD.Quantity * B.Price) AS TotalRevenue
FROM OrderDetails AS OD
JOIN Books AS B ON OD.ISBN = B.ISBN
JOIN Publisher AS P ON B.PublisherID = P.PublisherID
GROUP BY CUBE(P.PublisherName, B.Genre)
ORDER BY PublisherName, Genre

-- 3. Get the total revenue generated from each book genre per month with subtotals by genre and by month
SELECT B.Genre, FORMAT(O.OrderDate, 'yyyy-MM') AS Month, SUM(OD.Quantity * B.Price) AS TotalRevenue
FROM OrderTable AS O
JOIN OrderDetails AS OD ON O.OrderID = OD.OrderID
JOIN Books AS B ON OD.ISBN = B.ISBN
GROUP BY CUBE(B.Genre, FORMAT(O.OrderDate, 'yyyy-MM'))
ORDER BY Genre, Month

-- Assignment 6