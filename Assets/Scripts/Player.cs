using UnityEngine;
using UnityEngine.Events;

namespace ColorSwitch
{
    public class Player : MonoBehaviour
    {
        public float jumpForce = 10f;

        public Rigidbody2D rigid;
        public SpriteRenderer rend;

        public Color[] colors = new Color[4];

        // ------------------------------------------------- //

        private int score;

        private Color currentColor;

        // ------------------------------------------------- //

        void Start()
        {
            RandomizeColor();
        }

        // ------------------------------------------------- //

        void Update()
        {
            if (GameManager.Instance.IsPaused)
                return;

            if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
            {
                rigid.velocity = Vector2.up * jumpForce;
            }

            // Get our pos on screen and check if we're off it or not.
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            if (screenPosition.y < 0)
                Die();
        }

        // ------------------------------------------------- //

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.name == "ColorChanger")
            {
                RandomizeColor();
                Destroy(col.gameObject);
                return;
            }

            if (col.name == "Star")
            {
                // Add score
                score++;
                UIManager.Instance.UpdateScore(score);

                // 'Collect' the star
                Destroy(col.gameObject);
                return;
            }

            SpriteRenderer spriteRend = col.GetComponent<SpriteRenderer>();
            if (spriteRend != null && spriteRend.color != rend.color)
                Die();
        }

        // ------------------------------------------------- //

        private int currentColorIndex = -1;

        void RandomizeColor()
        {
            int index = currentColorIndex;

            while (index == currentColorIndex)
                index = Random.Range(0, colors.Length);
            
            rend.color = colors[index];

            currentColorIndex = index;
        }

        // ------------------------------------------------- //

        //public void Pause(bool pause)
        //{
        //    if (pause) {
        //        rigid.isKinematic = true;
        //    }
        //    else {
        //        rigid.isKinematic = false;
        //    }
        //}

        // ------------------------------------------------- //

        private void Die()
        {
            GameManager.Instance.GameOver();

            Destroy(gameObject);
        }
    }
}