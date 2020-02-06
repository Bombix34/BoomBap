using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public Life Life { get; private set; }
    public ActionBase CurrentAction { get; protected set; }

    // Start is called before the first frame update
    void Start()
    {
        this.Life = GetComponent<Life>();
    }

    public abstract void NextAction();
}
