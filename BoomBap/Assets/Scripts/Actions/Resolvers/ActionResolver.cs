public class ActionResolver
{
    public static readonly ActionResolver Default = new ActionResolver();
    public int Damage { get; set; } = 0;
    public bool CancelPattern { get; set; } = false;

}
