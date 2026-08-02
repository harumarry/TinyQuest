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
            Heal(10);
        }
    }

    public void TakeDamage(int amount)
    {
        CurrentHp = Mathf.Max(CurrentHp - amount, 0);
    }

    public void Heal(int amount)
    {
        CurrentHp = Mathf.Min(CurrentHp + amount, MaxHp);
    }
}
