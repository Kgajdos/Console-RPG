/* MAIN GAME IDEA: 
 * A small text based adventure in the world of Lemorea,
 * the player will be able to take on a rats nest for a tutorial mission,
 * they will be rewarded 25 copper and a level.
 * There will be several rooms the player can travel to, and options
 * available to them in the different rooms.
 * 
 * THERE IS A CHUNK OF CODE THAT NEEDS TO BE FIXED! IT IS A TIMER FUNCTION WHEN THE PLAYER FAINTS
 * IT NEEDS TO HOLD UP THE PLAYER FOR AT LEAST A FEW SECONDS!
 * 
 * 
 * ---------------------------------------------------
 * Next up:
 * --need to create a player function for look, attack, equip
 * --need to set health, strength, defense, and speed to a random number between 2 set parameters.
 * --need to fix sword logic
 *----------------------------------------------------
 *Well into the future:
 *--Keep code somewhat clean
 *--add better dialog for the user's ease of understanding
 *--add an enemy class
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

            //Give player a sword
            Dialog("'Here, take this.' \n");
            Console.WriteLine("Civeil hands you a sword, it is covered with minor scratches and dents.");
            //  player.StartingWeapon = new Sword();

            Tutorial();

        }
    }
}