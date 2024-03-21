using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class FOVTest : MonoBehaviour
{
    [Range(1f, 179f)] public float m_fov = 40f;
    public Camera m_camera;
    public Transform m_imageSensor;
    public Transform m_lens;
    public Transform m_line1;
    public Transform m_line2;
    public Transform m_line3;
    public Transform m_line4;
    
    // 이미지센서 코너 포인트. 거리 재는 용도라서 하나만 있어도 됨
    public Transform m_p1;

    void Update()
    {
        m_camera.fieldOfView = m_fov;
        Vector3 lensPos = Vector3.zero;
        lensPos.z = Mathf.Tan(Mathf.Deg2Rad * (180f - m_fov) * 0.5f);
        m_lens.localPosition = lensPos;

        m_imageSensor.transform.localPosition = lensPos * -1f;

        float pointDist = Vector3.Distance(transform.position, m_p1.position);
        Vector3 lineScale = new Vector3(0.01f, 0.01f, pointDist * 2f);
        m_line1.transform.localScale = lineScale;
        m_line2.transform.localScale = lineScale;
        m_line3.transform.localScale = lineScale;
        m_line4.transform.localScale = lineScale;
    }
}
