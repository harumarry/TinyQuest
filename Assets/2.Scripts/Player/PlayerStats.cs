using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int baseAttack = 5;
    [SerializeField] int baseDefense;

    int bonusAttack;
    int bonusDefense;

    public int FinalAttack => baseAttack + bonusAttack;
    public int FinalDefense => baseDefense + bonusDefense;

    public void AddBonusAttack(int amount)
    {
        bonusAttack += amount;
    }

    public void AddBonusDefense(int amount)
    {
        bonusDefense += amount;
    }

    public void RemoveBonusAttack(int amount)
    {
        bonusAttack -= amount;
    }

    public void RemoveBonusDefense(int amount)
    {
        bonusDefense -= amount;
    }
}
