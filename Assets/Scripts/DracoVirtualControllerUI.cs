using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DracoVirtualControllerUI : MonoBehaviour
{
    public Image _mImageA = null;
    public Image _mImageB = null;
    public Image _mImageX = null;
    public Image _mImageY = null;
    public Image _mImageDpadDown = null;
    public Image _mImageDpadLeft = null;
    public Image _mImageDpadRight = null;
    public Image _mImageDpadUp = null;
    public Image _mImageLeftBumper = null;
    public Image _mImageLeftStick = null;
    public Image _mImageLeftThumb = null;
    public Image _mImageLeftTrigger = null;
    public Image _mImageRightBumper = null;
    public Image _mImageRightStick = null;
    public Image _mImageRightThumb = null;
    public Image _mImageRightTrigger = null;
    public Image _mImageTap = null;
    public Image _mImageSelect = null;
    public Image _mImageStart = null;

    public float _mDeadZone = 0.2f;

    // Update is called once per frame
    void Update()
    {
        bool a = Input.GetButton("Fire1");
        float lt = Input.GetAxis("Fire1");
        _mImageA.enabled = a;
        _mImageLeftTrigger.enabled = Mathf.Abs(lt) >= _mDeadZone;
    }
}
