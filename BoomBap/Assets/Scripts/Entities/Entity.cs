using UnityEngine;

public class Entity : MonoBehaviour
{
    public Life Life { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        this.Life = GetComponent<Life>();
    }
}
