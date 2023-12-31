﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class FarmBuilding : Entity
    {
        public List<Animal> animalList = new List<Animal>();
        private int Capacity { get; set; }


        //Constructor 
        public FarmBuilding(int capacity, string name) : base(name)
        {
            this.Capacity = capacity;
        }


        public override string GetDescription() //Function to show the animals descriptions. 
        {
            return $"Id: {Id} \nName: {Name} \nCapacity: {Capacity}\nAnimals: {animalList.Count}\n";
        }

   
        public bool IsFull()        //Function to see if any farms are at max capacity
        {
            if (animalList.Count >= Capacity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void ListAnimals() //Function to list all animals in listOfAnimals
        {
            if (animalList.Count == 0)
            {
                Console.WriteLine("There are no animals to see...\n" +
                                  "Try adding some!\n");
            }
            else
            {
                foreach (Animal animal in animalList)
                {
                    Console.WriteLine(animal.GetDescription());
                }
            }
        }


        public void AddAnimal(Animal animal) //Adds animal to the animalList
        {
            if (!IsFull())
            {
                animalList.Add(animal);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("The farm is full, animal not added.\n\n");
                Console.WriteLine("Click to continue...");
                Console.ReadLine();
            }
        }


        public void RemoveAnimal(int num) //Removes Animal from the animalList.
        {
            foreach (Animal animal in animalList)
            {
                if (animal.Id == num)
                {
                    animalList.Remove(animal);
                }
            }
        }


        public bool IsEmpty() //Function to see if the farm is empty
        {
            if (animalList.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
