using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS_Damage : MonoBehaviour
{
    public Image HpBar;
    public Text HpText;

    private int initHP = 0;
    private int Maxhp = 100;

    private int SK_dam = 10;
    private int ZOM_dam = 1;
    private int MON_dam = 5;

    private string SK_attack_tag = "ATTACK_SK";
    private string ZOM_attack_tag = "ATTACK_ZOM";
    private string MON_attack_tag = "ATTACK_MON";

    void Start()
    {
        initHP = Maxhp;
        HpBar.color = Color.green;
        HPinfo();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(SK_attack_tag))
        {
            SK_Dam_hp();
        }
        if(other.gameObject.CompareTag(ZOM_attack_tag))
        {
            ZOM_Dam_hp();
        }
        if (other.gameObject.CompareTag(MON_attack_tag))
        {
            MON_Dam_hp();
        }
    }

    private void MON_Dam_hp()
    {
        initHP -= MON_dam;
        HpBar.fillAmount = (float)initHP / (float)Maxhp;
        HpText.text = $"HP : <color=#FF0000>{initHP.ToString()}</color>";
    }

    private void ZOM_Dam_hp()
    {
        initHP -= ZOM_dam;
        HpBar.fillAmount = (float)initHP / (float)Maxhp;
        HpText.text = $"HP : <color=#FF0000>{initHP.ToString()}</color>";
    }

    private void SK_Dam_hp()
    {
        initHP -= SK_dam;
        HpBar.fillAmount = (float)initHP / (float)Maxhp;
        HpText.text = $"HP : <color=#FF0000>{initHP.ToString()}</color>";
    }

    private void HPinfo()
    {
        HpText.text = $"HP : <color=#FF0000>{initHP.ToString()}</color>";
    }


}
