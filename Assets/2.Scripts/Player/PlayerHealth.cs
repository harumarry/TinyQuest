using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHp = 100;
    [SerializeField] int currentHp = 50;

    public int CurrentHp => currentHp;
    public int MaxHp => maxHp;

    public void TakeDamage(int amount)
    {
        currentHp = Mathf.Max(currentHp - amount, 0);
    }

    public bool TryHeal(int amount)
    {
        if (currentHp >= maxHp)
            return false;
        currentHp = Mathf.Min(currentHp + amount, maxHp);
        return true;
    }

    public void SetHp(int hp)
    {
        currentHp = hp;
    }
}
