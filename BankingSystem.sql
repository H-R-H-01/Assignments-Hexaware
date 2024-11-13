-- Assignment -  BANKING SYSTEM

-- Create HMBank DB
CREATE DATABASE HMBank

-- Use HMBank DB
USE HMBank

-- Create Customers Table
CREATE TABLE Customers (
customer_id INT PRIMARY KEY,
first_name VARCHAR(10),
last_name VARCHAR(10),
email VARCHAR(50) UNIQUE,
phone VARCHAR(15) NOT NULL,
C_address VARCHAR(100)  NOT NULL,
city VARCHAR(20)  NOT NULL,
C_state VARCHAR(20)  NOT NULL,
zip_code VARCHAR(10)  NOT NULL
)

-- Create Accounts Table
CREATE TABLE Accounts(
account_id INT PRIMARY KEY,
customer_id INT, -- Foreign key -> Customers table
account_type VARCHAR(10) CHECK (account_type IN ('savings', 'current')),
balance DECIMAL(10, 2) DEFAULT 0.00 NOT NULL,
FOREIGN KEY (customer_id) REFERENCES Customers(customer_id) ON DELETE CASCADE
)

-- Create Transactions Table
CREATE TABLE Transactions (
    transaction_id INT PRIMARY KEY,
    account_id INT, -- Foreign key -> Accounts table
    transaction_date DATE NOT NULL,
    transaction_type VARCHAR(10) CHECK (transaction_type IN ('deposit', 'withdrawal')) NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (account_id) REFERENCES Accounts(account_id) ON DELETE CASCADE
)

-- Insert Sample Data into Customers Table
INSERT INTO Customers (first_name, last_name, email, phone, C_address, city, C_state, zip_code) VALUES 
('John', 'Doe', 'john.doe@example.com', '1234567890', '123 Elm St', 'New York', 'NY', '10001'),
('Jane', 'Smith', 'jane.smith@example.com', '2345678901', '456 Oak St', 'Los Angeles', 'CA', '90001'),
('Albert', 'Einstein', 'albert.einstein@example.com', '3456789012', '789 Pine St', 'Chicago', 'IL', '60001'),
('Isaac', 'Newton', 'isaac.newton@example.com', '4567890123', '321 Maple St', 'Boston', 'MA', '70001'),
('Marie', 'Curie', 'marie.curie@example.com', '5678901234', '654 Birch St', 'San Francisco', 'CA', '80001')

-- Insert Sample Data into Accounts Table
INSERT INTO Accounts (customer_id, account_type, balance) VALUES
(1, 'savings', 1500.00),
(2, 'current', 2500.00),
(3, 'savings', 3000.00),
(4, 'current', 1800.00),
(5, 'savings', 2200.00)

-- Insert Sample Data into Transactions Table
INSERT INTO Transactions (account_id, transaction_date, transaction_type, amount) VALUES
(1, '2024-11-01', 'deposit', 500.00),
(2, '2024-11-02', 'withdrawal', 100.00),
(3, '2024-11-03', 'deposit', 300.00),
(4, '2024-11-04', 'withdrawal', 150.00),
(5, '2024-11-05', 'deposit', 200.00)

-- Task 2

-- 1: Get the full name, account type, and email of each customer
SELECT CONCAT(first_name, ' ', last_name) AS name, account_type, email
FROM Customers
JOIN Accounts ON Customers.customer_id = Accounts.customer_id

-- 2: Get all transactions made by customers
SELECT Customers.first_name, Customers.last_name, Transactions.*
FROM Customers
JOIN Accounts ON Customers.customer_id = Accounts.customer_id
JOIN Transactions ON Accounts.account_id = Transactions.account_id

-- 3: Update balance of an account
SELECT balance FROM Accounts WHERE account_id =1

UPDATE Accounts
SET balance = balance + 100.00
WHERE account_id = 1;

SELECT balance FROM Accounts WHERE account_id =1

-- 4: Get the full name of all customers
SELECT CONCAT(first_name, ' ', last_name) AS full_name FROM Customers;

-- 5: Delete accounts with zero balance and 'savings' account type
DELETE FROM Accounts
WHERE balance = 0 AND account_type = 'savings';

-- 6: Select customers from a specific city
SELECT * FROM Customers WHERE city = 'New York';

-- 7:  Get balance for a specific account
SELECT balance FROM Accounts WHERE account_id = 1;

-- 8: Get accounts with 'current' account type and balance greater than 1000
SELECT * FROM Accounts WHERE account_type = 'current' AND balance > 1000;

-- 9: Get all transactions for a specific account
SELECT * FROM Transactions WHERE account_id = 1;

-- 10: Calculate interest for savings accounts (3% interest)
SELECT account_id, balance * 0.03 AS interest
FROM Accounts
WHERE account_type = 'savings';

-- 11: Get accounts with negative balance
SELECT * FROM Accounts WHERE balance < 0 -- since no account has negative balance , updating an account to have negative balance
UPDATE Accounts SET balance = -100 WHERE account_id = 8
SELECT * FROM Accounts WHERE balance < 0;

-- 12: Select customers excluding those from 'Los Angeles'
SELECT * FROM Customers WHERE city != 'Los Angeles';



--Task 3 -> Aggregate Functions

-- 1. Find the average account balance for all customers
SELECT AVG(balance) AS average_balance
FROM Accounts

-- 2. Retrieve the top 10 highest account balances
SELECT TOP 10 * 
FROM Accounts
ORDER BY balance DESC

-- 3. Calculate Total Deposits for All Customers on a specific date (e.g., '2024-11-01')
SELECT SUM(amount) AS total_deposits
FROM Transactions
WHERE transaction_type = 'deposit' AND transaction_date = '2024-11-01'

-- 4. Find the Oldest and Newest Customers
-- Oldest customer
SELECT TOP 1 * 
FROM Customers
ORDER BY customer_id ASC

-- Newest customer
SELECT TOP 1 * 
FROM Customers
ORDER BY customer_id DESC

-- 5. Retrieve transaction details along with the account type
SELECT t.transaction_id, t.transaction_date, t.transaction_type, t.amount, a.account_type
FROM Transactions t
JOIN Accounts a ON t.account_id = a.account_id

-- 6. Get a list of customers along with their account details
SELECT c.first_name + ' ' + c.last_name AS Customer_Name, a.account_id, a.account_type, a.balance
FROM Customers c
JOIN Accounts a ON c.customer_id = a.customer_id

-- 7. Retrieve transaction details along with customer information for a specific account (e.g., account_id = 1)
SELECT c.first_name + ' ' + c.last_name AS Customer_Name, t.transaction_id, t.transaction_date, t.transaction_type, t.amount
FROM Transactions t
JOIN Accounts a ON t.account_id = a.account_id
JOIN Customers c ON a.customer_id = c.customer_id
WHERE a.account_id = 1

-- 8. Identify customers who have more than one account
	-- Insert additional accounts for existing customers
INSERT INTO Accounts (account_id, customer_id, account_type, balance) VALUES
(11, 3, 'savings', 2000.00),
(12, 4, 'current', 1500.00),  
(13, 5, 'savings', 3000.00),  
(14, 6, 'current', 2500.00)

SELECT c.first_name, c.last_name, COUNT(a.account_id) AS account_count
FROM Customers c
JOIN Accounts a ON c.customer_id = a.customer_id
GROUP BY c.customer_id, c.first_name, c.last_name
HAVING COUNT(a.account_id) > 1


-- 9. Calculate the difference in transaction amounts between deposits and withdrawals
SELECT t.account_id, 
SUM(CASE WHEN t.transaction_type = 'deposit' THEN t.amount ELSE 0 END) - 
SUM(CASE WHEN t.transaction_type = 'withdrawal' THEN t.amount ELSE 0 END) AS balance_difference
FROM Transactions t
GROUP BY t.account_id

-- 10. Calculate the average daily balance for each account over a specified period (e.g., '2024-11-01' to '2024-11-30')
SELECT a.account_id, AVG(a.balance) AS avg_daily_balance
FROM Accounts a
JOIN Transactions t ON a.account_id = t.account_id
WHERE t.transaction_date BETWEEN '2024-11-01' AND '2024-11-30'
GROUP BY a.account_id

-- 11. Calculate the total balance for each account type
SELECT account_type, SUM(balance) AS total_balance
FROM Accounts
GROUP BY account_type

-- 12. Identify accounts with the highest number of transactions, ordered by descending order
SELECT a.account_id, COUNT(t.transaction_id) AS transaction_count
FROM Accounts a
JOIN Transactions t ON a.account_id = t.account_id
GROUP BY a.account_id
ORDER BY transaction_count DESC

-- 13. List customers with high aggregate account balances, along with their account types
SELECT c.first_name + ' ' + c.last_name AS Cust_Name, a.account_type, SUM(a.balance) AS total_balance
FROM Customers c
JOIN Accounts a ON c.customer_id = a.customer_id
GROUP BY c.customer_id, c.first_name, c.last_name, a.account_type
ORDER BY total_balance DESC

-- 14. Identify and list duplicate transactions based on transaction amount, date, and account
SELECT t.transaction_date, t.amount, t.account_id, COUNT(*) AS duplicate_count
FROM Transactions t
GROUP BY t.transaction_date, t.amount, t.account_id
HAVING COUNT(*) > 1

-- Inserting duplicates
INSERT INTO Transactions (transaction_id, account_id, transaction_date, transaction_type, amount)
VALUES
(101, 1, '2024-11-01', 'deposit', 500.00),  
(102, 1, '2024-11-01', 'deposit', 500.00),
(103, 2, '2024-11-02', 'deposit', 200.00),
(104, 2, '2024-11-02', 'deposit', 200.00),
(105, 3, '2024-11-03', 'withdrawal', 100.00),
(106, 3, '2024-11-03', 'withdrawal', 100.00),
(107, 4, '2024-11-04', 'deposit', 150.00),
(108, 4, '2024-11-04', 'deposit', 150.00)


-- Task 4 --
-- 1. Retrieve the customer(s) with the highest account balance.
SELECT customer_id, first_name, last_name
FROM Customers
WHERE customer_id IN (
SELECT customer_id
FROM Accounts
WHERE balance = (SELECT MAX(balance) FROM Accounts)
)

-- 2. Calculate the average account balance for customers who have more than one account.
SELECT AVG(balance) AS average_balance
FROM Accounts
WHERE customer_id IN (
SELECT customer_id
FROM Accounts
GROUP BY customer_id
HAVING COUNT(account_id) > 1
)

-- 3. Retrieve accounts with transactions whose amounts exceed the average transaction amount.
SELECT account_id, transaction_id, transaction_date, amount
FROM Transactions
WHERE amount > (SELECT AVG(amount) FROM Transactions)

-- 4. Identify customers who have no recorded transactions.
	
	--Removing transactions for account id 1, to have no recorded transactions
	DELETE FROM Transactions WHERE account_id = 1

SELECT customer_id, first_name, last_name
FROM Customers
WHERE customer_id NOT IN (
SELECT DISTINCT customer_id
FROM Accounts a
JOIN Transactions t ON a.account_id = t.account_id
)

-- 5. Calculate the total balance of accounts with no recorded transactions.
SELECT SUM(balance) AS total_balance_no_transactions
FROM Accounts
WHERE account_id NOT IN (
SELECT DISTINCT account_id
FROM Transactions
)

-- 6. Retrieve transactions for accounts with the lowest balance.
SELECT transaction_id, account_id, transaction_date, amount
FROM Transactions
WHERE account_id = (
SELECT account_id
FROM Accounts
WHERE balance = (SELECT MIN(balance) FROM Accounts)
)

-- 7. Identify customers who have accounts of multiple types.
	--Inserting values to enable a customer (id=3) to have multiple accounts
	INSERT INTO Accounts (account_id, customer_id, account_type, balance)
	VALUES (15, 3, 'current', 500.00)
		
SELECT customer_id, first_name, last_name
FROM Customers
WHERE customer_id IN (
SELECT customer_id
FROM Accounts
GROUP BY customer_id
HAVING COUNT(DISTINCT account_type) > 1
)

-- 8. Calculate the percentage of each account type out of the total number of accounts.
SELECT account_type, 
(COUNT(account_id) * 100.0 / (SELECT COUNT(*) FROM Accounts)) AS percentage
FROM Accounts
GROUP BY account_type

-- 9. Retrieve all transactions for a customer with a given customer_id (= 3).
SELECT t.transaction_id, t.account_id, t.transaction_date, t.transaction_type, t.amount
FROM Transactions t
JOIN Accounts a ON t.account_id = a.account_id
WHERE a.customer_id = 3

-- 10. Calculate the total balance for each account type, including a subquery within the SELECT clause.
SELECT account_type, 
(SELECT SUM(balance) FROM Accounts WHERE account_type = a.account_type) AS total_balance
FROM Accounts a
GROUP BY account_type
