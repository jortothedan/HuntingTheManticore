int cityHealth = 15;
int manticoreHealth = 10;
int gameRound = 1;
int cannonDamage;
int cannonRange;

Console.WriteLine("Player 1, how far away from the city do you want to station the Manticore?");
int manticorePosition = Convert.ToInt32(Console.ReadLine());

Console.Clear();

Console.WriteLine("Player 2, it is your turn.");

while (cityHealth > 0 && manticoreHealth > 0) // condition is always true, you don't need a do while loop
{
    Cannon();
    Console.WriteLine("------------------------------------------------------------------------");
    Console.WriteLine($"Status: Round: {gameRound} City: {cityHealth}/15 Manticore: {manticoreHealth}/10");
    Console.WriteLine($"The cannon is expected to deal {cannonDamage} this round.");
    Console.WriteLine("Enter desired cannon range: ");
    cannonRange = Convert.ToInt32(Console.ReadLine());

    ShotPlacement();

    gameRound++;

    if (manticoreHealth > 0) cityHealth--;
}

if (manticoreHealth <= 0)
{
    Console.WriteLine("The Manticore has been destroyed! The city of Consolas is safe!");
}
else
{
    Console.WriteLine("The Manticore has destroyed the city of Consolas! Player 1 wins!");
}


void ShotPlacement() // get a target range from the second player, and resolve it's effect. tell the user if they over shoot, undershoot or hit the manticore. If hit reduce manticore health.
{
    if (cannonRange > manticorePosition)
    {
        Console.WriteLine("That round OVERSHOT the target.");
    }
    else if (cannonRange < manticorePosition)
    {
        Console.WriteLine("That round FELL SHORT the target.");
    }
    else
    {
        Console.WriteLine("That round was a DIRECT HIT!");
        manticoreHealth -= cannonDamage;
    }
}

void Cannon()
{
    if (gameRound % 5 == 0 || gameRound % 3 == 0)
    {
        cannonDamage = 3;
    }
    else if (gameRound % 5 == 0 && gameRound % 3 == 0)
    {
        cannonDamage = 10;
    }
    else
    {
        cannonDamage = 1;
    }
}


Console.ReadKey();