using UnityEngine;

namespace WombatCombat
{
    public class CubeMove : MonoBehaviour
    {
        public Transform cub;
        [SerializeField] private float speed = 10f;

        private FixedJoint2D fxj;
        private Rigidbody2D rb;
        private bool isConnected;

        void OnMouseDrag()
        {
            if (!Playermove.lose)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float minY = -0.59f;
                float maxY = 12.06f;
                float minX = -35.35f;
                float maxX = 35.35f;

                mousePos.y = mousePos.y < minY ? minY : mousePos.y;
                mousePos.y = mousePos.y > maxY ? maxY : mousePos.y;
                mousePos.x = mousePos.x < minX ? minX : mousePos.x;
                mousePos.x = mousePos.x > maxX ? maxX : mousePos.x;

                cub.position = Vector2.MoveTowards(cub.position, new Vector2(mousePos.x, mousePos.y),
                    speed * Time.deltaTime);
            }

        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (isConnected == false)
            {
                if (other.gameObject.CompareTag("Cube"))
                {
                    isConnected = true;
                    rb = other.gameObject.GetComponent<Rigidbody2D>();
                    fxj = gameObject.AddComponent<FixedJoint2D>();
                    fxj.autoConfigureConnectedAnchor = true;
                    fxj.connectedBody = rb;
                    fxj.autoConfigureConnectedAnchor = false;
                }
            }
        }

    }
}
