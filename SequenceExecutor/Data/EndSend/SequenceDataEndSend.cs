using System;
using UnityEngine;

#region Class: SequenceDataEndSend
/// <summary>
/// 시퀀스 데이터 처리가 끝났음을 알리는 기본 클래스
/// onEnd 콜백을 즉시 호출합니다.
/// </summary>
public class SequenceDataEndSend : MonoBehaviour
{
    #region Public Methods
    /// <summary>
    /// 시퀀스 종료 시 호출할 콜백을 즉시 실행
    /// </summary>
    /// <param name="onEnd">종료 후 실행할 콜백</param>
    public virtual void SendEnd(Action onEnd)
    {
        onEnd?.Invoke();
    }
    #endregion
}
#endregion
