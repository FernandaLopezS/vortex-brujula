using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [Header("Movimiento")]
    private float movimientohorizontal= 0f;
    [SerializeField] private float velocidadDeMovimiento;
    [SerializeField] private float suavizadoDelMovimiento;
    private Vector3 velocidad= Vector3.zero;
    private bool mirandoDerecha =true;

    [Header("Salto")]
    [SerializeField] private float fuerzaDelSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;
    private bool salto =false;

    [Header("Dash")]
    [SerializeField] private bool DashUnlocked=true;
    private bool canDash = true;
    private bool dashActivo;
    [SerializeField] private float fuerzaDash;
    [SerializeField] private float duracionDash;
    [SerializeField] private float cooldownDash;

    [SerializeField] private TrailRenderer tr;

    private void Start(){
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update(){
        if (dashActivo)
        {
            return;
        }
        movimientohorizontal=Input.GetAxis("Horizontal")* velocidadDeMovimiento;

        if(Input.GetButtonDown("Jump")){
            salto=true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)&& canDash && DashUnlocked)
        {
            StartCoroutine(Dash());
        }
    }
    private void FixedUpdate(){
        if (dashActivo){
            return;
        }

        enSuelo=Physics2D.OverlapBox(controladorSuelo.position,dimensionesCaja,0f,queEsSuelo);
        Mover(movimientohorizontal*Time.fixedDeltaTime,salto );
        salto=false;
        
    }
    private void Mover(float mover, bool saltar){
        Vector3 velocidadObjeto = new Vector2(mover,rb2D.velocity.y);
        rb2D.velocity=Vector3.SmoothDamp(rb2D.velocity,velocidadObjeto, ref velocidad, suavizadoDelMovimiento);
        if (mover>0 && !mirandoDerecha) {
            Girar();
        }
        else if(mover<0 && mirandoDerecha)
        {
            Girar();
        }
        if(enSuelo && saltar){
            enSuelo=false;
            rb2D.AddForce(new Vector2(0f,fuerzaDelSalto));
        }
    }
    private void Girar(){
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *=-1;
        transform.localScale = escala;
    }
    private void OnDrawnGizmos(){
        Gizmos.color=Color.red;
        Gizmos.DrawWireCube(controladorSuelo.position,dimensionesCaja);
    }

    private IEnumerator Dash()
    {
        canDash=false;
        dashActivo =true;
        float originalGravity =rb2D.gravityScale;
        rb2D.gravityScale=0f;
        rb2D.velocity=new Vector2(transform.localScale.x *fuerzaDash,0f);
        tr.emitting = true;
        yield return new WaitForSeconds(duracionDash);
        tr.emitting = false;
        rb2D.gravityScale=originalGravity;
        dashActivo=false;
        yield return new WaitForSeconds(cooldownDash);
        canDash = true;

    }
}
