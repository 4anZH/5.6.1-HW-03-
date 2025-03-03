using System;
using static System.Net.Mime.MediaTypeNames;
internal class Program

{
    //static (string firstName, string secondName, int iAge, bool petExist, int petCount, string[] petName, int colorCount, string[] colorSet) GlobUser;
    private static void Main(string[] args)
    {
        //GlobUser = SetGlobUser();
        //FillUser();

        ShowData(User());
    }

    static (string firstName, string secondName, int iAge, bool petExist, int petCount, string[] petName, int colorCount, string[] colorSet) User()
    {
        (string firstName, string secondName, int iAge, bool petExist, int petCount, string[] petName, int colorCount, string[] colorSet) LocalUser = ("", "", 0, false, 0, [], 0, []);

        LocalUser.firstName = CheckStr("Введите имя");

        LocalUser.secondName = CheckStr("Введите фамилию");

        LocalUser.iAge = CheckNum("Введите возраст цифрами",true);

        string sPetExist;
        bool exitDo = true;
        Console.WriteLine("Введите наличие питомца (да или нет)");
        do
        {
            sPetExist = Console.ReadLine();

            if (sPetExist == "да")
            {
                LocalUser.petExist = true;

                LocalUser.petCount = CheckNum("Введите кол-во питомцев", true);

                //LocalUser.petName = new string[LocalUser.petCount];

                LocalUser.petName = FillArray(LocalUser.petCount,"Имя питомца");

               exitDo = false;

            }
            else if (sPetExist == "нет")
            {
                LocalUser.petExist = false;
                LocalUser.petCount = 0;
                exitDo = false;
            }
            else
            {
                Console.WriteLine("Error Введите наличие питомца (да или нет)");
            }
        } while (exitDo);

        LocalUser.colorCount = CheckNum("Введите колличество любимых цветов цифрами", true);

        //LocalUser.colorSet = new string[LocalUser.colorCount];

        LocalUser.colorSet = FillArray(LocalUser.colorCount, "Название цвета");

        return LocalUser;

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

    static void ShowData((string firstName, string secondName, int iAge, bool petExist, int petCount, string[] petName, int colorCount, string[] colorSet) LocalUser)
    {
        Console.WriteLine("Вас зщвут {0} {1}, ваш возраст {2}",LocalUser.firstName,LocalUser.secondName,LocalUser.iAge);

        if (LocalUser.petExist == false)
        {
            Console.WriteLine("У вас нет питомцев");
        }
        else
        {
            string msgPet=$"У вас есть {LocalUser.petCount} питомцев";
            for (int i = 0; i < LocalUser.petName.Length; i++)
            {
                msgPet += "\n"+ LocalUser.petName[i];
            }
            Console.WriteLine(msgPet);
        }

        string msgColor = "Ваши любимые цвета";
        for (int i = 0; i < LocalUser.colorSet.Length; i++)
        {
            msgColor += "\n" + LocalUser.colorSet[i];
        }
        Console.WriteLine(msgColor);


    }

}
