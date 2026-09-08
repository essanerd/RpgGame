namespace Rpg
{
    public class Door : IInteractable
    {
        public void Interact()
        {
            Console.WriteLine("You opened the door!");
        }
    }
}