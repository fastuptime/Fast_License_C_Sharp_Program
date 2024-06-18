# Fast License C# Program 📜

![image](https://github.com/fastuptime/Fast_License_C_Sharp_Program/assets/63351166/b1f0fce6-7dc7-42bf-b2d7-4c49be70ba23)
![image](https://github.com/fastuptime/Fast_License_C_Sharp_Program/assets/63351166/62b223ca-8d3b-4a62-84d1-6865b800bf8a)
![image](https://github.com/fastuptime/Fast_License_C_Sharp_Program/assets/63351166/583c7966-0bc3-43a6-bf23-6b54ea36d1a3)
![image](https://github.com/fastuptime/Fast_License_C_Sharp_Program/assets/63351166/cd3f7bbc-1b9c-4493-8996-06870ce14522)


## Overview 🌟

Welcome to the **Fast License C# Program** repository! This program is designed to handle license validation and system information retrieval for the Fast License system. It allows users to enter a license key and checks its validity by communicating with the Fast License API. The program gathers comprehensive system information and displays it in a user-friendly interface.

💻 [Administration Panel Section](https://github.com/fastuptime/Fast_License_C_Sharp_PANEL) 💻


## Features 🚀

- **License Validation**: Check the validity of a license key.
- **IP Validation**: The program only works on the specified IP address.
- **System Information Retrieval**: Gather detailed information about the operating system, processor, memory, disk drives, and network adapters.
- **User-Friendly Interface**: Simple and intuitive form-based interface for easy interaction.

## Installation and Setup 🛠️

1. **Clone the Repository**:
   ```sh
   git clone https://github.com/fastuptime/Fast_License_C_Sharp_Program.git
   cd Fast_License_C_Sharp_Program
   ```

2. **Install Dependencies**:
   - Ensure you have the necessary .NET environment set up.
   - Install required NuGet packages:
     ```sh
     dotnet add package System.Management
     ```

3. **Update Configuration**:
   - Update the `scriptID` and `domain` variables in `Form1.cs` to match your script ID and API domain.

4. **Build and Run**:
   - Open the solution in Visual Studio or use the .NET CLI:
     ```sh
     dotnet build
     dotnet run
     ```

## Usage 💻

1. **Launch the Program**:
   - Start the application. You will see the main form interface.
   
2. **Enter License Key**:
   - Input your license key into the provided textbox.

3. **Check License**:
   - Click the "Check License" button to validate the key.
   - The program will display the result in a message box.

4. **View System Information**:
   - The program also retrieves and displays detailed system information.

## Contributing 🤝

Contributions are welcome! Feel free to open issues or submit pull requests.

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Open a pull request
