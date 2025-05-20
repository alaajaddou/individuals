using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    // Constants for configuration
    private const int RequiredFamilyMemberCount = 5;
    private const int RequiredFemaleOverEighteenCount = 1;
    private const int RequiredMaleOverEighteenCount = 1;

    private static readonly List<Individual> FamilyMembers = new()
    {
        new Individual(1, "Alice", 20, Gender.Female),
        new Individual(2, "Bob", 22, Gender.Male),
        new Individual(3, "Charlie", 17, Gender.Male),
        new Individual(4, "Diana", 25, Gender.Female),
        new Individual(5, "Diana", 25, Gender.Male)
    };

    private static readonly Individual CurrentIndividual = new Individual(4, "Diana", 25, Gender.Male, isEditMode: true);

    public static void Main()
    {
        Console.WriteLine("Hello World");
        Console.WriteLine($"Required family members: {RequiredFamilyMemberCount}");

        int currentMemberCount = FamilyMembers.Count;
        int femaleOver18Count = FamilyMembers.CountFemaleOverEighteen();
        int maleOver18Count = FamilyMembers.CountMaleOverEighteen();

        Console.WriteLine($"Current family members: {currentMemberCount}");
        Console.WriteLine($"Females over 18: {femaleOver18Count}");
        Console.WriteLine($"Males over 18: {maleOver18Count}");

        var updatedFamilyMembers = UpdateFamilyMembers(FamilyMembers, CurrentIndividual);

        if (currentMemberCount > RequiredFamilyMemberCount)
        {
            Console.WriteLine("Fail Reason: Current family member count exceeds required count.");
            return;
        }

        if (IsFamilyFull(updatedFamilyMembers))
        {
            if (femaleOver18Count < RequiredFemaleOverEighteenCount)
            {
                Console.WriteLine("Fail Reason: Not enough females over 18.");
                return;
            }

            if (maleOver18Count < RequiredMaleOverEighteenCount)
            {
                Console.WriteLine("Fail Reason: Not enough males over 18.");
                return;
            }
        }

        if (femaleOver18Count > RequiredFemaleOverEighteenCount)
        {
            Console.WriteLine("Fail Reason: Too many females over 18.");
            return;
        }

        if (maleOver18Count > RequiredMaleOverEighteenCount)
        {
            Console.WriteLine("Fail Reason: Too many males over 18.");
            return;
        }

        Console.WriteLine("Success!");
    }

    private static bool IsFamilyFull(List<Individual> family)
        => family.Count == RequiredFamilyMemberCount;

    private static List<Individual> UpdateFamilyMembers(List<Individual> currentMembers, Individual currentIndividual)
    {
        // Create deep copy
        var updatedMembers = currentMembers.Select(ind => ind.Clone()).ToList();

        if (!currentIndividual.IsEditMode)
        {
            updatedMembers.Add(currentIndividual.Clone());
        }
        else
        {
            int index = updatedMembers.FindIndex(ind => ind.Id == currentIndividual.Id);
            if (index >= 0)
            {
                updatedMembers[index] = currentIndividual.Clone();
            }
        }
        return updatedMembers;
    }
}

public enum Gender
{
    Male,
    Female
}

public class Individual
{
    public int Id { get; }
    public string Name { get; }
    public int Age { get; }
    public Gender Gender { get; }
    public bool IsEditMode { get; }

    public Individual(int id, string name, int age, Gender gender, bool isEditMode = false)
    {
        Id = id;
        Name = name;
        Age = age;
        Gender = gender;
        IsEditMode = isEditMode;
    }

    public bool IsOverEighteen() => Age >= 18;

    public Individual Clone()
    {
        // Create a copy with the same data
        return new Individual(Id, Name, Age, Gender, IsEditMode);
    }
}

public static class IndividualExtensions
{
    public static int CountFemaleOverEighteen(this IEnumerable<Individual> individuals)
        => individuals.Count(ind => ind.IsOverEighteen() && ind.Gender == Gender.Female);

    public static int CountMaleOverEighteen(this IEnumerable<Individual> individuals)
        => individuals.Count(ind => ind.IsOverEighteen() && ind.Gender == Gender.Male);
}
