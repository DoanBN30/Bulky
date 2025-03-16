The Bulky project is a comprehensive web application developed using ASP.NET Core, Entity Framework Core, and Razor Pages. It serves as a template for building robust e-commerce platforms, offering features like product management, category handling, and user authentication.

Key Features:

	- Product Management: Allows administrators to add, update, and delete products.
	- Category Management: Facilitates the organization of products into categories.
	- User Authentication: Integrates ASP.NET Identity for secure user login and registration.
	- Responsive Design: Ensures optimal viewing experiences across various devices.
Project Structure:

	- Bulky.DataAccess: Contains the database context and repositories for data operations.
	- Bulky.Models: Defines the data models used throughout the application.
	- Bulky.Utility: Holds utility classes and static details.
	- BulkyWeb: The main web application implementing the UI using Razor Pages.
Getting Started:

	1. Clone the Repository:
		git clone https://github.com/DoanBN30/Bulky.git
	2. Navigate to the Project Directory:
		cd Bulky
	3. Restore Dependencies:
		dotnet restore
	4. Apply Migrations and Update Database:
		dotnet ef database update
	5. Run the Application:
		dotnet run
Prerequisites:
	.NET 6 SDK or later
	SQL Server
Contributing: Contributions are welcome! Please fork the repository and submit a pull request for any enhancements or bug fixes.

License: This project is licensed under the MIT License.

Acknowledgements: Special thanks to the open-source community for continuous support and contributions.

For more details, visit the Bulky GitHub Repository.
