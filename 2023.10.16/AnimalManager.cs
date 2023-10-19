﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class AnimalManager
    {
        public List<Animal> listOfAnimals = new List<Animal>();

        public AnimalManager()
        {

        }


        public void AnimalMenu(List<FarmBuilding> farmList, List<Worker> workerList, List<Crop> cropList)
        {

            bool status = true;
            int answer = 0;
            while (status)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?\n\n" +
                                  "1. View Animals\n" +
                                  "2. Add Animal\n" +
                                  "3. SwitchBuilding\n" +
                                  "4. Remove Animal\n" +
                                  "5. Feed Animals\n" +
                                  "6. Back to Menu");
                try
                {
                    answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:
                            Console.Clear();
                            ViewAnimals();
                            Console.WriteLine("Click to continue...");
                            Console.ReadLine();
                            break;




                        case 2:
                            Console.Clear();
                            if (farmList.Count == 0)
                            {
                                Console.WriteLine("There are no farms to put your animal into. \n" +
                                                  "First you need to add a farm from buildings menu!\n\n" +
                                                  "Click to continue...");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("What farmbuilding do you want to add the animal to?\n" +
                                              "Enter farm Id: \n");
                                foreach (FarmBuilding farm in farmList) //Showing the available farms
                                {
                                    Console.WriteLine(farm.GetDescription());
                                }
                                bool status2 = false;

                                while (!status2)
                                {
                                    int farmId = int.Parse(Console.ReadLine());
                                    foreach (FarmBuilding farm in farmList) //If the choice by Id exists, we go to function AddAnimal()
                                    {
                                        if (farm.Id == farmId)
                                        {
                                            AddAnimal(farm);
                                        }
                                        else
                                        {
                                            Console.WriteLine("The farm you entered do not exist.\nTry again: ");
                                        }
                                    }
                                }
                            }
                            break;




                        case 3:
                            Console.WriteLine("What animal do you want to switch building?\n");
                            ViewAnimals();
                            int id = int.Parse(Console.ReadLine());
                            Animal animalChoice = null;
                            foreach(Animal animal in listOfAnimals)
                            {
                                if (animal.Id == id)
                                {
                                    animalChoice = animal;
                                }
                            }

                            Console.Clear();
                            Console.WriteLine("What building do you want the animal to go into?\n\n");
                            foreach (FarmBuilding farm in farmList)
                            {
                                Console.WriteLine(farm.GetDescription());
                            }
                            int id2 = int.Parse(Console.ReadLine());
                            FarmBuilding farmChoice2 = null;
                            foreach (FarmBuilding farm in farmList)
                            {
                                if (farm.Id == id2)
                                {
                                    farmChoice2 = farm;
                                }
                            }

                            SwitchBuilding(animalChoice, farmChoice2);
                            break;



                        case 4:
                            Console.Clear();
                            Console.WriteLine("What animal would you like to remove?\n");
                            ViewAnimals();
                            int choice = int.Parse(Console.ReadLine());
                            RemoveAnimal(choice);
                            break;



                        case 5:
                            Console.Clear();
                            Console.WriteLine("What kind of animal do you want to feed?");
                            string species = Console.ReadLine();
                            foreach (Animal animal in listOfAnimals)
                            {
                                if (animal.Species == species)
                                {
                                    foreach (Crop crop in cropList)
                                    {
                                        Console.WriteLine(crop.GetDescription());
                                    }
                                }
                                Console.Clear();
                                Console.WriteLine("What kind of crop do you want to feed the animal? (Choose by name)\n");
                                foreach (Crop crop in cropList)
                                {
                                    Console.WriteLine(crop.GetDescription());
                                }
                                string cropName = Console.ReadLine();
                                Crop crop1 = null;
                                foreach (Crop crop in cropList)
                                {
                                    if (cropName == crop.cropTyp)
                                    {
                                        crop1 = crop;
                                    }
                                }

                                Console.Clear();
                                Console.WriteLine("What worker should obey and feed the animal? (Choose by Id)\n");
                                Worker worker1 = null;
                                foreach (Worker worker in workerList)
                                {
                                    Console.WriteLine(worker.GetDescription());
                                }
                                int workerChoice = int.Parse(Console.ReadLine());
                                foreach (Worker worker in workerList)
                                {
                                    if (workerChoice == worker.Id)
                                    {
                                        worker1 = worker;
                                    }
                                }

                                FeedAnimals(cropName, worker1, crop1);
                                
                            }
                            break;



                        case 6:             //To return to Animal main menu
                            status = false;
                            Console.Clear();
                            break;


                        default:    //Fail safe, just in case user can spell a single digit
                            Console.WriteLine("Please write a number between 1 - 5");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Please write a number between 1 - 5");
                }
            }
        }



        private void ViewAnimals() //Iterating through the list and showing all the animals.
        {
            if (listOfAnimals.Count == 0)
            {
                Console.WriteLine("There are no animals to view.\n" +
                                  "Try adding some!\n");
            }
            else
            {
                for (int i = 0; i < listOfAnimals.Count; i++)
                {
                    Console.WriteLine(listOfAnimals[i].GetDescription());
                }
            }
        }


        private bool AddAnimal(FarmBuilding farmbuilding)
        {

            Console.WriteLine("What species of animal do you want to add?");
            string species = Console.ReadLine();
            Console.WriteLine("What is the animals name?");
            string name = Console.ReadLine();
            listOfAnimals.Add(new Animal(species, name));
            int index = listOfAnimals.Count - 1;
            farmbuilding.AddAnimal(listOfAnimals[index]);
            Console.WriteLine($"{name} has been added to farm with Id {farmbuilding.Id}");

            return true;

        }



        //This function need to check if the building s full or not! 
        //Still have some implementation to do here. 
        private bool SwitchBuilding(Animal animal, FarmBuilding farmbuilding) //SwitchBuilding tar Id't av vilket djur skall
                                                                              //byta byggnad och Id't från byggnaden djuret ska till.
        {
            Console.Clear();
            farmbuilding.AddAnimal(animal);
            Console.WriteLine($"The desired animal of Id: {animal.Id} has switched to the building of Id: {farmbuilding.Id}\n");
            Console.WriteLine("Click to continue...");
            Console.ReadLine();
            return true;
        }




        private void RemoveAnimal(int num)
        {
            foreach (Animal animal in listOfAnimals)
            {
                if (animal.Id == num)
                {
                    listOfAnimals.Remove(animal);
                    Console.WriteLine("The animal was removed.");
                    Console.WriteLine("Click to continue...");
                    Console.ReadLine();
                }
            }

        }



        private void FeedAnimals(string species, Worker worker, Crop crop)
        {
            foreach (Animal animal in listOfAnimals)
            {
                if (animal.Species == species)
                {
                    animal.Feed(crop);
                }
            }
            Console.WriteLine("Just to make sure we get here...");
            Console.WriteLine("Click to continue...");
            Console.ReadLine();
        }

    }
}
