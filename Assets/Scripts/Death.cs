using UnityEngine;

public class Death : MonoBehaviour
{     
    void Start()
    {
    }

    public virtual void Die()
    {
       Destroy(gameObject);
    }
}