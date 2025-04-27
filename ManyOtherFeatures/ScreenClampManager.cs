using UnityEngine;

#region Class: ScreenClampManager
/// <summary>
/// ������ Ÿ���� ȭ�� ����Ʈ ���� ������ ����(minX~maxX, minY~maxY)�� ������Ű�� Ŭ����
/// LateUpdate���� �� ������ ����Ʈ ��ǥ�� ����Ͽ� ���� ��ǥ�� �ٽ� ��ȯ
/// </summary>
public class ScreenClampManager : MonoBehaviour
{
    #region Serialized Fields
    [Header("Clamp Settings")]
    [Tooltip("ȭ�� �ȿ� ������ ������Ʈ(�̼��� �� �ڽ�)")]
    public Transform target;

    [Tooltip("����Ʈ X�� �ּҰ�")]
    public float minX = 0.05f;
    [Tooltip("����Ʈ X�� �ִ밪")]
    public float maxX = 0.95f;
    [Tooltip("����Ʈ Y�� �ּҰ�")]
    public float minY = 0.05f;
    [Tooltip("����Ʈ Y�� �ִ밪")]
    public float maxY = 0.95f;
    #endregion

    #region State
    private Camera mainCamera;  // ���� ī�޶� ����
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        mainCamera = Camera.main;
        if (target == null)
            target = transform;
    }

    private void LateUpdate()
    {
        ClampToScreen();
    }
    #endregion

    #region Helper Methods
    /// <summary>
    /// Ÿ���� ���� ��ġ�� ����Ʈ ���η� Ŭ�����Ͽ� �ٽ� ���� ��ġ�� ��ȯ �� ����
    /// </summary>
    private void ClampToScreen()
    {
        if (mainCamera == null || target == null)
            return;

        // ���� �� ����Ʈ ��ǥ ��ȯ
        Vector3 viewPos = mainCamera.WorldToViewportPoint(target.position);

        // ����Ʈ �� ������ ������ Ŭ����
        viewPos.x = Mathf.Clamp(viewPos.x, minX, maxX);
        viewPos.y = Mathf.Clamp(viewPos.y, minY, maxY);

        // ����Ʈ �� ���� ��ǥ ��ȯ
        Vector3 clampedWorldPos = mainCamera.ViewportToWorldPoint(viewPos);

        // Y���� �����ϰ� X,Z�� Ŭ���ε� �� ����
        target.position = new Vector3(
            clampedWorldPos.x,
            target.position.y,
            clampedWorldPos.z
        );
    }
    #endregion
}
#endregion
