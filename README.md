<h1 align=center>Randomizer</h1>

A randomizer made in C# for choosing a random item with a weighted chance

<h2 align=center>Usage:</h2>

```cs
using Randomizer;

// Create an object that inherits the 'IWeighted' inheritance with the 'Weight' property
struct Reward: IWeighted
{
    int Weight { get; set; }
    ...
}

// Past a list of objects into the constructor
List<Reward> foo = ...
Randomizer<Reward> bar = new Randomizer<Reward>(foo);

// Retrieve results!!!
Reward x = bar.Pick();
```