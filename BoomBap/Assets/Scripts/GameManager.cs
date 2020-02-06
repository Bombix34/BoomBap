using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Entity PlayerEntity;
    public Entity BossEntity;

    void Start()
    {
        
    }

    void Update()
    {
        if(PlayerEntity.Life.LifePoint == 0 || BossEntity.Life.LifePoint == 0)
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }
}
