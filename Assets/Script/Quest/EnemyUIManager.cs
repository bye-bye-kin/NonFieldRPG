using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EnemyUIManager : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI nameText;

    public void SetupUI(EnemyManager enemy)
    {
        hpText.text = string.Format("HP:{0}", enemy.hp);
        nameText.text = string.Format("{0}", enemy.name);
    }


    public void UpdateUI(EnemyManager enemy)
    {
        hpText.text = string.Format("HP:{0}", enemy.hp);
    }
}

