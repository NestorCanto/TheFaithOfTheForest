using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    //variables publicas
    public float Speed = 2f;
    public float MaxSpeed = 5f;
    public bool grounded;
    public float PoderDeSalto = 6.5f;
    public int DañoRecibido;
    public Vector3 PntoDeReaparición;
    [SerializeField]
    private int NivelaCargarSiMuere;
    
   






    //variable privadas
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer spr;
    private bool Saltar;
    private bool dobleSalto;
    private bool movimiento = true;
    private GameMaster gm;
   // private Dialogo dia;



    //El [SerializeField] vuelve una variable priva en una publica(Es una for de proteger completamnete la variable)
    [SerializeField]
    private Stats Vida;
    //objetos
    private GameObject BarraDeVida;




    //Justamente al iniciar 

    private void Awake()
    {


        Vida.inicializar();
    }


    // Use this for initialization
    void Start() {


        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

        BarraDeVida = GameObject.Find("BarraDeVida");


    }

    // Update is called once per frame
    void Update() {

       
        /// cosas del salto....
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("EnElSuelo", grounded);

        if (grounded) { dobleSalto = true; }

        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded) {
                Saltar = true;
                dobleSalto = true;
            } else if (dobleSalto) {
                Saltar = true;
                dobleSalto = false;
            }
        }


        //recupra la vida en un 100%
        if (Vida.ValorActual == 0 || Vida.ValorActual < 0)
        {
            //carga el game over
            SceneManager.LoadScene(3);
        }
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();


       
    }
    //reinicia el nivel que se seleccione
    public void CambioLevel()
    {
        SceneManager.LoadScene(NivelaCargarSiMuere);
       
    }





    void FixedUpdate() {
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.75f;
        if (grounded) { rb2d.velocity = fixedVelocity; }

        float h = Input.GetAxis("Horizontal");
        if (!movimiento) { h = 0; }

        rb2d.AddForce(Vector2.right * Speed * h);
        ////////limitación de vel///////
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -MaxSpeed, MaxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
        if (h > 0.1f) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (h < -0.1f) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (Saltar)
        {
            rb2d.AddForce(Vector2.up * PoderDeSalto, ForceMode2D.Impulse);
            Saltar = false;
        }
       
        
    }
   

    //semilas
    private void OnTriggerEnter2D(Collider2D col)
    {
        //cuenta las semillas
        if (col.CompareTag("Semilla"))
        {
            Destroy(col.gameObject);
            gm.points += 1;

        }
        if (col.CompareTag("Gota"))
        {
            if (gm.points>0) {
                Destroy(col.gameObject);
            }
            
            gm.points *=2;
        }
        //cuenta las uvas

        


        if (col.CompareTag("RecuperaHP"))
        {

            if (Vida.ValorActual == 100)
            {


            }
            if (Vida.ValorActual < Vida.MaxVal)
            {
                Destroy(col.gameObject);
                Vida.ValorActual += 7;
            }


        }
        //reaparición y punto de control
        if (col.tag == "DetectorDeCaida")
        {
            transform.position = PntoDeReaparición;

            //al detectar la caida resta 10 pts de vida(se puede cambiar luego)

            Vida.ValorActual -= 10;

        }
        if (col.tag == "PntoDeControl")
        {
            PntoDeReaparición = col.transform.position;
        }
        if (col.CompareTag("Fuego"))
        {

            rb2d.AddForce(Vector2.up * 4.5f, ForceMode2D.Impulse);
            Invoke("DañoPorFuego", 0.1f);
            Invoke("colorNormal", 0.7f);
        }


        
        


        
    }
    

    public void EnemyJump()
    {
        Saltar = true;
    }
   
   
    void colorNormal()
    {
        spr.color = Color.white;

    }
    void DañoPorFuego()
    {
        Vida.ValorActual -= 2;
        spr.color = Color.red;

    }


}
