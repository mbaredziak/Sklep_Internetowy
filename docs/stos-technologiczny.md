# Stos technologiczny – Sklep Internetowy

| Obszar | Technologia | Uzasadnienie |
|---|---|---|
| **Język** | C# | Język, który zespół zna najlepiej. Statyczne typowanie ogranicza błędy, a jeden język na frontendzie i backendzie upraszcza pracę. |
| **Platforma** | .NET (wersja LTS) | Darmowa, wieloplatformowa i wydajna. Wersja LTS ma długie wsparcie i poprawki bezpieczeństwa. |
| **Backend** | ASP.NET Core Web API | Standard do budowy REST API w .NET. Ma wbudowane wstrzykiwanie zależności, walidację, obsługę JWT i dokumentację OpenAPI. |
| **Frontend** | Blazor WebAssembly + MudBlazor | Frontend też w C#, więc cały zespół może pracować nad każdą częścią aplikacji, a modele danych (DTO) da się współdzielić z backendem. MudBlazor daje gotowe, responsywne komponenty (tabele, formularze, okna). |
| **Baza danych** | PostgreSQL | Darmowa, stabilna relacyjna baza. Dane sklepu (produkty, zamówienia, klienci) są ze sobą powiązane, więc model relacyjny pasuje najlepiej. Transakcje chronią spójność przy zamówieniach i płatnościach. |
| **Dostęp do danych** | Entity Framework Core (+ Npgsql) | ORM, który pozwala pracować na obiektach C# zamiast ręcznego SQL. Migracje wersjonują schemat bazy razem z kodem. |
| **Uwierzytelnianie** | ASP.NET Core Identity + JWT | Gotowe, bezpieczne mechanizmy rejestracji, logowania, hashowania haseł i ról (Klient, Administrator), więc nie trzeba pisać tego od zera. |
| **Płatności** | PayU / Przelewy24 (REST API, tryb sandbox) | Popularne w Polsce bramki obsługujące BLIK, przelewy i karty. Sandbox pozwala testować płatności bez prawdziwych pieniędzy. |
| **E-mail** | MailKit + SMTP (do testów: Mailpit) | Wysyłka potwierdzeń zamówień i powiadomień o wysyłce. Mailpit przechwytuje maile lokalnie podczas developmentu. |
| **Testy** | xUnit + NSubstitute | Standardowy framework testów w .NET i biblioteka do atrap (mocków) zależności w testach jednostkowych. |
| **Konteneryzacja** | Docker + Docker Compose | Jedno polecenie uruchamia API, frontend i bazę danych, a każdy członek zespołu ma identyczne środowisko. |
| **CI / repozytorium** | GitHub + GitHub Actions | Pull requesty z code review i automatyczne budowanie oraz testy przy każdym PR. |
| **Diagramy** | Mermaid | Diagramy zapisane jako kod: łatwo je przeglądać w PR, a GitHub wyświetla je bezpośrednio. |

## Podsumowanie

Wybrany stos opiera się na jednym języku (C#) w całej aplikacji, co przy małym zespole
przyspiesza pracę i ułatwia wzajemne code review. Wszystkie technologie są darmowe,
dobrze udokumentowane i powszechnie stosowane w aplikacjach e-commerce.
