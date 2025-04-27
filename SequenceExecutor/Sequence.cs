using System;
using System.Collections.Generic;
using UnityEngine;

#region Class: Sequence
/// <summary>
/// ���� SequenceData�� ���������� �����ϰ�,
/// ��� ������ ���� �Ϸ� �� onEnd �ݹ��� ȣ���ϴ� �Ŵ��� Ŭ����
/// </summary>
public class Sequence : MonoBehaviour
{
    #region Serialized Fields
    [Header("Sequence Data List")]
    public List<SequenceData> sequenceDatas = new();
    #endregion

    #region State
    private Action onEnd;
    private int currentIndex = 0;
    #endregion

    #region Public Methods
    /// <summary>
    /// �������� �����ϰ�, �Ϸ� �� onEndCallback�� ȣ���մϴ�.
    /// </summary>
    /// <param name="onEndCallback">��� SequenceData ���� �Ϸ� �� ȣ��� �ݹ�</param>
    public void StartSequenceData(Action onEndCallback)
    {
        onEnd = onEndCallback;
        currentIndex = 0;

        if (sequenceDatas == null || sequenceDatas.Count == 0)
        {
            EndSequenceData();
            return;
        }

        PlayCurrentSequence();
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// ���� �ε����� SequenceData�� �����ϰ�,
    /// �Ϸ� �� ���� SequenceData�� �����ϰų� ������
    /// </summary>
    private void PlayCurrentSequence()
    {
        sequenceDatas[currentIndex].PlaySequence(() =>
        {
            currentIndex++;
            if (currentIndex >= sequenceDatas.Count)
                EndSequenceData();
            else
                PlayCurrentSequence();
        });
    }

    /// <summary>
    /// ��� SequenceData ������ ������ onEnd �ݹ��� ȣ��
    /// </summary>
    private void EndSequenceData() => onEnd?.Invoke();
    #endregion
}
#endregion
