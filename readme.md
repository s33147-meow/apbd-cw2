# Uzasadnienie modelu
Serwisy zajmują się obsługiwaniem całej logiki, modele natomiast są anemiczne - służą jedynie do przechowywania danych. W myśl redukowania duplikacji, metody posługują się DTO - data transfer objects. Zapewniają one jak najmniejsze rozbieżności, tj. za każdym razem, kiedy używamy informacji o użytkowniku, informacje te są pobierane przez GetUser w UserService używając UserDto. Podobnie, DTO używane są do przechowywania informacji o powiązaniach (w przypadku Lease: DeviceDto i UserDto).
# Uruchamianie
```bash
dotnet run .
```
lub
```bash
just default
```
w folderze z `.csproj`.
