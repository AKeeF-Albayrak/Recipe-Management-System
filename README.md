# Recipe Management System

This repository contains a Recipe Management System developed as part of the BLM307 Software Lab I course project at Kocaeli University's Computer Engineering Department. The project is a desktop application designed for users to save, manage, and search for recipes based on available ingredients. This README provides an overview of the project, installation instructions, features, and technical details.

---

## Project Overview

The Recipe Management System is a C# desktop application that allows users to:
- Store and manage recipes and ingredients.
- Search for recipes based on ingredients in hand.
- Filter recipes by preparation time, cost, and ingredient count.
- Update and delete recipes with ease.
  
The project includes a relational database designed to store recipe and ingredient data, implementing dynamic search, filtering, and ingredient management capabilities.

## Features

1. **Recipe Addition**:
   - Add recipes by entering name, category, preparation time, and instructions.
   - Link multiple ingredients to each recipe with specified quantities.
   - Select existing ingredients or add new ones as needed.

2. **Recipe Suggestion**:
   - Suggest recipes based on available ingredients, highlighting those missing necessary ingredients.
   - Show total cost for recipes with missing ingredients.
   
3. **Dynamic Search**:
   - Search recipes by name or ingredients.
   - Display search results with percentage match based on ingredient availability.

4. **Filtering and Sorting**:
   - Filter recipes by preparation time, cost, ingredient count, and category.
   - Sort recipes by preparation time or cost in ascending or descending order.

5. **Recipe and Ingredient Management**:
   - Update and delete recipes and ingredients with automatic database updates.
   - Prevent duplicate recipe entries through a duplicate check mechanism.

## Technical Details

- **Programming Language**: C# (.NET)
- **Database**: MSSQL for relational data storage
- **GUI Framework**: Windows Forms with MetroSet UI for a modern interface
- **Architecture**: N-layered architecture including data, service, and repository layers

### Database Design

The database consists of three primary tables:
- **Recipes**: Stores recipe details like ID, name, category, preparation time, and instructions.
- **Ingredients**: Stores ingredient details like ID, name, quantity, unit, and price.
- **Recipe-Ingredient Relation**: A many-to-many relationship between recipes and ingredients, linking them with specified quantities.

![Database ER Diagram](https://github.com/user-attachments/assets/7a8cd761-51ee-4700-b07d-4bf335a73fe7)

---

## Installation and Setup

1. **Clone the Repository**
   ```bash
   git clone https://github.com/yourusername/recipe-management-system.git
   cd recipe-management-system
   
2. **Database Setup** (Not Available for now.)
- Ensure you have an MSSQL server installed.
- Create a database named `RecipeManagementDB`.
- Run the SQL scripts located in the `db` folder to initialize tables and relationships.

3. **Run the Application**
- Open the solution in Visual Studio.
- Restore NuGet packages if required.
- Configure database connection settings in the `app.config` file.
- Build and run the application.

---

## Screenshots

### Recipe Form
![Recipe Form](https://github.com/user-attachments/assets/381ea42d-5c3d-4e99-9a2a-e283f580e516)

### Ingredient Form
![Ingredient Form](https://github.com/user-attachments/assets/52304a88-da9f-410d-a437-586dbdb87e11)

### Recipe Management with Filter
![Recipe Management with Filter](https://github.com/user-attachments/assets/e4bd52ef-3ae0-4651-8f58-956dcd0247da)

---

## Development Process

This project adheres to object-oriented programming principles with a focus on modular and reusable code. The development process involved database normalization (1NF, 2NF, 3NF) and UI/UX design for a user-friendly experience.

### Core Modules

- **Recipe Addition Module**: Facilitates adding new recipes with associated ingredients.
- **Search and Filter Module**: Enables dynamic search by recipe name or ingredients, and filtering options.
- **Suggestion Module**: Recommends recipes based on available ingredients and highlights missing ingredients.
  
### UML Diagram

![UML Diagram](https://github.com/user-attachments/assets/c0e3e279-fb20-433b-a9f5-700a4e827d03)

---

## Features that may be added in the future

1. **Enhanced Recommendation Algorithm**: Improve recipe suggestions based on ingredient availability.
2. **User Authentication**: Implement user accounts and secure data access.
3. **API Integration**: Expose REST APIs for remote data access and third-party integrations.

## License

This project is licensed under the MIT License.

---

## References

1. [Smooth and Stylish Sidebar in Windows Form](https://www.youtube.com/watch?v=Ns0pBlbBZmE)
2. [Autocomplete Search in C#](https://www.youtube.com/watch?v=rb6HDX5eAPQ)
3. [Dependency Injection in C#](https://www.youtube.com/watch?v=Bhj2XdcoT2Q)

---

For questions or contributions, please feel free to open an issue or contact us.

## Contributors

### Mert Metin
<a href="https://www.linkedin.com/in/mertmetinn/" target="_blank">
<img src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white" alt="LinkedIn Profile - Mert Metin"/>
</a>

**📫 Contact**: mertmetin39@gmail.com

---

### Mehmet Akif Albayrak
<a href="https://www.linkedin.com/in/akif-albayrak-0b4616278/" target="_blank">
<img src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white" alt="LinkedIn Profile - Mehmet Akif Albayrak"/>
</a>

**📫 Contact**: akifalbayrakoffical@gmail.com
