using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Class: SequenceExecutor
/// <summary>
/// 등록된 Sequence들을 순차적으로 실행하고, 
/// 모든 시퀀스가 끝나면 onEnd 콜백을 호출하는 매니저 클래스입니다.
/// </summary>
public class SequenceExecutor : MonoBehaviour
{
    #region Serialized Fields
    [Header("Sequence Settings")]
    public Sequence[] startPlaySequences;   // 실행할 시퀀스 배열
    #endregion

    #region State
    private int currentSequenceIndex = 0;    // 현재 실행 중인 시퀀스 인덱스
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        // 화면 해상도를 고정 설정
        Screen.SetResolution(1920, 1080, false);
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// 등록된 모든 시퀀스를 순차적으로 실행합니다.
    /// </summary>
    /// <param name="onEnd">모든 시퀀스 완료 후 호출될 콜백</param>
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
