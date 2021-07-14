USE [ProductDb]
GO
/****** Object:  StoredProcedure [dbo].[spBulkImportProduct]    Script Date: 14-07-2021 19:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spBulkImportProduct]  
(  
      @tblTypeProduct [dbo].tblTypeProduct readonly
)  

AS  
BEGIN  
    MERGE Product  AS dbProduct 
    USING @tblTypeProduct AS tblTypePro  
    ON (dbProduct.EntityName = tblTypePro.EntityName)  
  
    WHEN  MATCHED THEN  
        UPDATE SET  FieldName = tblTypePro.FieldName,   
                    IsRequired = tblTypePro.IsRequired,  
                    [MaxLength]= tblTypePro.[MaxLength],  
                    FieldSource = tblTypePro.FieldSource
  
    WHEN NOT MATCHED THEN  
        INSERT (EntityName, [FieldName],[IsRequired],[MaxLength],FieldSource)  
        VALUES (tblTypePro.EntityName,tblTypePro.FieldName,tblTypePro.IsRequired,tblTypePro.[MaxLength],tblTypePro.FieldSource);  
END  