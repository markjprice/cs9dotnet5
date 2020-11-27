# Errata & Improvements

If you find any mistakes in the fifth edition, C# 9 and .NET 5, or if you have suggestions for improvements, then please raise an issue in this repository or email me at markjprice (at) gmail.com.

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
