using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Transform kafa_Transform;
    [SerializeField] private Transform basla_Transform;

    private void Start() {
        kafa_Transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
        basla_Transform.GetComponent<RectTransform>().DOLocalMoveY(-270f,1f).SetEase(Ease.OutBack);
    }

    public void OyunaBasla() {
        SceneManager.LoadScene("GameLevel");
    }
}
