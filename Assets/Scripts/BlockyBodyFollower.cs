using UnityEngine;

public class BlockyBodyFollower : MonoBehaviour
{
    [Header("XR Rig References")]
    public Transform xrRigOrigin;   // XR Origin or Camera Offset
    public Transform xrHead;        // Main Camera
    public Transform leftHand;
    public Transform rightHand;

    [Header("Body Parts")]
    public Transform torso;
    public Transform head;
    public Transform leftArm;
    public Transform rightArm;

    [Header("Torso Offsets")]
    public Vector3 torsoPositionOffset = new Vector3(0, -0.17f, -0.3f);
    public Vector3 torsoRotationOffset = new Vector3(0, 0, 0); // optional fine-tune

    [Header("Head Offsets")]
    public Vector3 headPositionOffset = new Vector3(0, 0.25f, -0.31f);
    public Vector3 headRotationOffset = new Vector3(0, 0, 0);

    [Header("Left Arm Offsets")]
    public Vector3 leftArmPositionOffset = new Vector3(0.04f, 0.06f, -0.23f);
    public Vector3 leftArmRotationOffset = new Vector3(-78.3f, -9.01f, 0);

    [Header("Right Arm Offsets")]
    public Vector3 rightArmPositionOffset = new Vector3(0.04f, 0.06f, -0.23f);
    public Vector3 rightArmRotationOffset = new Vector3(-78.3f, -9.01f, 0);

    [Header("Legs")]
    public Transform leftLeg;
    public Transform rightLeg;

    public Vector3 leftLegOffset = new Vector3(-0.15f, -1f, 0);
    public Vector3 rightLegOffset = new Vector3(0.15f, -1f, 0);

    void Update()
    {
        // Torso follows XR Origin
        if (xrRigOrigin != null && torso != null)
        {
            torso.position = xrHead.position + xrHead.TransformVector(torsoPositionOffset);
            torso.rotation = xrHead.rotation * Quaternion.Euler(torsoRotationOffset);
        }

        // Head follows headset directly
        if (xrHead != null && head != null)
        {
            head.position = xrHead.position + xrHead.TransformVector(headPositionOffset);
            head.rotation = xrHead.rotation * Quaternion.Euler(headRotationOffset);
        }

        // Left Arm
        if (leftHand != null && leftArm != null)
        {
            leftArm.position = leftHand.position + leftHand.TransformVector(leftArmPositionOffset);
            leftArm.rotation = leftHand.rotation * Quaternion.Euler(leftArmRotationOffset);
        }

        // Right Arm
        if (rightHand != null && rightArm != null)
        {
            rightArm.position = rightHand.position + rightHand.TransformVector(rightArmPositionOffset);
            rightArm.rotation = rightHand.rotation * Quaternion.Euler(rightArmRotationOffset);
        }

        // Left Leg
        if (torso != null && leftLeg != null)
        {
            leftLeg.position = torso.position + torso.TransformVector(leftLegOffset);
            leftLeg.rotation = torso.rotation;
        }

        // Right Leg
        if (torso != null && rightLeg != null)
        {
            rightLeg.position = torso.position + torso.TransformVector(rightLegOffset);
            rightLeg.rotation = torso.rotation;
        }


        
    }
}
