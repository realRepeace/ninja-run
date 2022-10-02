using System.Collections;

using UnityEngine;


    public class HitFlash : MonoBehaviour
    {
        [SerializeField] private Material flashMaterial;
        [SerializeField] private float duration;

        private SpriteRenderer spriteRenderer;
        private Material originalMaterial;
        private Coroutine flashRoutine;
        private SpriteRenderer[] spriteRenderers; 

        void Start()
        {
            spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer thisSpriteRenderer in spriteRenderers)
            {
                originalMaterial = thisSpriteRenderer.material;
            }
        }

        public void Flash()
        {
            if (flashRoutine != null)
            {
                StopCoroutine(flashRoutine);
            }
            flashRoutine = StartCoroutine(FlashRoutine());
        }

        private IEnumerator FlashRoutine()
        {

            foreach (SpriteRenderer thisSpriteRenderer in spriteRenderers)
            {
                thisSpriteRenderer.material = flashMaterial;
            }


            yield return new WaitForSeconds(duration);


            foreach (SpriteRenderer thisSpriteRenderer in spriteRenderers)
            {
                thisSpriteRenderer.material = originalMaterial;
            }
            flashRoutine = null;
        }
    }
