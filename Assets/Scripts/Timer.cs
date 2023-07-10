using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Timer : MonoBehaviour
{
    private int _sec = 0;
    private int _min = 0;

    [SerializeField]
    private Text _timerText;

    [Inject]
    private WinSystem winSystem;

    private void Start()
    {
        StartCoroutine(TimerRoutine());
        winSystem.WinE += SendTimeText;
    }

    private IEnumerator TimerRoutine()
    {
        while (true)
        {
            if(_sec == 59)
            {
                _min++;
                _sec = -1;
            }
            _sec ++;

            _timerText.text = _min.ToString("D2") + " : " + _sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }

    private void SendTimeText()
    {
        winSystem.WinE -= SendTimeText;
        winSystem.SetTime(_timerText.text);
        this.gameObject.SetActive(false);
    }
}
