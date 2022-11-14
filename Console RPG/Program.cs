/* MAIN GAME IDEA: 
 * A small text based adventure in the world of Lemorea,
 * the player will be able to take on a rats nest for a tutorial mission,
 * they will be rewarded 25 copper and a level.
 * There will be several rooms the player can travel to, and options
 * available to them in the different rooms.
 * 
 * THERE IS A CHUNK OF CODE THAT NEEDS TO BE FIXED! IT IS A TIMER FUNCTION WHEN THE PLAYER FAINTS
 * IT NEEDS TO HOLD UP THE PLAYER FOR AT LEAST A FEW SECONDS! -- Fixed
 * 
 * 
 * ---------------------------------------------------
 * Next up:
 * --need to create a player function for look, attack, equip
 * --need to fix sword logic
 *----------------------------------------------------
 *Well into the future:
 *--Keep code somewhat clean
 *--add better dialog for the user's ease of understanding
 *--add an enemy class (RAT ADDED)
 *--add a shopkeeper npc, and an innkeeper npc (already did INNKEEPER)
 *--need a character sheet!
 *--need a wallet mechanic
 *--more will be added at a later time
 *
 *Author: Kevin Gajdos
 *
 */
using static RPG.Methods;

namespace RPG
{
    class Game
    {
        //User global commands, needs work
        public static bool playerAttackCommand = false;
        public static string attack = "attack";
        public static void PlayerCommands()
        {
            if (Console.ReadLine() == attack)
            {
                playerAttackCommand = true;
               // Player.Attack();
            }
        }
        //Code instantiating the player and setting the stats
        public static Player player = new Player();
        public static void StartUp()
        {
            Dialog("'Welcome to Lemorea, weary traveller. There's a blizzard outside, why don't you sit down and enjoy the fire. \n" +
               "I'm Ceveil, what's your name?'");
            Console.WriteLine();
            string tempName = Methods.VerifyNameInput(Console.ReadLine());


            Dialog("How old are you?");
            Console.WriteLine();
            int tempAge = Methods.VerifyAgeInput(Console.ReadLine());

            Dialog("I'm having trouble determining what race you are, would you mind telling me? \n");
               Console.WriteLine( "A: Human \n" +
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
            }
            if (race == "Elf")
            {
                playerRace.RaceName = "Elf";
                playerRace.HealthModifier = 2.5;
                playerRace.StrengthModifier = 0.5;
                playerRace.DefenseModifier = 0.5;
                playerRace.SpeedModifier = 2.5;
            }
            if (race == "Dwarf")
            {
                playerRace.RaceName = "Dwarf";
                playerRace.HealthModifier = 0.5;
                playerRace.StrengthModifier = 2.5;
                playerRace.DefenseModifier = 2.5;
                playerRace.SpeedModifier = 0.5;
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
        //Code that handes the main program 
        static void Main()
        {

            StartUp();


            //Inn that player starts in
            Room StartingInn = new Room();
            StartingInn.Details = "You look around a small, sparesly decorated room. \n" +
                "In the center of the room is a small firepit casting a warm glow all around. \n" +
                "";
            StartingInn.NPC = "Civeil";

            //Innkeeper for starting inn
            InnKeeper Civeil = new InnKeeper();
            Civeil.Name = "Civeil";
            Civeil.Age = 59;
            //Testing the look function, works
            LookAround(StartingInn.Details);
            //Function Test
            Player.DisplayStats((int)player.Health, (int)player.Defense, (int)player.Strength, (int)player.Speed);

            //Give player a sword
            Dialog("'Here, take this.' \n");
            Console.WriteLine("Civeil hands you a sword, it is covered with minor scratches and dents.");
            Inventory().Add("Sword");
            player.StartingWeapon = new Sword();
            player.StartingWeapon.DamageMod = 2;

            //First mission, player will level up after this
            bool tutorial = Tutorial();
            if (tutorial == true)
            {
                Dialog("'As promised, here's your copper." + "\n");
                Console.WriteLine("Civeil hands you 25 copper. You place it in your inventory.");
                Wallet().Add(25);
                player.Level = 2;
                int statMulti = (int)Player.LevelUp(player.Level);
                player.Health = player.Health * statMulti;
                player.Defense = player.Defense * statMulti;
                player.Speed = player.Speed * statMulti;
                player.Strength = player.Strength * statMulti;
                Console.WriteLine("You gained a level!");
            }
            //Player.DisplayStats((int)player.Health, (int)player.Defense, (int)player.Strength, (int)player.Speed);

            //testing list works -- DELETE THIS CODE BEFORE TURNING IN
            foreach(string item in Inventory())
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("Press any key to exit"); Console.ReadLine();
        }
    }
}