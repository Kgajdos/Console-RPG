/*
 * ALL METHODS ARE HANDLED HERE, ONLY METHODS SHOULD BE HERE!
 * 
 * 
 */

namespace RPG
{

    public class Methods
    {
        public static double _playerHealthStat = 20;
        /* THESE ARE COMMENTED OUT TO TEST IF THEY'RE NEEDED!!!!!!
        public static double _playerDefenseStat = 20;
        public static double _playerStrengthStat = 20;
        public static double _playerSpeedStat = 20;
        public static double _weaponDamageStat = 2;
        public static int _playerLevel = 1;
        */


        //This seems reduntant, it exists to ensure that the stat modifiers are added but also shouldn't interfer anymore
        public static double _currentHealth = _playerHealthStat;
        public static double _mainHealth = 0;
        private static bool _goodInput = false;

        //Method for setting the players stats based on race and player
        public static double SetStats(double raceInput, double characterInput)
        {
            double newStat = characterInput * raceInput;
            return newStat;
        }

        //Inventory systems work
        public static List<string> Inventory = new List<string>();
        //ALL OF THIS IS BEING MOVED TO A WALLET CLASS!
        public static List<Wallet> WalletList = new List<Wallet> { };



        /* DOESN'T WORK, COME BACK TO THIS!
        //Gets the price of an item
        public static int PriceGrab(string input)
        {
            int output = 0;
            int healthPotionSmall = 10;
            int healthPotionMedium = 40;
            int healthPotionLarge = 100;
            int sheild = 50;
            int bow = 15;
            int arrows = 20;

            switch(input)
            {
                case healthPotionSmall:
                    output = healthPotionSmall;
                    break;
                case healthPotionMedium:
                    output = healthPotionMedium;
                    break;
                case healthPotionLarge:
                    output = healthPotionLarge;
                    break;
                case sheild:
                    output = sheild;
                    break;
                case bow:
                    output = bow;
                    break;
                case arrows:
                    output = arrows;
                    break;
                default:
                    output = 0;
                    break;
            }

            return output;
        }
        */
        //Changes text color so user understands that the game is giving them a hint
        public static void Help(string consoleMessage)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(consoleMessage);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        //user commands logic, maybe (http://pont.ist/micropuzzle/ -- got help from this site, code is still mostly my own though)
        public static bool UserCommand(string roomDetails, List<string> roomLoot)
        {
            bool breakingOut = false;
            Console.WriteLine("What do you want to do?");
            Help("Command structure must be COMMAND OBJECT (OBJECT being whatever you want to interact with).");
            Help("Example: GRAB MUG");
            Console.Write("List of available commands:\n"
                + "TALK\nLOOK\nGRAB\nSTATS\nINVENTORY\n");
            string userCommand = Console.ReadLine().ToUpper();
            string[] emptySpace = new string[1] { " " };
            string[] newCommand = userCommand.Split(emptySpace, 2, StringSplitOptions.None);
            bool validAnswer = false;
            //This still needs work, some things will need to be moved.
            while (validAnswer == false)
            {
                switch (newCommand[0])
                {
                    //This command should be amorphous with the innkeeper class (i.e. Actual dialog should be grabbed from that 
                    //objects class!)
                    case "TALK":
                        Dialog(InnKeeper.ListOfDialog().ToString());
                        validAnswer = true;
                        breakingOut = true;
                        break;
                    case "LOOK":
                        LookAround(roomDetails, roomLoot);
                        validAnswer = true;
                        break;
                    //Need to create logic that determines what's being grabbed
                    case "GRAB":
                        Inventory.Add(newCommand[1]);
                        validAnswer = true;
                        break;
                    case "STATS":
                        DisplayStats();
                        validAnswer = true;
                        break;
                    case "INVENTORY":
                        if (Inventory.Count > 0)
                        {
                            Inventory.ForEach(Console.WriteLine);
                            validAnswer = true;
                        }
                        else
                        {
                            Console.WriteLine("You do not currently have anything in your inventory.");
                            validAnswer = true;
                        }
                        break;
                    //Bug fixed, do NOT change validAnswer to false
                    default:
                        Help("Please choose a valid answer.");
                        validAnswer = true;
                        break;
                }
            }
            return breakingOut;
        }


        //Verify Name
        public static string VerifyNameInput(string nameInput)
        {
            string name = "";

            if (nameInput == "")
            {
                name = "No Name";
            }
            else
            {

                name = nameInput;
            }

            return name;

        }

        //Verify Age
        public static int VerifyAgeInput(string input)
        {
            int output = 0;
            bool verify = false;
            verify = int.TryParse(input, out output);
            if (output == 0)
            {
                verify = false;
            }

            while (verify == false)
            {
                Console.WriteLine("Did not enter a valid number, Please enter a valid number");
                _goodInput = false;

                verify = int.TryParse(Console.ReadLine(), out output);
                if (output <= 0)
                {
                    verify = false;
                }
            }
            return output;
        }

        //Method for giving the player details about their background and available loot
        public static string LookAround(string roomDetails, List<string> roomLoot)
        {
            string scenary = roomDetails;
            Console.WriteLine(roomDetails);
            Console.WriteLine("The items available to grab are:");
            for (int i = 0; i < roomLoot.Count(); i++)
            {
                Console.WriteLine(roomLoot[i]);
            }

            return scenary;
        }
        //Display Player Stats
        public static void DisplayStats()
        {
            string stats = "Name: " + player.Name + "\n" + "Race: " + player.PlayerRace + "\n" +
                "Age: " + player.Age + "\n" + "Health: " + player.Health + "\n" + "Strength: " + player.Strength + "\n" +
                "Defense: " + player.Defense + "\n" + "Speed: " + player.Speed + "\n" + "Weapon: " + player.StartingWeapon.Name + "\n" +
                "Level: " + player.Level;
            Help(stats);
        }

        //Run away logic
        public static bool RunAway(double playerSpeed, double enemySpeed)
        {
            bool result = false;

            if (playerSpeed >= enemySpeed)
            {
                result = true;
            }

            return result;
        }

        //Code instantiating the player and setting the stats
        public static Player player = new Player();
        public static void StartUp()
        {
            Dialog("'Welcome to Lemorea, weary traveller. There's a blizzard outside, why don't you sit down and enjoy the fire. \n" +
               "I'm Ceveil, what's your name?'");
            Console.WriteLine();
            string tempName = VerifyNameInput(Console.ReadLine());


            Dialog("How old are you?");
            Console.WriteLine();
            int tempAge = VerifyAgeInput(Console.ReadLine());

            Dialog("I'm having trouble determining what race you are, would you mind telling me? \n");
            Console.WriteLine("A: Human \n" +
             "B: Elf \n" +
             "C: Dwarf \n");

            string race = Race.SetRace(Console.ReadLine());


            player.Name = tempName;
            player.Age = tempAge;
            player.PlayerRace = race;

            Race playerRace = new Race();
            playerRace.RaceName = race;

            if (race == "Human")
            {
                playerRace.RaceName = "Human";
                playerRace.HealthModifier = 2;
                playerRace.StrengthModifier = 2;
                playerRace.DefenseModifier = 2;
                playerRace.SpeedModifier = 2;
                player.PlayerRace = "Human";
            }
            if (race == "Elf")
            {
                playerRace.RaceName = "Elf";
                playerRace.HealthModifier = 2.5;
                playerRace.StrengthModifier = 0.5;
                playerRace.DefenseModifier = 0.5;
                playerRace.SpeedModifier = 2.5;
                player.PlayerRace = "Elf";
            }
            if (race == "Dwarf")
            {
                playerRace.RaceName = "Dwarf";
                playerRace.HealthModifier = 0.5;
                playerRace.StrengthModifier = 2.5;
                playerRace.DefenseModifier = 2.5;
                playerRace.SpeedModifier = 0.5;
                player.PlayerRace = "Dwarf";
            }


            //setting player stats
            player.Health = Player.SetStats(playerRace.HealthModifier, player.Health);
            _currentHealth = player.Health;
            _mainHealth = player.Health;
            player.Strength = Player.SetStats(playerRace.StrengthModifier, player.Strength);
            player.Defense = Player.SetStats(playerRace.DefenseModifier, player.Defense);
            player.Speed = Player.SetStats(playerRace.SpeedModifier, player.Speed);
            player.Level = 1;
        }
        /*
         *------------------------------------------------------/
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         */

        //Player health logic
        public static void HealthPlusorMinus(double damage)
        {
            double health = _currentHealth;
            _currentHealth = _currentHealth - damage;
            if (_currentHealth > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You took " + damage + " damage!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Your health is now " + _currentHealth);
            }
            if (_currentHealth <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You fainted!");
                var timer = new System.Timers.Timer(1000);
                timer.Elapsed += Timer_Elapsed;
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        //Attack hit or not function// THIS MAY GET REMOVED!/////////////
        public static int DamageCalc(int attackerStrength, int defenderDefense, int attackerHealth, int defenderHealth)
        {
            bool itHit = false;
            int damageTaken = 0;
            if (attackerStrength > defenderDefense)
            {
                itHit = true;
            }
            if (itHit == true)
            {
                damageTaken = attackerStrength - defenderDefense;
            }
            return damageTaken;
        }
        //Method for forcing all user entered data to uppercase. Might be reduntant but was running into issues otherwise
        public static string ToUpperCase(string input)
        {
            string output = input.ToUpper();

            return output;
        }
        //Code Pulled from Microsofts Help Page------
        /*
         * ------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         */
        private static void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
        //--------End of code pulled from Microsoft.
        /*
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         *------------------------------------------------------/ 
         */

        //yes no logic will either spit out a cap A/B or a not Correct response
        public static string AorB(string input)
        {
            string output = "";
            string test = input.ToUpper();

            switch (test)
            {
                case "A":
                    output = "A";
                    break;
                case "B":
                    output = "B";
                    break;
                default:
                    output = "Not Correct";
                    break;
            }

            return output;
        }

        public static void Dialog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(message);
            Console.ResetColor();
        }

        //Tutorial Quest
        public static bool Tutorial()
        {
            bool tutorialComplete = false;
            //Give player a sword
            Dialog("'Why don't you hold onto this old sword of mine.' \n");
            Console.WriteLine("Civeil hands you a sword, it is covered with minor scratches and dents.");
            //added sword to inventory
            Inventory.Add("Sword");
            player.StartingWeapon = new Sword();
            player.StartingWeapon.DamageMod = 2;
            player.StartingWeapon.Name = "Old Sword";

            //give player the choice to start the tutorial
            Dialog("'If you're looking for some coin, I have a rats nest downstairs that could use a burning.'\n");
            Console.WriteLine("A: YES\nB: NO");
            string playerAnser = Console.ReadLine();
            bool _startQuest = false;

            switch (playerAnser.ToUpper())
            {
                case "A":
                    Dialog("'Great!'\n");
                    Console.WriteLine("Civeil hands you a torch, and a match to light it.");
                    Inventory.Add("Torch");
                    Inventory.Add("Match");
                    _startQuest = true;
                    break;
                case "B":
                    Dialog("'Ok, maybe next time.'" + "\n");
                    return tutorialComplete = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            if (_startQuest == true)
            {
                //sets cellar logic, might move to global, since this vs would delete as soon as the player leaves the tutorial.
                Room Cellar = new Room();
                Cellar.RoomNumber = 2;
                Cellar.Details = "";
                Cellar.LootInventory.Add("Rat Bones");
                Cellar.LootInventory.Add("");
                bool ratsNestDestroyed = false;

                //Actual Quest Logic
                Console.WriteLine("You go down a set of old, yet sturdy wooded stairs. Along your descent you spot several large cobwebs. \n" +
                    "Your breath is visible as the air gets colder and more stale. You reach the bottom.");
                Console.WriteLine("What do you want to do? \n" + "A: Look around\nB: Rest");
                string input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "A":
                        Console.WriteLine("You are in a small cellar, the walls are cracked and old. There is broken furniture \n" +
                            "scattered about. In the center of the room lays a large rats nest. The smell of it makes you queesy.");
                        break;
                    case "B":
                        //Heals the player
                        _currentHealth = Player.Rest((int)_currentHealth);
                        Console.WriteLine("You are in a small cellar, the walls are cracked and old. There is broken furniture \n" +
                            "scattered about. In the center of the room lays a large rats nest. The smell of it makes you queesy.");
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option.");
                        break;
                }


                //set rat 
                Rat rat1 = new Rat();
                rat1.Health = 20;
                rat1.Defense = 7;
                rat1.Strength = 5;
                rat1.Speed = 15;
                Console.WriteLine("A small rat has wondered near you.\nIt attacks!");

                //First attack from rat
                double damageTaken = Rat.RatAttack((int)rat1.Strength, (int)player.Defense);
                HealthPlusorMinus(damageTaken);
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("A: Attack\nB: Run Away");

                //I apologize for this mess, but it's the rat vs player combat logic
                bool validInput = false;
                bool deadRat = false;
                while (validInput == false)
                {
                    string userAnswer = Console.ReadLine();
                    switch (userAnswer.ToUpper())
                    {
                        case "A":
                            int damage = Player.Attack((int)player.Strength, rat1.Defense, (int)player.StartingWeapon.DamageMod, rat1.Health);

                            rat1.Health = rat1.Health - damage;
                            if (rat1.Health <= 10)
                            {
                                Console.WriteLine("The rat is bloodied and looks tired.");
                            }
                            else
                            {
                                Console.WriteLine("The rat looks unfased by your attack.");
                            }
                            bool ratAlive = true;
                            while (ratAlive == true)
                            {
                                Console.WriteLine("Attack again? Y/N");
                                string yOrN = Console.ReadLine().ToUpper();
                                switch (yOrN)
                                {
                                    case "Y":

                                        int anotherAttack = Player.Attack((int)player.Strength, rat1.Defense, (int)player.StartingWeapon.DamageMod, rat1.Health);
                                        rat1.Health = rat1.Health - anotherAttack;
                                        if (rat1.Health <= 10)
                                        {
                                            Console.WriteLine("The rat is bloodied and looks tired.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("The rat looks unfased by your attack.");
                                        }
                                        if (rat1.Health <= 0)
                                        {
                                            Console.WriteLine("With a loud squeak, the rat died.");
                                            deadRat = true;
                                            ratAlive = false;
                                            validInput = true;
                                        }
                                        else
                                        {
                                            ratAlive = true;
                                        }

                                        break;

                                    case "N":
                                        bool runSuccess2 = RunAway(player.Speed, (int)rat1.Speed);
                                        if (runSuccess2 == true)
                                        {
                                            Console.WriteLine("You ran away!");
                                            validInput = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("You failed to run away...");
                                            Console.WriteLine("The rat attacks again!");
                                            int newDamage2 = Rat.RatAttack((int)rat1.Strength, (int)player.Defense);
                                            HealthPlusorMinus(newDamage2);
                                            validInput = false;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }


                            break;
                        case "B":
                            bool runSuccess = RunAway(player.Speed, (int)rat1.Speed);
                            if (runSuccess == true)
                            {
                                Console.WriteLine("You ran away!");
                                validInput = true;
                            }
                            else
                            {
                                Console.WriteLine("You failed to run away...");
                                Console.WriteLine("The rat attacks again!");
                                int newDamage = Rat.RatAttack((int)rat1.Strength, (int)player.Defense);
                                HealthPlusorMinus(newDamage);
                                validInput = false;
                            }
                            break;
                        default:
                            Console.WriteLine("Please enter A or B.");
                            validInput = false;
                            break;
                    }
                }

                Console.WriteLine("What do you want to do?");
                Console.WriteLine("A: Look Around\nB: Return to Civeil");
                string playerResponse = Console.ReadLine().ToUpper();
                bool validResponse = false;
                if (playerResponse == "A" || playerResponse == "B")
                {
                    validResponse = true;
                }
                while (validResponse == false)
                {
                    Console.WriteLine("Please answer A or B.");
                    playerResponse = Console.ReadLine().ToUpper();
                    if (playerResponse == "A" || playerResponse == "B")
                    {
                        validResponse = true;
                    }
                    else
                    {
                        validResponse = false;
                    }
                }

                //still working on this
                switch (playerResponse)
                {
                    case "A":
                        //Dead rat or not bool placement
                        if (deadRat == true)
                        {
                            Console.WriteLine("There is a dead rat next to you.");
                        }
                        else
                        {
                            Console.WriteLine("There is a small rat wandering around, it doesn't look interested" +
                                "in you for now.");
                        }
                        Console.WriteLine("In the center of the room is a large nest.");
                        Console.WriteLine("The smell of the room is nauseating. Would you like to light your torch now?" + "\nA: Yes \nB: No");
                        string userAnswer = AorB(Console.ReadLine());
                        if (userAnswer == "A")
                        {
                            Console.WriteLine("\nYou light your torch and throw it on the nest.\nThe room fills with acrid smoke." +
                             "\nYou return upstairs.");
                            ratsNestDestroyed = true;
                            tutorialComplete = true;
                        }
                        else
                        {
                            Console.WriteLine("You decide to not light the nest.");
                        }
                        if (ratsNestDestroyed == true)
                        {
                            Dialog("'Welcome back, judging by that smell, I'd say you were successful.'" + "\n");
                            //behind the scenes info
                            player.Level = 2;
                            validResponse = true;
                            return tutorialComplete;
                        }
                        break;
                    case "B":
                        Console.WriteLine("You decided to return upstairs.");
                        Dialog("'Maybe next time.'");
                        validResponse = true;
                        return tutorialComplete;
                        break;
                    default:
                        validResponse = false;
                        break;

                }
                return tutorialComplete;
            }
            tutorialComplete = true;
            return tutorialComplete;

        }
        //Second "dungeon"
        public static void Forest()
        {
            //set room up with it's details
            Room Forest = new Room();
            Forest.NPC = "Girn";
            Forest.RoomNumber = 3;
            Forest.LootInventory.Add("Bones");
            Forest.LootInventory.Add("Seed");
            Forest.LootInventory.Add("Wood");
            Forest.LootInventory.Add("Unknown Ore");
            Forest.Details = "The trees here are overgrown and old. You struggle to see more than twenty feet in front of you.\n" +
                "Firns and other small bushes cover the ground, even growing over fallen trees.\n" +
                "There are three rats wandering around, they don't seem to be interested in you.\n";
            UserCommand(Forest.Details, Forest.LootInventory);
            //Spawn 3 enemies (will need to add attack logic to them)
            Rat rat1 = new Rat();
            Rat rat2 = new Rat();
            Rat rat3 = new Rat();
            rat1.Health = 10;
            rat2.Health = 15;
            rat3.Health = 19;
            rat1.Defense = 5;
            rat2.Defense = 7;
            rat3.Defense = 10;
            rat1.Speed = 15;
            rat2.Speed = 10;
            rat3.Speed = 8;
            rat1.Strength = 6;
            rat2.Strength = 9;
            rat3.Strength = 11;


        }
    }
}