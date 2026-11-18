# Wymagania: Sklep internetowy

## Legenda priorytetów (MoSCoW)

| Priorytet | Znaczenie |
|---|---|
| **M** (Must have) | Niezbędne do działania systemu (MVP) |
| **S** (Should have) | Ważne, ale system może bez nich wystartować |
| **C** (Could have) | Przydatne, realizowane przy wolnym czasie |
| **W** (Won't have this time) | Świadomie poza zakresem obecnej wersji |

Aktorzy: **Gość**, **Klient** (zalogowany), **Administrator**, **System płatności** (zewnętrzny).


## 1. Wymagania funkcjonalne (user stories)

### US-01 Rejestracja konta (M)
**Jako** gość **chcę** założyć konto **aby** móc składać zamówienia i śledzić ich historię.

Kryteria akceptacji:
* Formularz wymaga: imienia, nazwiska, e-maila, hasła i powtórzenia hasła.
* E-mail musi być unikalny. Przy duplikacie wyświetla się komunikat „Konto o tym adresie już istnieje”.
* Hasło ma min. 8 znaków, w tym cyfrę i wielką literę.
* Po rejestracji użytkownik jest automatycznie zalogowany.

### US-02 Logowanie i wylogowanie (M)
**Jako** klient **chcę** zalogować się e-mailem i hasłem **aby** mieć dostęp do swojego konta.

Kryteria akceptacji:
* Po podaniu poprawnych danych użytkownik trafia na stronę główną, a w nagłówku widać jego nazwę.
* Przy błędnych danych wyświetla się komunikat „Nieprawidłowy e-mail lub hasło” (bez wskazania, które pole jest błędne).
* Po 5 nieudanych próbach konto jest blokowane na 15 minut.
* Przycisk „Wyloguj” kończy sesję.

### US-03 Przeglądanie katalogu produktów (M)
**Jako** gość **chcę** przeglądać produkty według kategorii **aby** znaleźć interesujący mnie towar.

Kryteria akceptacji:
* Lista pokazuje zdjęcie, nazwę, cenę i dostępność produktu.
* Lista jest stronicowana (20 produktów na stronę).
* Produkty niedostępne są oznaczone i nie da się ich dodać do koszyka.

### US-04 Wyszukiwanie i filtrowanie (S)
**Jako** gość **chcę** wyszukiwać produkty po nazwie i filtrować je po cenie i kategorii **aby** szybciej znaleźć produkt.

Kryteria akceptacji:
* Wyszukiwanie działa od 3 znaków i nie rozróżnia wielkości liter.
* Filtry można łączyć (np. kategoria + przedział cenowy).
* Gdy brak wyników, wyświetla się komunikat „Nie znaleziono produktów”.
* Sortowanie po cenie (rosnąco i malejąco) oraz po nazwie alfabetycznie.

### US-05 Szczegóły produktu (M)
**Jako** gość **chcę** zobaczyć stronę produktu **aby** poznać jego opis, cenę i dostępność.

Kryteria akceptacji:
* Strona zawiera: nazwę, zdjęcia, opis, cenę, stan magazynowy, przycisk „Dodaj do koszyka”.

### US-06 Zarządzanie koszykiem (M)
**Jako** gość lub klient **chcę** dodawać, usuwać i zmieniać ilość produktów w koszyku **aby** przygotować zamówienie.

Kryteria akceptacji:
* Przy próbie przekroczenia stanu magazynowego wyświetla się komunikat, a ilość nie zostaje zmieniona.
* Suma koszyka przelicza się automatycznie po każdej zmianie.
* Koszyk gościa jest przechowywany w sesji, a po zalogowaniu łączony z koszykiem konta.

### US-07 Składanie zamówienia (M)
**Jako** klient **chcę** złożyć zamówienie z koszyka **aby** kupić wybrane produkty.

Kryteria akceptacji:
* Wymagany jest adres dostawy i wybór metody dostawy.
* Przed potwierdzeniem wyświetla się podsumowanie (produkty, koszt dostawy, suma).
* Przed zapisem system ponownie sprawdza dostępność. Jeśli produktu zabrakło, klient dostaje komunikat i zamówienie nie jest tworzone.
* Po złożeniu zamówienie ma status „Oczekuje na płatność”, a stany magazynowe są rezerwowane.

### US-08 Płatność online (M)
**Jako** klient **chcę** opłacić zamówienie przez zewnętrzny system płatności **aby** sfinalizować zakup.

Kryteria akceptacji:
* Klient jest przekierowany do bramki płatności i z powrotem do sklepu.
* Po udanej płatności zamówienie dostaje status „Opłacone”, a klient otrzymuje e-mail z potwierdzeniem.
* Gdy płatność zostanie odrzucona lub anulowana, status się nie zmienia, a klient może ponowić płatność.
* Zamówienie nieopłacone w ciągu 24 h jest anulowane, a rezerwacja zwalniana.

### US-09 Historia i status zamówień (S)
**Jako** klient **chcę** widzieć listę swoich zamówień i ich statusy **aby** śledzić realizację.

Kryteria akceptacji:
* Lista zawiera: numer, datę, kwotę, status.
* Kliknięcie otwiera szczegóły zamówienia.
* Klient widzi wyłącznie własne zamówienia.

### US-10 Anulowanie zamówienia (S)
**Jako** klient **chcę** anulować zamówienie, które nie zostało jeszcze wysłane **aby** zrezygnować z zakupu.

Kryteria akceptacji:
* Przycisk „Anuluj” jest dostępny tylko dla statusów „Oczekuje na płatność” i „Opłacone”.
* Anulowanie opłaconego zamówienia inicjuje zwrot środków.
* Produkty wracają na stan magazynowy.

### US-11 Zarządzanie produktami (M)
**Jako** administrator **chcę** dodawać, edytować i usuwać produkty **aby** utrzymywać aktualną ofertę.

Kryteria akceptacji:
* Wymagane pola: nazwa, kategoria, cena większa od 0, stan nie mniejszy niż 0.
* Produktu występującego w zamówieniach nie da się usunąć, można go jedynie ukryć.
* Zmiany są widoczne w sklepie od razu po zapisaniu.

### US-12 Zarządzanie kategoriami (S)
**Jako** administrator **chcę** tworzyć i edytować kategorie **aby** porządkować katalog.

Kryteria akceptacji:
* Nazwa kategorii jest unikalna.
* Nie można usunąć kategorii zawierającej produkty.

### US-13 Obsługa zamówień (M)
**Jako** administrator **chcę** przeglądać zamówienia i zmieniać ich status **aby** realizować wysyłki.

Kryteria akceptacji:
* Lista zamówień z filtrem po statusie i dacie.
* Dozwolona kolejność statusów: Opłacone, W realizacji, Wysłane, Dostarczone.
* Każda zmiana statusu wysyła e-mail do klienta.

### US-14 Reset hasła (S)
**Jako** klient **chcę** zresetować zapomniane hasło **aby** odzyskać dostęp do konta.

Kryteria akceptacji:
* Link resetujący jest wysyłany na e-mail i ważny 1 godzinę.
* Link jest jednorazowy.

### US-15 Opinie o produktach (C)
**Jako** klient **chcę** wystawić ocenę w skali od 1 do 5 i komentarz kupionemu produktowi **aby** pomóc innym w wyborze.

Kryteria akceptacji:
* Opinię może dodać tylko klient, który kupił produkt.
* Na stronie produktu widoczna jest średnia ocen.

### US-16 Kody rabatowe (C)
**Jako** klient **chcę** wpisać kod rabatowy w koszyku **aby** otrzymać zniżkę.

Kryteria akceptacji:
* Przy nieważnym lub wygasłym kodzie wyświetla się komunikat, a cena się nie zmienia.
* Rabat jest widoczny w podsumowaniu zamówienia.

### Poza zakresem (W, Won't have)
* Natywna aplikacja mobilna.
* Program lojalnościowy i system punktów.
* Obsługa wielu walut i języków.
* Marketplace z wieloma sprzedawcami.


## 2. Wymagania niefunkcjonalne

| ID | Kategoria | Wymaganie |
|---|---|---|
| NFR-01 | Wydajność | Strony katalogu ładują się w czasie poniżej 2 s przy 100 jednoczesnych użytkownikach. |
| NFR-02 | Bezpieczeństwo | Hasła przechowywane wyłącznie jako hash (bcrypt lub PBKDF2). |
| NFR-03 | Bezpieczeństwo | Cała komunikacja przez HTTPS. |
| NFR-04 | Bezpieczeństwo | Ochrona przed SQL Injection, XSS i CSRF (zapytania parametryzowane, walidacja danych, tokeny antyCSRF). |
| NFR-05 | Bezpieczeństwo | Panel administratora dostępny wyłącznie dla roli „Administrator”. |
| NFR-06 | Bezpieczeństwo, RODO | Dane kart płatniczych nie są przechowywane w systemie, obsługuje je zewnętrzna bramka. Klient może zażądać usunięcia konta. |
| NFR-07 | Dostępność | Dostępność systemu co najmniej 99% w skali miesiąca. |
| NFR-08 | Użyteczność | Interfejs responsywny, działający poprawnie na ekranach o szerokości od 360 px (telefon) do 1920 px. |
| NFR-09 | Użyteczność | Złożenie zamówienia z koszyka wymaga najwyżej 3 kroków. |
| NFR-10 | Kompatybilność | Obsługa aktualnych wersji Chrome, Firefox, Edge i Safari. |
| NFR-11 | Niezawodność | Kopia zapasowa bazy danych wykonywana codziennie, przechowywana 30 dni. |
| NFR-12 | Spójność danych | Złożenie zamówienia i rezerwacja stanów wykonywane w jednej transakcji bazodanowej. |
| NFR-13 | Utrzymywalność | Kod w repozytorium Git, zmiany wyłącznie przez pull request z code review. |
| NFR-14 | Testowalność | Logika biznesowa (koszyk, zamówienia) pokryta testami jednostkowymi w co najmniej 60%. |
| NFR-15 | Lokalizacja | Interfejs w języku polskim, ceny w PLN z VAT. |
