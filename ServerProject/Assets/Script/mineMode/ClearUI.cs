using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearUI : MonoBehaviour
{
    public Text scoreText;
    public RoundData roundData;
    public PlayerContainer playerContainer;
    private CanvasGroup canvasGroup;
    private float countdownTime = 0f;
    public isDeadContainer isDeadContainer;

    bool temp = false;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        scoreText.text = string.Format("  ");
    }

    // Update is called once per frame
    void Update()
    {
        if (roundData.ReturnRound() == 5 && isDeadContainer.ReturnisAllDead() == true && !temp)
        {
            IsClear();
            temp = true;
        }
    }

    void IsClear()
    {
        canvasGroup.alpha = 1;
       countdownTime = roundData.ReturnTime();

        int seconds = Mathf.FloorToInt(countdownTime);
        int milliseconds = Mathf.FloorToInt((countdownTime - seconds) * 100);
        scoreText.text = string.Format("{0}.{1:D2}", seconds, milliseconds);
    }
}
