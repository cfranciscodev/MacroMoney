CREATE TABLE [dbo].[Transaction]
(
	[Id] UniqueIdentifier NOT NULL PRIMARY KEY, 
	[AccountId] UniqueIdentifier NOT NULL, 
    [TransactionDate] DATE NOT NULL, 
    [Payee] NVARCHAR(200) NOT NULL, 
    CONSTRAINT [FK_Transaction_Account] FOREIGN KEY (AccountId) REFERENCES Account(Id)
)
