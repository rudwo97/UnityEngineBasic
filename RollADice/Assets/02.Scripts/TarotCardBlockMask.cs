using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// [RequireComponent(System.Type)]
// �� MonoBehaviour �� ���� GameObject �� ��õ� Type�� ������Ʈ�� �������� üũ�ϰ�
// ������ �˾Ƽ� �߰����ش�. 
// ��õ� Type�� ������Ʈ�� GameObject ���� �����Ϸ��� �� �� �� MonoBehaviour �� �ʿ��ϴϱ� �ź��ϵ��� �Ѵ�.
[RequireComponent(typeof(Button))]
public class TarotCardBlockMask : MonoBehaviour
{
    [SerializeField] private TarotCard _card;
    private Button _button;
    [SerializeField] private float _animationDuration = 1.0f;
    [SerializeField] private float _animationSpeed = 1.0f;
    public event Action onAnimationFinished;

    public void Flip()
    {
        StartCoroutine(E_FlipAnimation());
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Flip);
        onAnimationFinished += () =>
        {
            StopAllCoroutines();
            TarotUI.instance.Hide();
            _card.OnSelected();
        };
    }

    private void OnEnable()
    {
        transform.eulerAngles = Vector3.zero;
    }

    private IEnumerator E_FlipAnimation()
    {
        float timeMark = Time.time;
        while (Time.time - timeMark < _animationDuration)
        {
            transform.eulerAngles = Vector3.up * 90.0f * _animationSpeed * (Time.time - timeMark) / _animationDuration;
            yield return null;
        }
        transform.eulerAngles = Vector3.up * 90.0f;
        yield return new WaitForSeconds(2.0f);
        onAnimationFinished?.Invoke();
    }
}
