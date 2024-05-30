# Joc de Dame

## Descriere

Acest proiect implementează un joc de dame folosind C# și WPF, urmând design pattern-ul MVVM (Model-View-ViewModel). Jocul include două seturi de piese (albe și roșii), o tablă de 8x8 și respectă regulile standard ale jocului de dame. Aplicația permite mutări simple, sărituri peste adversar și sărituri multiple (opțional). De asemenea, suportă salvarea și încărcarea stării jocului și menține statistici despre câștigători.

## Funcționalități

1. **Mutări și Capturi:**
   - Mutare simplă
   - Săritură peste adversar
   - Sărituri multiple (opțional)
   - Transformare în "rege" la capătul opus al tablei

2. **Interfața Utilizator:**
   - Tabla de joc
   - Indică vizual jucătorul curent
   - Afișează numărul de piese rămase pentru fiecare jucător

3. **Finalul Jocului:**
   - Jocul se termină când un jucător nu mai are piese
   - Afișează un mesaj cu câștigătorul

4. **Meniu:**
   - **New Game:** Începe un joc nou
   - **Save:** Salvează starea curentă a jocului
   - **Open:** Încarcă un joc salvat
   - **Allow Multiple Jump:** Activează/dezactivează săriturile multiple
   - **Statistics:** Afișează statistici despre câștigători și maximul de piese rămase

## Ghid de Utilizare

1. **Pornirea unui joc nou:**
   - Din meniul `File`, selectează `New Game`.

2. **Salvarea jocului curent:**
   - Din meniul `File`, selectează `Save` și alege locația de salvare.

3. **Încărcarea unui joc salvat:**
   - Din meniul `File`, selectează `Open` și alege fișierul de joc salvat anterior.

4. **Activarea săriturilor multiple:**
   -   - Din meniul `File`, selectează `Allow Multiple Jump` pentru a activa sau dezactiva opțiunea de sărituri multiple.

5. **Vizualizarea statisticilor:**
   - Din meniul `File`, selectează `Statistics` pentru a vedea statistici despre câștigătorii anteriori și maximul de piese rămase ale câștigătorului.
