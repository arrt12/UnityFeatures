using System.Collections;
using UnityEngine;

#region Class: MoveToPositionSmoothly
/// <summary>
/// 지정된 타겟을 부드럽게 원래 위치로 되돌리는 클래스
/// SmoothStep 보간으로 자연스러운 움직임을 연출합니다.
/// </summary>
public class MoveToPositionSmoothly : MonoBehaviour
{
    #region Serialized Fields
    [Header("Move Settings")]
    [Tooltip("움직일 대상 오브젝트(미설정 시 자신)")]
    public Transform target;
    [Tooltip("원래 위치로 되돌아오는 데 걸릴 시간(초)")]
    public float returnDuration = 1.0f;
    #endregion

    #region State
    private Vector3 originalPosition;   // 초기 위치 저장
    private Coroutine moveCoroutine;    // 진행 중인 이동 코루틴 참조
    #endregion

    #region Unity Callbacks
    private void Start()
    {
        if (target == null)
            target = transform;

        originalPosition = target.position;
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// 외부에서 호출하여 target을 originalPosition으로 부드럽게 이동
    /// </summary>
    public void ReturnToOrigin()
    {
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);

        moveCoroutine = StartCoroutine(MoveBackSmoothCoroutine(target, originalPosition, returnDuration));
    }
    #endregion

    #region Coroutines
    /// <summary>
    /// duration 초 동안 SmoothStep 보간을 사용해 시작 위치에서 원위치로 이동
    /// </summary>
    private IEnumerator MoveBackSmoothCoroutine(Transform obj, Vector3 originPos, float duration)
    {
        float elapsed = 0f;
        Vector3 startPos = obj.position;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            t = Mathf.SmoothStep(0f, 1f, t);
            obj.position = Vector3.Lerp(startPos, originPos, t);
            yield return null;
        }

        obj.position = originPos;
        moveCoroutine = null;
    }
    #endregion
}
#endregion
