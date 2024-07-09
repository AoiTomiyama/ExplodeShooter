using UnityEngine;

public class BlockMove : MonoBehaviour
{
    private float _wallSpeed = 1;
    public float WallSpeed { set => _wallSpeed = value; }
    private void FixedUpdate()
    {
        transform.Translate(_wallSpeed * Time.deltaTime * Vector3.left);
        if (transform.position.x < -25)
        {
            Destroy(this.gameObject);
        }
    }
}
