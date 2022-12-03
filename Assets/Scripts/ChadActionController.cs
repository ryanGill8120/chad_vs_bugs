using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChadActionController : MonoBehaviour
{

    [SerializeField]
    private ChadStatus chadStatus;

    [SerializeField]
    private GameObject LightProjectile;
    private Animator swordAnimator;
    private Animator chadAnimator;
    public GameObject Chad;
    public GameObject Sword;

    private float nextLightTime = 0.0f;
    private float nextHeavyTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        chadAnimator = Chad.GetComponent<Animator>();
        swordAnimator = Sword.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // melee attack
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Melee Attack!");
            //swordAnimator.SetTrigger("doAttack");
            swordAnimator.Play("RIG_Sword|ANIM_Swing");
            swordAnimator.Play("RIG_Sword|ANIM_Idle");
        }

        // basic projectile
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Time.time > nextLightTime)
            {
                nextLightTime = Time.time + chadStatus.LightCooldown;
                var projectileLocation = new Vector3(
                    chadStatus.ChadModel.transform.position.x,
                    chadStatus.ChadModel.transform.position.y + 0.25f,
                    chadStatus.ChadModel.transform.position.z);
                projectileLocation = projectileLocation + chadStatus.ChadModel.transform.forward * 0.5f;
                var projectile = Instantiate(LightProjectile);
                projectile.transform.position = projectileLocation;
                projectile.transform.rotation = chadStatus.ChadModel.transform.rotation;

                Destroy(projectile, chadStatus.LightCooldown);
                Debug.Log(" *** Light Attack! *** ");
            }
            else
                Debug.Log("Light attack not ready!");
        }

        // large stun
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Time.time > nextHeavyTime)
            {
                nextHeavyTime = Time.time + chadStatus.HeavyCooldown;
                Debug.Log(" *** Heavy Attack! *** ");
            }
            else
                Debug.Log("Heavy attack not ready!");
        }
    }

    public void attackEnd()
    {
        chadAnimator.ResetTrigger("doAttack");
        chadAnimator.ResetTrigger("notAttack");
    }
}