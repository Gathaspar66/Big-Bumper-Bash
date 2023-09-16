using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICarMenu
{
    public List<int> GetCarStats();

    public void EnableCarFunctionality(CarFunction carFunction, bool enabled);
}
