IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Utilizador]') AND type in (N'U'))
DROP TABLE [dbo].[Utilizador]
GO

CREATE TABLE [dbo].[Utilizador](
	[ID] [int]  NOT NULL    IDENTITY    PRIMARY KEY,
	[NomeUtilizador] [nvarchar](80) NOT NULL,
	[HashPass] [nvarchar](80) NULL,
	[Cargo] [int] NOT NULL)
GO

INSERT INTO [dbo].[Utilizador]
           ([NomeUtilizador]
		   ,[HashPass]
		   ,[Cargo]
           )
     VALUES
           ('João Santos','teste',3),
		  ('admin','admin',0)
		  
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GravarUtilizador]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GravarUtilizador]
GO

CREATE Procedure [dbo].[GravarUtilizador]
@ID int,
@NomeUtilizador nvarchar(80),
@Hash nvarchar(80),
@Cargo int
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GravarNovoUtilizador]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GravarNovoUtilizador]
GO

CREATE Procedure [dbo].[GravarNovoUtilizador]
@NomeUtilizador nvarchar(80),
@Hash nvarchar(80),
@Cargo int
As 
Begin

Begin Transaction
      Begin
         Insert Into [Utilizador] (NomeUtilizador, HashPass, Cargo)
         Values (@NomeUtilizador, @Hash, @Cargo)
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ObterUtilizadorLogin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ObterUtilizadorLogin]
GO

CREATE Procedure [dbo].[ObterUtilizadorLogin]
@nome nvarchar(80),
@pass nvarchar(80)
As 
Begin

	Select * From Utilizador Where NomeUtilizador = @nome and HashPass=@pass
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarClientes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ListarClientes]
GO

CREATE Procedure [dbo].[ListarClientes]
As 
Begin

	Select * From Utilizador WHERE Utilizador.Cargo = 3
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ObterUltimoRegistoUtilizador]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ObterUltimoRegistoUtilizador]
GO

CREATE Procedure [dbo].[ObterUltimoRegistoUtilizador]
@ID nvarchar(10)
AS
Begin

Begin Transaction
         
          Begin
              SELECT TOP 1 * FROM Utilizador ORDER BY ID DESC
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



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Filme]') AND type in (N'U'))
DROP TABLE [dbo].[Filme]
GO

CREATE TABLE [dbo].[Filme](
	[ID] [int]  NOT NULL    IDENTITY    PRIMARY KEY,
	[NomeFilme] [nvarchar](80) NOT NULL,
	[Quantidade] [int] NOT NULL)
GO

INSERT INTO [dbo].[Filme]
           ([NomeFilme]
		   ,[Quantidade]
           )
     VALUES
           ('Interstellar',3),
		   ('Finding Nemo',3)
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GravarFilme]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GravarFilme]
GO

CREATE Procedure [dbo].[GravarFilme]
@ID int,
@NomeFilme nvarchar(80),
@Quantidade int 
As 
Begin

Begin Transaction
   
 IF (Select Count(*) From [Filme] Where ID=@ID)=0
      Begin
         Insert Into [Filme] (NomeFilme, Quantidade)
         Values (@NomeFilme, @Quantidade)
      End
 Else
     Begin
         Update [Filme]
         Set NomeFilme = @NomeFilme, Quantidade = @Quantidade
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GravarNovoFilme]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GravarNovoFilme]
GO

CREATE Procedure [dbo].[GravarNovoFilme]
@NomeFilme nvarchar(80),
@Quantidade int 
As 
Begin

Begin Transaction
      Begin
          Insert Into [Filme] (NomeFilme, Quantidade)
         Values (@NomeFilme, @Quantidade)
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarFilmes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ListarFilmes]
GO					

CREATE Procedure [dbo].[ListarFilmes]
As 
Begin

	Select * From Filme
End

GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EliminarFilme]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EliminarFilme]
GO

CREATE Procedure [dbo].[EliminarFilme]
@ID nvarchar(10)
AS
Begin

Begin Transaction
         
      If (Select Count(*) From Filme Where ID=@ID)<>0
          Begin
              Delete from Filme
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GravarNovaQuantidadeFilme]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GravarNovaQuantidadeFilme]
GO

CREATE Procedure [dbo].[GravarNovaQuantidadeFilme]
@ID int,
@NomeFilme nvarchar(80),
@Quantidade int 
As 
Begin

Begin Transaction
   
 IF (Select Count(*) From [Filme] Where ID=@ID)=0
      Begin
         Insert Into [Filme] (NomeFilme, Quantidade)
         Values (@NomeFilme, @Quantidade)
      End
 Else
     Begin
         Update [Filme]
         SET Quantidade = Quantidade + @Quantidade
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reserva]') AND type in (N'U'))
DROP TABLE [dbo].[Reserva]
GO

CREATE TABLE [dbo].[Reserva](
	[ID] [int]  NOT NULL    IDENTITY    PRIMARY KEY,
	[DataInicio] [datetime] NULL,
	[DataFim] [datetime] NULL,
	[IDCliente] [int] NOT NULL,
	[NomeCliente] [nvarchar](80) NOT NULL,
	[IDFilme] [int] NOT NULL,
	[NomeFilme] [nvarchar](80) NOT NULL,
	[Estado] [int] NOT NULL)
GO

INSERT INTO [dbo].[Reserva]
           (
		   [DataInicio],
		   [IDCliente],
		   [NomeCliente],
		   [IDFilme],
		   [NomeFilme],
		   [Estado]
           )
     VALUES
           ('2022-12-7',1,'João Santos',1, 'Interstellar', 0)
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListarReservas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ListarReservas]
GO					

CREATE Procedure [dbo].[ListarReservas]
As 
Begin

	Select * From Reserva
End

GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApagarReserva]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ApagarReserva]
GO

CREATE Procedure [dbo].[ApagarReserva]
@ID int
AS
Begin

Begin Transaction
         
      If (Select Count(*) From Reserva Where ID=@ID)<>0
          Begin
              Delete from Reserva
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TerminarReserva]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TerminarReserva]
GO

CREATE Procedure [dbo].[TerminarReserva]
@ID int
AS
Begin

Begin Transaction
   

      Begin
         Update [Reserva]
         SET DataFim = CURRENT_TIMESTAMP, Estado = 1
		 WHERE ID = @ID
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GravarNovaReserva]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GravarNovaReserva]
GO

CREATE Procedure [dbo].[GravarNovaReserva]
@IDCliente int,
@NomeCliente nvarchar(80),
@IDFilme int,
@NomeFilme nvarchar(80)
As 
Begin
Begin Transaction
      Begin
         Insert Into Reserva(DataInicio, IDCliente, NomeCliente, IDFilme, NomeFilme, Estado)
         Values (CURRENT_TIMESTAMP, @IDCliente, @NomeCliente, @IDFilme, @NomeFilme, 0)
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