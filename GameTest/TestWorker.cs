using System;
using System.Collections.Generic;
using System.Text;
using Sail_n__Shoot___Obl_Opg._aswc.Creatures;
using Sail_n__Shoot___Obl_Opg._aswc.Items;
using Sail_n__Shoot___Obl_Opg._aswc.Trace;
using Sail_n__Shoot___Obl_Opg._aswc.World;
using Sail_n__Shoot___Obl_Opg._aswc.XMLConfig;

namespace GameTest
{
   public class TestWorker
    {
        public void Start()
        {

            //TestShoot();
            //TestSea();
            //MovementTest();
            //PlayerTest();
            TestGame();
        }
        Player p1 = new Player(3, "Player - ahab");
        Enemy e1 = new Enemy(3, "moby");
        public void TestShoot()
        {

            Console.WriteLine("enemy hp: " + e1.Hp);
            p1.Shoot(e1);
            Console.WriteLine("enemy hp: " + e1.Hp);
            Console.WriteLine("---------------------------------");
        }

        public void TestSea()
        { 

            XmlConfig xml = new XmlConfig();
            Sea sea = new Sea(xml.UseConfigFile("width"), xml.UseConfigFile("height"));
            //sea.PrintGround();
            
            sea.CreatureList.Add(e1);
            sea.CreatureList.Add(p1);

            Console.WriteLine("places creatures...");
            sea.PlaceCreatures();

            Console.WriteLine("position of enemies");
            sea.PrintShips(10);
            Console.WriteLine($"Xpoition: {sea.CreatureList[0].Xposition} - Yposition:  {sea.CreatureList[0].Yposition}");

            
        }

        public void MovementTest()
        {
            ShipStateMachine sm = new ShipStateMachine();

            while (true)
            {
                p1.ChangePosition(sm.ChangeDirection(sm.ReadNextKey()));
            }
        }

        public void TraceTest(TraceWorker trace, string text)
        {
            trace.TraceTest();
            trace.TextToTrace(text);
            
        }

        public void PlayerTest()
        {
            Cannon c1 = new Cannon(1,"Cannon", "A one-use special shot", 20, 2);
            Carpenters_Tools c2Tools = new Carpenters_Tools( 2,"Carpenters tools", "heals 1 hp");

            Console.WriteLine("player hp: " + p1.Hp);
            Console.WriteLine("enemy hp: " + e1.Hp);

            p1.PickUpItem(c1,p1);
            p1.PickUpItem(c2Tools,p1);
            
            //tests the cannon range and damage
            e1.Xposition = 10;
            
            p1.UseItem(p1, e1);
            Console.WriteLine("enemy hp" + e1.Hp);

            //tests the carpenters tools
            p1.UseItem(p1, e1);
            Console.WriteLine("player hp" + p1.Hp);
        }

        public void GameSetup()
        {

        }
        public void TestGame()
        {
            XmlConfig xml = new XmlConfig();
            Sea sea = new Sea(xml.UseConfigFile("width"), xml.UseConfigFile("height"));
            TraceWorker trace = new TraceWorker();
            sea.CreatureList.Add(p1);
            sea.CreatureList.Add(e1);

            Console.WriteLine("places creatures...");
            //sea.CreatureList[0].Xposition = sea.Width / 2;
            //sea.CreatureList[0].Yposition = 5;

            //sea.CreatureList[1].Xposition = sea.Width / 2;
            //sea.CreatureList[1].Yposition = sea.Height;
            sea.PlaceCreatures();

            Carpenters_Tools c2Tools = new Carpenters_Tools(2,"Carpenters Tools", "heals ");

            Cannon c1 = new Cannon(1, "Cannon", "A one-use special shot", 20, 2);
            sea.ItemList.Add(c1);
            sea.PlaceItems();

            ShipStateMachine sm = new ShipStateMachine();

            while (true)
            {
                sea.PrintShips(10);
                sea.PrintItems();

                Console.WriteLine("Choose your next action: shoot, use item, pickup item, check inventory, move");
                string action = Console.ReadLine();
                trace.TextToTrace(action);
                if (action.ToLower() == "move")
                {
                    p1.ChangePosition(sm.ChangeDirection(sm.ReadNextKey()));
                }

                if (action.ToLower() == "shoot")
                {
                    p1.Shoot(e1);
                    Console.WriteLine("you fire your cannons, hitting the enemy for 1");
                    Console.WriteLine(e1.Hp);
                }

                if (action == "pickup item")
                {
                    sea.PrintItems();
                    foreach (var item in sea.ItemList)
                    {
                        Console.WriteLine("Do you want to pickup the item y/n");
                        if (Console.ReadLine() == "y")
                        {
                            p1.PickUpItem(item,p1);
                        }
                    }
                }

                if (action.ToLower() == "use item")
                {
                    p1.UseItem(p1,e1);
                }

                if (action.ToLower() == "check inventory")
                {
                    Console.WriteLine("-------------------------");
                    p1.CheckItems();
                    Console.WriteLine("-------------------------");
                }
                else
                {
                    Console.WriteLine("action not vaild");
                }

                
                
            }
        }

    }
}
