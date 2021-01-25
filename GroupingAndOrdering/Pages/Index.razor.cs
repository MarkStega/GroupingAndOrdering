using GroupingAndOrdering.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupingAndOrdering.Pages
{
    public partial class Index
    {
        private class Person
        {
            public Guid UniqueIdentifier { get; set; }
            public string Salutation { get; set; }
            public string GivenName { get; set; }
            public string FamilyName { get; set; }

            public override string ToString()
            {
                return $"{Salutation} {GivenName} *{FamilyName}*";
            }
        }

        private Person[] People =
        {
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Prof", GivenName = "Marie", FamilyName = "Curie" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Prof", GivenName = "Albert", FamilyName = "Einstein" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Prof", GivenName = "Andrew", FamilyName = "Huxley" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Mr", GivenName = "Bob", FamilyName = "Dylan" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Mr", GivenName = "Barack", FamilyName = "Obama" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Ms", GivenName = "Nadine", FamilyName = "Gordimer" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Mr", GivenName = "Muhammad", FamilyName = "Yunus" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "RtHon", GivenName = "Lord", FamilyName = "Rayleigh" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Ms", GivenName = "Grazia", FamilyName = "Deledda" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Mr", GivenName = "Jean-Paul", FamilyName = "Sartre" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Prof", GivenName = "Esther", FamilyName = "Duflo" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Prof", GivenName = "Yoshinori", FamilyName = "Ohsumi" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Prof", GivenName = "Robert", FamilyName = "Merton" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Prof", GivenName = "Barbara", FamilyName = "McClintock" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Mr", GivenName = "Boris", FamilyName = "Pasternak" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Mr", GivenName = "Willy", FamilyName = "Brandt" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Mr", GivenName = "Isaac", FamilyName = "Bashevis Singer" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Ms", GivenName = "Olga", FamilyName = "Tokarczuk" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Mr", GivenName = "Günter", FamilyName = "Grass" },
            new Person() { UniqueIdentifier=Guid.NewGuid(), Salutation = "Mr", GivenName = "John", FamilyName = "Hume" },
        };

        private readonly string[] Salutations = { "Dr", "Mr", "Ms", "Prof", "Lord", "Mrs" };

        private bool GroupData { get; set; }
        private bool GroupDescending { get; set; }
        private bool ItemsDescending { get; set; }
        private bool ShowEmptyGroups { get; set; }


        private IOrderedEnumerable<Person> OrderPeople(IEnumerable<Person> people, Direction direction) => direction == Direction.Ascending ? people.OrderBy(x => x.FamilyName) : people.OrderByDescending(x => x.FamilyName);

        private IEnumerable<IGrouping<string, Person>> GroupMethod(IEnumerable<Person> people) => people.GroupBy(x => x.Salutation);

        private IOrderedEnumerable<string> OrderSalutations(IEnumerable<string> salutations, Direction direction) => direction == Direction.Ascending ? salutations.OrderBy(x => x) : salutations.OrderByDescending(x => x);

    }
}
