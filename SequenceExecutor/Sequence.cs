using System;
using System.Collections.Generic;
using UnityEngine;

#region Class: Sequence
/// <summary>
/// 여러 SequenceData를 순차적으로 실행하고,
/// 모든 데이터 실행 완료 시 onEnd 콜백을 호출하는 매니저 클래스
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
    /// 시퀀스를 시작하고, 완료 시 onEndCallback을 호출합니다.
    /// </summary>
    /// <param name="onEndCallback">모든 SequenceData 실행 완료 후 호출될 콜백</param>
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
    /// 현재 인덱스의 SequenceData를 실행하고,
    /// 완료 시 다음 SequenceData를 실행하거나 끝낸다
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
    /// 모든 SequenceData 실행이 끝나면 onEnd 콜백을 호출
    /// </summary>
    private void EndSequenceData() => onEnd?.Invoke();
    #endregion
}
#endregion
