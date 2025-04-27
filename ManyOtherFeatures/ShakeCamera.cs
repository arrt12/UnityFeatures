using System.Collections;
using UnityEngine;

#region Class: ShakeCamera
/// <summary>
/// ī�޶� ��鸲 ȿ���� �����Ѵ�.
/// SetUp(duration, power) ȣ�� �� ������ �ð� ���� ���� �������� �����ϰ�,
/// ȿ���� ������ �ε巴�� ����ġ�� ����
/// </summary>
public class ShakeCamera : MonoBehaviour
{
    #region State
    private Vector3 originalPos;      // �ʱ� ī�޶� ��ġ
    private Coroutine shakeCoroutine; // ���� ���� ��鸲 �ڷ�ƾ
    private float shakePower;         // ��鸲 ����
    #endregion

    #region Unity Callbacks
    private void Start()
    {
        originalPos = transform.position;
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// ��鸲 ȿ���� �����ϰ� �ڷ�ƾ�� ����
    /// </summary>
    /// <param name="duration">��鸱 �ð�(��)</param>
    /// <param name="power">��鸲 ����</param>
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
    /// duration ���� ī�޶� ��ġ�� �������� ����,
    /// �Ϸ� �� �ε巴�� ����ġ�� ����
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

        // ��鸲 ���� �� �ε巴�� ����ġ�� ����
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
