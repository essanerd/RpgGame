namespace Rpg{
    class Barrel : IDamageable
{
    public int Health { get; set; }

    public Barrel(int health)
    {
        Health = health;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
    }
}
}