/*Спроектируйте программу для построения генеалогического дерева. 
    Учтите что у нас есть члены семьи у кого нет детей(дет). 
    Есть члены семьи у кого дети есть (взрослые). Есть мужчины и женщины.*/

/*Доработать предыдущий класс реализовав методы вывода родителей, детей, 
           братьев/сестер(включая двоюродных), бабушеки дедушек.
           Подумайте как лучше реализовать данные методы.*/

/*Доработайте приложение генеалогического дерева таким образом чтобы программа 
    выводила на экран близких родственников (жену/мужа - дополнительно выводить и родителей и детей). 
Продумайте способ более красивого вывода с использованием горизонтальных и вертикальных черточек.*/


namespace FamilyTree
{
    public class Program
    {

        static void Main(string[] args)
        {
            FamilyMember GrandMotherOne = new FamilyMember();
            FamilyMember GrandFatherOne = new FamilyMember();
            FamilyMember GrandMotherTwo = new FamilyMember();
            FamilyMember GrandFatherTwo = new FamilyMember();
            FamilyMember FatherOne = new FamilyMember();
            FamilyMember MotherOne = new FamilyMember();
            FamilyMember SonOne = new FamilyMember();
            FamilyMember DaughterOne = new FamilyMember();
            FamilyMember MotherTwo = new FamilyMember();
            FamilyMember SonTwo = new FamilyMember();


            GrandMotherOne.Name = "Alena";
            GrandMotherOne.Patronymic = "Mihailovna";
            GrandMotherOne.Surname = "Petrova";
            GrandMotherOne.DateOfBirth = new DateTime(1963, 8, 12);
            GrandMotherOne.Gender = Gender.female;
            GrandMotherOne.Son = FatherOne;
            GrandMotherOne.Husband = GrandFatherOne;

            GrandFatherOne.Name = "Ivan";
            GrandFatherOne.Patronymic = "Dmitrievich";
            GrandFatherOne.Surname = "Petrov";
            GrandFatherOne.DateOfBirth = new DateTime(1962, 4, 13);
            GrandFatherOne.Gender = Gender.male;
            GrandFatherOne.Son = FatherOne;
            GrandFatherOne.Wife = GrandMotherOne;

            GrandMotherTwo.Name = "Elena";
            GrandMotherTwo.Patronymic = "Olegovna";
            GrandMotherTwo.Surname = "Smirnova";
            GrandMotherTwo.DateOfBirth = new DateTime(1960, 10, 21);
            GrandMotherTwo.Gender = Gender.female;
            GrandMotherTwo.Daughter = MotherOne;
            GrandMotherTwo.Husband = GrandFatherTwo;

            GrandFatherTwo.Name = "Pawel";
            GrandFatherTwo.Patronymic = "Igorevich";
            GrandFatherTwo.Surname = "Smirnov";
            GrandFatherTwo.DateOfBirth = new DateTime(1961, 12, 14);
            GrandFatherTwo.Gender = Gender.male;
            GrandFatherTwo.Daughter = MotherOne;
            GrandFatherTwo.Wife = GrandMotherTwo;

            FatherOne.Name = "Semen";
            FatherOne.Patronymic = "Ivanovich";
            FatherOne.Surname = "Petrov";
            FatherOne.DateOfBirth = new DateTime(1987, 5, 3);
            FatherOne.Gender = Gender.male;
            FatherOne.Mother = GrandMotherOne;
            FatherOne.Father = GrandFatherOne;
            FatherOne.Son = SonOne;
            FatherOne.Daughter = DaughterOne;
            FatherOne.Wife = MotherOne;

            MotherOne.Name = "Anna";
            MotherOne.Patronymic = "Pavlovna";
            MotherOne.Surname = "Petrova";
            MotherOne.DateOfBirth = new DateTime(1987, 11, 14);
            MotherOne.Gender = Gender.female;
            MotherOne.Mother = GrandMotherTwo;
            MotherOne.Father = GrandFatherTwo;
            MotherOne.Son = SonOne;
            MotherOne.Daughter = DaughterOne;
            MotherOne.Husband = FatherOne;

            SonOne.Name = "Daniil";
            SonOne.Patronymic = "Semenovich";
            SonOne.Surname = "Petrov";
            SonOne.DateOfBirth = new DateTime(2012, 7, 30);
            SonOne.Gender = Gender.male;
            SonOne.Mother = MotherOne;
            SonOne.Father = FatherOne;
            SonOne.CousinMale = SonTwo;

            DaughterOne.Name = "Karina";
            DaughterOne.Patronymic = "Semenovna";
            DaughterOne.Surname = "Petrova";
            DaughterOne.DateOfBirth = new DateTime(2001, 1, 15);
            DaughterOne.Gender = Gender.female;
            DaughterOne.Mother = MotherOne;
            DaughterOne.Father = FatherOne;
            DaughterOne.CousinMale = SonTwo;

            MotherTwo.Name = "Maria";
            MotherTwo.Patronymic = "Pavlovna";
            MotherTwo.Surname = "Kotova";
            MotherTwo.DateOfBirth = new DateTime(1985, 10, 4);
            MotherTwo.Gender = Gender.female;
            MotherTwo.Mother = GrandMotherOne;
            MotherTwo.Father = GrandFatherOne;
            MotherTwo.Son = SonTwo;

            SonTwo.Name = "Arseniy";
            SonTwo.Patronymic = "Nikolaevich";
            SonTwo.Surname = "Kotov";
            SonTwo.DateOfBirth = new DateTime(2015, 8, 7);
            SonTwo.Gender = Gender.male;
            SonTwo.Mother = MotherTwo;
            SonTwo.CousinMale = SonOne;
            SonTwo.CousinFemale = DaughterOne;

            /*var TheRelative1 = SonOne.GetRelative(Relative.father);
            Console.WriteLine(TheRelative1[0].GetFullNameAndBirthDate() );
            var TheRelative2 = MotherOne.GetRelative(Relative.son);
            Console.WriteLine(TheRelative2[0].GetFullNameAndBirthDate());
            var TheRelative3 = MotherTwo.GetRelative(Relative.son);
            Console.WriteLine(TheRelative3[0].GetFullNameAndBirthDate());*/
            /* var closeRelatives = MotherOne.GetCloseRelatives();
             foreach (var (relation, relative) in closeRelatives)
             {
                 Console.Write($"{relation}: ");
                 Console.WriteLine(relative.GetFullNameAndBirthDate());
             }*/

            void PrintRelative(FamilyMember theRelative)
            {

                var closeRelatives = theRelative?.GetCloseRelatives() ?? new (string, FamilyMember)[0];
                int MaxStringLenght = 0;
                foreach (var (relation, relative) in closeRelatives)
                {
                    if (relation.Length + relative.GetFullNameAndBirthDate().Length > MaxStringLenght)
                        MaxStringLenght = relation.Length + relative.GetFullNameAndBirthDate().Length;
                }

                foreach (var (relation, relative) in closeRelatives)
                {
                    //if (relative.GetFullNameAndBirthDate() == "Нет данных") continue;
                    if (theRelative?.GetAge() < 18 && (relation == "Жена" || relation == "Муж" || relation == "Сын" || relation == "Дочь") ) continue;
                    Console.Write(" ");
                    for (int i = 0; i <= MaxStringLenght + 3; i++)
                        Console.Write("_");

                    Console.Write($"\n|");

                    for (int i = 0; i <= MaxStringLenght + 3; i++)
                        Console.Write(" ");

                    Console.WriteLine("|");

                    Console.Write($"  {relation}: ");
                    Console.Write(relative.GetFullNameAndBirthDate());
                    Console.WriteLine(" ");

                    Console.Write("|");
                    for (int i = 0; i <= MaxStringLenght + 3; i++)
                        Console.Write("_");
                    Console.WriteLine("|");
                }
            }

            PrintRelative(SonOne);
            
            Console.WriteLine("\n");
            PrintRelative(SonTwo);

            Console.WriteLine("\n");
            PrintRelative(MotherOne);

            Console.WriteLine("\n");
            PrintRelative(FatherOne);

        }
    }
}
