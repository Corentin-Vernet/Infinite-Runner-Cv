using UnityEngine;
using TMPro;

public class UI_Life_View : MonoBehaviour
{
    [SerializeField] private TMP_Text _lifeText;

    private void Awake()
    {
        EventSystem.OnPlayerLifeUpdated += LifeUpdated;
    }

    private void OnDestroy()
    {
        EventSystem.OnPlayerLifeUpdated -= LifeUpdated;
    }

    private void LifeUpdated(int newLifeCount)
    {
        _lifeText.text = "Lives: " + newLifeCount;
    }
}