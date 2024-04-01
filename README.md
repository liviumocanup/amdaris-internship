# Assignment: Creational Design Patterns
### Assignment instructions

Build a simple application where you use the best creational design pattern that matches the requirements below:

You are the manager of a coffee shop, and you can create 3 coffee recipes:

* Espresso = `Black coffee`
* Cappuccino = `Black coffee` + `Milk`
* Flat white = `Black coffee` + `Black coffee` + `Milk`

There is only one type of coffee you can use for each beverage (`Black coffee`), but there are several types of `Milk` (Regular milk, Oat milk, Soy milk).

And you can also add extra sugar and extra milk to any coffee to get custom beverages, example:

* Espresso + `Soy milk` + `Sugar`
* Cappuccino + `Sugar` + `Sugar`
* Flat white + `Sugar`

## Builder Pattern

The Builder Pattern is a creational design pattern used to construct a complex object step by step. I considered it the most fitting for these requirements since it is especially useful when an object can be created with multiple possible configurations (different types of milk, multiple shots of black coffee or sugar) and when the construction process needs to be separated from the representation of the finished object.