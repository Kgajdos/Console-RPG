/* MAIN GAME IDEA: 
 * A small text based adventure in the world of Lemorea,
 * the player will be able to take on a rats nest for a tutorial mission,
 * they will be rewarded 25 copper and a level.
 * There will be several rooms the player can travel to, and options
 * available to them in the different rooms.
 * 
 * 
 * 
 * ---------------------------------------------------
 * Next up:
 * --need to create a player function for look, attack, equip
 * --need to fix sword logic
 *----------------------------------------------------
 *Well into the future:
 *--Keep code somewhat clean
 *--add an enemy class (RAT ADDED)
 *--add a shopkeeper npc, and an innkeeper npc (already did INNKEEPER)
 *--need a character sheet!
 *--need a wallet mechanic (in its infancy, but there)
 *--more will be added at a later time
 *
 *Author: Kevin Gajdos
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static RPG.Methods;


namespace RPG
{
    class Game
    {
        //User global commands, needs work
        public static bool playerAttackCommand = false;
        public static string attack = "attack";
        public static bool tutorial = false;
        
        public static void PlayerCommands()
        {
            if (Console.ReadLine() == attack)
            {
                playerAttackCommand = true;
                // Player.Attack();
            }
        }

        //Code that handes the main program 
        static void Main()
        {
            //beginning save/load logic
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }
            Load(out bool newP);
            if (newP == true)
            {
                tutorial = Tutorial();
            }else
            {
                tutorial = true;
            }
            
            

            Wallet playerWallet = new Wallet();
            playerWallet.CopperAvailable = 0;
            playerWallet.SilverAvailable = 0;
            playerWallet.GoldAvailable = 0;
            //Inn that player starts in
            Room StartingInn = new Room();
            StartingInn.Details = "You look around a small, sparesly decorated room. \n" +
                "In the center of the room is a small firepit casting a warm glow all around. \n" +
                "";
            StartingInn.NPC = "Civeil";
            StartingInn.RoomNumber = 1;
            StartingInn.LootInventory.Add("Mug of Ale");
            StartingInn.LootInventory.Add("Chunk of Bread");

            //Innkeeper for starting inn
            InnKeeper Civeil = new InnKeeper();
            Civeil.Name = "Civeil";
            Civeil.Age = 59;
            Civeil.ShopInventory = new List<string> { };
            Civeil.ShopInventory.Add("Small Health Potion");
            Civeil.ShopInventory.Add("Shield");

            //Lets the player choose their next move, keeps them in a loop unless they choose to talk
            bool userChoice = UserCommand(StartingInn.Details, StartingInn.LootInventory);
            while (userChoice == false)
            {
                userChoice = UserCommand(StartingInn.Details, StartingInn.LootInventory);
            }

            //First mission, player will level up after this
            
            if (tutorial == true)
            {
                Dialog("'As promised, here's your copper." + "\n");
                Console.WriteLine("Civeil hands you 25 copper. You place it in your inventory.");

                //Tutorial rewards, level up 
                playerWallet.CopperAvailable = 25;
                player.Level = 2;
                int statMulti = (int)Player.LevelUp(player.Level);
                player.Health = player.Health * statMulti;
                player.Defense = player.Defense * statMulti;
                player.Speed = player.Speed * statMulti;
                player.Strength = player.Strength * statMulti;
                Console.WriteLine("You gained a level!");
            }

            //Moving on in the game
            Dialog("Would you like to check out my wares?" + "\n");
            Console.WriteLine("A: Yes\n" + "B: No");
            bool correctResponse = false;
            string playerResponse = AorB(Console.ReadLine());
            while (correctResponse == false)
            {
                switch (playerResponse)
                {
                    case "A":
                        for (int i = 0; i < Civeil.ShopInventory.Count; i++)
                        {
                            Console.WriteLine(Civeil.ShopInventory[i]);
                        }
                        correctResponse = true;
                        break;
                    case "B":
                        Dialog("Ok then.\n");
                        correctResponse = true;
                        break;
                    default:
                        Console.WriteLine("Civeil waits patiently for your response.");
                        correctResponse = false;
                        break;
                }
            }
            UserCommand(StartingInn.Details, StartingInn.LootInventory);
            Console.WriteLine("Press any key to exit"); Console.ReadLine();
        }
    }
}