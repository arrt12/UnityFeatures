using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#region Class: SequenceData
/// <summary>
/// 여러 UnityEvent 시퀀스를 순차적으로 실행한 뒤,
/// SequenceDataEndSend를 통해 완료 콜백을 호출하는 클래스
/// </summary>
[RequireComponent(typeof(SequenceDataEndSend))]
public class SequenceData : MonoBehaviour
{
    #region Components
    private SequenceDataEndSend sequenceDataEndSend;  // 완료 콜백 매니저
    #endregion

    #region Serialized Fields
    [Header("Sequence Events")]
    public List<UnityEvent> sequences = new();        // 실행할 순차적 이벤트 리스트
    #endregion

    #region Unity Callbacks
    private void Awake() => sequenceDataEndSend = GetComponent<SequenceDataEndSend>();
    #endregion

    #region Public Methods
    /// <summary>
    /// 등록된 모든 시퀀스를 실행한 뒤 onSequenceEnd 콜백을 전달
    /// </summary>
    /// <param name="onSequenceEnd">시퀀스 종료 시 호출할 콜백</param>
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
