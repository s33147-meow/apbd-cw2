# Uzasadnienie modelu
Serwisy zajmują się obsługiwaniem całej logiki, modele natomiast są anemiczne - służą jedynie do przechowywania danych. W myśl redukowania duplikacji, metody posługują się DTO - data transfer objects. Zapewniają one jak najmniejsze rozbieżności w stanie aplikacji, tj. za każdym razem, kiedy używamy informacji o użytkowniku, informacje te są pobierane przez GetUser w UserService używając UserDto. Podobnie, DTO używane są do przechowywania informacji o powiązaniach (w przypadku Lease: DeviceDto i UserDto). W myśl tej zasady, unikam również swobodnej konstrukcji obiektów modeli - zamiast tego preferowane jest tworzenie przez Service, lub w przypadku Device - przez delegate (symulujący logikę zewnętrzną, np. Controller który wczytuje dane od użytkownika i klasa identyfikująca je jako konkretny typ Device).
# Uruchamianie
```bash
dotnet run .
```
lub
```bash
just default
```
w folderze z `.csproj`.
