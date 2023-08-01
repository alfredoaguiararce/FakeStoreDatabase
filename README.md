# FakeStoreDatabase Project

The FakeStoreDatabase project provides a static database of fake data for use in other projects. This fake database includes simulated information for users, products, and categories, which can be useful for testing and development without the need to access a real database.

## **Installation via NuGet**

To install the FakeStoreDatabase package via NuGet, you can use the Package Manager Console in Visual Studio or the .NET CLI. Here's how to do it:

### **Package Manager Console**

```bash
Install-Package FakeStore.Database

```

### **.NET CLI**

```bash
dotnet add package FakeStore.Database
```

## **Configuration**

To use the fake database in your project, follow these steps:

1. Installation: Add a reference to the FakeStoreDatabase project in your solution or project.
2. Dependency Injection: In your startup configuration file (Startup.cs or similar), add the following code to configure and use the fake database:

```csharp
csharpCopy code
builder.Services.UseFakeStoreDatabase(new FakeDatabaseConfigurator()
{
    UsersConfiguration = new UsersConfigurator()
    {
        MaxDefaultUsers = 10,
        NullProbability = 0.1f
    },
    ProductsConfiguration = new ProductsConfigurator()
    {
        MaxProducts = 100,
        MaxPrice = 1000,
        MinPrice = 100,
        NullProbability = 0.3f
    },
    CategoriesConfiguration = new CategoriesConfigurator()
    {
        MaxCategories = 10,
        NullProbability = 0.2f
    }
});

```

1. Public Methods: To access the fake database, use the following methods provided by the **`IFakeStoreDatabase`** interface:

### **`List<FakeUser> GetUsers()`**

This method returns a list of fake users, generating them if they do not already exist. If the users have already been generated previously, the function will return the existing list. Each fake user is represented by a **`FakeUser`** object.

### **`List<FakeProduct> GetProducts()`**

This method returns a list of fake products, retrieving them from the database generator if they have not been retrieved before. If the products have already been generated previously, the function will return the existing list. Each fake product is represented by a **`FakeProduct`** object.

### **`List<FakeCategory> GetCategories()`**

This method returns a list of fake categories, generating them if they do not already exist. If the categories have already been generated previously, the function will return the existing list. Each fake category is represented by a **`FakeCategory`** object.
## **Update methods**
### **`void UpdateUsers(List<FakeUser> Users)`**

The function updates the list of fake users with a new list of users.
### **`void UpdateProducts(List<FakeProduct> Products)`**

The function updates the list of fake products with a new list of fake products.
### **`void UpdateCategories(List<FakeCategory> Categories)`**

The function updates the list of fake categories with the provided list of 

Example: 


```csharp
List<FakeUser> users = _FakeStoredDb.GetUsers();
FakeUser? userToUpdate = users.FirstOrDefault(u => u.UserId == userId);

if (userToUpdate != null)
{
    userToUpdate.UserName = "string new";
    userToUpdate.Email = "new email";
    // Update other properties as needed.
}

// Save changes
_FakeStoredDb.UpdateUsers(users);
```

## **Working with Relationships between Collections**

The FakeStoreDatabase project is currently under development to provide more advanced functionality for handling relationships between different collections, such as users, products, and categories. The goal is to improve the way fake data can interact with each other to simulate more realistic scenarios.

While this functionality is still in development, you can use LINQ (Language Integrated Query) to work with relationships between existing collections. LINQ is a powerful tool in C# that allows you to perform queries and operations on collections in an elegant and expressive way.

Below is an example of how to perform a join based on the **`CategoryId`** between the categories and products collections:

```csharp
List<FakeCategory> categories = _FakeStoredDb.GetCategories();
List<FakeProduct> products = _FakeStoredDb.GetProducts();

// Perform the join based on CategoryId
var joinedData = categories
    .Join(products,
        category => category.CategoryId,
        product => product.CategoryId,
        (category, product) => new
        {
            Category = category,
            Product = product
        })
    .ToList();

```

In this example, we are joining the **`categories`** and **`products`** collections using the **`Join`** clause of LINQ, where we specify how to compare the elements of both collections based on the **`CategoryId`**. We then project the results into a new collection that contains both the category and the related product.

### **Example: Getting Product Names for a Specific CategoryId**

Let's say we want to get the product names for a specific **`CategoryId`** (e.g., **`categoryIdToFilter = 1`**):

```csharp
int categoryIdToFilter = 1;
var productsWithCategoryId = joinedData
    .Where(data => data.Category.CategoryId == categoryIdToFilter)
    .Select(data => data.Product.Name)
    .ToList();

```

In this example, we use the **`Where`** clause to filter the elements in **`joinedData`** where the **`CategoryId`** of the category matches the **`categoryIdToFilter`**. We then use **`Select`** to project only the names of the products related to the filtered category.

**Note**: As the functionality for handling relationships is developed in the project, specific methods and utilities are expected to be added to work with relationships more easily and efficiently.

## **Generate fake image urls**

These methods allow you to generate fake image URLs using the 'https://picsum.photos/' service. The GetImagesUrl method generates multiple fake image URLs in a list, while the GetFakeImageUrl method generates a single fake image URL. The image URLs are based on the specified _ImageWidth_ and _ImageHeight_.

**Interface: IFakeImageUrl**

This interface defines methods for generating fake image URLs.

**GetImagesUrl Method**

```csharp
List<string> GetImagesUrl(int NumberOfImages, int ImageWidth, int ImageHeight);
```

Generates a list of fake image URLs.

Parameters:

_NumberOfImages (int)_: The number of fake image URLs to generate.
_ImageWidth (int)_: The width of the images in pixels.
_ImageHeight (int)_: The height of the images in pixels.
Returns:

_List<string>_: A list of fake image URLs.

**GetFakeImageUrl Method**

```csharp
string GetFakeImageUrl(int ImageWidth, int ImageHeight);
```

Generates a single fake image URL.

Parameters:

_ImageWidth (int)_: The width of the image in pixels.
_ImageHeight (int)_: The height of the image in pixels.
Returns:

_string_: A fake image URL.


## **License**

This project is distributed under the MIT license. See the LICENSE file for more details.

If you find it useful, consider supporting the project by making a donation via PayPal:

**[Support in Paypal ♥️](https://www.paypal.com/donate/?hosted_button_id=Z6KKYZKYY25CW)**

Enjoy using FakeStoreDatabase in your project! If you have any questions or need assistance, do not hesitate to contact the development team.