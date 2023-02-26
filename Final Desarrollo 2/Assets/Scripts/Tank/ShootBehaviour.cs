using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

namespace TankGame
{
    public class ShootBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private Rigidbody bulletPrefab;
        [SerializeField] private LayerMask layer;
        [SerializeField] private float rotationSpeed = 100f;
        [SerializeField] private AudioSource shootSfx;

        [SerializeField] private GameObject cursor;
        private bool aimed = false;
        private bool aiming = false;

        private bool canShoot = true;

        private Camera cam;

        private void Start()
        {
            cam = Camera.main;
        }
        void Update()
        {
            if (canShoot)
            {
                LaunchProjectile();
            }
        }

        void LaunchProjectile()
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            float minDistance = 3f;
            float distance = Vector3.Distance(bulletSpawnPoint.position, cursor.transform.position);

            if (Physics.Raycast(ray, out hit, 100f, layer))
            {
                cursor.SetActive(true);
                cursor.transform.position = hit.point + Vector3.up * 0.1f;
                if (distance > minDistance)
                {
                    Vector3 Vo = CalculateVelocity(hit.point, bulletSpawnPoint.transform.position, 1f);
                    Vector3 direction = cursor.transform.position - bulletSpawnPoint.transform.position;

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (!aiming)
                        {
                            StartCoroutine(AimCoroutine(Vo, direction));
                        }

                    }
                }


            }

            else
            {
                cursor.SetActive(false);
            }
        }
        Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
        {
            Vector3 distance = target - origin;
            Vector3 distanceXZ = distance;
            distanceXZ.y = 0f;

            float sY = distance.y;
            float sXZ = distance.magnitude;

            float Vxz = sXZ / time;
            float Vy = sY / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

            Vector3 result = distanceXZ.normalized;
            result *= Vxz;
            result.y = Vy;

            return result;
        }

        private void Aim(Vector3 targetRot)
        {
            Quaternion rotation = Quaternion.LookRotation(targetRot);

            aimed = false;
            if (Quaternion.Angle(rotation, transform.rotation) < 1f)
            {
                aimed = true;
            }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }

        private IEnumerator AimCoroutine(Vector3 velocity, Vector3 direction)
        {
            aiming = true;
            while (!aimed)
            {
                Aim(direction);
                yield return null;
            }
            Rigidbody obj = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            obj.velocity = velocity;
            shootSfx.Play();
            aimed = false;
            aiming = false;
            yield return null;
        }

        public void DisableCanShoot()
        {
            canShoot = false;
        }
    }
}