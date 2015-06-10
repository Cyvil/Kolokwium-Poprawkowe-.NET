# Zestaw C: Scenariusz dla projektu Cards

Celem zadania jest przygotowanie aplikacji, która pozwala na obliczenie prawdopodobieństwa wyboru kart z talii 52 kart. Może nastąpić wybór rang (karty numerowanej lub figury) lub kolorów, lub wielu jednocześnie. Obliczenie prawdopodobieństwa odbywa się zgodnie z zasadą włączeń i wyłączeń. Dodatkowo użytkownik ma możliwość wyszukania (spośród obliczonych zestawów kart) zestawu mającego najwyższe prawdopodobieństwo oraz zapisania listy wcześniej obliczonych prawdopodobieństw do pliku.

Aplikacja jest skonstruowana w oparciu o podejście MVVM. O ile nie napisano inaczej, cały kod należy napisać w klasie odpowiadającej warstwie ViewModel. Warstwa View jest już zaimplementowana i nie powinna być zmieniana. W ramach implementacji klasy CardsViewModel należy dostarczyć brakujących składowych (właściwa część zadania). Tam, gdzie mowa o przeszukiwaniu należy użyć kwerendy LINQ.

Z projektem dostarczone są klasy:
* MyDispatcher – odpowiedzialna za wywołanie akcji przekazanej do metody RunOnUi na wątku głównym aplikacji (instancja jest dostarczona pod postacią interfejsu IDispatcher)
* MyCommand – odpowiedzialna za dostarczenie uproszczonej implementacji dla interfejsu System.Windows.Input.ICommand
* CardRank – enumeracja zawierająca wszystkie możliwe karty
* CardSuit – enumeracja zawierająca wszystkie możliwe kolory
* ProbabilitySet – klasa modelu do trzymania informacji o obliczonym prawdopodobieństwie (właściwość Probability) dla zadanych rodzajów kart (listy Ranks i Suits)


### Zadanie 1: Jako użytkownik chcę widzieć ekran ze wszystkimi dostępnymi funkcjami celem wybrania kart lub kolorów do obliczenia prawdopodobieństwa.

Kryteria oceny:
* Należy zaimplementować interfejs ICardsViewModel w klasie o nazwie CardsViewModel.
* Właściwości z metodami get/set wywołuje zdarzenie pochodzące z interfejsu INotifyPropertyChanged w momencie przypisania wartości.
* Właściwości AvailableRanks i AvailableSuits zawierają odpowiednio wszystkie składowe enumeracji, odpowiednio CardRank i CardSuit.
* Właściwości ChosenSuits, ChosenRanks, EvaluatedSets są zainicjalizowane pustymi kolekcjami odpowiednich typów.

Wskazówki:
* Właściwości typu ICommand mogą być zaimplementowane za pomocą udostępnionej klasy MyCommand.

### Zadanie 2: Jako użytkownik chcę wybrać kartę lub kolor i obliczyć prawdopodobieństwo wylosowania jej z talii kart.

Kryteria oceny:
* Należy zaimplementować metodą odpowiadającą na wykonanie komendy CalcCommand.
* Obliczenie prawdopodobieństwa odbywa się za pomocą wzoru:

((liczba wybranych kolorów * liczba wszystkich kart dla jednego koloru) + (liczba wybranych kart * liczba wszystkich kolorów) - (liczba wybranych kolorów * liczba wybranych kart)) / liczba kart w talii

Gdzie:
  * Liczba wybranych kolorów to liczba elementów w kolekcji ChosenSuits 
  * Liczba wybranych kart to liczba elementów w kolekcji ChosenRanks
  * Liczba wszystkich kolorów to liczba elementów w kolekcji AvailableSuits 
  * Liczba wszystkich kart dla jednego koloru to liczba elementów w kolekcji AvailableRanks

Obliczenia mogą być dokonane tylko gdy wybrano jakiekolwiek kolory lub jakiekolwiek rangi karty (np. tylko czerwone lub tylko króle). Jeżeli nie wybrano koloru ani rangi, należy pokazać na ekranie wiadomość z o niemożliwości obliczenia prawdopodobieństwa (metoda MessageBox.Show).


Wskazówki:
* Należy pamiętać o doborze właściwych typów danych.

### Zadanie 3: Zadanie 3: Jako użytkownik chcę, żeby system zapamiętał obliczone prawdopodobieństwa celem późniejszej analizy.

Kryteria oceny:
* Należy uzupełnić klasę CardsViewModel o kolekcję, w której zapamiętywane są kolejne rangi i kolory używane w obliczeniach prawdopodobieństwa. Kolekcja jest udostępniona w ramach właściwości EvaluatedSets. Czas życia kolekcji jest taki sam jak obiektu klasy CardsViewModel.
* Należy zaimplementować „zapamiętywanie” kolejnych obliczeń zakończonych sukcesem w w/w kolekcji, w ramach metody odpowiadającej na wykonanie komendy CalcCommand.

Wskazówki:
* Należy pamiętać o charakterystyce typów referencyjnych.

### Zadanie 4: Jako użytkownik chcę zapisać na dysku kolekcję kolejnych obliczeń prawdopodobieństwa, celem późniejszej analizy.

Kryteria oceny:
* Należy zaimplementować metodą odpowiadającą na wykonanie komendy SaveSearchesCommand.
* Zawartość kolekcji, w której zapamiętane są kolejne obliczenia (właściwość EvaluatedSets) jest zapisana w pliku tymczasowym i formacie JSON.

Wskazówki:
* Do implementacji zapisu do formatu JSON można użyć dodatkowej biblioteki dostarczonej w ramach środowiska .NET.
* Operacje wejścia/wyjścia są zabiegami czasochłonnymi. Należy mieć to na uwadze implementując rozwiązanie.

### Zadanie 5: Jako użytkownik chcę spośród obliczonych prawdopodobieństw wyszukać zestaw rang i kolorów z najwyższym prawdopodobieństwem.

Kryteria oceny:
* Należy zaimplementować metodą odpowiadającą na wykonanie komendy ShowHighestCommand.
* Za pomocą wyrażenia LINQ należy wyszukać element o największym prawdopodobieństwie w kolekcji EvaluatedSets (Zadanie 3)
* Znaleziony element powinien być utrwalony we właściwości HighestProbability, a wynik powinien pojawić się na ekranie.
