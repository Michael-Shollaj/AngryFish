using UnityEngine;
using System.Collections;
using Assets.Scripts;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    public GameObject boom;
    private Rigidbody2D r2d;
    public bool isFly;

    // Use this for initialization
    public void Start()
    {
        //trailrenderer is not visible until we throw the bird
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<TrailRenderer>().sortingLayerName = "Foreground";
        //no gravity at first
        GetComponent<Rigidbody2D>().isKinematic = true;
        //make the collider bigger to allow for easy touching
        GetComponent<CircleCollider2D>().radius = Constants.BirdColliderRadiusBig;
        State = BirdState.BeforeThrown;

        isFly = false;

    }



    public void Update()
    {
        if (Input.GetMouseButtonDown(0)&& State == BirdState.Thrown)
        {
            isFly = false;
            GameObject bo = Instantiate(boom, transform.position, Quaternion.identity);
            bo.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

            r2d.velocity *= 2.2f;
        }
        //if we've thrown the bird
        //and its speed is very small
        if (State == BirdState.Thrown &&
            GetComponent<Rigidbody2D>().velocity.sqrMagnitude <= Constants.MinVelocity)
        {

            //destroy the bird after 2 seconds
            StartCoroutine(DestroyAfter(2));
        }

    }

    public void OnThrow()
    {
        //play the sound
        GetComponent<AudioSource>().Play();
        //show the trail renderer
        GetComponent<TrailRenderer>().enabled = true;
        //allow for gravity forces
        GetComponent<Rigidbody2D>().isKinematic = false;
        //make the collider normal size
        GetComponent<CircleCollider2D>().radius = Constants.BirdColliderRadiusNormal;
        State = BirdState.Thrown;


    }




    IEnumerator DestroyAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
    
    public BirdState State
    {
        get;
        private set;

    }

    public void BoomerangSkill()
    {
        isFly = false;
        GameObject bo = Instantiate(boom, transform.position, Quaternion.identity);
        bo.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        r2d.velocity = new Vector2(-r2d.velocity.x * 1.5f, r2d.velocity.y * 0.5f);
    }


    public void DirectionalSpeedUpSkill()
    {
        isFly = false;
        GameObject bo = Instantiate(boom, transform.position, Quaternion.identity);
        bo.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

        r2d.velocity *= 2.2f;
    }
}
