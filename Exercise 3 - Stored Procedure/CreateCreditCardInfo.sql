/*
	This procedure will accept parameters to create Account, Bank Account and Credit card records 
	and update output parameter AccountID with primary key value of newly created record.

	declare @AccountID bigint
	exec dbo.Proc_CreateCreditCardInfo 1, 1, '123123','123123123',null,'1234123412341234','2020.3.21', @AccountID out
	select @AccountID as AccountID

	select * from dbo.Account
	select * from dbo.BankAccount
	select * from dbo.CreditCard


*/
create procedure dbo.Proc_CreateCreditCardInfo
(
	@AccountTypeID tinyint,
	@AddedByUserID smallint,
	@BSB nvarchar(6),
	@AccountNumber nvarchar(9),
	@Suffic nvarchar(2),
	@CardNumber nvarchar(16),
	@ExpiryDate date,
	@AccountID bigint out
)
as
begin
	begin try
		begin transaction

		insert into dbo.Account (AccountTypeID, AddedDate, AddedByUserID) values (@AccountTypeID, getdate(), @AddedByUserID)
		set @AccountID = @@IDENTITY

		insert into dbo.BankAccount (AccountID, BSB, AccountNumber, Suffic) values (@AccountID, @BSB, @AccountNumber, @Suffic)

		insert into dbo.CreditCard (AccountID, CardNumber, ExpiryDate) values (@AccountID, @CardNumber, @ExpiryDate)

		commit
	end try
	begin catch
		rollback
		declare @ErrorMessage nvarchar(4000) = error_message(), 
				@ErrorSeverity int = error_severity(),
				@ErrorState int = error_state()

		raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState)   
	end catch	
end
go




