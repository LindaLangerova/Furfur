public class PickedUpItemReaction : DelayedReaction
{
    public Item item;
    private TextManager textManager;


    private Inventory inventory;


    protected override void SpecificInit()
    {
        inventory = FindObjectOfType<Inventory>();
        textManager = FindObjectOfType<TextManager>();
    }


    protected override void ImmediateReaction()
    {
        inventory.AddItem(item);
    }
}
