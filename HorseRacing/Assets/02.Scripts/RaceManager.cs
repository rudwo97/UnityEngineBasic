using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ������ �����ϴ� Ŭ����
/// </summary>
public class RaceManager : MonoBehaviour
{
    [SerializeField] private Horse[] _horses;
    [SerializeField] private List<Horse> _finishedHorses = new List<Horse>();
    [SerializeField] private TargetFollowCamera[] _followCams;
    [SerializeField] private GameObject _finishedUI;

    //============================================================
    //                      Public Methods
    //============================================================

    /// <summary>
    /// ���ֽ���, ������ ��߽�Ŵ
    /// </summary>
    public void StartRace()
    {
        for (int i = 0; i < _horses.Length; i++)
        {
            _horses[i].doMove = true;
        }
    }

    /// <summary>
    /// ���� ��, 1, 2, 3�� �� UI �� �����
    /// </summary>
    public void StopRace()
    {
        for (int i = 0; i < _followCams.Length; i++)
        {
            // ����ī�޶�� �����
            if (i > _finishedHorses.Count - 1)
                break;

            _followCams[i].target = _finishedHorses[i].transform;
        }
        _finishedUI.SetActive(true);
    }

    /// <summary>
    /// ����ο� ������ ���� ��Ͻ�Ŵ
    /// </summary>
    /// <param name="horse"> ����ο� ������ ��</param>
    public void RegisterFinishedHorse(Horse horse)
    {
        if (_finishedHorses.Contains(horse))
        {
            Debug.LogWarning($"[RaceManager] : {horse.name} is already arrived");
            return;
        }

        _finishedHorses.Add(horse);
        Debug.Log($"[RaceManager] : {horse.name} is finished");
        CheckRaceFinished();
    }


    //============================================================
    //                      Private Methods
    //============================================================

    /// <summary>
    /// ���� ������ ���� üũ�ϰ� ���ָ� ����
    /// </summary>
    private void CheckRaceFinished()
    {
        if (_horses.Length == _finishedHorses.Count)
        {
            StopRace();
        }
    }
}
