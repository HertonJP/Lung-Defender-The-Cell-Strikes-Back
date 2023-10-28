using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaboratoryManager : MonoBehaviour
{
    public GameObject CellPanel;
    public GameObject TBCPanel;


    //Cells
    [SerializeField] public GameObject[] CellsPanels;
    [SerializeField] public GameObject[] TBCsPanels;
    
    void Start()
    {
        CellPanel.SetActive(false);
        TBCPanel.SetActive(false);
    }

    public void menuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void onClickCellButton()
    {
        if (CellPanel.activeSelf == true)
        {
            CellPanel.SetActive(false);
        }
        else
        {
            CellPanel.SetActive(true);
            TBCPanel.SetActive(false);
            
        }
        for (int i = 0; i < CellsPanels.Length; i++)
        {
            CellsPanels[i].SetActive(false);
        }
        for (int i = 0; i < TBCsPanels.Length; i++)
        {
            TBCsPanels[i].SetActive(false);
        }
    }
    public void onClickTBCButton()
    {
        if (TBCPanel.activeSelf == true)
        {
            TBCPanel.SetActive(false);
        }
        else
        {
            TBCPanel.SetActive(true);
            CellPanel.SetActive(false);
        }
        for (int i = 0; i < CellsPanels.Length; i++)
        {
            CellsPanels[i].SetActive(false);
        }
        for (int i = 0; i < TBCsPanels.Length; i++)
        {
            TBCsPanels[i].SetActive(false);
        }
    }



    #region CellsButtons
    public void WBCbutton()
    {
        for (int i = 0; i < CellsPanels.Length; i++)
        {
            CellsPanels[i].SetActive(false);
        }
        if (CellsPanels[0].activeSelf == true)
        {
            CellsPanels[0].SetActive(false);
        }
        else
        {
            
            CellsPanels[0].SetActive(true);
            
        }
    }

    public void KillerTbutton()
    {
        for (int i = 0; i < CellsPanels.Length; i++)
        {
            CellsPanels[i].SetActive(false);
        }
        if (CellsPanels[1].activeSelf == true)
        {
            CellsPanels[1].SetActive(false);
        }
        else
        {
            CellsPanels[1].SetActive(true);
            
        }
    }
    public void MacrophageButton()
    {
        for (int i = 0; i < CellsPanels.Length; i++)
        {
            CellsPanels[i].SetActive(false);
        }
        if (CellsPanels[2].activeSelf == true)
        {
            CellsPanels[2].SetActive(false);
        }
        else
        {
            CellsPanels[2].SetActive(true);
            
        }
    }
    public void DendriticButton()
    {
        for (int i = 0; i < CellsPanels.Length; i++)
        {
            CellsPanels[i].SetActive(false);
        }
        if (CellsPanels[3].activeSelf == true)
        {
            CellsPanels[3].SetActive(false);
        }
        else
        {
            CellsPanels[3].SetActive(true);
            
        }
    }
    public void NKButton()
    {
        for (int i = 0; i < CellsPanels.Length; i++)
        {
            CellsPanels[i].SetActive(false);
        }
        if (CellsPanels[4].activeSelf == true)
        {
            CellsPanels[4].SetActive(false);
        }
        else
        {
            CellsPanels[4].SetActive(true);
            
        }
    }
    public void BCellButton()
    {
        for (int i = 0; i < CellsPanels.Length; i++)
        {
            CellsPanels[i].SetActive(false);
        }
        if (CellsPanels[5].activeSelf == true)
        {
            CellsPanels[5].SetActive(false);
        }
        else
        {
            CellsPanels[5].SetActive(true);
            
        }
    }
    public void MemoryCellButton()
    {
        for (int i = 0; i < CellsPanels.Length; i++)
        {
            CellsPanels[i].SetActive(false);
        }
        if (CellsPanels[6].activeSelf == true)
        {
            CellsPanels[6].SetActive(false);
        }
        else
        {
            CellsPanels[6].SetActive(true);
            
        }
    }
    #endregion


    #region TBCsButtons
    public void MycoMeleeButton()
    {
        for (int i = 0; i < TBCsPanels.Length; i++)
        {
            TBCsPanels[i].SetActive(false);
        }
        if (TBCsPanels[0].activeSelf == true)
        {
            TBCsPanels[0].SetActive(false);
        }
        else
        {

            TBCsPanels[0].SetActive(true);

        }
    }

    public void LatentButton()
    {
        for (int i = 0; i < TBCsPanels.Length; i++)
        {
            TBCsPanels[i].SetActive(false);
        }
        if (TBCsPanels[1].activeSelf == true)
        {
            TBCsPanels[1].SetActive(false);
        }
        else
        {

            TBCsPanels[1].SetActive(true);

        }
    }

    public void MycoRangeButton()
    {
        for (int i = 0; i < TBCsPanels.Length; i++)
        {
            TBCsPanels[i].SetActive(false);
        }
        if (TBCsPanels[2].activeSelf == true)
        {
            TBCsPanels[2].SetActive(false);
        }
        else
        {

            TBCsPanels[2].SetActive(true);

        }
    }

    public void MDRButton()
    {
        for (int i = 0; i < TBCsPanels.Length; i++)
        {
            TBCsPanels[i].SetActive(false);
        }
        if (TBCsPanels[3].activeSelf == true)
        {
            TBCsPanels[3].SetActive(false);
        }
        else
        {

            TBCsPanels[3].SetActive(true);

        }
    }

    public void XDRButton()
    {
        for (int i = 0; i < TBCsPanels.Length; i++)
        {
            TBCsPanels[i].SetActive(false);
        }
        if (TBCsPanels[4].activeSelf == true)
        {
            TBCsPanels[4].SetActive(false);
        }
        else
        {

            TBCsPanels[4].SetActive(true);

        }
    }
    #endregion
}
