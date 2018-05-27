public class LostItemReaction : DelayedReaction
{
    private Inventory inventory;
    public Item item;


    protected override void SpecificInit()
    {
        inventory = FindObjectOfType<Inventory>();
    }


    protected override void ImmediateReaction()
    {
        inventory.RemoveItem(item);
    }
}