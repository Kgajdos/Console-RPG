/*
 * ALL CLASSES ARE INSTANTIATED HERE! 
 * Remember to add methods that belong to the classes 
 * 
 */
using System.Reflection.Metadata.Ecma335;

namespace RPG
{
    public class Sword
    {
        int _damageMod = 0;
        string _name = "";

        public int DamageMod
        {
            get { return _damageMod; }
            set { _damageMod = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }

    public class Race
    {
        //Moved set race function to class, also moved var's it relied on (may be reduntant)
        public static double _playerHealthStat = 20;
        public static double _playerDefenseStat = 20;
        public static double _playerStrengthStat = 20;
        public static double _playerSpeedStat = 20;
        public static double _weaponDamageStat = 2;
        public static int _playerLevel = 1;

        string raceName = "";
        double healthModifier = 0;
        double strengthModifier = 0;
        double defenseModifier = 0;
        double speedModifier = 0;

        public string RaceName
        {
            get { return raceName; }
            set { raceName = value; }
        }
        public double SpeedModifier
        {
            get { return speedModifier; }
            set { speedModifier = value; }
        }
        public double HealthModifier
        {
            get { return healthModifier; }
            set { healthModifier = value; }
        }
        public double DefenseModifier
        {
            get { return defenseModifier; }
            set { defenseModifier = value; }
        }
        public double StrengthModifier
        {
            get { return strengthModifier; }
            set { strengthModifier = value; }
        }

        //Method for setting race, Fixed
        public static string SetRace(string input)
        {
            string race = "";
            bool inputIsGood = false;

            if (input.ToUpper() == "A" || input.ToUpper() == "B" || input.ToUpper() == "C")
            {
                inputIsGood = true;
            }
            else inputIsGood = false;


            while (inputIsGood == false)
            {
                Console.WriteLine("Try again.");
                input = Console.ReadLine();
            }
            switch (input.ToUpper())
            {
                case "A":
                    race = "Human";
                    _playerHealthStat = _playerHealthStat * 2;
                    _playerDefenseStat = _playerDefenseStat * 2;
                    _playerStrengthStat = _playerStrengthStat * 2;
                    _playerSpeedStat = _playerSpeedStat * 2;
                    inputIsGood = true;
                    break;

                case "B":
                    race = "Elf";
                    _playerHealthStat = _playerHealthStat * 2.5;
                    _playerDefenseStat = _playerDefenseStat * 0.5;
                    _playerStrengthStat = _playerStrengthStat * 0.5;
                    _playerSpeedStat = _playerSpeedStat * 2.5;
                    inputIsGood = true;
                    break;

                case "C":
                    race = "Dwarf";
                    _playerHealthStat = _playerHealthStat * 0.5;
                    _playerDefenseStat = _playerDefenseStat * 2.5;
                    _playerStrengthStat = _playerStrengthStat * 2.5;
                    _playerSpeedStat = _playerSpeedStat * 0.5;
                    inputIsGood = true;
                    break;
            }

            return race;
        }
        //work around to move stats from race class to player class (after modifications have been set)
        //
        public static string[] GetRaceStats()
        {
            int playerHealth = (int)_playerHealthStat;
            int playerDefense = (int)_playerDefenseStat;
            int playerStrength = (int)_playerStrengthStat;
            int playerSpeed = (int)_playerSpeedStat;
            string[] stats = new string[4] { playerDefense.ToString(), playerHealth.ToString(), playerSpeed.ToString(), playerStrength.ToString() };

            return stats;
        }
    }
    [Serializable]
    public class Player
    {

        string _name = "";
        int _age = 0;
        double health = 20;
        double strength = 20;
        double defense = 20;
        double speed = 20;
        int _level = 0;
        int saveID = 0;
        string _race = "";
        public Sword _startingWeapon = new Sword();

        public Sword StartingWeapon
        {
            get { return _startingWeapon; }
            set { _startingWeapon = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public string PlayerRace
        {
            get { return _race; }
            set { _race = value; }
        }
        public double Health
        {
            get { return health; }
            set { health = value; }
        }
        public double Strength
        {
            get { return strength; }
            set { strength = value; }
        }
        public double Defense
        {
            get { return defense; }
            set { defense = value; }
        }
        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        public int SaveID
        {
            get { return saveID; }
            set { saveID = value; }
        }
        //Method for setting the players stats based on race and player
        public static double SetStats(double raceInput, double characterInput)
        {
            double newStat = characterInput * raceInput;
            return newStat;
        }
        public static void DisplayStats(int playerHealth, int playerDefense, int playerStrength, int playerSpeed)
        {
            Console.WriteLine("Health: " + playerHealth + "\n" +
                  "Defense: " + playerDefense + "\n" + "Strength: " + playerStrength +
                  "\nSpeed: " + playerSpeed);

        }
        //Rest
        public static int Rest(int currentHealth)
        {
            string[] currentStats = Race.GetRaceStats();
            int playerHealth = int.Parse(currentStats[1]);
            int output = (int)currentHealth;
            int healAmount = playerHealth - currentHealth;
            Console.WriteLine("Your rest has returned " + healAmount + " amount of health.");

            return output;
        }
        //players attack - change to int

        public static int Attack(int playerStrength, int enemyDefense, int weaponDamage, int enemyHealth)
        {
            int damage = 0;

            if (playerStrength > enemyDefense)
            {
                damage = (playerStrength * weaponDamage) / enemyDefense;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You did " + damage + " damage!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            return damage;
        }

        //Level up logic basically a stat multiplier
        public static double LevelUp(int level)
        {
            double output = (int)level * 1.12;
            return output;
        }


    }
    public class Rat
    {
        string _name = "Rat";
        int _health = 20;
        int _strength = 5;
        int _defense = 7;
        int _speed = 15;

        public int Health { get { return _health; } set { _health = value; } }
        public int Strength { get { return _strength; } set { _strength = value; } }
        public int Defense { get { return _defense; } set { _defense = value; } }
        public int Speed { get { return _speed; } set { _speed = value; } }

        //handles the rats attack move
        public static int RatAttack(int Strength, int playerDefense)
        {
            int damage = 0;
            if (Strength > playerDefense)
            {
                damage = Strength - playerDefense;
            }

            return damage;
        }
        public static string Dead()
        {
            string output = "With a squeal, the rat dies.";

            return output;
        }
    }

    public class Wallet
    {
        string cp = "Copper";
        string sp = "Silver";
        string gp = "Gold";
        int copperAvailable = 0;
        int silverAvailable = 0;
        int goldAvailable = 0;

        public string Copper
        {
            get { return cp; }
            set { cp = value; }
        }
        public string Silver
        {
            get { return sp; }
            set { sp = value; }
        }
        public string Gold
        {
            get { return gp; }
            set { gp = value; }
        }
        public int CopperAvailable
        {
            get { return copperAvailable; }
            set { copperAvailable += value; }
        }
        public int SilverAvailable
        {
            get { return silverAvailable; }
            set { silverAvailable = value; }
        }
        public int GoldAvailable
        {
            get { return goldAvailable; }
            set { goldAvailable = value; }
        }
        //Function to display wallet
        public static void playerMonies(int copper, int silver, int gold)
        {
            string output = "Copper: " + copper + "\n" +
                "Silver: " + silver + "\n" + "Gold: " + gold;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(output);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
    public class InnKeeper
    {
        string _name = "";
        int _age = 0;
        string _dialog = "";
        List<string> ShopInv = new List<string>
        { };

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public string Dialog
        {
            get { return _dialog; }
            set { _dialog = value; }
        }
        public List<string> ShopInventory
        {
            get { return ShopInv; }
            set { ShopInv = value; }
        }
        //Delivers an array of possible dialog, then randomly selects one.
        public static string ListOfDialog()
        {
            string output = "";
            string[] possibleDialog = new string[5] {"'Hello there.'\n", "'How can I help you?'\n",
            "'Do you need something?'\n", "'How can I be of assistance?'\n", "'Come to chat?'\n"};

            Random randomDialog = new Random();
            int rnd = randomDialog.Next(possibleDialog.Length);
            output = possibleDialog[rnd];

            return output;
        }
        /* DOESN'T WORK, NEED TO FIGURE THIS OUT
        public static List<string> GetInventory()
        {
            string output = "";

            foreach(ShopInventory in Inkeeper)
        }
        */
    }
    //Room class for the room the player is standing in
    public class Room
    {
        //_roomNumber is how the player will move to and from each room
        string _details = "";
        string _NPC = "";
        int _roomNumber = 0;
        List<string> Loot = new List<string> { };

        public string NPC
        {
            get { return _NPC; }
            set { _NPC = value; }
        }

        public string Details
        {
            get { return _details; }
            set { _details = value; }
        }
        public int RoomNumber
        {
            get { return _roomNumber; }
            set { _roomNumber = value; }
        }
        public List<string> LootInventory
        {
            get { return Loot; }
            set { Loot = value; }
        }
    }

}
