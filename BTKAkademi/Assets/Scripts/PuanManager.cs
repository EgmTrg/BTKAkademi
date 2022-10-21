using System;
using UnityEngine;
using UnityEngine.UI;

public class PuanManager : MonoBehaviour
{
    private int toplamPuan;
    private int puanArtisi;

    [SerializeField] private Text puanText;

    internal void PuanArttir(string soruZorlukDerecesi) {
        switch (soruZorlukDerecesi) {
            case "Kolay":
                puanArtisi = 5;
                    break;
            case "Orta":
                puanArtisi = 10;
                    break;
            case "Zor":
                puanArtisi = 15;
                    break;
            default:
                break;
        }

        toplamPuan += puanArtisi;
        puanText.text = toplamPuan.ToString();
    }
}
