using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField]
    private int defaultLifePoint;

    private int DefaultLifePoint { get => defaultLifePoint; set => defaultLifePoint = value; }
    private int lifePoint;
    public int LifePoint { 
        get => lifePoint;
        private set
        {
            if (value < 0)
            {
                value = 0;
            };
            if (value > defaultLifePoint)
            {
                value = defaultLifePoint;
            };

            lifePoint = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.LifePoint = this.DefaultLifePoint;
    }

    public void DoDamage(int damage)
    {
        if (damage < 0)
        {
            throw new System.ArgumentException("Cannot be lower than 0", nameof(damage));
        }
        this.LifePoint -= damage;
    }

    public void DoHeal(int heal)
    {
        if (heal < 0)
        {
            throw new System.ArgumentException("Cannot be lower than 0", nameof(heal));
        }
        this.LifePoint += heal;
    }


}
