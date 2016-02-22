CREATE TABLE [dbo].[TransactionDetail]
(
	[Id] UniqueIdentifier NOT NULL PRIMARY KEY,
	[TransactionId] UniqueIdentifier NOT NULL,
	[Amount] Money NOT NULL,
	[CategoryId] UniqueIdentifier NOT NULL, 
    CONSTRAINT [FK_TransactionDetail_Transaction] FOREIGN KEY ([TransactionId]) REFERENCES dbo.[Transaction]([Id]), 
    CONSTRAINT [FK_TransactionDetail_Category] FOREIGN KEY (CategoryId) REFERENCES Category(Id)
)
