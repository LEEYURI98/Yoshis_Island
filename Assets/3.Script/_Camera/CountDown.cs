using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    private float setTime = 5.0f;//Ä«¿îÆ®
    [SerializeField] Text countdown_Text;

    private void OnEnable()
    {
        setTime = 5.0f;
        countdown_Text.text = setTime.ToString();
    }

    private void Update()
    {
        if (setTime > 0)
        {
            setTime -= Time.deltaTime;
        }
        else if (setTime <= 0)
        {
            Time.timeScale = 0.0f;
            SceneManager.LoadScene("GameOver");
        }

        countdown_Text.text = Mathf.Round(setTime).ToString();
    }

}
