# Graphentheorie
>Es geht um Graphentheorie im Allgemeinen, dazu passend um 4 Algorithmen: *Kruskal, Boruvka, Dijsktra, Floyd-Warshall* und um meine Anwendung zu diesen Algorithmen.
>Diese Dokumentation ist geteilt zu 3 Teilen und der Fokus dabei liegt **nur** auf einen Teil der Graphentheorie. Also, Graphentheorie ist **weit mehr als nur** diese Dokumentation:

- **Graph**
  - [1.Worum geht es?](#1-Worum-geht-es)
  - [2.Was ist ein Graph?](#2-Was-ist-ein-Graph)
  - [3.Welche Eigenschaften hat ein Graph?](#3-Welche-Eigenschaften-hat-ein-Graph)
- **Algorithmen**
  - [1. Was ist ein (minimaler) Spannbaum?](#1-Was-ist-ein-minimaler-Spannbaum)
  - [2. Algorithmus von Kruskal](#2-Algorithmus-von-Kruskal)
  - [3. Algorithmus von Boruvka](#3-Algorithmus-von-Borůvka)
  - [4. Was ist kürzester Pfad Problem?](#4-Was-ist-kürzester-Pfad-Problem)
  - [5. Algorithmus von Dijkstra](#5-Algorithmus-von-Dijkstra)
  - [6. Algorithmus von Floyd-Warshall](#6-Algorithmus-von-Floyd-Warshall)

- **Die Anwendung**
  - [1. Komponente](#1-Komponente)
  - [2. Knoten erzeugen, löschen und hin und herschieben](#2-Knoten-erzeugen-löschen-und-hin-und-herschieben)
  - [3. Verbindung herstellen](#3-Verbindung-herstellen)
  - [4. Beispiel Kruskal](#4-Beispiel-Kruskal-und-Borůvka)
  - [5. Beispiel Dijkstra](#5-Beispiel-Dijkstra)
  - [6. Beispiel Floyd-Warshall](#6-Beispiel-Floyd-Warshall)

# Graph

## 1. Worum geht es?

Das folgende Bild beschreibt das berühmte [Königsberger Brückenproblem](https://de.wikipedia.org/wiki/K%C3%B6nigsberger_Br%C3%BCckenproblem)


<img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/K%C3%B6nigsberger%20Br%C3%BCckenproblem.png" width="450" height="300">

Die Fragestellung ist, ob es eine Route gibt, bei der man alle sieben Brücken genau einmal überquert. Falls es möglich ist, gibt es dann einen Rundweg gibt, bei dem man wieder zu seiner Ausgangsposition kommt. [Leonhard Euler](https://de.wikipedia.org/wiki/Leonhard_Euler) hat es 1736 bewiesen, dass es einen solchen Weg bzw. ***„Eulerschen Weg“*** in Königsberg **nicht** geben kann, da zu allen vier Ufergebieten bzw. Inseln eine ungerade Zahl von Brücken führt. Es ist ein klassisches Beispiel, das man beim Thema Graphentheorie bringt. Aber in der modernen Welt gibt es andere rellen Probleme, die mit Hilfe der Graphentheorie gelöst werden.Z.B schaue man sich das folgende Bild an, nämlich das Schienennetz in Deutschland:

<img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/Schienennetz%20Deutschlad.png" width="250" height="250">

Die Frage ist, wann und wo ein Zug sein muss bzw. welche Route der Lokführer fahren muss, sodass er z.B kleinste mögliche Strecke hinterlegt, um von Hamburg über Frankfurt nach München fahren zu können. Dasselbe gilt auch für z.B. Flugreisen:

<img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/Fluglinien.jpg" width="450" height="250">

Ein anderer Anwendungsbereich der Graphentheorie ist in der Frequenzplanung von Funkmasten. Es wichtig zu wissen, wie man am besten Frequenzen auf Funkmasten verteilen. Denn wenn sich ein Kunde zwischen zwei Sendern befindet, die mit derselben Frequenz senden, kommt es darunter zu Interferenz, die das Signal beeinträchtigt und die Gesprächsqualität negativ beeinflusst.

<img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/Funkmasten5g.png" width="250" height="150">

Ebenso ein Beispiel für die Anwendung der Graphentheorie an reellen Problem wäre das Bezahlungssystem von [City Bot](https://www.edag-citybot.de/) von EDAG.
Das Unternehmen [IOTA](https://www.iota.org/) verwendet unter anderem die Graphentheorie, um die Bezahlung zwischen dem Kunden und City Bot zu ermöglichen.

<img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/EDAG_CityBot_SmartCity_small-Iota.jpg" width="380" height="250">

## 2. Was ist ein Graph?

Ein Graph ist ein **Trippel** *(E,K,N)*, wobei *E* ist die Menge der Ecken mit ***E* ≠ Ø** , ***K*** ist die Menge der Kanten und ***N*** ist die Abbildung, die jeder Kante ein Paar aus zwei Ecken zuweist.

<img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/Graphbeispiel.png" width="330" height="200">

## 3. Welche Eigenschaften hat ein Graph?
Es gibt sehr viele Eigenschaften, die einen Graphen bescheiben könnten. Hier sind Beispiele für mögliche Eigenschaften eines Graphen:
- Zusammenhängender Graph: Zu je zwei Ecken existiert eine Verbindung.

<img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/Zusammenh%C3%A4ngender%20Graph.png" width="330" height="200">

- Nicht zusammenhängender Graph: Es gibt mindestens zwei Ecken, zwischen denen es keine Verbindung existiert.
 
 <img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/Nicht%20zusammenh%C3%A4ngender%20Graph.png" width="330" height="200">
 
- Gerichteter Graph: Verbindungen sind gerichtet d.h. es gibt manche Verbindungen mit nur einer Richtung.

<img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/Gerichteter%20Graph.png" width="330" height="200">

- Ungerichteter Graph: Bei jeder Verdindung ist Kommunikation in beider Richtung möglich.

<img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/nicht%20gerichteter%20Graph.png" width="330" height="200">

- Kreisfreier Graph: von jeder Ecke *u* zu jeder Ecke *v* gibt es höchstens eine Verbindung.
  
  <img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/kreisfreier%20Graph.png" width="330" height="200">

- Nicht kreisfreier Graph: Es gibt von Ecken *u* und *v*, zwischen welchen mehr als eine Verbindung existiert.

  <img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/nicht%20kreisfreier%20Graph.png" width="250" height="200">
  
- Kantengewichteter Graph: jede Kante hat eine reelle Zahl als Kantengewicht
  
  <img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/kantengewichteter%20Graph.png" width="330" height="200">
  
# Algorithmen

## **1. Was ist ein (minimaler) [Spannbaum](https://de.wikipedia.org/wiki/Spannbaum)?**
Ein Spannbaum (*Englisch: spanning tree*) ist ein Teilgrahp, der alle Ecken eines zusammengängenden und ungerichteten Graphen enthält.

Ein minimaler Spannbaum (*Englisch: minimum spanning tree, öfters nur gekürzt als MST*) hat die kleinste Summe seiner Kantengewichte von allen Spannbäumen.

Die Berechnung minimaler Spannbäume findet direkte Anwendung in der Praxis, beispielsweise für die Erstellung von kostengünstigen zusammenhängenden Netzwerken, z.B. alle möglichen Netzwerke (Telefonnetz, Stromnetz) einer Großstadt.


## **2. [Algorithmus von Kruskal](https://de.wikipedia.org/wiki/Algorithmus_von_Kruskal):**

Der Algorithmus von Kruskal funktioniert kantengewichtet, ungerichtet und zusammenhängenden Graphen.

Es ist ein  [Greedy-Algorithmus](https://de.wikipedia.org/wiki/Greedy-Algorithmus) d.h. er berechnet nur den nächsten Schritt, als er ist schnell aber nicht optimal.

Prinzip: Sortiere alle Kanten aufsteigend. Iteriere in dieser sortierten Liste bis Ende und wähle die Kanten und dazu gehörige Knoten aus, die mit den bereits ausgewählten Kanten und Knoten **keinen Kreis** bilden

  <img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/Kruskal_Beispiel.png" width="530" height="380">
  
Man sieht auf dem Bild, dass der Algorithmus mit der Kante zwischen den Knoten A und B anfängt und dann mit der Kante zwischen den Knoten C und E weiterfährt. Man sieht auch z.B. dass die Kante zwischen den Knoten B und C mit dem Gewicht 8 nicht verbunden wird, da sonst zwischen B, C und E ein Kreis entseht. Also, für ***MST*** muss die [Kreisfreihheit](Kreisfreier-Graph) bewahrt werden.

Der Algorithmus von Kruskal ist einfach zu implementieren. Man iteriert in einer nach dem Kantengewicht sortierten Liste, die als Elemente ein Tuple besitzt. Dieses Tuple besitzt wiederum das Gewicht der Kante und die Knotenindexe.

<img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/KruskalAlgorithm.png" width="470" height="380">

Bei jeder neu hinzugefügten Kante zu der gesuchten Adjazenzmatrix von **MST** wird es geschaut, ob da [Kreisfreihheit](Kreisfreier-Graph) weiterhin existiert. Wenn nicht, dann wird dieser Schritt rückgängig gemacht, in dem die Einträge der entsprechenden Stellen wieder mit null befüllt werden.

Um die [Kreisfreihheit](Kreisfreier-Graph) zu überprüfen, hilft folgende Methode. 

Bei einem [kreisfreien Graph](Kreisfreier-Graph) kann die Anzahl der Kanten höchstens Anzahl der Knoten - 1 sein. 

Die Anzahl der Kanten ist die Anzahl der Einträge ungleich null geteilt durch 2.
Dabei muss man beachten, dass es auch noch nicht verbundene Kanten zu der adj_MatrixOfSearchedMST gibt und sie in der Berechnung muss man berücksichtigen.

Also, in derletzten If-Abfrage kann man anhand dieser Zahlen stellt man es fest, ob adj_MatrixOfSearchedMST ein [kreisfreien Graph](Kreisfreier-Graph) ist.

<img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/%20CircuitExistenceCheck.png" width="600" height="480">

## **3. [Algorithmus von Borůvka](https://de.wikipedia.org/wiki/Algorithmus_von_Bor%C5%AFvka):**

Dieser funktioniert wie der Algorithmus von Kruskal nur bei kantengewichtet, ungerichtet und zusammenhängenden Graphen und ist ebenso ein [Greedy-Algorithmus](https://de.wikipedia.org/wiki/Greedy-Algorithmus).

Prinzip: Nehme nach der Knotenindizies einen Knoten und finde seine leichteste Kante. Verbinde ihn mit dem anderen Knoten an dieser Kante so, dass kein Kreis entsteht. Wiederhole es bis zum letzten Knoten nach der Knotenindizenz. Minimaler Spannbaum besteht aus diesen Kompenenten. Verbinde diese Komponente nach der leichtesten Kante, sodass kein Kreis entsteht.

  <img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/Boruvka_Beispiel.png" width="680" height="380">

## **4. Was ist [kürzester Pfad Problem](https://de.wikipedia.org/wiki/K%C3%BCrzester_Pfad)?**

Für Logistikunternehmen ist es von großer Bedeutung, wenn man die Route zwischen zwei Stationen am kleinsten halten kann, damit man Geld spart. Man spricht von beispielsweise von *single-source shortest path problem* und  *all-pairs shortest path*.

***Single-source shortest path problem*** - Zwischen einem Knoten *u* und allen anderen Knoten den kürzesten Pfad zu finden.

***All-pairs shortest path problem*** -  Zu jeden zwei Knoten *u* und *v* den kürzesten Pfad zu finden.

## **5. [Algorithmus von Dijkstra](https://de.wikipedia.org/wiki/Dijkstra-Algorithmus)**

Der Algorithmus von Dijkstra findet zwischen einen Startknoten *u* und allen anderen Knoten auf dem Graph den kürzesten Weg. Also, er löst das ***Single-source shortest path problem***.

 Beispiele dazu von der Anwendung folgen.

## **6. [Algorithmus von Floyd-Warshall](https://de.wikipedia.org/wiki/Algorithmus_von_Floyd_und_Warshall)**

Der Algorithmus von Floyd-Warshall findet zu jeden zwei Knoten *u* und *v* den kürzesten Pfad. Also, er löst das ***All-pairs shortest path problem*** 


 Beispiele dazu von der Anwendung folgen.


# Anwendung
Ich habe die Anwendung in **C#** geschrieben und als GUI habe ich **Windows Forms** gewählt. Dabei habe ich auch Bibliothek [OxyPlot](https://oxyplot.readthedocs.io/en/master/index.html#) verwendet und auch manche Funktionen von [Lion1Blue](https://github.com/Lion1Blue/Splines) übernommen.
## 1. Komponente

  <img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/Komponente.png" width="900" height="600">
  

## 2. Knoten erzeugen, löschen und hin und herschieben

  <img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/KnotenBeispiel.png" width="900" height="600">
  
**Knoten herstellen**: Unten rechts mit linkem Mausklick. Über dem Knoten steht Knotenindex

**Knoten löschen**: auf einem Knoten mit rechtem Mausklick oder auf Coordinates Tabelle Zeile auswählen und Delete Drücken

**Knoten hin und herschieben**: linke Mausseite gedrückt halten und die Maus bewegen
  
## 3. Verbindung herstellen

  <img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/KnotenVerbindung.png" width="900" height="600">

Eine Verbindung geht von dem Knoten in der Zeile zu dem Knoten in der Spalte hinzu. Die Kosten werden an der Kante mit roter Schrift angezeigt.

Bei Kruskal und Borůvka funktionieren **nur bei ungewichteten Kanten**, deswegen wird bei einer Verbindung in beide Seiten ein Pfeil gezeichnet. 

Bei Dijkstra und Floyd-Warshall kann man in einer Richtung Verbindung herstellen, in dem man nur an einer Stelle den Eintrag macht. Stellt man zwischen zwei Knoten mit unterschiedlichen Kosten, so wird die eine Richtung mit grüner und die andere Richtung mit Roter Farbe gezeigt. Ansonsten, sieht man es auch auf Adjacencymatrix, in welche Richtung welcher Kosten steht.


  <img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/DisktraundFloydAusnahme.png" width="900" height="600">


## 4. Beispiel Kruskal und Borůvka

  <img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/KruskalL%C3%B6sung.png" width="900" height="600">
  
**Grüner Graph** steht für [MST](#1-Was-ist-ein-minimaler-Spannbaum)

## 5. Beispiel Dijkstra

  <img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/DisjktraL%C3%B6sung.png" width="900" height="600">

## 6. Beispiel Floyd-Warshall

  <img src="https://github.com/Fazil-edu/GraphTheory/blob/main/Bilder/Floyd-WarshallL%C3%B6sung.png" width="900" height="600">

