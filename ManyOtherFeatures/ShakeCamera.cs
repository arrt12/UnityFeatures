using System.Collections;
using UnityEngine;

#region Class: ShakeCamera
/// <summary>
/// 카메라에 흔들림 효과를 적용한다.
/// SetUp(duration, power) 호출 시 지정된 시간 동안 랜덤 오프셋을 적용하고,
/// 효과가 끝나면 부드럽게 원위치로 복귀
/// </summary>
public class ShakeCamera : MonoBehaviour
{
    #region State
    private Vector3 originalPos;      // 초기 카메라 위치
    private Coroutine shakeCoroutine; // 진행 중인 흔들림 코루틴
    private float shakePower;         // 흔들림 세기
    #endregion

    #region Unity Callbacks
    private void Start()
    {
        originalPos = transform.position;
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// 흔들림 효과를 설정하고 코루틴을 시작
    /// </summary>
    /// <param name="duration">흔들릴 시간(초)</param>
    /// <param name="power">흔들림 세기</param>
    public void SetUp(float duration, float power)
    {
        shakePower = power;
        if (shakeCoroutine != null)
            StopCoroutine(shakeCoroutine);

        shakeCoroutine = StartCoroutine(ShakeCoroutine(duration));
    }
    #endregion

    #region Coroutines
    /// <summary>
    /// duration 동안 카메라 위치를 무작위로 흔들고,
    /// 완료 후 부드럽게 원위치로 복귀
    /// </summary>
    private IEnumerator ShakeCoroutine(float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            Vector3 randomOffset = Random.insideUnitSphere * shakePower;
            transform.position = new Vector3(
                originalPos.x + randomOffset.x,
                originalPos.y,
                originalPos.z + randomOffset.z
            );
            yield return null;
        }

        // 흔들림 종료 후 부드럽게 원위치로 복귀
        float smoothTime = 0.1f;
        float recoveryElapsed = 0f;
        Vector3 startPos = transform.position;

        while (recoveryElapsed < smoothTime)
        {
            recoveryElapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, originalPos, recoveryElapsed / smoothTime);
            yield return null;
        }

        transform.position = originalPos;
        shakeCoroutine = null;
    }
    #endregion
}
#endregion
