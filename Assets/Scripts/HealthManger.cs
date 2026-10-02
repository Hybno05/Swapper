using UnityEngine;
using UnityEngine.Serialization;

public class HealthManger : MonoBehaviour
{
    public int health = 100;

    public void ReduceHealth(int damage)
    {
        health -= damage;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public bool GetIsDead()
    {
        return health <= 0;
    }
}
