using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    public void ChooseStage(int stage)
    {
        GameManager.Instance.targetStageLD = stage;
    }
}
