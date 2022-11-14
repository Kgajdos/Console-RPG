/*
 * ALL METHODS ARE HANDLED HERE, ONLY METHODS SHOULD BE HERE!
 * 
 * 
 */

namespace RPG
{

    public class Methods
    {
        //This should be fixed and deleted!
        public static double _playerHealthStat = 20;
        public static double _playerDefenseStat = 20;
        public static double _playerStrengthStat = 20;
        public static double _playerSpeedStat = 20;
        public static double _weaponDamageStat = 2;
        public static int _playerLevel = 1;

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

        //!!!!!!!!!!!!!!!!!!!!!!!!Method for inventory WORK ON THIS, I DOUBT IT WORKS RIGHT NOW!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //!!!!!!!!!!!!!!!!!!!!!!!!Method for inventory WORK ON THIS, I DOUBT IT WORKS RIGHT NOW!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public static List<string> Inventory()
        {
            List<string> Inventory = new List<string>();
            //Player player = new Player();



            return Inventory;
        }
        //Wallet -- will need functions to determine if copper, silver, or gold
        public static List<int> Wallet()
        {
            List<int> Wallet = new List<int>();


            return Wallet;
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

        //Method for giving the player details about their background (will use classes to do this)
        public static string LookAround(string input)
        {
            string scenary = input;
            Console.WriteLine(input);

            return scenary;
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
                Console.WriteLine("You took " + damage + " damage!");
                Console.WriteLine("Your health is now " + _currentHealth);
            }
            if (_currentHealth <= 0)
            {
                Console.WriteLine("You fainted!");
                var timer = new System.Timers.Timer(1000);
                timer.Elapsed += Timer_Elapsed;
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
        //Method for forcing all user entered data to uppercase
        public static string ToUpperCase(string input)
        {
            string output = input.ToUpper();

            return output;
        }
        //Code Pulled from Microsofts Help Page------
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
            Dialog("'Well, if you're looking for some coin, I have a rats nest downstairs that could use a burning.'\n");
            Console.WriteLine("A: YES\nB: NO");
            string playerAnser = Console.ReadLine();
            bool _startQuest = false;

            switch (playerAnser.ToUpper())
            {
                case "A":
                    Dialog("'Great!'\n");
                    Console.WriteLine("Civeil hands you a torch, and a match to light it.");
                    Inventory().Add("Torch");
                    Inventory().Add("Match");
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
                Room Cellar = new Room();

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
                double playerDefense = _playerDefenseStat;
                double damageTaken = Rat.RatAttack((int)rat1.Strength, (int)playerDefense);
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
                            int damage = Player.Attack((int)_playerStrengthStat, rat1.Defense, (int)_weaponDamageStat, rat1.Health);

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

                                        int anotherAttack = Player.Attack((int)_playerStrengthStat, rat1.Defense, (int)_weaponDamageStat, rat1.Health);
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
                                        bool runSuccess2 = RunAway(_playerSpeedStat, (int)rat1.Speed);
                                        if (runSuccess2 == true)
                                        {
                                            Console.WriteLine("You ran away!");
                                            validInput = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("You failed to run away...");
                                            Console.WriteLine("The rat attacks again!");
                                            int newDamage2 = Rat.RatAttack((int)rat1.Strength, (int)playerDefense);
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
                            bool runSuccess = RunAway(_playerSpeedStat, (int)rat1.Speed);
                            if (runSuccess == true)
                            {
                                Console.WriteLine("You ran away!");
                                validInput = true;
                            }
                            else
                            {
                                Console.WriteLine("You failed to run away...");
                                Console.WriteLine("The rat attacks again!");
                                int newDamage = Rat.RatAttack((int)rat1.Strength, (int)playerDefense);
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
                        }else
                        {
                            Console.WriteLine("There is a small rat wandering around, it doesn't look interested" +
                                "in you for now.");
                        }
                        Console.WriteLine("In the center of the room is a large nest.");
                        Console.WriteLine("The smell of the room is nauseating. You should light your torch now." +
                            "\nYou light your torch and throw it on the nest.\nThe room fills with acrid smoke." +
                            "\nYou return upstairs.");
                        Dialog("'Welcome back, judging by that smell, I'd say you were successful.'" + "\n");
                        //behind the scenes info
                        _playerLevel = 2;
                        validResponse = true;
                        return tutorialComplete;
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
    }
}