using System;
using System.Collections;
using UnityEngine;

#region Class: SequenceDataEndSend_Timer
/// <summary>
/// 일정 시간(timer) 후에 onEnd 콜백을 호출하는 SequenceDataEndSend 구현체
/// </summary>
public class SequenceDataEndSend_Timer : SequenceDataEndSend
{
    #region Serialized Fields
    [Header("Timer Settings")]
    public float timer = 1f;  // 대기할 시간(초)
    #endregion

    #region State
    private Coroutine timerCoroutine;  // 진행 중인 코루틴 참조
    #endregion

    #region Public Methods
    /// <summary>
    /// 기존 코루틴이 있으면 중지하고, 새로운 타이머 코루틴을 시작
    /// </summary>
    /// <param name="onEnd">타이머 종료 후 호출할 콜백</param>
    public override void SendEnd(Action onEnd)
    {
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        timerCoroutine = StartCoroutine(StartEndTimer(onEnd));
    }
    #endregion

    #region Coroutines
    /// <summary>
    /// timer 초 대기 후 onEnd 콜백을 Invoke
    /// </summary>
    private IEnumerator StartEndTimer(Action onEnd)
    {
        yield return new WaitForSeconds(timer);
        onEnd?.Invoke();
    }
    #endregion
}
#endregion
