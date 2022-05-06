using UnityEngine;

[ExecuteInEditMode]
public class CarTurretRotation : MonoBehaviour
{

    [SerializeField] GameObject gun;
    [SerializeField] float gunLength;
    [SerializeField] GameObject target;
    [SerializeField] bool showAimLine;
    [SerializeField] [Range(-90f, 90f)] float pitchMin;
    [SerializeField] [Range(-90f, 90f)] float pitchMax;

    bool _invalid;
    Quaternion _twist = Quaternion.Euler(0f, -90f, 0f);

    void Update()
    {
        var baseRot = transform.localRotation;
        var gunRot = gun.transform.localRotation;

        if (target is null)
        {
            _invalid = true;

        }
        else
        {
            var tdir = getTargetPivotPos() - getGunPivotPos();
            tdir = Quaternion.Inverse(getCarRotation()) * tdir;

            var pdir = new Vector3(tdir.x, 0f, tdir.z);

            var baseQuat = Quaternion.LookRotation(pdir.normalized, Vector3.up);
            baseRot = _twist * baseQuat;

            var gunQuat = Quaternion.Inverse(baseRot) * Quaternion.LookRotation(tdir.normalized, Vector3.up);
            gunRot = gunQuat;

            var pitch = 180f - mod(gunQuat.eulerAngles.x + 180f, 360f);
            _invalid = pitch < pitchMin || pitch > pitchMax;

        }

        transform.localRotation = baseRot;
        gun.transform.localRotation = gunRot;
    }

    float mod(float v, float m) => (v %= m) < 0f ? v + m : v;

    private void OnDrawGizmos()
    { // again with ()
    if(gun is null) return;
    drawBase(Color.red);
    drawGun(!_invalid? Color.yellow : Color.magenta);
 
    if(target is null) return;
    if(showAimLine) drawAimLine(Color.cyan);
}

// I've decided to name everything, for clarity
// please note that this is not optimized code, and there is a lot room for improvement
Quaternion getCarRotation() => transform.parent.rotation;
Vector3 getGunPivotPos() => gun.transform.position;
Vector3 getGunNozzlePos() => getGunPivotPos() + gun.transform.rotation * (gunLength * Vector3.up);
Vector3 getTargetPivotPos() => target.transform.position;
Vector3 getBasePivotPos() => transform.position;

void drawBase(Color color)
{
    var p1 = getBasePivotPos();
    var p2 = getGunPivotPos();
    drawLine(p1, p2, color);
}

void drawGun(Color color)
{
    var p1 = getGunPivotPos();
    var p2 = getGunNozzlePos();
    drawLine(p1, p2, color);
}

void drawAimLine(Color color)
{
    var p1 = getGunPivotPos();
    var p2 = getTargetPivotPos();
    drawLine(p1, p2, color);
}

void drawLine(Vector3 a, Vector3 b, Color color)
{
    Gizmos.color = color;
    Gizmos.DrawLine(a, b);
}
 
}