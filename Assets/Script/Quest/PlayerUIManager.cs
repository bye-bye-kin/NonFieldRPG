using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerUIManager : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI atText;

    public void SetupUI(PlayerManager player)
    {
        hpText.text = string.Format("HP:{0}", player.hp);
        atText.text = string.Format("AT:{0}", player.at);
    }

    public void UpdateUI(PlayerManager player)
    {
        hpText.text = string.Format("HP:{0}", player.hp);
    }
}
