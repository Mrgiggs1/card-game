using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace winner
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string[] player = new string[5];
            int num = 0;
            int highest = 0;
            int points = 0;
            String winnerName = "";
            int suitPoints = 0;
            int totalPoints = 0;
            String tieName = "";
            String currName = "";


            try
            {
                var file = File.ReadAllLines("C:\\Users\\LATITUDE 5480\\Desktop\\cards\\winner\\data.txt");
                Console.WriteLine("Name \t\tCards \t\t Points");
                foreach (var line in file)
                {
                    player[num] = line;
                    String[] nameCards = line.Split(':');
                    String name = nameCards[0];
                    String cards = nameCards[1];

                    
                    




                    points = calculatePoints(cards);

                    Console.WriteLine(name + " \t\t" + cards + "\t" + points);

                    if (points > highest)
                    {
                        highest = points;
                        winnerName = name;
                    }
                    else if (points == highest)
                    {
                        suitPoints = calculateSuit(cards);
                        totalPoints = suitPoints+ points;
                        currName = name;
                        
                    }
                    tieName = name + ", "+ currName;

                    num++;
                }

                //display the winner
                Console.WriteLine("\nWinner:");
                
                Console.WriteLine(winnerName + ":\t " + highest);
                
                //display tie and points
                Console.WriteLine(tieName + ": " + totalPoints);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }

        //This will return the points calculated
        public static int calculatePoints(String cards)
        {
            String[] cardArr = cards.Split(",");

            int points = 0;

            foreach (String card in cardArr)
            {
                String value = card.Substring(0, 1);

                if (value == "J")
                {
                    points = points + 11;
                }
                else if (value == "Q")
                {
                    points = points + 12;
                }
                else if (value == "K")
                {
                    points = points + 13;
                }
                else if (value == "A")
                {
                    points = points + 1;
                }
                else if (value == "T")
                {
                    points = points + 10;
                }
                else
                {
                    points = points + Int32.Parse(value);
                }
            }

            return points;
        }


        //this is add suit if there is tie
        public static int calculateSuit(String cards)
        {
            String[] cardArr = cards.Split(",");

            int suitPoints =0;
            int totalPoints = 0;

            //run deck card again for suit calculation
            foreach (String card in cardArr)
            {
                String value = card.Substring(1, 2);

                if (value == "S")
                {
                    suitPoints = 4;
                }
                else if (value == "H")
                {
                    suitPoints = 3;
                }
                else if (value == "D")
                {
                    suitPoints = 2;
                }
                else if (value == "C")
                {
                    suitPoints = 1;
                }
                totalPoints = totalPoints + suitPoints;

            }
            Console.WriteLine(totalPoints);
            return totalPoints;
        }
    }
}
