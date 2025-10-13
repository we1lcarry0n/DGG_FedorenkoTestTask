using UnityEngine;

public class GroundAligner : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _alignMaxDistance;

    public void AlignToGround()
    {
        transform.position = DeterminePosition();
    }

    private Vector3 DeterminePosition()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, _alignMaxDistance, _groundLayer)) // Shoot the raycast down to search the Ground layer object
        {
            AdjustRotation(hit);
            return hit.point; // Get the hit point coordinates
        }
        Debug.Log("Alignment to ground was not successfull!");
        return transform.position;
    }

    private void AdjustRotation(RaycastHit hit)
    { 
        Vector3 hitNormal = hit.normal;  // Determine the normal vector of the surface
        if (hitNormal.y > 0 && hitNormal.y < 0.9f)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(Vector3.down, hitNormal) * -1f); // Project normal vector on plane to get the rotation of standing object
        }
    }

}
