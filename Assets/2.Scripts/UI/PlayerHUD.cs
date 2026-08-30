using UnityEngine;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] PlayerHealth playerHealth;

    [SerializeField] TMP_Text hpText;
    [SerializeField] TMP_Text attackText;
    [SerializeField] TMP_Text defenseText;

    void Update()
    {
        hpText.text = ("HP " + playerHealth.CurrentHp + "/" + playerHealth.MaxHp);
        attackText.text = ("공격력 " + playerStats.FinalAttack);
        defenseText.text = ("방어력 " + playerStats.FinalDefense);
    }
}
