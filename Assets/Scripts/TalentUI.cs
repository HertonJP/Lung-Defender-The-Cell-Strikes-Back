using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentUI : MonoBehaviour
{
    public Image abilityImage1;
    public float cooldown1 = 5;
    bool isCooldown1 = false;
    public KeyCode ability1;

    //public Image abilityImage2;
    //public float cooldown2 = 2;
    //bool isCooldown2 = false;
    //public KeyCode ability2;

    public Image abilityImage3;
    public float cooldown3 = 15;
    bool isCooldown3 = false;
    public KeyCode ability3;

    private void Start()
    {
        abilityImage1.fillAmount = 0;
        //abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
    }

    private void Update()
    {
        Ability1();
        //Ability2();
        Ability3();
    }

    void Ability1()
    {
        if(Input.GetKey(ability1) && isCooldown1 == false)
        {
            isCooldown1 = true;
            abilityImage1.fillAmount = 1;
        }

        if (isCooldown1)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if(abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown1 = false;
            }
        }
    }

    //void Ability2()
   // {
       // if (Input.GetKey(ability2) && isCooldown2 == false)
       // {
           // isCooldown2 = true;
            //abilityImage2.fillAmount = 1;
       // }
        //if (isCooldown2)
       // {
           // abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;

           // if (abilityImage2.fillAmount <= 0)
          //  {
           //     abilityImage2.fillAmount = 0;
             //   isCooldown2 = false;
          //  }
       // }
  //  }

    void Ability3()
    {
        if (Input.GetKey(ability3) && isCooldown3 == false)
        {
            isCooldown3 = true;
            abilityImage3.fillAmount = 1;
        }

        if (isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if (abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }
}
