using DG.Tweening;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UI;

public class TrueFalseManager : MonoBehaviour
{
    [SerializeField] private GameObject trueIcon, falseIcon;
    [SerializeField] private Text score;

    public Text Score { get { return score; } }

    int trueCount, falseCount;

    private void Start() {
        score.text = "0";
        ScaleDegeriniKapat();
    }

    public void TrueFalseScaleAc(bool dogrumuYanlismi, int questionScore = 0) {
        if (dogrumuYanlismi) {
            trueIcon.GetComponent<RectTransform>().DOScale(1f, 0.2f).SetEase(Ease.OutBack);
            falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
            Invoke("ScaleDegeriniKapat", 0.5f);
            ScaleDegeriniKapat();
            score.text = (int.Parse(score.text) + questionScore).ToString();
            trueCount++;
        }
        else {
            trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
            falseIcon.GetComponent<RectTransform>().DOScale(1f, 0.2f).SetEase(Ease.OutBack);
            Invoke("ScaleDegeriniKapat", 0.5f);
            ScaleDegeriniKapat();
            falseCount++;
        }
    }

    private void ScaleDegeriniKapat() {
        trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}
