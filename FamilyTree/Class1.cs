namespace FamilyTree
{
    public enum Gender
    {
        male,
        female
    }

    public enum Relative
    {
        grandfather,
        grandmother,
        mother,
        father,
        husband,
        wife,
        spouse,
        son,
        daughter
    }

    public class FamilyMember
    {
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public string? Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string? Status { get; set; }

        public FamilyMember? Mother { get; set; }
        public FamilyMember? Father { get; set; }
        public FamilyMember? Son { get; set; }
        public FamilyMember? Daughter { get; set; }
        public FamilyMember? Husband { get; set; }
        public FamilyMember? Wife { get; set; }
        public FamilyMember? CousinMale { get; set; }
        public FamilyMember? CousinFemale { get; set; }


        /*  public override string ToString()
          {
              return $"{Name}\t | \t{Patronymic}\t | \t{Surname}\t | \t{DateOfBirth?.ToString("d")}\t | \t{Gender}";
          }*/

        public FamilyMember GetRelativeOrDefault(FamilyMember? member)
        {
            return member ?? new FamilyMember { Name = "Нет данных" };
        }

        public FamilyMember GetRelativeOrDefaultSpouse()
        {
            if (Gender == FamilyTree.Gender.male)
                return Wife ?? new FamilyMember { Name = "Нет данных" };
            else
                return Husband ?? new FamilyMember { Name = "Нет данных" };
        }

        public (string, FamilyMember)[] GetCloseRelatives()
        {
            var spouseRelation = Gender == FamilyTree.Gender.male ? "Жена" : "Муж";
            return new (string, FamilyMember)[]
           {
                     ("Бабушка по материнской линии", GetRelativeOrDefault(Mother?.Mother)),
                     ("Дедушка по материнской линии", GetRelativeOrDefault(Mother?.Father)),
                     ("Бабушка по отцовской линии", GetRelativeOrDefault(Father?.Mother)),
                     ("Дедушка по отцовской линии", GetRelativeOrDefault(Father?.Father)),
                     ("Мама", GetRelativeOrDefault(Mother)),
                     ("Папа", GetRelativeOrDefault(Father)),
                     (spouseRelation, GetRelativeOrDefaultSpouse()),
                     ("Сын", GetRelativeOrDefault(Son)),
                     ("Дочь", GetRelativeOrDefault(Daughter)),
                     ("Двоюродный брат", GetRelativeOrDefault(CousinMale)),
                     ("Двоюродная сестра", GetRelativeOrDefault(CousinFemale)),
           };
        }

        public FamilyMember[] GetRelative(Relative relative)
        {
            switch (relative)
            {
                case Relative.grandmother:
                    return new FamilyMember[]
                          {
                          Mother?.Mother ?? new FamilyMember { Name = "Нет данных" },
                          Father?.Mother ?? new FamilyMember { Name = "Нет данных" }
                          };
                case Relative.grandfather:
                    return new FamilyMember[]
                          {
                          Mother?.Father ?? new FamilyMember { Name = "Нет данных" },
                          Father?.Father ?? new FamilyMember { Name = "Нет данных" }
                          };
                case Relative.mother:
                    return new FamilyMember[]
                          {
                          Mother ?? new FamilyMember { Name = "Нет данных" }
                                                    };
                case Relative.father:
                    return new FamilyMember[]
                           {
                           Father ?? new FamilyMember { Name = "Нет данных" }
                           };
                case Relative.son:
                    return new FamilyMember[]
                          {
                        Son ?? new FamilyMember { Name = "Нет данных" }
                                                    };
                case Relative.daughter:
                    return new FamilyMember[]
                          {
                           Daughter ?? new FamilyMember { Name = "Нет данных" }
                           };
                default:
                    return new FamilyMember[] { new FamilyMember { Name = "Неверно указан родственник" } };
            }
        }

        public string GetFullName()
        {
            return Name + " " + Patronymic + " " + Surname;
        }

        public string GetFullNameAndBirthDate()
        {
            if (Name == "Нет данных")
                return Name;
            else
                return Name + " " + Patronymic + " " + Surname + ", " + DateOfBirth?.ToString("d");
        }

        public string GetAllInfo()
        {
            return Name + " " + Patronymic + " " + Surname + ", " + DateOfBirth?.ToString("d") + ", " + Gender;
        }

        public int GetAge()
        {
            if (DateOfBirth == null)
                return 0;

            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Value.Year;

            if (DateOfBirth.Value.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
