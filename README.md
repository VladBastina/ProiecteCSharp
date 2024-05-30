# Gestionarea unui Supermarket

## Introducere

Această documentație descrie proiectul de gestionare a unui supermarket dezvoltat folosind limbajul C#, framework-ul WPF și SQL Server pentru baza de date. Proiectul este structurat pe modelul MVVM (Model-View-ViewModel) și include funcționalități pentru gestionarea utilizatorilor, produselor, producătorilor, categoriilor de produse, stocurilor, bonurilor de casă și ofertelor. Aplicația are două tipuri de utilizatori: administrator și casier.

## Arhitectura Proiectului

### Model-View-ViewModel (MVVM)

- **Model**: Reprezintă datele și logica de acces la date.
- **View**: Interfața grafică cu utilizatorul (WPF).
- **ViewModel**: Logica de prezentare care leagă Modelul de View.

### Straturile Aplicației

- **Presentation Layer**: Implementat cu WPF pentru interfața grafică.
- **Business Logic Layer**: Conține clase și metode care gestionează logica aplicației.
- **Data Access Layer**: Folosește ADO.NET pentru accesarea și manipularea bazei de date.
- **Database**: SQL Server pentru stocarea datelor.

## Baza de Date

### Tabelele și Structura Bazei de Date

1. **Produse**
   - ID (int, Primary Key)
   - Nume (nvarchar)
   - CodBare (varchar)
   - CategorieID (int, Foreign Key)
   - ProducatorID (int, Foreign Key)

2. **Producatori**
   - ID (int, Primary Key)
   - Nume (nvarchar)
   - TaraOrigine (nvarchar)

3. **CategoriiProduse**
   - ID (int, Primary Key)
   - Denumire (nvarchar)

4. **Stocuri**
   - ID (int, Primary Key)
   - ProdusID (int, Foreign Key)
   - Cantitate (int)
   - UnitateMasura (nvarchar)
   - DataAprovizionarii (datetime)
   - DataExpirarii (datetime)
   - PretAchizitie (decimal)
   - PretVanzare (decimal)
   - Activ (bit)

5. **Utilizatori**
   - ID (int, Primary Key)
   - Nume (nvarchar)
   - Parola (nvarchar)
   - TipUtilizator (nvarchar) - Admin, Casier

6. **BonuriCasa**
   - ID (int, Primary Key)
   - DataEliberarii (datetime)
   - CasierID (int, Foreign Key)
   - SumaIncasata (decimal)

7. **DetaliiBonuri**
   - ID (int, Primary Key)
   - BonCasaID (int, Foreign Key)
   - ProdusID (int, Foreign Key)
   - Cantitate (int)
   - Subtotal (decimal)

8. **Oferte** (optional)
   - ID (int, Primary Key)
   - MotivOferta (nvarchar)
   - ProdusID (int, Foreign Key)
   - ProcentReducere (int)
   - DataInceput (datetime)
   - DataSfarsit (datetime)

## Funcționalitatea Aplicației

### Funcționalități pentru Administrator

1. **Gestionarea Utilizatorilor**
   - Adăugare, modificare, ștergere (logică) și vizualizare utilizatori.

2. **Gestionarea Produselor**
   - Adăugare, modificare, ștergere (logică) și vizualizare produse.

3. **Gestionarea Producătorilor**
   - Adăugare, modificare, ștergere (logică) și vizualizare producători.

4. **Gestionarea Categoriilor de Produse**
   - Adăugare, modificare, ștergere (logică) și vizualizare categorii de produse.

5. **Gestionarea Stocurilor**
   - Adăugare, modificare, ștergere (logică) și vizualizare stocuri.
   - Calcul automat al prețului de vânzare pe baza prețului de achiziție și adaosului comercial.
   - Validarea campurilor din formulare.
   - Stocurile devin inactive când nu mai sunt produse disponibile sau când acestea expiră.

6. **Gestionarea Bonurilor de Casă**
   - Vizualizare bonuri de casă.
   - Vizualizare detalii bonuri.

7. **Gestionarea Ofertelor** (funcționalitate opțională)
   - Adăugare, modificare, ștergere și vizualizare oferte.

8. **Căutare și Vizualizare Date**
   - Selectare producător și listarea tuturor produselor pe care le-a adus acesta în magazin, pe categorii.
   - Afișarea valorii pentru fiecare categorie de produs din supermarket.
   - Selectarea unui utilizator și a unei luni și vizualizarea sumelor încasate de acesta pe zi, în luna selectată.
   - Afișarea datelor de pe cel mai mare bon al zilei selectate.

### Funcționalități pentru Casier

1. **Căutarea Produselor**
   - Căutare produse după nume, cod de bare, data expirării, producător, categorie.

2. **Emiterea și Vizualizarea Bonurilor de Casă**
   - Adăugare produse pe bon cu afișarea prețului corect (inclusiv reducerile aplicabile).
   - Calcularea subtotalului și sumei totale pe bon.
   - Emiterea bonurilor de casă.
   - După emiterea bonului, acesta nu mai poate fi modificat.
