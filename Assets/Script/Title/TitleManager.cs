using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{

    public GameObject testprefab;

   public void OnToTownButton()
    {
        SoundManager.instance.PlaySE(0);
        Instantiate(testprefab);
    }
}
