/* 
 * ----------POTENTIAL ISSUES WITH CURRENT WORKING STATE----------
 * Current issue with game only saving some user data,
 * will need to look into why this is happening and how to mitigate;
 * there is a possibility that this will not get implemented in time.
 * This will still be implemented eventually!
 * Some forms of user entered data may not be validated properly:
 *  -Testing needed for ALL user information entering points.
 * ---------------------------------------------------
 *
 *Author: Kevin Gajdos
 *Date: 12/04/2022
 */
using static RPG.Methods;


namespace RPG
{
    class Game
    {
        /*
        //--------------------------------probably dead code------------------------------------------------//
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
        //-------------------------------------end of dead code---------------------------------------------//
        */
        //Code that handes the main program 
        static void Main()
        {
            //beginning save/load logic 
            if (!Directory.Exists(@"C:\Users\Veteran\Desktop\Lemoria\Lemoria vs 1.11\Console RPG\Console RPG\bin\Debug\saves"))
            {
                Directory.CreateDirectory(@"C:\Users\Veteran\Desktop\Lemoria\Lemoria vs 1.11\Console RPG\Console RPG\bin\Debug\saves");
            }
            Load(out bool newP);
            if (newP == true)
            {
                tutorial = Tutorial();
            }
            else
            {
                tutorial = true;
            }
            string[] innLoot = new string[2] { Loot.ale, Loot.bread };
            string innDetail = "You look around a small, sparesly decorated room. \n" +
                "In the center of the room is a small firepit casting a warm glow all around. \n" +
                "There is one door on the southern wall. \n";
            Room StartingInn = SpawnRoom(innDetail, "Civeil", 1, innLoot);

            string[] shopInv = new string[2] { Loot.healthPotion, Loot.sheild };
            InnKeeper StartingInnKeeper = SpawnInnkeeper("Civeil", 59, shopInv);


            /*
            //Innkeeper for starting inn MOVING TO METHODS FOR REFRACTION
            InnKeeper Civeil = new InnKeeper();
            Civeil.Name = "Civeil";
            Civeil.Age = 59;
            Civeil.ShopInventory = new List<string> { };
            Civeil.ShopInventory.Add("Small Health Potion");
            Civeil.ShopInventory.Add("Shield");
            */

            //Lets the player choose their next move, keeps them in a loop unless they choose to talk
            bool userChoice = UserCommand(StartingInn.Details, StartingInn.LootInventory, StartingInnKeeper);
            while (userChoice == false)
            {
                userChoice = UserCommand(StartingInn.Details, StartingInn.LootInventory, StartingInnKeeper);
            }


            //UserCommand(StartingInn.Details, StartingInn.LootInventory, StartingInnKeeper);
            Console.WriteLine("Press any key to exit"); Console.ReadLine();
        }
    }
}