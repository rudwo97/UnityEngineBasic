using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TarotUI : MonoBehaviour
{
    #region Singleton
    public static TarotUI instance;
    private void Awake()
    {
        instance = this;
        _content.localPosition = Vector3.zero;
        gameObject.SetActive(false);
    }
    #endregion

    [SerializeField] private RectTransform _content;
    [SerializeField] private List<TarotCard> _cards;

    public void Show()
    {
        // ī�� ���� �������� ����
        IEnumerable<TarotCard> shuffled = _cards.OrderBy((x) => Guid.NewGuid());

        // ī�� ���� ����
        int count = 0;
        foreach (TarotCard card in shuffled)
        {
            card.gameObject.SetActive(count < 3);
            count++;
        }

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
