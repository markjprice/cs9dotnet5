namespace Packt.Shared
{
  public record ImmutablePerson
  {
    string FirstName {get; init;}
    string LastName {get; init;}

    // public ImmutablePerson(string FirstName, string LastName)
    // {
    //   this.FirstName = FirstName;
    //   this.LastName = LastName;
    // }

    // public void Deconstruct(out string firstName, out string lastName)
    // {
    //   firstName = FirstName;
    //   lastName = LastName;
    // }
  }

  public record ImmutablePerson2(string FirstName, string LastName);
}