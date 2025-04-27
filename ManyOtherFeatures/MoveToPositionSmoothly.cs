using System.Collections;
using UnityEngine;

#region Class: MoveToPositionSmoothly
/// <summary>
/// ������ Ÿ���� �ε巴�� ���� ��ġ�� �ǵ����� Ŭ����
/// SmoothStep �������� �ڿ������� �������� �����մϴ�.
/// </summary>
public class MoveToPositionSmoothly : MonoBehaviour
{
    #region Serialized Fields
    [Header("Move Settings")]
    [Tooltip("������ ��� ������Ʈ(�̼��� �� �ڽ�)")]
    public Transform target;
    [Tooltip("���� ��ġ�� �ǵ��ƿ��� �� �ɸ� �ð�(��)")]
    public float returnDuration = 1.0f;
    #endregion

    #region State
    private Vector3 originalPosition;   // �ʱ� ��ġ ����
    private Coroutine moveCoroutine;    // ���� ���� �̵� �ڷ�ƾ ����
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
    /// �ܺο��� ȣ���Ͽ� target�� originalPosition���� �ε巴�� �̵�
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
    /// duration �� ���� SmoothStep ������ ����� ���� ��ġ���� ����ġ�� �̵�
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
