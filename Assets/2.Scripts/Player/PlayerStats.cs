using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int baseAttack = 5;
    [SerializeField] int baseDefense;

    int bonusAttack;
    int bonusDefense;

    public int FinalAttack => baseAttack + bonusAttack;
    public int FinalDefense => baseDefense + bonusDefense;
}
