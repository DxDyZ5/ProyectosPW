using System;
using System.Collections.Generic;

public class AccidenteService
{
    private List<Accidente> accidentes = new List<Accidente>();

    public IReadOnlyList<Accidente> GetAccidentes()
    {
        return accidentes.AsReadOnly();
    }

    public void AgregarAccidente(Accidente accidente)
    {
        accidentes.Add(accidente);
    }
}
