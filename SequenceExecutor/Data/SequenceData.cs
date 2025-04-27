using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#region Class: SequenceData
/// <summary>
/// ���� UnityEvent �������� ���������� ������ ��,
/// SequenceDataEndSend�� ���� �Ϸ� �ݹ��� ȣ���ϴ� Ŭ����
/// </summary>
[RequireComponent(typeof(SequenceDataEndSend))]
public class SequenceData : MonoBehaviour
{
    #region Components
    private SequenceDataEndSend sequenceDataEndSend;  // �Ϸ� �ݹ� �Ŵ���
    #endregion

    #region Serialized Fields
    [Header("Sequence Events")]
    public List<UnityEvent> sequences = new();        // ������ ������ �̺�Ʈ ����Ʈ
    #endregion

    #region Unity Callbacks
    private void Awake() => sequenceDataEndSend = GetComponent<SequenceDataEndSend>();
    #endregion

    #region Public Methods
    /// <summary>
    /// ��ϵ� ��� �������� ������ �� onSequenceEnd �ݹ��� ����
    /// </summary>
    /// <param name="onSequenceEnd">������ ���� �� ȣ���� �ݹ�</param>
    public void PlaySequence(Action onSequenceEnd)
    {
        if (sequences != null)
        {
            foreach (var sequence in sequences)
                sequence?.Invoke();
        }

        sequenceDataEndSend.SendEnd(onSequenceEnd);
    }
    #endregion
}
#endregion
