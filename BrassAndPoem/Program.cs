using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

List<ProductType> productTypes = new List<ProductType>()
        {
            new ProductType { Id = 1, Title = "Brass" },
            new ProductType { Id = 2, Title = "Poem" },
        };

List<Product> products = new List<Product>()
        {
            new Product { Name = "Saxaphone", Price = 999.99m, ProductTypeId = 1 },
            new Product { Name = "Poetry 101", Price = 19.99m, ProductTypeId = 2 },
            new Product { Name = "Tuba", Price = 799.99m, ProductTypeId = 1 },
            new Product { Name = "The Giving Tree", Price = 49.99m, ProductTypeId = 2 },
            new Product { Name = "Some other brass instrument", Price = 14.99m, ProductTypeId = 2 }
        };

void MainProgram()
{
    Console.WriteLine("Welcome to the Store");

    int choice;
    do
    {
        DisplayMenu();
        String input = Console.ReadLine();

        if (int.TryParse(input, out choice))
        {
            switch (choice)
            {
                case 1:
                    DisplayAllProducts(products, productTypes);
                    break;
                case 2:
                    DeleteProduct(products, productTypes);
                    break;
                case 3:
                    AddProduct(products, productTypes);
                    break;
                case 4:
                    UpdateProduct(products, productTypes);
                    break;
                case 5:
                    Console.WriteLine("Exit App...");
                    return;
                default:
                    Console.WriteLine("Wrong try again");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Wrong try again");
        };

    }
    while (choice != 5);
}

void DisplayMenu()
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Display all products");
    Console.WriteLine("2. Delete a product");
    Console.WriteLine("3. Add a new product");
    Console.WriteLine("4. Update product properties");
    Console.WriteLine("5. Exit");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];
        ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);
        Console.WriteLine($"[{i + 1}] {product.Name} - ${product.Price} ({productType?.Title})");
    }
}


void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);

  Console.WriteLine("Pick a product to delete");

  string input = Console.ReadLine();
  if (int.TryParse(input, out int index))
  {
     if (index >= 1 && index <= products.Count)
    {
      products.RemoveAt(index - 1);
      Console.WriteLine("Product removed");
    }
    else
    {
      Console.WriteLine("Wrong pick again");
    }
  }
  else
  {
      Console.WriteLine("Wrong pick again");
  }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Please enter name of the product");
    string NewName = Console.ReadLine();

    Console.WriteLine("Please enter the Price of your Product");
    string TempPrice = Console.ReadLine();
    if (decimal.TryParse(TempPrice, out decimal NewPrice))
    {
        Console.WriteLine("Select the type of product it is 1 for Brass and 2 for Poem");
        string TempType = Console.ReadLine();
        if(int.TryParse(TempType, out int NewType))
        {
            switch (NewType)
            {
                case 1:
                case 2:
                    var product = new Product { Name = NewName, Price = NewPrice, ProductTypeId = NewType };
                    products.Add(product);
                    Console.WriteLine("Product added successfully.");
                    break;
                default: Console.WriteLine("Wrong selction must be 1 or 2 try again");
                    break;                 
            }
        }
        else
        {
            Console.WriteLine("Wrong selction must be 1 or 2 try again");
        }
    }
    else
    {
        Console.WriteLine("Wrong selction must be 1 or 2 try again");
    }

}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);

    Console.WriteLine("Enter the number of the product you want to update: ");
    string input = Console.ReadLine();
    if (int.TryParse(input, out int index))
    {
        if (index >= 1 && index <= products.Count)
        {
            var product = products[index - 1];
            Console.WriteLine("Enter the New name of the Product (press enter to leave the same:");
            string Name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(Name))
            {
                product.Name = Name;
            }
            else
            {
                Console.WriteLine("Wrong selction must be 1 or 2 try again");
            }

            Console.WriteLine("Please enter the new price of your Product (press enter to leave the same)");
            string PriceInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(PriceInput) && decimal.TryParse(PriceInput, out decimal price))
            {
                product.Price = price;
            }
            else
            {
                Console.WriteLine("Wrong selction must be 1 or 2 try again");
            }

            Console.WriteLine("Select the type of product it is 1 for Brass and 2 for Poem (press enter to leave the same)");
            string TypeInput = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(TypeInput) && int.TryParse(TypeInput, out int type))
            {
                switch (type)
                {
                    case 1:
                    case 2:
                        product.ProductTypeId = type;
                        break;
                    default: Console.WriteLine("Wrong selction must be 1 or 2 try again");
                        break;
                }
                
            }
        }
        else
        {
            Console.WriteLine("Wrong selction must be 1 or 2 try again");
        }
    }
    else
    {
        Console.WriteLine("Wrong selction must be 1 or 2 try again");
    }
}
MainProgram();

// don't move or change this!
public partial class Program { }