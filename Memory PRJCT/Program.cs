using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_PRJCT
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter an even number not bigger then 8");
            int mmryArraySize;
            while (true) //check if condition for array are suitable
            {
                mmryArraySize = int.Parse(Console.ReadLine());
                if (mmryArraySize <= 8 && mmryArraySize % 2 == 0)
                {
                    break;
                }
                Console.WriteLine("not in range, enter again");
            }

            string[] CharArry = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "א", "ב", "ג", "ד", "ה", "ח", "ט" };
            string[,] MemoryMetrix = SetMRYMetrix(mmryArraySize, CharArry);
            int checker = 0;
            int Player1points = 0;
            int Player2points = 0;
            int row1 = 0;
            int cullom1 = 0;
            int row2 = 0;
            int cullom2 = 0;
            bool redo1 = true, redo2 = true;

            PrintMetrix(MemoryMetrix);

            Printgap();

            while (checker < mmryArraySize)
            {

                
                checker = 0;
                Console.WriteLine("player 1");

                while (redo1)
                {
                    Console.WriteLine("please enter a row");
                    row1 = (int.Parse(Console.ReadLine())) - 1;
                    Console.WriteLine("please enter a cullom");
                    cullom1 = (int.Parse(Console.ReadLine())) - 1;

                    redo1 = CheckchoiceAvilabilty(MemoryMetrix, row1, cullom1);
                    
                }

                redo1 = true;

                
                Printgap();

                PrintChoice1(MemoryMetrix, row1, cullom1);

                Printgap();

                while (redo1 || redo2)
                {
                    Console.WriteLine("please enter a row");
                    row2 = (int.Parse(Console.ReadLine())) - 1;
                    Console.WriteLine("please enter a cullom");
                    cullom2 = (int.Parse(Console.ReadLine())) - 1;
                   
                    redo1 = CheckchoiceAvilabilty(MemoryMetrix, row2, cullom2);
                    redo2 = SecPhaseAvilabilityCheck(row1,row2, cullom1 , cullom2);
                }

                redo1 = true;
                redo2 = true;

                Printgap();

                PrintChoice2(MemoryMetrix, row1, cullom1, row2, cullom2);

                Printgap();

                Checkstrike(MemoryMetrix, row1, cullom1, row2, cullom2); //turn end
                Player1points += AddPoints(MemoryMetrix, row1, cullom1, row2, cullom2);
               
               checker = CheckEndGame(MemoryMetrix); //check end game
                
                if (checker == mmryArraySize)  
                {
                    break;
                }

                TurnEnder();

                PrintMetrix(MemoryMetrix);

                Printgap();

                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                
                
                checker = 0;

                
                Console.WriteLine("player 2");

                while (redo1)
                {
                    Console.WriteLine("please enter a row");
                    row1 = (int.Parse(Console.ReadLine())) - 1;
                    Console.WriteLine("please enter a cullom");
                    cullom1 = (int.Parse(Console.ReadLine())) - 1;

                    redo1 = CheckchoiceAvilabilty(MemoryMetrix, row1, cullom1);
                }
                 redo1 = true;

                Printgap();

                PrintChoice1(MemoryMetrix, row1, cullom1);

                Printgap();

                while (redo1 || redo2)
                {
                    Console.WriteLine("please enter a row");
                    row2 = (int.Parse(Console.ReadLine())) - 1;
                    Console.WriteLine("please enter a cullom");
                    cullom2 = (int.Parse(Console.ReadLine())) - 1;
                    
                    redo1 = CheckchoiceAvilabilty(MemoryMetrix, row2, cullom2);
                    redo2 = SecPhaseAvilabilityCheck(row1, row2, cullom1, cullom2);
                }

                redo1 = true;
                redo2 = true;

                Printgap();

                PrintChoice2(MemoryMetrix, row1, cullom1, row2, cullom2);

                Printgap();
                
               TurnEnder();

                Checkstrike(MemoryMetrix, row1, cullom1, row2, cullom2); //turn end
                Player2points += AddPoints(MemoryMetrix, row1, cullom1, row2, cullom2);

                checker = CheckEndGame(MemoryMetrix); //check end game

                PrintMetrix(MemoryMetrix);

                Printgap();
            }
            
            Console.WriteLine($"player 1 points: {Player1points}");
            Console.WriteLine($"player 2 points: {Player2points}");
            

        }

        #region F_SetMemoryGameLayout
        public static string[,] SetMRYMetrix(int size, string[] chararrytoprint)
        {

            string[,] MetrixToSet = new string[size, size];
            Random randomn = new Random();

            int Rnum1;
            int Rnum2;

            for (int i = 0; i < ((size * size) / 2); i++)
            {

                while (true)
                {
                    Rnum1 = randomn.Next(0, size);
                    Rnum2 = randomn.Next(0, size);
                    if (MetrixToSet[Rnum1, Rnum2] == null)
                    {
                        MetrixToSet[Rnum1, Rnum2] = chararrytoprint[i];
                        break;
                    }
                }
                while (true)
                {
                    Rnum1 = randomn.Next(0, size);
                    Rnum2 = randomn.Next(0, size);
                    if (MetrixToSet[Rnum1, Rnum2] == null)
                    {
                        MetrixToSet[Rnum1, Rnum2] = chararrytoprint[i];
                        break;
                    }
                }
            }
            return MetrixToSet;
        }
        #endregion

        #region F_PrintArray 
        public static void PrintMetrix(string[,] arrytoPrint)
        {
            for (int i = 0; i < arrytoPrint.GetLength(0); i++)
            {
                for (int j = 0; j < arrytoPrint.GetLength(1); j++)
                {

                    if (arrytoPrint[i, j] != "0")
                    {
                        Console.Write(" x");
                    }

                    else
                    {
                        Console.Write(" 0");
                    }

                }
                Console.WriteLine();
            }
        }


        #endregion

        #region FirstTimeChoice
        public static void PrintChoice1(string[,] arrytoPrint, int row1, int cullom1)
        {
            for (int i = 0; i < arrytoPrint.GetLength(0); i++)
            {
                for (int j = 0; j < arrytoPrint.GetLength(1); j++)
                {
                    if (i == row1 && j == cullom1)
                    {
                        Console.Write($" {arrytoPrint[row1, cullom1]}");
                    }
                    else if (arrytoPrint[i, j] != "0")
                    {
                        Console.Write(" x");
                    }

                    else
                    {
                        Console.Write(" 0");
                    }

                }
                Console.WriteLine();
            }
        }

        #endregion

        #region SecChoice
        public static void PrintChoice2(string[,] arrytoPrint, int row1, int cullom1, int row2, int cullom2)
        {
            for (int i = 0; i < arrytoPrint.GetLength(0); i++)
            {
                for (int j = 0; j < arrytoPrint.GetLength(1); j++)
                {
                    if (i == row1 && j == cullom1)
                    {
                        Console.Write($" {arrytoPrint[i, j]}");
                    }
                    else if (i == row2 && j == cullom2)
                    {
                        Console.Write($" {arrytoPrint[i, j]}");
                    }
                    else if (arrytoPrint[i, j] != "0")
                    {
                        Console.Write(" x");
                    }

                    else
                    {
                        Console.Write(" 0");
                    }

                }
                Console.WriteLine();
            }
        }

        #endregion

        #region Check for strike

        public static void Checkstrike(string[,] mmrystring, int row1, int cullom1, int row2, int cullom2)
        {
            for (int i = 0; i < mmrystring.GetLength(0); i++)
            {
                for (int j = 0; j < mmrystring.GetLength(1); j++)       
                {
                    if (mmrystring[row1,cullom1] == mmrystring[row2,cullom2])
                    {
                        mmrystring[row1, cullom1] = "0";
                        mmrystring[row2, cullom2] = "0";
                    }
                }
            }
        }
        #endregion

        #region Add Points

        public static int AddPoints(string[,] mmrystringarry ,int row1, int cullom1, int row2, int cullom2)
        {
            
            if (mmrystringarry[row1,cullom1] == mmrystringarry[row2, cullom2])
            {
                return 1;
            }
            return 0;
        }


        #endregion

        #region check for game end
        public static int CheckEndGame(string[,] mmrystringarry)
        {
            int check0 = 0;
            for (int i = 0; i < mmrystringarry.GetLength(0); i++)
            {
                for (int j = 0; j < mmrystringarry.GetLength(1); j++)
                {
                    if (mmrystringarry[i,j] == "0")
                    {
                        check0++;
                    }
                }
            }
            return check0/2;
        }


        #endregion

        #region printgap

        public static void Printgap()
        {
            Console.WriteLine();
            Console.WriteLine("==========");
            Console.WriteLine();
        }


        #endregion

        #region CheckForCHoice Avilablity

        public static bool CheckchoiceAvilabilty(string [,] mmrystringarry ,int row , int cullom)
        {
            if (mmrystringarry[row,cullom] == "0")
            {
                Console.WriteLine("this space is already paired ,please try again");
                return true;
            }
            
            return false;
        }

        #endregion

        #region SecPhaseAvilabilityCheck

        public static bool SecPhaseAvilabilityCheck(int row1 , int row2, int collum1, int collum2)
        {
            if (row1 == row2 && collum1 == collum2)
            {
                Console.WriteLine("can't choose the same card twice");
                return true;
            }
            return false;
        }

        #endregion

        #region TurnEnder

        public static void TurnEnder()
        {
            Console.WriteLine("Press enter to start next turn");
            Console.ReadLine();
            Console.Clear();
        }
        #endregion
    }
}
