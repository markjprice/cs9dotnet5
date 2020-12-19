# Errata & Improvements

If you find any mistakes in the fifth edition, C# 9 and .NET 5, or if you have suggestions for improvements, then please raise an issue in this repository or email me at markjprice (at) gmail.com.

## A message from a reader

Hi! This isn't an errata. 

I know that I've submitted a few potential errata, but I just wanted to say that this is one of the most cleanly written programming books I've read in quite a while. The author clearly cares about the quality of his book and takes time to anticipate what a reader might run into. It is a pleasure working through it. Keep up the great work! 

I hope you share this comment with the author to let him know that his work is greatly enjoyed and appreciated.

## Page 51 - Comparing double and decimal types

In the book, I say that the `double` type has some special static members, including one named `Infinity`. This is wrong. There are two members named `PositiveInfinity` and `NegativeInfinity`.

## Page 51 - Using Visual Studio Code workspaces

The book says, "Visual Studio has a feature called workspaces that enables this." It should have said, "Visual Studio **Code** has a feature called workspaces that enables this."

## Page 53 - Storing dynamic types

In the code example, I show assigning a `string` value to a dynamically-typed variable, as shown in the following code:
```
// storing a string in a dynamic object
dynamic anotherName = "Ahmed";

// this compiles but would throw an exception at run-time
// if you later store a data type that does not have a 
// property named Length
int length = anotherName.Length;
```

The above example code does not throw an exception because at the time we get the `Length` property, the value stored in `anotherName` is a `string` which does have a `Length` property.

The example would have been clearer if I had shown some examples of assigning values with other data types that do and do not have a `Length` property, as shown in the following code:

```
// storing a string in a dynamic object
// string has a Length property
dynamic anotherName = "Ahmed";

// int does not have a Length property
anotherName = 12;

// an array of any type has a Length property
// anotherName = new[] { 3, 5, 7 };

// this compiles but would throw an exception at run-time
// if you had stored a value with a data type that does not 
// have a property named Length
int length = anotherName.Length;
```

The above example code does throw an exception because at the time we get the `Length` property, the value stored in `anotherName` is an `int` which does not have a `Length` property, as shown in the following output:

```
Unhandled exception. Microsoft.CSharp.RuntimeBinder.RuntimeBinderException: 'int' does not contain a definition for 'Length'
   at CallSite.Target(Closure , CallSite , Object )
   at System.Dynamic.UpdateDelegates.UpdateAndExecute1[T0,TRet](CallSite site, T0 arg0)
   at Variables.Program.Main(String[] args) in /Users/markjprice/Code/Chapter02/Variables/Program.cs:line 34
```

If you uncomment the statement that assigns an array of `int` values, then the code works without throwing an exception because all arrays have a `Length` property.

## Page 94 - Rounding numbers

In Step 1, the code uses `ToInt` as a label for the output. It should use `ToInt32` to match the actual method name. The following code:
```
double[] doubles = new[] 
  { 9.49, 9.5, 9.51, 10.49, 10.5, 10.51 };

foreach (double n in doubles)
{
  WriteLine($"ToInt({n}) is {ToInt32(n)}");
}
```
Should be:
```
double[] doubles = new[] 
  { 9.49, 9.5, 9.51, 10.49, 10.5, 10.51 };

foreach (double n in doubles)
{
  WriteLine($"ToInt32({n}) is {ToInt32(n)}");
}
```
The output shown in Step 2 would then look like the following:
```
ToInt32(9.49) is 9
ToInt32(9.5) is 10
ToInt32(9.51) is 10
ToInt32(10.49) is 10
ToInt32(10.5) is 10
ToInt32(10.51) is 11
```

## Page 113 - Writing a function that returns a value
The `switch case` value of `ME` is commented as Maryland. `ME` is the abbreviation for Maine.

## Page 163 - Deconstructing tuples
The code example is about deconstructing tuples into individual parts. It shows that you do not have to return a named tuple because during deconstruction the syntax allows explicit naming of the individual parts, as shown in the following code:

```
public (string, int) GetFruit()
{
  return ("Apples", 5);
}

public (string Name, int Number) GetNamedFruit()
{
  return (Name: "Apples", Number: 5);
}

(string fruitName, int fruitNumber) = bob.GetFruit() // GetNamedFruit would also work but is not necessary

WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");
```

## Page 178 - Init-only properties

In Step 5, the book says to "Comment out the attempt to set the `LastName` property after instantiation." This should have said, "Comment out the attempt to set the `FirstName` property after instantiation."

## Page 180 - Positional records
In Step 1, the code in the book to define a positional record uses the original keywords, `data class`, that were used in early previews of .NET 5, as shown in the following code:
```
// simpler way to define a record that does the equivalent
public data class ImmutableAnimal(string Name, string Species);
```
It should have been updated to use the keyword, `record`, that was used in later previews and the final release of .NET 5, as shown in the following code:
```
// simpler way to define a record that does the equivalent
public record ImmutableAnimal(string Name, string Species);
```
The code in the GitHub repository was already correct. It is only the print book that has this errata.

## Pages 338 to 340 - Encrypting symmetrically with AES

The code in the book uses 2000 iterations for PBKDF2 to generate a key and initialization vector (IV) for the encryption algorithm. I said that this is "double the recommended salt size and iteration count". I first wrote that code and statement in the fall of 2015 for the first edition and I have neglected to keep it updated. More than five years later, 2000 is not enough! I have updated the project in GitHub to use 50,000 iterations, as shown in the following code:

```
// iterations should be high enough to take at least 100ms to 
// generate a Key and IV on the target machine. 50,000 iterations
// takes 131ms on my 3.3 GHz Dual-Core Intel Core i7 MacBook Pro.
private static readonly int iterations = 50_000;
```

To avoid updating the value every edition, what I will say in the sixth edition is that the best iteration count for PBKDF2 is whatever number takes about 100ms on the target machine. Now that anyone can buy a $699 Apple Mac mini with amazing performance, that recommendation could be closer to a million iterations! And that value will only increase as time passes. 

As I said on page 334, "If security is important to you (and it should be!), then hire an experienced security expert for guidance rather than relying on advice found online." Or in a generalist programming book.

## Page 343 - Hashing with the commonly used SHA256
To make it easier to complete Exercise 10.3, I split the `CheckPassword` method into two overloaded methods, as shown in the following code:
```
// check a user's password that is stored
// in the private static dictionary Users
public static bool CheckPassword(string username, string password)
{
  if (!Users.ContainsKey(username))
  {
    return false;
  }

  var user = Users[username];

  return CheckPassword(username, password, 
    user.Salt, user.SaltedHashedPassword);
}

// check a user's password using salt and hashed password
public static bool CheckPassword(string username, string password, 
  string salt, string hashedPassword)
{
  // re-generate the salted and hashed password 
  var saltedhashedPassword = SaltAndHashPassword(
    password, salt);

  return (saltedhashedPassword == hashedPassword);
}
```

## Appendix A - Chapter 3 - Question 10

10. What interface must an object implement to be enumerated over by using the `foreach` statement?

Answer: An object must implement the `IEnumerable` interface.

Although an object does not have to formally implement an interface to be enumerable using `foreach`, the question asks "What interface...", so the answer must be the name of an interface. `IEnumerable` is that interface. In the next edition, I will put quote-marks around "implement" so it is clear that it can either formally implement the `IEnumerable` interface or just have matching members.
