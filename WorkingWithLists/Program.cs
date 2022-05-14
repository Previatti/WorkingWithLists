using WorkingWithLists.Model;


Console.WriteLine("========= Working With Lists =========");
Console.WriteLine();
Console.WriteLine();

List<Person> FamilyOne = new();
FamilyOne.Add(new Person(1, "Georgia"));
FamilyOne.Add(new Person(2, "Ros"));
FamilyOne.Add(new Person(3, "Phillis"));
FamilyOne.Add(new Person(4, "Duana"));

List<Person> FamilyTwo = new();
FamilyTwo.Add(new Person(5, "Glyn"));
FamilyTwo.Add(new Person(6, "Tomos "));
FamilyTwo.Add(new Person(7, "Kerry"));
FamilyTwo.Add(new Person(1, "Georgia"));
FamilyTwo.Add(new Person(3, "Phillis"));
FamilyTwo.Add(new Person(4, "Duana"));

List<Person> FamilyUnion = new();
List<Person> InBothFamilies = new();
List<Person> notInFamilyTwo = new();
List<Person> notInFamilyOne = new();
List<Person> unionOfTheExcluded = new();
List<Person> RemoveDuplicatesPeople = new();

FamilyUnion = FamilyOne.Union(FamilyTwo).ToList();

InBothFamilies.AddRange(FamilyOne.IntersectBy(FamilyTwo.Select(x => x.Id), x => x.Id));

notInFamilyOne.AddRange(FamilyTwo.ExceptBy(FamilyOne.Select(x => x.Id), x => x.Id));
notInFamilyTwo.AddRange(FamilyOne.ExceptBy(FamilyTwo.Select(x => x.Id), x => x.Id));

unionOfTheExcluded = notInFamilyTwo.Union(notInFamilyOne).ToList();

RemoveDuplicatesPeople.AddRange(InBothFamilies.DistinctBy(x => x.Id));


Console.WriteLine("Family One -------------------");
printList(FamilyOne);

Console.WriteLine("Family Two -------------------");
printList(FamilyTwo);

Console.WriteLine("Union ------------------------");
printList(FamilyUnion);

Console.WriteLine("Intersect --------------------");
printList(InBothFamilies);

Console.WriteLine("not in one (ExceptBy) --------");
printList(notInFamilyOne);

Console.WriteLine("not in two (ExceptBy) --------");
printList(notInFamilyTwo);

Console.WriteLine("union of the excluded --------");
printList(unionOfTheExcluded);

Console.WriteLine("Not Duplicate ----------------");
printList(RemoveDuplicatesPeople);



Console.WriteLine("All Distinct -----------------");
FamilyUnion = FamilyUnion.DistinctBy(x => x.Id).ToList();
printList(FamilyUnion);



static void printList(List<Person> people)
{
    foreach (var person in people.OrderBy(x => x.Id))
    {
        Console.WriteLine($"{person.Id} - {person.Name}");
    }
    Console.WriteLine();
}