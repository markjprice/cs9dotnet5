# Errata & Improvements
If you find any mistakes in the fifth edition, C# 9 and .NET 5, or if you have suggestions for improvements, then please raise an issue in this repository or email me at markjprice (at) gmail.com.
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
