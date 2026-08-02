using UnityEngine;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] PlayerHealth playerhealth;

    [SerializeField] TMP_Text hpText;
    [SerializeField] TMP_Text attackText;
    [SerializeField] TMP_Text defenseText;

    void Update()
    {
        hpText.text = ("HP " + playerhealth.CurrentHp + "/" + playerhealth.MaxHp);
        attackText.text = ("공격력 " + playerStats.FinalAttack);
        defenseText.text = ("방어력 " + playerStats.FinalDefense);
    }
}
