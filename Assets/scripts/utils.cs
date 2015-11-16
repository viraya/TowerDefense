using UnityEngine;
using System.Collections;

public static class utils {
    /// <summary>
    /// -- correctPos --
    /// <para>Put the Vector3 given in depth for 2D.</para>
    /// </summary>
    /// <param name="i">The Vector3 to modify.</param>
    /// <returns>Vector3 with Z set to Y.</returns>
    public static Vector3 cP(Vector3 i) {
        return new Vector3(i.x, i.y, i.y);
    }
}
