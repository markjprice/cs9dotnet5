namespace Packt.Shared
{
  public data class ImmutablePerson // a record
  {
    string FirstName;
    string LastName;

    public ImmutablePerson(string firstName, string lastName)
    {
      FirstName = firstName;
      LastName = lastName;
    }

    public void Deconstruct(out string firstName, out string lastName)
    {
      firstName = FirstName;
      lastName = LastName;
    }
  }

  public data class ImmutablePerson2(string FirstName, string LastName);
}