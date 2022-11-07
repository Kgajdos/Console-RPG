/*
 * ALL CLASSES ARE INSTANTIATED HERE! NOTHING ELSE SHOULD BE HERE!
 * 
 * 
 */
namespace RPG
{
    //Sword class
    public class Sword
    {
        int _damageMod = 0;

        public int DamageMod
        {
            get { return _damageMod; }
            set { _damageMod = value; }
        }
    }

    public class Race
    {
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
        public int RatAttack(int Strength, int playerDefense)
        {
            int damage = 0;
            if (Strength > playerDefense)
            {
                damage = Strength - playerDefense;
            }

            return damage;
        }
    }
    public class Player
    {

        string _name = "";
        int _age = 0;
        double health = 20;
        double strength = 20;
        double defense = 20;
        double speed = 20;
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
        public string Race
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
    }

    public class InnKeeper
    {
        string _name = "";
        int _age = 0;

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
    }
    //Room class for the room the player is standing in
    public class Room
    {
        string _details = "";
        string _NPC = "";

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
    }

}
