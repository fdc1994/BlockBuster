IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Utilizador]') AND type in (N'U'))
DROP TABLE [dbo].[Utilizador]
GO

CREATE TABLE [dbo].[Utilizador](
	[ID] [int]  NOT NULL    IDENTITY    PRIMARY KEY,
	[NomeUtilizador] [nvarchar](80) NOT NULL,
	[HashPass] [nvarchar](80) NOT NULL,
	[Cargo] [nvarchar](80) NOT NULL)
GO

INSERT INTO [dbo].[Utilizador]
           ([NomeUtilizador]
		   ,[HashPass]
		   ,[Cargo]
           )
     VALUES
           ('João Santos','teste','Colaborador')
		  
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GravarUtilizador]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GravarUtilizador]
GO

CREATE Procedure [dbo].[GravarUtilizador]
@ID nvarchar(10),
@NomeUtilizador nvarchar(80),
@Hash nvarchar(80),
@Cargo nvarchar(80)
As 
Begin

Begin Transaction
   
 IF (Select Count(*) From [Utilizador] Where ID=@ID)=0
      Begin
         Insert Into [Utilizador] (NomeUtilizador, HashPass, Cargo)
         Values (@NomeUtilizador, @Hash, @Cargo)
      End
 Else
     Begin
         Update Utilizador
         Set NomeUtilizador = @NomeUtilizador, HashPass = @Hash, Cargo= @Cargo
         Where ID=@ID
      End
 
      If @@error <>0
            Begin
               Rollback transaction
            End
      Else
            Begin
               Commit Transaction
            End
End

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ObterUtilizador]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ObterUtilizador]
GO

CREATE Procedure [dbo].[ObterUtilizador]
@ID nvarchar(10)
As 
Begin

	Select * From Utilizador Where ID=@ID
End


GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarUtilizadores]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ListarUtilizadores]
GO

CREATE Procedure [dbo].[ListarUtilizadores]
As 
Begin

	Select * From Utilizador
End

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EliminarUtilizador]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EliminarUtilizador]
GO

CREATE Procedure [dbo].[EliminarUtilizador]
@ID nvarchar(10)
AS
Begin

Begin Transaction
         
      If (Select Count(*) From Utilizador Where ID=@ID)<>0
          Begin
              Delete from Utilizador
              Where ID=@ID	
            End

       If @@error <>0
               Begin 
                  Rollback TRansaction
               End
       Else
            Begin
               Commit Transaction
            End

End


GO

