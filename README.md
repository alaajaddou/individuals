# Family Member Validation in C#

This is a simple C# console application that validates a family based on specific criteria, such as the number of members, age, and gender composition.

## ✅ Features

- Checks if the number of family members meets the required count.
- Validates the number of females and males over the age of 18.
- Allows updating existing members or adding new ones.
- Provides clear reasons for validation failure or success confirmation.

## 📋 Requirements

- [.NET 6.0 SDK or later](https://dotnet.microsoft.com/en-us/download)

## 🚀 How to Run

1. Clone the repository:

```bash
git clone https://github.com/your-username/your-repo-name.git
cd your-repo-name
```

2. Build and run the application:

 ```bash
 dotnet run
 ```

## 🧠 How It Works

* The `Program` class defines configuration constants and a sample list of family members.
* Validation is performed based on:

  * Total family members (must be exactly 5)
  * At least 1 female and 1 male over the age of 18
* The `Individual` class represents a family member.
* Extension methods on `IEnumerable<Individual>` provide helper functions to count males and females over 18.
* Supports "edit mode" where an existing member is updated rather than added.

## 📄 Sample Output

```bash
Hello World
Required family members: 5
Current family members: 5
Females over 18: 2
Males over 18: 2
Fail Reason: Too many females over 18.
```

## 📁 Project Structure

```
├── Program.cs         # Main logic
├── Individual.cs      # Individual class and related logic
├── README.md          # Project documentation
```

## 📝 License

This project is open-source and available under the [MIT License](LICENSE).
