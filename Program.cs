﻿// the ourAnimals array will store the following: 
using System.Globalization;
using System.Net.NetworkInformation;

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string animalDonation = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";
decimal decimalDonation;

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 7];

// TODO: Convert the if-elseif-else construct to a switch statement

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            animalDonation = "20:C";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            animalDonation = "60:C";

            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            animalDonation = "50:C";

            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            animalDonation = "";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            animalDonation = "";
            break;

    }

    if (!decimal.TryParse(animalDonation, out decimalDonation))
    {
        decimalDonation = 45.00m; // if suggestedDonation NOT a number, default to 45.00
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
    ourAnimals[i, 6] = $"Suggested Donation:  {decimalDonation:C}";
}

do
{
    // display the top-level menu options

    // Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    menuSelection = Console.ReadLine();
    if (menuSelection != null)
    {
        // use switch-case to process the selected menu option


        switch (menuSelection)
        {
            case "1":
                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] != "ID #: ")
                    {
                        Console.WriteLine();
                        for (int j = 0; j < 7; j++)
                        {
                            Console.WriteLine(ourAnimals[i, j]);
                        }
                    }
                }
                readResult = Console.ReadLine();
                break;

            case "2":
                // List all of our current pet information
                // Add a new animal friend to the ourAnimals array
                string anotherPet = "y";
                int petCount = 0;
                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] != "ID #: ")
                    {
                        petCount += 1;
                    }

                }

                if (petCount < maxPets)
                {
                    Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
                    while (anotherPet == "y" && petCount < maxPets)
                    {
                        bool validEntry = false;

                        // get species (cat or dog) - string animalSpecies is a required field 

                        do
                        {
                            Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalSpecies = readResult.ToLower();
                                if (animalSpecies != "dog" && animalSpecies != "cat")
                                {
                                    //Console.WriteLine($"You entered: {animalSpecies}.");
                                    validEntry = false;
                                }
                                else
                                {
                                    validEntry = true;
                                }
                            }
                        } while (validEntry == false);

                        // build the animal the ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
                        animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                        // get the pet's age. can be ? at initial entry.
                        do
                        {
                            int petAge;
                            Console.WriteLine("Enter the pet's age or enter ? if unknown");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalAge = readResult;
                                if (animalAge != "?")
                                {
                                    validEntry = int.TryParse(animalAge, out petAge);
                                }
                                else
                                {
                                    validEntry = true;
                                }
                            }
                        } while (validEntry == false);

                        // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank.
                        do
                        {
                            Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPhysicalDescription = readResult.ToLower();
                                if (animalPhysicalDescription == "")
                                {
                                    animalPhysicalDescription = "tbd";
                                }
                            }
                        } while (animalPhysicalDescription == "");

                        // get a description of the pet's personality - animalPersonalityDescription can be blank.
                        do
                        {
                            Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPersonalityDescription = readResult.ToLower();
                                if (animalPersonalityDescription == "")
                                {
                                    animalPersonalityDescription = "tbd";
                                }
                            }
                        } while (animalPersonalityDescription == "");

                        // get the pet's nickname. animalNickname can be blank.
                        do
                        {
                            Console.WriteLine("Enter a nickname for the pet");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalNickname = readResult.ToLower();
                                if (animalNickname == "")
                                {
                                    animalNickname = "tbd";
                                }
                            }
                        } while (animalNickname == "");

                        // store the pet information in the ourAnimals array (zero based)
                        ourAnimals[petCount, 0] = "ID #: " + animalID;
                        ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                        ourAnimals[petCount, 2] = "Age: " + animalAge;
                        ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                        ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                        ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                        // increment petCount (the array is zero-based, so we increment the counter after adding to the array)
                        petCount = petCount + 1;

                        // check maxPet limit
                        if (petCount < maxPets)
                        {
                            // another pet?
                            Console.WriteLine("Do you want to enter info for another pet (y/n)");
                            do
                            {
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    anotherPet = readResult.ToLower();
                                }

                            } while (anotherPet != "y" && anotherPet != "n");
                        }
                    }

                    if (petCount >= maxPets)
                    {
                        Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                    }
                }

                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();

                break;

            case "3":
                //  Ensure animal ages and physical descriptions are complete
                // Console.WriteLine("Challenge Project - please check back soon to see progress.");
                // Console.WriteLine("Press the Enter key to continue.");
                // readResult = Console.ReadLine();


                for (int i = 0; i < maxPets; i++)
                {
                    bool validAge = false;
                    int petAge;



                    if (ourAnimals[i, 2] == "Age: " || ourAnimals[i, 2] == "Age: ?")
                    {
                        while (!validAge)
                        {
                            // Age Validation
                            Console.WriteLine($"Enter an age for {ourAnimals[i, 0]}");
                            readResult = Console.ReadLine();
                            var isParsable = Int32.TryParse(readResult, out petAge);
                            if (readResult != null && isParsable)
                            {
                                ourAnimals[i, 2] = petAge.ToString();
                                var currentPetAge = ourAnimals[i, 2];
                                validAge = true;
                            }

                            //Physical Description

                            do
                            {
                                Console.WriteLine($"Enter a physical description for {ourAnimals[i, 0]} size, color, gender, weight, housebroken");
                                readResult = Console.ReadLine();
                                var test = readResult is null;
                                if (readResult != "" && readResult != null)
                                {
                                    ourAnimals[i, 4] = readResult;
                                }
                            } while (readResult == "");

                        }

                    };
                }

                break;

            case "4":
                //  Ensure animal nicknames and personality descriptions are complete
                for (int i = 0; i < 7; i++)
                {
                    do
                    {
                        Console.WriteLine($"Enter a nickname for {ourAnimals[i, 0]}");
                        readResult = Console.ReadLine();
                    } while (readResult == "");
                    do
                    {
                        Console.WriteLine($"Enter a personality description for {ourAnimals[i, 0]} (likes or dislikes, tricks, energy level)");
                        readResult = Console.ReadLine();
                    } while (readResult == "");
                }
                break;

            case "5":
                //  Edit an animal’s age
                Console.WriteLine("Challenge Project - please check back soon to see progress.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;

            case "6":
                //  Edit an animal’s personality description
                Console.WriteLine("Challenge Project - please check back soon to see progress.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;

            case "7":
                //  Display all cats with a specified characteristic
                Console.WriteLine("Challenge Project - please check back soon to see progress.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;

            case "8":
                // Display all dogs with a specified characteristic");

                // string dogCharacteristic = "";

                // while (dogCharacteristic == "")
                // {
                //     // have the user enter physical characteristics to search for
                //     Console.WriteLine($"\nEnter one desired dog characteristics to search for");
                //     readResult = Console.ReadLine();
                //     if (readResult != null)
                //     {
                //         dogCharacteristic = readResult.ToLower().Trim();
                //     }
                // }

                // bool noMatchesDog = true;
                // string dogDescription = "";

                // // #6 loop through the ourAnimals array to search for matching animals
                // for (int i = 0; i < maxPets; i++)
                // {
                //     bool dogMatch = true;

                //     if (ourAnimals[i, 1].Contains("dog"))
                //     {

                //         if (dogMatch == true)
                //         {
                //             // #7 Search combined descriptions and report results
                //             dogDescription = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];


                //             if (dogDescription.Contains(dogCharacteristic))
                //             {
                //                 Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a match!");
                //                 Console.WriteLine(dogDescription);

                //                 noMatchesDog = false;
                //             }
                //         }
                //     }
                // }

                // if (noMatchesDog)
                // {
                //     Console.WriteLine("None of our dogs are a match found for: " + dogCharacteristic);
                // }

                // Console.WriteLine("\n\rPress the Enter key to continue");
                // readResult = Console.ReadLine();

                // #1 Display all dogs with a multiple search characteristics

                string dogCharacteristics = "";

                while (dogCharacteristics == "")
                {
                    // #2 have user enter multiple comma separated characteristics to search for
                    Console.WriteLine($"\nEnter dog characteristics to search for separated by commas");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        dogCharacteristics = readResult.ToLower();
                        Console.WriteLine();
                    }
                }

                string[] dogSearches = dogCharacteristics.Split(",");
                // trim leading and trailing spaces from each search term
                for (int i = 0; i < dogSearches.Length; i++)
                {
                    dogSearches[i] = dogSearches[i].Trim();
                }

                Array.Sort(dogSearches);
                // #4 update to "rotating" animation with countdown
                string[] searchingIcons = { " |", " /", "--", " \\", " *" };

                bool matchesAnyDog = false;
                string dogDescription = "";

                // loops through the ourAnimals array to search for matching animals
                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 1].Contains("dog"))
                    {

                        // Search combined descriptions and report results
                        dogDescription = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];
                        bool matchesCurrentDog = false;

                        foreach (string term in dogSearches)
                        {
                            // only search if there is a term to search for
                            if (term != null && term.Trim() != "")
                            {
                                for (int j = 2; j > -1; j--)
                                {
                                    // #5 update "searching" message to show countdown
                                    foreach (string icon in searchingIcons)
                                    {
                                        Console.Write($"\rsearching our dog {ourAnimals[i, 3]} for {term.Trim()} {icon} {j.ToString()}");
                                        Thread.Sleep(100);
                                    }

                                    Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                                }

                                // #3a iterate submitted characteristic terms and search description for each term
                                if (dogDescription.Contains(" " + term.Trim() + " "))
                                {
                                    // #3b update message to reflect current search term match 

                                    Console.WriteLine($"\rOur dog {ourAnimals[i, 3]} matches your search for {term.Trim()}");

                                    matchesCurrentDog = true;
                                    matchesAnyDog = true;
                                }
                            }
                        }

                        // #3d if the current dog is match, display the dog's info
                        if (matchesCurrentDog)
                        {
                            Console.WriteLine($"\r{ourAnimals[i, 3]} ({ourAnimals[i, 0]})\n{dogDescription}\n");
                        }
                    }
                }

                if (!matchesAnyDog)
                {
                    Console.WriteLine("None of our dogs are a match found for: " + dogCharacteristics);
                }

                Console.WriteLine("\n\rPress the Enter key to continue");
                readResult = Console.ReadLine();


                // 1-- capture input.
                // 2-- populate inputs as a string array.
                // 2-- search dogs by the characterisics in the array.
                // 3-- display the found dogs information.
                // 4-- display not found if there is no match.

                // string dogCharacteristics = "";

                // while (dogCharacteristics == "")
                // {
                //     Console.WriteLine("Enter dog characteristics to search for separated by commas");
                //     dogCharacteristics = Console.ReadLine();
                // }

                // string[] splitedDogCharacteristics = dogCharacteristics.Split(',');
                // bool matchesAnyDog = false;
                // bool matchesCurrentDog = false;

                // for (var i = 0; i < maxPets; i++)
                // {
                //     if (ourAnimals[i, 1].Contains("dog"))
                //     {
                //         foreach (var term in splitedDogCharacteristics)
                //         {
                //             string handledTerm = term.Trim();

                //             if (ourAnimals[i, 4].Contains(handledTerm))
                //             {
                //                 Console.WriteLine($"Our {ourAnimals[i, 0]} is a {term} match!");
                //                 matchesCurrentDog = true;
                //                 matchesAnyDog = true;
                //             }
                //             if (matchesCurrentDog)
                //             {
                //                 break;
                //             }
                //         }

                //         if (matchesCurrentDog)
                //         {
                //             for (int j = 0; j < 7; j++)
                //             {
                //                 Console.WriteLine(ourAnimals[i, j]);
                //             }
                //         }
                //     }

                //     if (!matchesAnyDog)
                //     {
                //         Console.WriteLine("match not found");
                //     }
                // }


                break;

            default:
                break;
        }
    }
} while (menuSelection != "exit");




