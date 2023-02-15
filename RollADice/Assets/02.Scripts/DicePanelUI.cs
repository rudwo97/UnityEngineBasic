using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

/// <summary>
/// �ֻ��� ������ �ٲ� �� ���� �ֻ�������  UI ����
/// </summary>
public class DicePanelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _normalDice;
    [SerializeField] private TMP_Text _goldenDice;
    [SerializeField] private Button _normalDiceButton;
    [SerializeField] private Button _goldenDiceButton;
    [SerializeField] private GameObject _reverseIcons;
    [SerializeField] private GameObject _goldenDiceSelectionPanel;
    [SerializeField] private List<Button> _goldenDiceSelectionButtons;

    private void Start()
    {
        DiceManager diceManager = DiceManager.instance;
        diceManager.onNormalDiceChanged += (dice) =>
        {
            _normalDiceButton.interactable = dice > 0;
            _normalDice.text = dice.ToString();
        };
        diceManager.onGoldenDiceChanged += (dice) =>
        {
            _goldenDiceButton.interactable = dice > 0;
            _goldenDice.text = dice.ToString();
        };

        // �Ϲ��ֻ�����ư Ŭ����
        // �ֻ���������, ���� �������� �ִϸ��̼� ����ϰ� , �ִϸ��̼ǳ����� �÷��̾ �ش� ���ݸ�ŭ �̵���Ŵ
        _normalDiceButton.onClick.AddListener(() =>
        {
            if (DiceAnimationUI.instance.isBusy)
                return;

            int diceValue = diceManager.RollANormalDice();
            DiceAnimationUI.instance.Play(diceValue, () => Player.instance.Move(diceValue));
        });

        // Ȳ���ֻ�����ư Ŭ����
        _goldenDiceButton.onClick.AddListener(() =>
        {
            _goldenDiceSelectionPanel.SetActive(true);
        });

        // Ȳ���ֻ��� ���� ��ư��
        for (int i = 0; i < _goldenDiceSelectionButtons.Count; i++)
        {
            // ����. �ݺ������� �븮�ڿ� �����Ҷ� �ε����� ���� (i) �� ���ԵǸ� ��� �����Լ��� i �� �����ϹǷ�
            // ������ ���� ��������ʰ� ������ ���� ���� �����ͼ� ����ؾ���.
            int selectedValue = i + 1;

            _goldenDiceSelectionButtons[i].onClick.AddListener(() =>
            {
                if (DiceAnimationUI.instance.isBusy)
                    return;
                                
                int diceValue = diceManager.RollAGoldenDice(selectedValue);
                _goldenDiceSelectionPanel.SetActive(false);
                DiceAnimationUI.instance.Play(diceValue, () => Player.instance.Move(diceValue));
            });
        }


        // ������ȯ�� ���� ��Ģ ������ Ȱ��
        Player.instance.onDirectionChanged += (value) =>
        {
            _reverseIcons.SetActive(value == Player.DIRECTION_BACKWARD);
        };

        _normalDice.text = diceManager.normalDice.ToString();
        _goldenDice.text = diceManager.goldenDice.ToString();
        _normalDiceButton.interactable = diceManager.normalDice > 0;
        _goldenDiceButton.interactable = diceManager.goldenDice > 0;
        _reverseIcons.SetActive(Player.instance.direction == Player.DIRECTION_BACKWARD);
    }
}
