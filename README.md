# Product Viewer

This is a .Net Core Web Solution using React as front end.

The application reads the content from two product files.

  1. Product File
     The file location is ~/Files/IRIProducts.txt. It then parses the content to products.
   
  2. RetailerProduct File
     The file location is ~/Files/RetailerProducts.txt. It then parses the content to RetailerProduct.
     
For each product from the Product File, it will display a distinct list of code types with their latest codes.     
   
   
# Technologies   
- .Net Core 2.2
- NUnit and Moq
- React js

# Usage
- Clone the repo.
- Open the solution in Visual Studio 2017 or higher.
- Run Solution.
- The data will be read from the default files in the solution.
- Change the content in the file locations and press reload to see new results.
