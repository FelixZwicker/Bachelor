using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceObjects : MonoBehaviour
{
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public VelocityEstimator velocityEstimator;
    public LayerMask sliceableLayer;
    public Material crossSectionMaterial;

    public float cutForce = 2000f;

    void FixedUpdate()
    {
        // Perform a linecast to detect objects in the slicing path
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }
    }

    // Method to slice the target object
    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);
        SoundManager.PlaySounds(SoundManager.Sound.Chopping);
        if(hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);
            SetupSlicedComponent(upperHull);

            GameObject lowerHull = hull.CreateLowerHull(target, crossSectionMaterial);
            SetupSlicedComponent(lowerHull);

            Destroy(target);
        }
    }

    // Method to setup physical properties for the sliced component
    public void SetupSlicedComponent(GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
        
        rb.AddExplosionForce(cutForce, slicedObject.transform.position, 1);

        StartCoroutine(DestroySlicedPeaces(slicedObject));
    }

    //delete sliced objects after time
    IEnumerator DestroySlicedPeaces(GameObject slicedObject)
    {
        yield return new WaitForSeconds(5f);
        Destroy(slicedObject);
    }
}
