using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Townmanager : MonoBehaviour
{
    private void Start()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "arrived at Town" });
    }
    public void OnToQuestButton()
    {
        SoundManager.instance.PlaySE(0);
    }
}
