using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Class: SequenceExecutor
/// <summary>
/// ��ϵ� Sequence���� ���������� �����ϰ�, 
/// ��� �������� ������ onEnd �ݹ��� ȣ���ϴ� �Ŵ��� Ŭ�����Դϴ�.
/// </summary>
public class SequenceExecutor : MonoBehaviour
{
    #region Serialized Fields
    [Header("Sequence Settings")]
    public Sequence[] startPlaySequences;   // ������ ������ �迭
    #endregion

    #region State
    private int currentSequenceIndex = 0;    // ���� ���� ���� ������ �ε���
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        // ȭ�� �ػ󵵸� ���� ����
        Screen.SetResolution(1920, 1080, false);
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// ��ϵ� ��� �������� ���������� �����մϴ�.
    /// </summary>
    /// <param name="onEnd">��� ������ �Ϸ� �� ȣ��� �ݹ�</param>
    public void PlaySequence(Action onEnd = null)
    {
        currentSequenceIndex = 0;

        if (startPlaySequences == null || startPlaySequences.Length == 0)
        {
            onEnd?.Invoke();
            return;
        }

        foreach (var sequence in startPlaySequences)
        {
            sequence.StartSequenceData(() =>
            {
                currentSequenceIndex++;
                if (currentSequenceIndex >= startPlaySequences.Length)
                    onEnd?.Invoke();
            });
        }
    }
    #endregion
}
#endregion
