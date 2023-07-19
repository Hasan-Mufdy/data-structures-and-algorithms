# First-in, First out Animal Shelter.

this is a shelter app that operates using a first-in, first-out approach.
users can enqueue and dequeue a cat or a dog, and input their names.

## Whiteboard Process

![WhiteBoard](/assets/shelterwb.jpg)

## Approach & Efficiency

time complexity for this implementation is O(n), because there is a loop that loops through animals list, so the performance depends on the size of the list.

## Solution

#### code:
```
public class Animal
{
    public string Species { get; set; }
    public string Name { get; set; }

    public Animal(string species, string name)
    {
        Species = species;
        Name = name;
    }
}

public class Shelter
{
    private List<Animal> animals;

    public Shelter()
    {
        animals = new List<Animal>();
    }

    public void Enqueue(Animal animal)
    {
        animals.Add(animal);
    }

    public Animal Dequeue(string pref) // this pref argument can be either cat or dog
    {
        foreach (Animal animal in animals)
        {
            if (animal.Species == pref)
            {
                animals.Remove(animal);
                return animal;
            }
        }
        return null;
    }
}

```

#### unit tests:
```
[Fact]
        public void Check_If_Dequeue_ReturnAnimal()
        {
            Shelter shelter = new Shelter();
            Animal dog = new Animal("dog", "dog1");
            Animal cat = new Animal("cat", "cat1");

            shelter.Enqueue(dog);
            shelter.Enqueue(cat);

            Animal dequeuedDog = shelter.Dequeue("dog");
            Animal dequeuedCat = shelter.Dequeue("cat");

            Assert.Equal(dog, dequeuedDog);
            Assert.Equal(cat, dequeuedCat);
            
        }

        [Fact]
        public void check_If_Dequeue_ReturnNull_When_there_Is_No_Match()
        {
            Shelter shelter = new Shelter();
            Animal cat = new Animal("cat", "cat1");
            shelter.Enqueue(cat);

            Animal dequeuedDog = shelter.Dequeue("dog");

            Assert.Null(dequeuedDog);
        }
```
