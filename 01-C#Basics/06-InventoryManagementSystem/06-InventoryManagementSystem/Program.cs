// Add Product
// Update Product
// View Product (ID, Name, quantity, Price)
// Exit

const int numberOfProducts = 50;
string[,] Inventory = new string[numberOfProducts,3];
int productCount = 0;

Console.WriteLine("Welcome to the inventory system");

while(true)
{
    Console.WriteLine("==================================");
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. Update Product");
    Console.WriteLine("3. View Products");
    Console.WriteLine("4. Exit");

    string userInput =  Console.ReadLine()!;
    int choice = Convert.ToInt32(userInput);

    try
    {
        switch(choice)
        {
            case 1: AddProduct();
                    break;

            case 2: UpdateProduct();
                    break;

            case 3: ViewProducts();
                    break;
    
            case 4: Environment.Exit(0);
                    break;
            default: break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void AddProduct()
{
    Console.Write("Enter product name: ");
    string name = Console.ReadLine()!;
    Console.Write("Enter product quantity: ");
    string quantity = Console.ReadLine()!;
    Console.Write("Enter product price: ");
    string price = Console.ReadLine()!;

    Inventory[productCount, 0] = name;
    Inventory[productCount, 1] = quantity;
    Inventory[productCount, 2] = price;

    productCount++;

    Console.WriteLine("Added New Product.");
}
void UpdateProduct()
{
    Console.Write("Enter product name to update: ");
    string searchproduct = Console.ReadLine()!;

    ThrowExceptionProductCount();
    int productId = -1;
    for (int i = 0; i < productCount; i++)
    {
        if (searchproduct == Inventory[i, 0])
        {
            productId = i;
            break;
        }
    }

    if(productId == -1)
    {
        Console.WriteLine("Product Not Found");
    }
    else
    {
        Console.Write("Enter Product Quantity: ");
        string quantityUpdated = Console.ReadLine()!;
        Console.Write("Enter Product Price: ");
        string priceUpdated = Console.ReadLine()!;

        Inventory[productId, 1] = quantityUpdated;
        Inventory[productId, 2] = priceUpdated;
    }
}
void ViewProducts()
{
    ThrowExceptionProductCount();

    Console.WriteLine("Products List");
    for (int i = 0; i < productCount; i++)
    {
        Console.WriteLine($"product ID: {i}, product name: {Inventory[i,0]}, product quantity: {Inventory[i, 1]}, product price: {Inventory[i, 2]}");
    }
}

void ThrowExceptionProductCount()
{
    if (productCount == 0)
        throw new Exception("There are no products in the list.");
}