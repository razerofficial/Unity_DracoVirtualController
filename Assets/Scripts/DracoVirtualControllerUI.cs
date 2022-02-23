using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

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

    private float _mDeadZone = 0.15f;

    void FixedUpdate()
    {
        Gamepad gamepad = Gamepad.current;
        if (gamepad == null)
        {
            return; // No gamepad connected.
        }

        _mImageA.enabled = gamepad.aButton.isPressed;
        _mImageB.enabled = gamepad.bButton.isPressed;
        _mImageX.enabled = gamepad.xButton.isPressed;
        _mImageY.enabled = gamepad.yButton.isPressed;
        _mImageDpadDown.enabled = gamepad.dpad.down.isPressed;
        _mImageDpadLeft.enabled = gamepad.dpad.left.isPressed;
        _mImageDpadRight.enabled = gamepad.dpad.right.isPressed;
        _mImageDpadUp.enabled = gamepad.dpad.up.isPressed;
        _mImageLeftBumper.enabled = gamepad.leftShoulder.isPressed;
        _mImageLeftThumb.enabled = gamepad.leftStickButton.isPressed;
        //_mImageLeftTrigger.enabled = gamepad.leftTrigger.isPressed;
        _mImageLeftTrigger.enabled = Mathf.Abs(gamepad.leftTrigger.ReadValue()) >= _mDeadZone;
        _mImageRightBumper.enabled = gamepad.rightShoulder.isPressed;
        _mImageRightThumb.enabled = gamepad.rightStickButton.isPressed;
        //_mImageRightTrigger.enabled = gamepad.rightTrigger.isPressed;
        _mImageRightTrigger.enabled = Mathf.Abs(gamepad.rightTrigger.ReadValue()) >= _mDeadZone;
        _mImageSelect.enabled = gamepad.selectButton.isPressed;
        _mImageStart.enabled = gamepad.startButton.isPressed;

        const float rotDegrees = 165f;
        const float rotRadians = rotDegrees / 180f * Mathf.PI;
        float rotCos = Mathf.Cos(rotRadians);
        float rotSin = Mathf.Sin(rotRadians);

        const float stickMultiplier = 10f;

        Vector2 ls = gamepad.leftStick.ReadValue();
        Vector2 newLeft;
        newLeft.x = rotCos * ls.x - rotSin * ls.y;
        newLeft.y = rotSin * ls.x + rotCos * ls.y;
        newLeft *= stickMultiplier;
        _mImageLeftStick.transform.localPosition = newLeft;
        _mImageLeftThumb.transform.localPosition = newLeft;

        Vector2 rs = gamepad.rightStick.ReadValue();
        Vector2 newRight;
        newRight.x = rotCos * rs.x - rotSin * rs.y;
        newRight.y = rotSin * rs.x + rotCos * rs.y;
        newRight *= stickMultiplier;
        _mImageRightStick.transform.localPosition = newRight;
        _mImageRightThumb.transform.localPosition = newRight;

        Touchscreen touch = Touchscreen.current;
        if (touch != null)
        {
            _mImageTap.enabled = touch.IsPressed();
        }        
    }
}
