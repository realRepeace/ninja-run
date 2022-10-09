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

        void Start() //Für jedes Kindelement wird der originale Sprite gespeichert 
        {
            spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer thisSpriteRenderer in spriteRenderers)
            {
                originalMaterial = thisSpriteRenderer.material;
            }
        }

        public void Flash() //Überprüfung ob Schadeneffekt nicht bereit gespielt wird
        {
            if (flashRoutine != null)
            {
                StopCoroutine(flashRoutine);
            }
            flashRoutine = StartCoroutine(FlashRoutine());
        }

        private IEnumerator FlashRoutine() //Schaden Effekt wird ausgeführt
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
