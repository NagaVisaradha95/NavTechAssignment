USE [ProductDb]
GO
/****** Object:  StoredProcedure [dbo].[Masterinsertupdatedelete]    Script Date: 14-07-2021 20:04:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Masterinsertupdatedelete] (@entity_Name           nvarchar(50),
                                          @field_name    nvarchar(50),
                                          @isRequired     bit,
                                          @max_length       int,
                                          @field_source          nvarchar(50),
                                          @StatementType NVARCHAR(20) = '')
AS
  BEGIN
      IF @StatementType = 'Insert'
        BEGIN
            INSERT INTO [dbo].[Product]
                        ([EntityName]
					   ,[FieldName]
					   ,[IsRequired]
					   ,[MaxLength]
					   ,[FieldSource])
            VALUES     ( @entity_Name,
                         @field_name,
                         @isRequired,
                         @max_length ,
                         @field_source)
        END

      IF @StatementType = 'Select'
        BEGIN
            SELECT *
            FROM   [dbo].[Product] where FieldName = @field_name
        END

      IF @StatementType = 'Update'
        BEGIN
            UPDATE [dbo].[Product]
            SET    [EntityName]= @entity_Name,
                   [FieldName] = @field_name,
                   [IsRequired] = @isRequired,
                   [MaxLength] = @max_length,
				   [FieldSource] = @field_source
            WHERE  [FieldName] = @field_name 
        END
      ELSE IF @StatementType = 'Delete'
        BEGIN
            DELETE FROM [dbo].[Product]
            WHERE  [FieldSource] = @field_source
        END
  END