CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Users" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY,
    "Username" TEXT NOT NULL,
    "Email" TEXT NOT NULL,
    "PasswordHash" TEXT NOT NULL,
    "CreatedAt" TEXT NOT NULL,
    "UpdatedAt" TEXT NULL,
    "DeletedAt" TEXT NULL,
    "IsActive" INTEGER NOT NULL
);

CREATE TABLE "RefreshTokens" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_RefreshTokens" PRIMARY KEY AUTOINCREMENT,
    "Token" TEXT NOT NULL,
    "UserId" TEXT NOT NULL,
    "ExpiresAt" TEXT NOT NULL,
    "RevokedAt" TEXT NULL,
    "CreatedAt" TEXT NOT NULL,
    CONSTRAINT "FK_RefreshTokens_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Transacoes" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Transacoes" PRIMARY KEY AUTOINCREMENT,
    "UserId" TEXT NOT NULL,
    "Type" INTEGER NOT NULL,
    "Category" INTEGER NOT NULL,
    "Description" TEXT NOT NULL,
    "Amount" TEXT NOT NULL,
    "Date" TEXT NOT NULL,
    "CreatedAt" TEXT NOT NULL,
    "UpdatedAt" TEXT NULL,
    "DeletedAt" TEXT NULL,
    CONSTRAINT "FK_Transacoes_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_RefreshTokens_UserId" ON "RefreshTokens" ("UserId");

CREATE INDEX "IX_Transacoes_UserId" ON "Transacoes" ("UserId");

CREATE UNIQUE INDEX "IX_Users_Email" ON "Users" ("Email");

CREATE UNIQUE INDEX "IX_Users_Username" ON "Users" ("Username");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20260722183753_InitialCreation', '8.0.17');

COMMIT;

