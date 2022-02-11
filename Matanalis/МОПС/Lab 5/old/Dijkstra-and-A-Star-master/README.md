# Dijkstra and A* Search - WIP for a possible search tool (ie. Maze solver, or Path search in map software)
C# Implementation of Dijkstra's Algorithm and A* in one method!

This project may expand into other Algorithms. However, I wanted to show how Dijkstra may perform like A* without any heuristics.
To showcase this, I implemented Dijktra's Algorithm to take into account heuristics. By default, we set h(n) = 0.

- Unit tests have been provided to show that heuristic search does work, including a pre-made Console App program that the user can change.

- Another visual confirmation of the implementation's correctness can be referenced to the Search Applet in AISPACE. The user
can download this applet and create Graphs that correspond to the one being used in the C# program (or any graph that a user wants to create).

- Future plans include changing the way this 'queue' is used. It is currently using List, followed by the OrderBy expression to make it behave like a priority queue - thus, it may not be the fastest. Unfortunately, there is no Priority Queue data structure in .NET.
A binary Heap implementation or SortedList implementation can be used. 

