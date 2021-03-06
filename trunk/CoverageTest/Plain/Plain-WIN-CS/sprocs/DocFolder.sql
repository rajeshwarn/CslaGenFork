/****** Object:  StoredProcedure [AddDocFolderRelation] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddDocFolderRelation]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddDocFolderRelation]
GO

CREATE PROCEDURE [AddDocFolderRelation]
    @DocID int,
    @FolderID int,
    @CreateDate datetime2,
    @CreateUserID int,
    @ChangeDate datetime2,
    @ChangeUserID int,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for soft deleted object existence */
        IF EXISTS
        (
            SELECT [DocID], [FolderID] FROM [DocsFolders]
            WHERE
                [DocID] = @DocID AND
                [FolderID] = @FolderID AND
                [IsActive] = 'false'
        )
            BEGIN
                /* Update object in DocsFolders */
                UPDATE [DocsFolders]
                SET
                    [ChangeDate] = @ChangeDate,
                    [ChangeUserID] = @ChangeUserID,
                    [IsActive] = 'true'
                WHERE
                    [DocID] = @DocID AND
                    [FolderID] = @FolderID
            END
        ELSE
            BEGIN
                /* Insert object into DocsFolders */
                INSERT INTO [DocsFolders]
                (
                    [DocID],
                    [FolderID],
                    [CreateDate],
                    [CreateUserID],
                    [ChangeDate],
                    [ChangeUserID]
                )
                VALUES
                (
                    @DocID,
                    @FolderID,
                    @CreateDate,
                    @CreateUserID,
                    @ChangeDate,
                    @ChangeUserID
                )
            END

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [DocsFolders]
        WHERE
            [DocID] = @DocID AND
            [FolderID] = @FolderID

    END
GO

/****** Object:  StoredProcedure [UpdateDocFolderRelation] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateDocFolderRelation]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateDocFolderRelation]
GO

CREATE PROCEDURE [UpdateDocFolderRelation]
    @DocID int,
    @FolderID int,
    @ChangeDate datetime2,
    @ChangeUserID int,
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [DocID], [FolderID] FROM [DocsFolders]
            WHERE
                [DocID] = @DocID AND
                [FolderID] = @FolderID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''DocFolder'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [DocID], [FolderID] FROM [DocsFolders]
            WHERE
                [DocID] = @DocID AND
                [FolderID] = @FolderID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''DocFolder'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in DocsFolders */
        UPDATE [DocsFolders]
        SET
            [ChangeDate] = @ChangeDate,
            [ChangeUserID] = @ChangeUserID
        WHERE
            [DocID] = @DocID AND
            [FolderID] = @FolderID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [DocsFolders]
        WHERE
            [DocID] = @DocID AND
            [FolderID] = @FolderID

    END
GO

/****** Object:  StoredProcedure [DeleteDocFolderRelation] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteDocFolderRelation]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteDocFolderRelation]
GO

CREATE PROCEDURE [DeleteDocFolderRelation]
    @DocID int,
    @FolderID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [DocID], [FolderID] FROM [DocsFolders]
            WHERE
                [DocID] = @DocID AND
                [FolderID] = @FolderID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''DocFolder'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark DocFolder object as not active */
        UPDATE [DocsFolders]
        SET    [IsActive] = 'false'
        WHERE
            [DocsFolders].[DocID] = @DocID AND
            [DocsFolders].[FolderID] = @FolderID

    END
GO
