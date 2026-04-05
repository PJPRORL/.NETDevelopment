@echo off
title Push naar GitHub
echo ==============================================================
echo Pushing ".NET Development" map naar GitHub
echo Repository: https://github.com/PJPRORL/.NETDevelopment
echo ==============================================================
echo.

:: 1. Git initialiseren indien nog niet gebeurd
if not exist ".git\" (
    echo [1/5] Git repository wordt klaargemaakt...
    git init
) else (
    echo [1/5] Git repository is al aanwezig.
)

:: 2. Bestanden toevoegen
echo [2/5] Bestanden worden toegevoegd...
:: (Let op: de .gitignore file zorgt ervoor dat grote bin/obj mappen worden overgeslagen)
git add .

:: 3. Wijzigingen vastleggen (Commit)
echo [3/5] Wijzigingen worden opgeslagen (commit)...
git commit -m "Automatische update van .NET projecten"

:: Zorg ervoor dat de hoofd-branch "main" heet
git branch -M main

:: 4. Remote instellen of updaten
echo [4/5] GitHub connectie wordt ingesteld...
git remote set-url origin https://github.com/PJPRORL/.NETDevelopment.git >nul 2>&1
if errorlevel 1 (
    git remote add origin https://github.com/PJPRORL/.NETDevelopment.git
)

:: 5. Bestanden Pushing naar GitHub
echo [5/5] Bestanden worden doorgestuurd naar GitHub...
git push -u origin main

echo.
echo ==============================================================
echo Klaar! Lees hierboven of er eventuele inlog-schermen of fouten waren.
echo ==============================================================
pause
