using System;
using static System.Net.Mime.MediaTypeNames;
internal class Program

{
    static (string firstName, string secondName, int iAge, bool petExist, int petCount, string[] petName, int colorCount, string[] colorSet) GlobUser;
    private static void Main(string[] args)
    {
        FillUser();

        ShowData();
    }

    static void FillUser() 
    {
        //(string firstName, string secondName, int iAge, bool petExist, int petCount, string[] petName, int colorCount, string[] colorSet) LocalUser;


        GlobUser.firstName = CheckStr("Введите имя");

        GlobUser.secondName = CheckStr("Введите фамилию");

        GlobUser.iAge = CheckNum("Введите возраст цифрами",true);



        string sPetExist;
        bool exitDo = true;
        Console.WriteLine("Введите наличие питомца (да или нет)");
        do
        {
       

            sPetExist = Console.ReadLine();

            if (sPetExist == "да")
            {
                GlobUser.petExist = true;

                GlobUser.petCount = CheckNum("Введите кол-во питомцев", true);

                GlobUser.petName = FillArray(GlobUser.petCount,"Имя питомца");

               exitDo = false;

            }
            else if (sPetExist == "нет")
            {
                GlobUser.petExist = false;
                GlobUser.petCount = 0;
                exitDo = false;
            }
            else
            {
                Console.WriteLine("Error Введите наличие питомца (да или нет)");
            }
        } while (exitDo);

        GlobUser.colorCount = CheckNum("Введите колличество любимых цветов цифрами", true);

        GlobUser.colorSet = FillArray(GlobUser.colorCount, "Название цвета");

       

    }
    static string CheckStr(string msg)
    {
        Console.WriteLine(msg);
        string str;
        bool exitDo=true;
        do
        {
            
            str = Console.ReadLine();
            if (int.TryParse(str, out int Num) || str == "")
            {
                Console.WriteLine("Error " + msg);
            }
            else
            {
                
                exitDo = false;
            }


        } while(exitDo);  
            
        return str;
    }
    static int CheckNum(string msg, bool checkZero)
    {
        Console.WriteLine(msg);
        string str;
        bool exitDo = true;
        int inum=0;
        do
        {
            str = Console.ReadLine();

            if (int.TryParse(str, out int num))
            {
                if (num == 0 && checkZero == true)
                {
                    Console.WriteLine("Error " + msg);
                }
                else
                {
                    exitDo = false;
                    inum = num;

                }
            }
            else
            {
                Console.WriteLine("Error " + msg);

            }


        } while (exitDo);
        return inum;
        

    }

    static string[] FillArray(int arrLenght, string msg)
    {
        string[] array=new string[arrLenght];
        for (int i = 0; i<arrLenght; i++)
        {
            array[i] = CheckStr(msg+" "+Convert.ToString(i+1));
        }

        return array;
    }

    static void ShowData()
    {
        Console.WriteLine("Вас зщвут {0} {1}, ваш возраст {2}",GlobUser.firstName,GlobUser.secondName,GlobUser.iAge);

        if (GlobUser.petExist == false)
        {
            Console.WriteLine("У вас нет питомцев");
        }
        else
        {
            string msgPet=$"У вас есть {GlobUser.petCount} питомцев";
            for (int i = 0; i < GlobUser.petName.Length; i++)
            {
                msgPet += "\n"+ GlobUser.petName[i];
            }
            Console.WriteLine(msgPet);
        }

        string msgColor = "Ваши любимые цвета";
        for (int i = 0; i < GlobUser.colorSet.Length; i++)
        {
            msgColor += "\n" + GlobUser.colorSet[i];
        }
        Console.WriteLine(msgColor);


    }

}
