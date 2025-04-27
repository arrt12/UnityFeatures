using System;
using UnityEngine;

#region Class: SequenceDataEndSend
/// <summary>
/// ������ ������ ó���� �������� �˸��� �⺻ Ŭ����
/// onEnd �ݹ��� ��� ȣ���մϴ�.
/// </summary>
public class SequenceDataEndSend : MonoBehaviour
{
    #region Public Methods
    /// <summary>
    /// ������ ���� �� ȣ���� �ݹ��� ��� ����
    /// </summary>
    /// <param name="onEnd">���� �� ������ �ݹ�</param>
    public virtual void SendEnd(Action onEnd)
    {
        onEnd?.Invoke();
    }
    #endregion
}
#endregion
