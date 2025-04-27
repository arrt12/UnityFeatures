using System;
using System.Collections;
using UnityEngine;

#region Class: SequenceDataEndSend_Timer
/// <summary>
/// ���� �ð�(timer) �Ŀ� onEnd �ݹ��� ȣ���ϴ� SequenceDataEndSend ����ü
/// </summary>
public class SequenceDataEndSend_Timer : SequenceDataEndSend
{
    #region Serialized Fields
    [Header("Timer Settings")]
    public float timer = 1f;  // ����� �ð�(��)
    #endregion

    #region State
    private Coroutine timerCoroutine;  // ���� ���� �ڷ�ƾ ����
    #endregion

    #region Public Methods
    /// <summary>
    /// ���� �ڷ�ƾ�� ������ �����ϰ�, ���ο� Ÿ�̸� �ڷ�ƾ�� ����
    /// </summary>
    /// <param name="onEnd">Ÿ�̸� ���� �� ȣ���� �ݹ�</param>
    public override void SendEnd(Action onEnd)
    {
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        timerCoroutine = StartCoroutine(StartEndTimer(onEnd));
    }
    #endregion

    #region Coroutines
    /// <summary>
    /// timer �� ��� �� onEnd �ݹ��� Invoke
    /// </summary>
    private IEnumerator StartEndTimer(Action onEnd)
    {
        yield return new WaitForSeconds(timer);
        onEnd?.Invoke();
    }
    #endregion
}
#endregion
