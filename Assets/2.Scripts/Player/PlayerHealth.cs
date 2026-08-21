using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHp = 100;

    public int CurrentHp { get; private set; }
    public int MaxHp => maxHp;

    private void Start()
    {
        CurrentHp = MaxHp;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            TryHeal(10);
        }
    }

    public void TakeDamage(int amount)
    {
        CurrentHp = Mathf.Max(CurrentHp - amount, 0);
    }

    public bool TryHeal(int amount)
    {
        if (CurrentHp >= MaxHp)
            return false;
        CurrentHp = Mathf.Min(CurrentHp + amount, MaxHp);
        return true;
    }
}
