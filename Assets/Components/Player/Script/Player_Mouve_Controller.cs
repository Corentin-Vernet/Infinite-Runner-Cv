using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Mouve_Controller : MonoBehaviour
{
    [SerializeField] private float _jumpDuration = 1f;
    [SerializeField] private float _heightJump = 2f;
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private AnimationCurve _fallCurve;

    public void Update()
    {
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            StartCoroutine(routine: SautCoroutine());
        }

        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {

        }

        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {

        }

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {

        }
    }

    private IEnumerator SautCoroutine()
    {
        var jumpTimer = 0f;
        var halfJumpDuration = _jumpDuration / 2f;

        while (jumpTimer < halfJumpDuration)
        {
            jumpTimer += Time.deltaTime;
            var normalizedTime = jumpTimer / halfJumpDuration;
            var heightTarget = _jumpCurve.Evaluate(normalizedTime) * _heightJump; // fait correspondre la hauteur du saut en fonction de ça durée
            var targetPosition = new Vector3(transform.position.x, heightTarget, transform.position.z);

            transform.position = targetPosition;

            yield return null; // attend la prochaine frame
        }

        jumpTimer = 0f;

        while (jumpTimer < halfJumpDuration)
        {
            jumpTimer += Time.deltaTime;
            var normalizedTime = jumpTimer / halfJumpDuration;
            var heightTarget = _fallCurve.Evaluate(normalizedTime) * _heightJump; // idem pour la chute
            var targetPosition = new Vector3(transform.position.x, heightTarget, transform.position.z);

            transform.position = targetPosition;

            yield return null; // attend la prochaine frame
        }
    }
}
