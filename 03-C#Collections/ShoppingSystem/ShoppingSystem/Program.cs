
internal class Program
{
    static public List<string> cartList = new();
    static public Dictionary<string, double> itemPrices = new()
    {
        { "Camera", 1440 },
        { "Laptop", 3000 },
        { "TV" , 5000 }
    };
    static public Stack<string> actions = new();

    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Add item to Cart.");
            Console.WriteLine("2. View car Items.");
            Console.WriteLine("3. Remove Item from Cart.");
            Console.WriteLine("4. Checkout.");
            Console.WriteLine("5. Undo Last action.");
            Console.WriteLine("6. Exit.");
            Console.WriteLine();

            Console.Write("Enter your choise number: ");
            string choise = Console.ReadLine()!;
            int intChoise = Convert.ToInt32(choise);

            switch (intChoise)
            {
                case 1:
                    AddItem();
                    break;
                case 2:
                    ViewCart();
                    break;
                case 3:
                    RemoveItem();
                    break;
                case 4:
                    Checkout();
                    break;
                case 5:
                    UndoAction();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Choise.");
                    break;
            }
        }
    }
    private static void AddItem()
    {
        Console.WriteLine("=================================");
        Console.WriteLine("Availabel items");
        foreach (var item in itemPrices)
        {
            Console.WriteLine($"Item: {item.Key}, Price: {item.Value}");
        }
        Console.WriteLine();
        Console.Write("Enter product name: ");
        string carItem = Console.ReadLine()!;

        if(itemPrices.ContainsKey(carItem))
        {
            cartList.Add(carItem);
            actions.Push($"Item {carItem} added to the cart");
            Console.WriteLine("Item added to the cart");
        }    
        else
        {
            Console.WriteLine("Item is no available, or out of stock.");
        }
    }

    private static void ViewCart()
    {
        if(cartList.Any())
        {
            var itemPriceCollection = GetCartPrices();
            foreach (var item in itemPriceCollection)
            {
                Console.WriteLine($"Item: {item.Item1}, Price: {item.Item2}");
            }
        }
        else
        {
            Console.WriteLine("Cart is empty");
        }
    }

    private static IEnumerable<Tuple<string,double>> GetCartPrices()
    {
        var cartPrices = new List<Tuple<string, double>>();

        foreach (var item in cartList)
        {
            double price = 0;

            bool foundItem = itemPrices.TryGetValue(item, out price);

            if (foundItem)
            {
                cartPrices.Add(new Tuple<string, double>(item, price));
            }
        }
        return cartPrices;
    }

    private static void RemoveItem()
    {
        ViewCart();

        if(cartList.Any())
        {
            Console.WriteLine("Please select item to remove.");
            
            string itemToRemove = Console.ReadLine()!;

            if(cartList.Contains(itemToRemove))
            {
                cartList.Remove(itemToRemove);
                actions.Push($"Item {itemToRemove} removed from the cart");
                Console.WriteLine($"Item {itemToRemove} removed");
            }
            else
            {
                Console.WriteLine("Item does not exist");
            }
        }
    }

    private static void Checkout()
    {
        if(cartList.Any())
        {
            double totalPrices = 0;
            Console.WriteLine("Your cart items are: ");
            var itemsInCart = GetCartPrices();
            foreach (var item in itemsInCart)
            {
                totalPrices += item.Item2;
                Console.WriteLine($"{item.Item1}: {item.Item2}");
            }
            Console.WriteLine($"Total price to pay: {totalPrices}");
            Console.WriteLine("Proceed to payment. thank you for shopping");
            cartList.Clear();

            actions.Push("Checkout");
        }
        else
        {
            Console.WriteLine("Cart is empty");
        }
    }

    private static void UndoAction()
    {
        if(actions.Count > 0)
        {
            string lastAction = actions.Pop();
            Console.WriteLine($"Your last action is: {lastAction}");

            string[] actionArray = lastAction.Split(' ');
            if(actionArray.Contains("added"))
            {
                cartList.Remove(actionArray[1]);
            }
            else if(actionArray.Contains("removed"))
            {
                cartList.Add(actionArray[1]);
            }
            else
            {
                Console.WriteLine("Checkout can not be undo.");
            }
        }
        else
        {
            Console.WriteLine("No Action until now");
        }
    }


}