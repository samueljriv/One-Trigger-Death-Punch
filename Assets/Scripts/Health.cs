using UnityEngine;

public class Health : MonoBehaviour
{
    private Death Death;

    public float CurrentHealth = 100;
    public float MaxHealth = 100;

    void Start()
    {
        Death = GetComponent<Death>();
    }

    public virtual bool IsAlive()
    {
        return CurrentHealth > 0.0f;
    }

    public virtual void InflictDamage(float Damage)
    {
        CurrentHealth -= Damage;
        if (CurrentHealth < 0.0f)
        {
            CurrentHealth = 0.0f;
        }
        if (CurrentHealth == 0.0f)
        {
            if (Death != null)
            {
                Death.Die();
            }
        }
    }

    public virtual void InflictHeal(float Heal)
    {
        CurrentHealth += Heal;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }


}
