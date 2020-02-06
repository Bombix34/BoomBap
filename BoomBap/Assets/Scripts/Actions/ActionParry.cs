public class ActionParry: ActionBase, IActionLevel
{
    public int Level { get; private set; }
	public ActionParry(int level)
    {
        this.Level = level;
    }
}
