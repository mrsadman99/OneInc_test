CREATE TABLE [dbo].[Policy] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [StartDate]    DATE          NOT NULL,
    [EndDate]      DATE          NOT NULL,
    [BirthDate]    DATE          NOT NULL,
    [ObjectName]   NVARCHAR (40) NOT NULL,
    [MonthCreated] INT           DEFAULT (datepart(month,getdate())) NULL,
    [Type]         INT           NOT NULL,
    [UpdateDate]   DATE          DEFAULT (CONVERT([date],getdate())) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([EndDate]>[StartDate]),
    CHECK (datediff(day,[BirthDate],getdate())/(365)>=(18))
);


GO

CREATE TRIGGER [dbo].[UpdateDisableTrigger]
    ON [dbo].[Policy]
    FOR UPDATE
    AS
	declare @error nvarchar(40)='Cannot modify column:'
	declare @errorHappened bit =0
    BEGIN
		if Update(StartDate)
			begin
				set @errorHappened=1
				set @error=@error+' StartDate '			
			end
		if Update(EndDate)
			begin
				set @errorHappened=1
				set @error=@error+' EndDate '			
			end
		if Update(MonthCreated)
			begin
				set @errorHappened=1
				set @error=@error+' MonthCreated '			
			end
		if Update(BirthDate)
			begin
				set @errorHappened=1
				set @error=@error+' BirthDate '			
			end
		if @errorHappened=1
			begin
				rollback
				raiserror(@error,16,1)
			end
    END