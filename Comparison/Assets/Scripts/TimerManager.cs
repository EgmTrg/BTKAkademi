using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private Text sure_Text;
    int kalanSure;
    bool sureDurumu = true;

    private void Start() {
        kalanSure = 90;
    }

    public void SureyiBaslat() {
        StartCoroutine(SureTimerRoutine());
    }

    private IEnumerator SureTimerRoutine() {
        while (sureDurumu) {
            yield return new WaitForSeconds(1f);

            if (kalanSure < 0) {
                sureDurumu = false;
                break;
            }

            if (kalanSure >= 10)
                sure_Text.text = kalanSure.ToString();
            else
                sure_Text.text = "0" + kalanSure.ToString();

            kalanSure--;
        }
    }
}
